using System;
using TCP_Server_ESP_Client.Services;
using TCP_Server_ESP_Client.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCP_Server_ESP_Client
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
