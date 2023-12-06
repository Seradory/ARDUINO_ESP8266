using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_Server_ESP_Client.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCP_Server_ESP_Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}