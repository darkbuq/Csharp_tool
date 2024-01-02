using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Socket_server_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_server_start_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 12345;

            // 建立伺服器
            TcpListener server = new TcpListener(ipAddress, port);
            server.Start();

            while (true)
            {
                // 接受一個新的客戶端連線
                TcpClient client = server.AcceptTcpClient();
                //Console.WriteLine($"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
                txt_server_note.Text = $"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}";

                // 開啟一個執行緒處理該客戶端的通訊
                Thread clientThread = new Thread(HandleClientComm);
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object clientObj)
        {
            TcpClient tcpClient = (TcpClient)clientObj;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                    break;

                string receivedMessage = Encoding.ASCII.GetString(message, 0, bytesRead);
                //Console.WriteLine($"Received: {receivedMessage}");
                string gg = $"Received: {receivedMessage}";
                this.Invoke(new Action<TextBox,string>((TextBox,strr) => TextBox.Text = strr), txt_server_note,gg);

                // 在這裡處理收到的訊息

                byte[] reply = Encoding.ASCII.GetBytes("Server received your message");
                clientStream.Write(reply, 0, reply.Length);
                clientStream.Flush();
            }

            tcpClient.Close();
        }
    }
}
