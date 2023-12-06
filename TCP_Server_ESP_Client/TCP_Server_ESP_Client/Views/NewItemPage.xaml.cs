using System;
using System.Collections.Generic;
using System.ComponentModel;
using TCP_Server_ESP_Client.Models;
using TCP_Server_ESP_Client.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCP_Server_ESP_Client.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}