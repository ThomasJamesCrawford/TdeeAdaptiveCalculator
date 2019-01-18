using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;



[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TDEE
{
    public partial class App : Application
    {
        static TodoItemDatabase database;
        public static List<TodoItem> Items { get => GetItemTask.Result; }
        static Task<List<TodoItem>> GetItemTask { get; set; }

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

        public App()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDkwMjZAMzEzNjJlMzMyZTMwSjdUMXhPaGRJSlhqV1BxZ1RSb1JSbHFRYlhYNGJPRTQxR0Y2cWZwcUtLUT0=");
            InitializeComponent();

            UpdateItems();

            MainPage = new MainPageCS();

            sw.Stop();

            Console.WriteLine("LOADED IN: " + sw.ElapsedMilliseconds);
        }

        public static void UpdateItems()
        {
            GetItemTask = Task.Run(() => App.Database.GetItemsAsync());
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        

    }
}
