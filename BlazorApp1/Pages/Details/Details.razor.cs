using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages.Details
{
    public partial class Details
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
            NavigationManager.NavigateTo("/ShowEmp");

        }
    }
}
