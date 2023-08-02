using System.Reflection.Metadata;
using crud.mud.blazor.Models;
using crud.mud.blazor.Models.Entities;
using Microsoft.AspNetCore.Components;

namespace crud.mud.blazor.Pages.Pagecomponent
{
    public partial class BookDetail
    {
        [Inject] AppDBContext appcontext {get;set;}
        [Inject] NavigationManager NavManager { get; set; }
        [Parameter] public bool ShowAdd {get; set;}
        [Parameter] public List<Books> Getallbooks {get; set;}
        [Parameter] public EventCallback<bool> isshowdetelchang {get; set;}

        Books bookes = new Books();
        private List<Books> AllBooks = new();
        private bool showAdd = false;
        

        // public async Task<bool> Insertbook(Books bookes)
        // {
        //     await appcontext.books.AddRangeAsync(bookes);
        //     await appcontext.SaveChangesAsync();
        //     return true;
        // }

        public async Task<Books> Insertbook(Books bookes)
        {
            var insertbook = appcontext.Add(bookes).Entity;
            await appcontext.SaveChangesAsync();
            return(insertbook);
        }
  

         public async void CreateBook()
        {
            // NavManager.NavigateTo("/Pagecomponent/BooksDetail");
            await Insertbook(bookes);
            showAdd = true;
          
            
        }
        private Task Cancel()
        {
            ShowAdd = false;
            return isshowdetelchang.InvokeAsync(ShowAdd);
        }
       
    }
}