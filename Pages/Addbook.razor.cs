using crud.mud.blazor.Models;
using crud.mud.blazor.Models.Entities;
using Microsoft.AspNetCore.Components;

namespace crud.mud.blazor.Pages
{
    public partial class Addbook
    {
        [Inject] AppDBContext appcontext {get;set;}
        [Inject] NavigationManager NavManager { get; set; }

        Books bookes = new Books();

        public async Task<bool> Insertbook(Books bookes)
        {
            await appcontext.books.AddRangeAsync(bookes);
            await appcontext.SaveChangesAsync();
            return true;
        }

        protected async void CreateBook()
        {
            await Insertbook(bookes);
            NavManager.NavigateTo("/");
        }

        protected void Cancels()
        {
            NavManager.NavigateTo("/");
        }
    }
}