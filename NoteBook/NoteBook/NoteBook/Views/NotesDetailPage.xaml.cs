using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteBook.Models;


namespace NoteBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesDetailPage : ContentPage
    {        public string title { get; set; }
             public string notes { get; set; }
        public NotesDetailPage( Note note )
        {
            InitializeComponent();
            title = note.Title;
            notes = note.Notes;
            this.BindingContext = this;

            }
        public NotesDetailPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (note.Title == null)
            {
                note.Title = " ";
            }
            if(note.Notes == null)
            {
                note.Notes = " ";
            }
            
            await App.Database.SaveItemAsync(note);
            await Navigation.PopAsync();

        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteItemAsync(note);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.SaveItemAsync(note);
            await Navigation.PopAsync();
        }
    }

}
