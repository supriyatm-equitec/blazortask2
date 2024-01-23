using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages.RestorePages
{
    public partial class RestorePages
    {
        [Parameter]
        public int Id { get; set; }
        Emptbl emp = new Emptbl();


        protected override async Task OnInitializedAsync()
        {
            emp = await Empservice.Getempid(Id);
        }
        private void CancelClick()
        {
            // Redirect to the ShowEmp page
            NavigationManager.NavigateTo("/Delete");

        }
        private async Task RestoreAsync(int employeeId)
        {
            try
            {
               await Empservice.RetriveAsync(employeeId);
                await JSRuntime.InvokeVoidAsync("alert", "Employee Restored successfully!");
                NavigationManager.NavigateTo("/Restore");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
        }

    }
}
