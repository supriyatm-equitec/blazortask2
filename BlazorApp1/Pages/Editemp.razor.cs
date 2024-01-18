using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
namespace BlazorApp1.Pages
{
    public partial class Editemp
    {
        Emptbl newEmployee1 = new Emptbl();
        //show
        //private Emptbl? forecasts;

        [Parameter]
        public int id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            newEmployee1 = await Empservice.Getempid(id);
        }
     private  async Task UpdateEmp()
        {
            newEmployee1.Skills = string.Join(",", skills.Where(skill => skill.IsSelect).Select(skill => skill.Name));
           await Empservice.UpdateEmployeeAsync(newEmployee1);
       // Redirect back to the main page or wherever you want to go after editing
         NavigationManager.NavigateTo("/fetchdataemp");
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

