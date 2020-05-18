using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mics.Mobile.Services;
using Mics.Mobile.Views;
using System.Diagnostics;
using Mics.Mobile.Data;

namespace Mics.Mobile
{
    public partial class App : Application
    {
        public static string BackendUrl = "http://aymanw10";
        public static string FilePath;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CustomerDataService>();
            DependencyService.Register<CustomerViewDataService>();
            DependencyService.Register<SqliteDataService>();

            MainPage = new MainPage();
        }
        public App(string filePath)
        {
            InitializeComponent();
            Debug.WriteLine($"database located at {filePath}");

            DependencyService.Register<SalesTerritoryRepository>();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CustomerDataService>();
            DependencyService.Register<CustomerViewDataService>();
            DependencyService.Register<WebApiDataService>();
            DependencyService.Register<SqliteDataService>();
            FilePath = filePath;
            MainPage = new MainPage();
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
