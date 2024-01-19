using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
namespace BlazorApp1.Pages
{
    public partial class Detailsemp
    {
        [Parameter]
        public int Id { get; set; }
        Emptbl emp=new Emptbl();
        protected override async Task OnInitializedAsync()
        {
            emp = await Empservice.GetDetailsIdAsync(Id);
        }

      
    }
}
