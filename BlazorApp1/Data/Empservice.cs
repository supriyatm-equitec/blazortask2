using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class Empservice
    {
        private readonly EmpdbContext context;

        public Empservice(EmpdbContext context)
        {
            this.context = context;
        }

        //show(here get all employee)
        public async Task<List<SP_selectResult>> SP_selectAsync()
        {
            return await context.Procedures.SP_selectAsync();
        }  
        
        public async Task<List<Emptbl>> SP_selectDeleteUserAsync()
        {
            return  context.Emptbls.Where(x => x.Isactive == true).ToList();
        }

        //restore
        public async Task RetriveAsync(int id)
        {
            try
            {
                var sToDelete = await context.Emptbls.FindAsync(id);

                if (sToDelete != null)
                {
                    await context.Procedures.RetriveAsync(sToDelete.Id);
                    sToDelete.Isactive = false;
                    context.Entry(sToDelete).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Employee with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }



        //get all data of skillstbl
        public async Task<List<sp_skillsResult>> Getskill()
        {
            //return await context.Procedures.sp_skillsAsync();

            var skillsData = await context.Procedures.sp_skillsAsync();
            return skillsData;
        }

        //details
        public async Task<Emptbl> GetDetailsIdAsync(int id)
        {

            return await context.Emptbls.FindAsync(id);
        }

        public async Task<Emptbl> Getempid(int id)
        {
            Emptbl employee = context.Emptbls.Where(x => x.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return null;
            }
            return employee;
        }
        //insert
        public async Task InsertEmployeeAsync(Emptbl employee)
        {
            try
            {


                await context.Procedures.Sp_InsertAsync(employee.Name, employee.Age, employee.Address, employee.Skills, employee.Email);
                context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }
        }

        //delete
        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                var employeeToDelete = await context.Emptbls.FindAsync(id);

                if (employeeToDelete != null)
                {
                    await context.Procedures.SP_DeleteRecordAsync(employeeToDelete.Id);

                 
                    employeeToDelete.Isactive = true; 
                    context.Entry(employeeToDelete).State = EntityState.Modified;

                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Employee with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }
        }

        //edit
        public async Task UpdateEmployeeAsync(Emptbl employee)
        {
            try
            {
                await context.Procedures.Sp_UpdateAsync(employee.Id, employee.Name, employee.Age, employee.Address, employee.Skills, employee.Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
