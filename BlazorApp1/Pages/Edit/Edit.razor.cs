using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages.Edit
{
    public partial class Edit
    {
        private List<SP_selectResult>? forecasts;
        protected override async Task OnInitializedAsync()
        {
            forecasts = await Empservice.SP_selectAsync();


        }

        private void UpdateEmployeeAsync(int id)
        {
            NavigationManager.NavigateTo($"/Update/{id}");
        }

    }
    }

