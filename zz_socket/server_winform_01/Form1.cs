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

namespace server_winform_01
{
    public partial class Form1 : Form
    {
        private TcpListener server;

        public Form1()
        {
            InitializeComponent();
        }

        TcpClient client;
        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                server = new TcpListener(IPAddress.Parse(txt_ip.Text), int.Parse(txt_port.Text));
                server.Start();

                txt_note.Text = $"waiting for client to connect..";

                // 得到客戶端連線
                client = server.AcceptTcpClient();
                txt_note.Text = "";

                // 開啟新執行緒處理receive
                Thread client_receive = new Thread(receive);
                client_receive.Start(client);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void receive(object clientObj)
        {
            TcpClient tcpClient = (TcpClient)clientObj;
            NetworkStream clientStream = tcpClient.GetStream();

            // 在這裡實現與客戶端通訊的邏輯
            byte[] message = new byte[4096];
            int bytesRead;

            while (true)//一直跑  
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                    // NetworkStream.Read 方法是一個阻塞的方法，
                    // 它會一直等待，直到有資料可供讀取，
                    // 或者發生了例外情況（例如，連線關閉、超時等）。
                    // 這就是為什麼在這個 while 迴圈中，
                    // 當沒有資料可供讀取時，它會一直等待。
                }
                catch
                {
                    Action<TextBox, string> reflashUI3 = (TextBox, strr) => TextBox.Text += strr + "\r\n";
                    this.Invoke(reflashUI3, txt_note, $"try_catch...catch something...");
                    break;
                }

                //如果使用阻塞方法 那下面這個if基本上用不到
                if (bytesRead == 0)//等於0  就是沒收到東西  就跳過下面程式碼
                {
                    Action<TextBox, string> reflashUI2 = (TextBox, strr) => TextBox.Text += strr + "\r\n";
                    this.Invoke(reflashUI2, txt_note, $"Received 0 bytes. Breaking the loop.");
                    break;
                }
                    

                string receivedMessage = Encoding.ASCII.GetString(message, 0, bytesRead);
                //Console.WriteLine($"Received: {receivedMessage}");
                Action<TextBox, string> reflashUI = (TextBox, strr) => TextBox.Text += strr + "\r\n";
                this.Invoke(reflashUI, txt_note, $"{receivedMessage}");
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 關閉伺服器
            server?.Stop();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string message = txt_send.Text;

            try
            {
                NetworkStream clientStream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(message);
                clientStream.Write(data, 0, data.Length);
                clientStream.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message to client: {ex.Message}");
            }
        }

    }
}
