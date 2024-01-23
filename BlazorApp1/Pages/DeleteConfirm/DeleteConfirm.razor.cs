using BlazorApp1.Models;
using BlazorApp1.Pages.RestorePages;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages.DeleteConfirm
{
    public partial class DeleteConfirm
    {
        [Parameter]
        public int Id { get; set; }
        Emptbl emp = new Emptbl();
        protected override async Task OnInitializedAsync()
        {
            emp = await Empservice.GetDetailsIdAsync(Id);
        }
        private void CancelClick()
        {
            // Redirect to the ShowEmp page
            NavigationManager.NavigateTo("/Delete");

        }

        private async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                await Empservice.DeleteEmployeeAsync(employeeId);
                await JSRuntime.InvokeVoidAsync("alert", "Employee deleted successfully!");
       

                //await JSRuntime.InvokeVoidAsync("location.reload");
                NavigationManager.NavigateTo("/Restore");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
        }

    }
}
