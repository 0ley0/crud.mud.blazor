using System.Reflection.Metadata;
using Microsoft.AspNetCore.Components;
using crud.mud.blazor.Models.Entities;
using crud.mud.blazor.Models;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace crud.mud.blazor.Pages
{
    public partial class Editbook
    {
        [Inject] AppDBContext appDBContext {get;set;}
        [Inject] IDialogService _dialogService {get;set;}
        [Inject] NavigationManager NavManager { get; set; }
        [Parameter] public int Id { get; set; }
        List<Books> allbooks = new();
        Books bookedit = new Books();

        public async Task<Books> GetBooks(int Id)
        {
            bookedit = await appDBContext.books.FirstOrDefaultAsync(c=> c.id.Equals(Id));
            return bookedit;
        }
        public async Task<bool> UpdateBook(Books bookedit)
        {
            appDBContext.books.Update(bookedit);
            await appDBContext.SaveChangesAsync();
            return true;
        }

        protected override async Task OnInitializedAsync()
        {
            bookedit = await GetBooks(Id);
        }
        private async Task DeleteAsync(int id)
        {
            bool? alterdelete = await _dialogService.ShowMessageBox(
            "Delete Confirmation",
	        "Deleting can not be undone!",
            yesText: "Delete!", cancelText: "Cancel"
            );
            if (alterdelete ?? false)
            {
                appDBContext.books.Remove(bookedit);
                await appDBContext.SaveChangesAsync();
                NavManager.NavigateTo("/");
            }
        }
        protected async void Updatebook()
        {
            bool? result = await _dialogService.ShowMessageBox(
                "Update Confirmation",
                "Update can not undone!",
                yesText: "update!",cancelText:"Cancel"
            );
            if(result ?? false)
            {
                allbooks.Remove(bookedit);
                await UpdateBook(bookedit);
                NavManager.NavigateTo("/");
                
            }
        }
        protected void Cancels()
        {
           NavManager.NavigateTo("/");
        }

    }
}