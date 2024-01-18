using BlazorApp1.Models;
namespace BlazorApp1.Pages
{
    public partial class Emppage
    {
        public List<SP_selectResult> Emplist = new List<SP_selectResult>();
        public List<sp_skillsResult> Skilllist = new List<sp_skillsResult>();
        public Dictionary<int, string> SkillsDictionary = new Dictionary<int, string>();

        //show
   private List<SP_selectResult>? forecasts;
protected override async Task OnInitializedAsync()
        {
            Emplist = await Empservice.SP_selectAsync() ?? new List<SP_selectResult>();
            Skilllist = await Empservice.Getskill() ?? new List<sp_skillsResult>();
         if (Emplist == null)
            {
                // Handle the case where the list is null (e.g., show an error message)
            }
            else
            {
               foreach (var emp in Emplist)
                {
                    var EmpSkills = Skilllist
                        .Where(skill => skill.skill_id == emp.id)
                        .Select(skill => skill.name);

                    SkillsDictionary[emp.id] = string.Join(", ", EmpSkills);
                }
            }
        }
        private void NavigateToAddEmployee()
        {
         NavigationManager.NavigateTo("/EmpInsert");
        }
        private void UpdateEmployeeAsync(int id)
        {
       NavigationManager.NavigateTo($"/Editemp/{id}");
        }
   private void Displayemp(int id)
        {
       NavigationManager.NavigateTo($"/Detailsemp/{id}");
        }
    }
}
