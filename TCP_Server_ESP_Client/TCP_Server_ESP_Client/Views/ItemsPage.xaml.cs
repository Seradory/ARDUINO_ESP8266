using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_Server_ESP_Client.Models;
using TCP_Server_ESP_Client.ViewModels;
using TCP_Server_ESP_Client.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCP_Server_ESP_Client.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}