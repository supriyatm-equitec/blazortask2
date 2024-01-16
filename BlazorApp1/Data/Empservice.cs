using BlazorApp1.Models;

namespace BlazorApp1.Data
{
    public class Empservice
    {
        private readonly EmpdbContext context;

        public Empservice(EmpdbContext context)
        {
            this.context = context;
        }

        public Task<List<SP_selectResult>> SP_selectAsync()
        {
            return context.Procedures.SP_selectAsync();
        }
    }
}
