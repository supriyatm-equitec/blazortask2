using BlazorApp1.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp1.Pages.Add
{
    public partial class AddEmp
    {

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
            FieldIdentifier field = new FieldIdentifier(newEmployee, nameof(newEmployee.Name));
            if (newEmployee != null)
            {
                if (string.IsNullOrEmpty(newEmployee.Name))
                {
                    messageStore.Add(field, "Name cannot be blank");
                }
            }

            if(messageStore != null)
            {
                return false;

            }
            return true;

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
