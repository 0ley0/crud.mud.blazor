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
        private List<Books> Getallbooks = new();
        private Books Getallbook = new();
        private int oderid;
        private bool showAdd = false;
        private int pageno = 1;
        private int page = 0;
        private int pageSize = 10;
        private int dataCount = 1000;
        private MudTable<Books> _table;
        

        protected override async Task OnInitializedAsync()
        {
            Getallbook = new Books();
            Getallbooks.Add(Getallbook);
          await GetBooksAll(page,pageSize);
        }

        private async Task PageChangAsync(int i)
        {
            pageno = i;
            _table.NavigateTo(i-1);
            await GetBooksAll((i-1)*pageSize,pageSize);

        }

        private async Task<List<Books>> GetBooksAll(int p ,int ps)
        {
            dataCount = await appDBContext.books.Select(x => x.id).CountAsync();
            Getallbooks = await appDBContext.books.Skip(p).OrderBy(e => e.id).Take(ps).ToListAsync();
            return Getallbooks;
        }

        private void GotoBooksAdd(int Id)
        {   
            oderid = Id;
            showAdd = true;
        } 
    }

    
}