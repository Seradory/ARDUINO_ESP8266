using System.ComponentModel;
using TCP_Server_ESP_Client.ViewModels;
using Xamarin.Forms;

namespace TCP_Server_ESP_Client.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}