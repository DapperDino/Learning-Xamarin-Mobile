using System;
using Xamarin.Forms;
using DapperTools.Models;

namespace DapperTools
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            if (string.IsNullOrWhiteSpace(note.Title))
            {
                await DisplayAlert("Doofus Alert", "Don't forget to give this Note a Title!\n\nYou'll thank me later.", "Thanks Dapper");
            }
            else
            {
                await App.DataBase.SaveNoteAsync(note);
                await Navigation.PopAsync();
            }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.DataBase.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}