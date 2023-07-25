using crud.mud.blazor.Models;
using crud.mud.blazor.Models.Entities;
using Microsoft.AspNetCore.Components;

namespace crud.mud.blazor.Pages.Pagecomponent
{
    public partial class BookDetail
    {
        [Inject] AppDBContext appcontext {get;set;}
        [Inject] NavigationManager NavManager { get; set; }

        Books bookes = new Books();
        private List<Books> AllBooks = new();
        private bool ShowDetail = false;

        

        public async Task<bool> Insertbook(Books bookes)
        {
            await appcontext.books.AddRangeAsync(bookes);
            await appcontext.SaveChangesAsync();
            return true;
        }

         public async void CreateBook()
        {
            ShowDetail = true;
            await Insertbook(bookes);
            
        }
        protected void GotoCancel()
        {
            ShowDetail = true;
        }
    }
}