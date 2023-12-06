using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TCP_Server_ESP_Client;
using System;
using System.Threading;

public class TcpServer
{
    private TcpListener listener;
    private TcpClient client;
    private NetworkStream stream;
    private bool isRunning;
    private gpt_api gpt=new gpt_api();

    public string ServerIp { get; private set; }
    public int ServerPort { get; private set; }
    public string ConnectedDevice { get; private set; }

    public TcpServer(int port)
    {
        ServerIp = "192.168.196.63";
        ServerPort = port;
        listener = new TcpListener(IPAddress.Parse("192.168.196.63"), ServerPort);

    }

    private string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "Not Found";
    }

    public async Task StartServerAsync()
    {


        listener.Start();
        isRunning = true;
        if (client == null)
        {
            this.client=new TcpClient();
        }
            while (isRunning)
        {
            client = await listener.AcceptTcpClientAsync();
            ConnectedDevice = client.Client.RemoteEndPoint.ToString();
            stream = client.GetStream();
            await ReceiveDataAsync();
        }
    }

    private async Task ReceiveDataAsync()
    {
        byte[] buffer = new byte[4096];
        int bytesRead;

        while (client.Connected)
        {
            bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Array.Clear(buffer, 0, bytesRead);
            // Burada alınan veriyi işleyebilirsiniz.
           string return_data=await gpt.soru_sor_cevap_alAsync(receivedData);
           int send_count = System.Text.Encoding.UTF8.GetBytes(return_data,0,return_data.Length,buffer,0);
            int rem_bytes = send_count % 16;
            send_count=send_count+rem_bytes;
            for (int i = 0; i < send_count/16; i++) 
            {
                if (i == (send_count / 16) - 1) 
                {
                    await Task.Delay(400);
                    await stream.WriteAsync(buffer, 16 * i, 16-rem_bytes);
                }
                else 
                {
                    await Task.Delay(400);
                    await stream.WriteAsync(buffer, 16 * i, 16);
                }
                
            }
            await stream.WriteAsync(new byte[] {10,10,10}, 0, 1);
            Array.Clear(buffer, 0, bytesRead);
        }
    }

    public async Task SendDataAsync(string data)
    {
        if (client != null && stream != null)
        {
            //byte[] dataToSend = Encoding.UTF8.GetBytes(data);
           // await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
        }
    }



}
