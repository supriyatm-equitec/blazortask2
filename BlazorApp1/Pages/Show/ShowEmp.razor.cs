using BlazorApp1.Models;

namespace BlazorApp1.Pages.Show
{
    public partial class ShowEmp
    {
        private List<SP_selectResult>? forecasts;
        protected override async Task OnInitializedAsync()
        {
            forecasts= await Empservice.SP_selectAsync();


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
            NavigationManager.NavigateTo($"/Details/{id}");
        }
    }
}

  
