
using crud.mud.blazor.Models;
using crud.mud.blazor.Models.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace crud.mud.blazor.Pages
{
    public partial class Index
    {
        
        [Inject] AppDBContext appcontext {get;set;}
        [Inject] NavigationManager NavManager { get; set; }
        [Inject] IDialogService _dialogService {get;set;}

        
        List<Books> allbooks = new();
        Books bookse = new Books();
        private string searchString ="";


        protected override async Task OnInitializedAsync()
        {
            allbooks = await appcontext.books.ToListAsync();
        }

        public async Task Indexs(string searchString)
        {
            var empquery = from x in appcontext.books select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                empquery = empquery.Where(x => x.title.Contains(searchString)
                || x.author.Contains(searchString)
                || x.count.ToString().Contains(searchString));
            }
            allbooks = await empquery.AsNoTracking().ToListAsync();
        }

        private void Addbook()
        {
            NavManager.NavigateTo($"/Addbook");
        }
         private void Gotoeditbook(int id)
        {
            NavManager.NavigateTo($"/Editbook/{id}");
        }
      
    }
}