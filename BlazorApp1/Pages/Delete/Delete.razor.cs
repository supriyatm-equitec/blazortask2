using BlazorApp1.Models;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages.Delete
{
    public partial class Delete
    {
        private List<SP_selectResult>? forecasts;
        protected override async Task OnInitializedAsync()
        {
            forecasts = await Empservice.SP_selectAsync();

        }
        private async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                await Empservice.DeleteEmployeeAsync(employeeId);
                await JSRuntime.InvokeVoidAsync("location.reload");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Handle or log the exception as needed
            }

        }
    }
}

