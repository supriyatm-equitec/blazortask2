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
        private void DeleteConfirm(int id)
        {
            NavigationManager.NavigateTo($"/Deletepage/{id}");
        }

     


    }
    }


