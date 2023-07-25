using crud.mud.blazor.Models;
using crud.mud.blazor.Models.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace crud.mud.blazor.Pages.Pagecomponent
{
    public partial class BooksDetail
    {

        [Inject] AppDBContext appDBContext {get; set;}
        List<Books> Getallbooks = new();
        private bool ShowAdd = false;
        private int pageno = 1;
        private int page = 0;
        private int pageSize = 10;
        private MudTable<Books> _table;

        protected override async Task OnInitializedAsync()
        {
          await GetBooksAll();
        }

        private async Task PageChangAsync(int i)
        {
            // pageno = i;
            _table.NavigateTo(i-1);

        }

        private async Task<List<Books>> GetBooksAll()
        {
            Getallbooks = await appDBContext.books.ToListAsync();
            return Getallbooks;
        }

        protected void GotoBooksAdd()
        {
            ShowAdd = true;
        } 
    }

    
}