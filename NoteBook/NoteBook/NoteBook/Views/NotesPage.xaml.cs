using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoteBook.Models;
using System.Collections;

namespace NoteBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
          

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            myNotes.ItemsSource = await App.Database.GetItemsAsync();
        }
          async void OnAddClicked(object sender, EventArgs e)
         {
           
            await Navigation.PushAsync(new NotesDetailPage
            {

                BindingContext = new Note()

            });
        }

        async void DeleteAll(object sender,EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteItemsAsync();
           

        }

        private async void myNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var note = e.CurrentSelection[0] as Note;

            if (note != null)
            {


                await Navigation.PushAsync(new NotesDetailPage
                {
                    BindingContext = note
                });

            }


        }

        private async void searchBar_BindingContextChanged(object sender, TextChangedEventArgs e)
        {
            myNotes.ItemsSource = await App.Database.SearchItemAsync(e.NewTextValue);


        }
    }




    }
    
