using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace TCP_Server_ESP_Client.Views
{
    public partial class AboutPage : ContentPage
    {
        private TcpServer server;


        public AboutPage()
        {
            InitializeComponent();
             // Sunucuyu yeniden başlat
            StartServer();
        }

        private async void StartServer()
        {
            server = new TcpServer(8000);
            serverInfoLabel.Text = $"Server IP: {server.ServerIp}, Port: {server.ServerPort}";
            clientInfoLabel.Text = "Connected Device: Waiting for connection...";
            await server.StartServerAsync();

        }

        private void Update_Status(object sender, System.EventArgs e)
        {
            clientInfoLabel.Text = server.ConnectedDevice;

        }
    }
}
