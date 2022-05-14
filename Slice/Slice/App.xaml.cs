using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Slice.Pages;
using Slice.DataBase;
using System.IO;

namespace Slice
{
    public partial class App : Application
    {
        public static DataAccess db;
        public const string DATABASE_NAME = "Slice.db";

        public static DataAccess Db
        {
            get
            {
                if (db == null)
                {
                    db = new DataAccess(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
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
