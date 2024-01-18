using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class EmpInsert
    {

       private  Emptbl newEmployee = new Emptbl();

     private async Task AddEmp()
        {
            if (newEmployee != null)
            {
                newEmployee.Skills = string.Join(",", skills.Where(skill => skill.IsSelect).Select(skill => skill.Name));

                await Empservice.InsertEmployeeAsync(newEmployee);
                NavigationManager.NavigateTo("/fetchdataemp");
            }
        }
        public class Skill
        {
            public string? Name { get; set; }
            public bool IsSelect { get; set; }
        }

       

        private List<Skill> skills = new List<Skill>
    {
        new Skill { Name = "Java", IsSelect = false },
        new Skill { Name = "Python", IsSelect = false },
        new Skill { Name = "C#", IsSelect = false },
        new Skill { Name = "HTML", IsSelect = false },
        new Skill { Name = "CSS", IsSelect = false }
    };


    }
}
