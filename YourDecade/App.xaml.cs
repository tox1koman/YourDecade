using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace YourDecade
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Goals.db";
        public static GoalRepos database;
        public static GoalRepos Database
        {
            get
            {
                if (database == null)
                {
                    database = new GoalRepos(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new FirstStartPage();
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
