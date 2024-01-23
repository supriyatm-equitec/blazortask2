using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages.Restore
{

  
    public partial class Restore
    {
        [Parameter]
        public int Id { get; set; }
        Emptbl emp = new Emptbl();
        private List<Emptbl>? forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Empservice.SP_selectDeleteUserAsync();
        }
        private async void RestoreConfirm(int id)
        {
            NavigationManager.NavigateTo($"/Restorepage/{id}");
        }
    }
}
