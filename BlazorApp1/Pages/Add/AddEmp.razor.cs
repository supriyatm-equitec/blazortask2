


using BlazorApp1.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.RegularExpressions;

namespace BlazorApp1.Pages.Add
{
    public partial class AddEmp
    {


        //private Emptbl newEmployee1 = new Emptbl { Age = null }; 


        private Emptbl newEmployee = new Emptbl();
        EditContext? editContext;
        ValidationMessageStore messageStore;
        protected override void OnInitialized()
        {
            editContext = new(newEmployee);
            StateHasChanged();



        }
        private async Task AddEmps()
        {
            editContext = new(newEmployee);
            messageStore?.Clear();
            messageStore = new(editContext);
            if (await ValidateModel())
            {
                if (!editContext.GetValidationMessages().Any())
                {
                    if (newEmployee != null)
                    {
                        newEmployee.Skills = string.Join(",", skills.Where(skill => skill.IsSelect).Select(skill => skill.Name));

                        await Empservice.InsertEmployeeAsync(newEmployee);
                        NavigationManager.NavigateTo("/ShowEmp");
                    }
                }
                else
                {
                    FieldIdentifier field = new FieldIdentifier(newEmployee, nameof(newEmployee.Name));
                    messageStore.Add(field, "Invalid");
                    editContext.NotifyValidationStateChanged();
                }
            }
        }

        private async Task<bool> ValidateModel()
        {
            FieldIdentifier nameField = new FieldIdentifier(newEmployee, nameof(newEmployee.Name));
            FieldIdentifier ageField = new FieldIdentifier(newEmployee, nameof(newEmployee.Age));
            FieldIdentifier addressField = new FieldIdentifier(newEmployee, nameof(newEmployee.Address));
            FieldIdentifier emailField = new FieldIdentifier(newEmployee, nameof(newEmployee.Email));
            FieldIdentifier skillsField = new FieldIdentifier(newEmployee, nameof(newEmployee.Skills));

            if (newEmployee != null)
            {
                if (string.IsNullOrEmpty(newEmployee.Name))
                {
                    messageStore.Add(nameField, "Name cannot be blank");
                }

                if (newEmployee.Age <= 0)
                {
                    messageStore.Add(ageField, "Age must be greater than 0");
                }

                if (string.IsNullOrEmpty(newEmployee.Address))
                {
                    messageStore.Add(addressField, "Address cannot be blank");
                }

                if (string.IsNullOrEmpty(newEmployee.Email))
                {
                    messageStore.Add(emailField, "Email cannot be blank");
                }
                else if (!IsValidEmail(newEmployee.Email))
                {
                    messageStore.Add(emailField, "Invalid email format");
                }

                if (skills.All(skill => !skill.IsSelect))
                {
                    messageStore.Add(skillsField, "At least one skill must be selected");
                }
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {

            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
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
