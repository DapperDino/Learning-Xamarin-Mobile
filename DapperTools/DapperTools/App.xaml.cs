using DapperTools.Data;
using System;
using System.IO;
using Xamarin.Forms;

namespace DapperTools
{
    public partial class App : Application
    {
        private static NoteDatabase database;

        public static NoteDatabase DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new NotesPage());
        }
    }
}
