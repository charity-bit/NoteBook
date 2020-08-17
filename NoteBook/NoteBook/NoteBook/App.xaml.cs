using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteBook.Data;
using NoteBook.Views;


namespace NoteBook
{
    public partial class App : Application
    {
        static NoteItemDatabase database;
        public App()
        {
            InitializeComponent();
            ///Device.SetFlags(new string[] { "AppTheme_Experimental" });
            MainPage = new NavigationPage(new NotesPage());
        }


        public static NoteItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
