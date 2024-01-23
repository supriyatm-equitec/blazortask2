using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.RegularExpressions;

namespace BlazorApp1.Pages.Update
{
    public partial class Update
    {
        Emptbl newEmployee1 = new Emptbl();
        EditContext? editContext;
        ValidationMessageStore messageStore;

        [Parameter]
        public int id { get; set; }

   





    protected override async Task OnInitializedAsync()
        {
            editContext = new(newEmployee1);
            StateHasChanged();
            newEmployee1 = await Empservice.Getempid(id);



            // Set the initial state of checkboxes based on existing skills
            foreach (var skill in skills)
            {
                skill.IsSelect = newEmployee1.Skills?.Split(',').Contains(skill.Name) ?? false;
            }
        }


        private void ToggleSkill(Skill skill)
        {
            skill.IsSelect = skill.IsSelect;
        }
        private async Task UpdateEmp()
        {
            if (await ValidateModel())
            {
                if (!editContext.GetValidationMessages().Any())
                {
                    if (newEmployee1 != null)
                    {
                        newEmployee1.Skills = string.Join(",", skills.Where(skill => skill.IsSelect).Select(skill => skill.Name));
                        await Empservice.UpdateEmployeeAsync(newEmployee1);
                        // Redirect back to the main page or wherever you want to go after editing
                        NavigationManager.NavigateTo("/Update");
                    }
                    else
                    {
                        FieldIdentifier field = new FieldIdentifier(newEmployee1, nameof(newEmployee1.Name));
                        messageStore.Add(field, "Invalid");
                        editContext.NotifyValidationStateChanged();
                    }
                }
            }
        }



        private async Task<bool> ValidateModel()
        {
            FieldIdentifier nameField = new FieldIdentifier(newEmployee1, nameof(newEmployee1.Name));
            FieldIdentifier ageField = new FieldIdentifier(newEmployee1, nameof(newEmployee1.Age));
            FieldIdentifier addressField = new FieldIdentifier(newEmployee1, nameof(newEmployee1.Address));
            FieldIdentifier emailField = new FieldIdentifier(newEmployee1, nameof(newEmployee1.Email));
            FieldIdentifier skillsField = new FieldIdentifier(newEmployee1, nameof(newEmployee1.Skills));

            if (newEmployee1 != null)
            {
                if (string.IsNullOrEmpty(newEmployee1.Name))
                {
                    messageStore.Add(nameField, "Name cannot be blank");
                }

                if (newEmployee1.Age <= 0)
                {
                    messageStore.Add(ageField, "Age must be greater than 0");
                }

                if (string.IsNullOrEmpty(newEmployee1.Address))
                {
                    messageStore.Add(addressField, "Address cannot be blank");
                }

                if (string.IsNullOrEmpty(newEmployee1.Email))
                {
                    messageStore.Add(emailField, "Email cannot be blank");
                }
                else if (!IsValidEmail(newEmployee1.Email))
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

