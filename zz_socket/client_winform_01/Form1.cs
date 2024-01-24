using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace client_winform_01
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        //string result_str = "";

        private string terminator(string message)
        {
            //string message = "*IDN?";
            if (cbo_endstr.Text == "\\r")
            {
                message += "\r";
            }
            else if (cbo_endstr.Text == "\\n")
            {
                message += "\n";
            }
            else if (cbo_endstr.Text == "\\r\\n")
            {
                message += "\r\n";
            }
            else
            {
                //message = txt_send.Text;
            }

            return message;
        }

        public Form1()
        {
            InitializeComponent();
            cbo_endstr.SelectedIndex = 3;
        }

        //string gg = "";
        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(txt_ip.Text, int.Parse(txt_port.Text));

                StartReceiving();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        #region -- receive --

        private Thread receiveThread;//接收需要多執行緒  傳送不用 送了就送了
        private void StartReceiving()
        {
            receiveThread = new Thread(ReceiveMessages);
            receiveThread.Start();
        }


        private void ReceiveMessages()
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("not connect..");
                    return;
                }


                NetworkStream clientStream = client.GetStream();
                byte[] message = new byte[4096];
                int bytesRead;
                while (true)
                {
                    bytesRead = 0;

                    bytesRead = clientStream.Read(message, 0, 4096);
                    // NetworkStream.Read 方法是一個阻塞的方法，
                    // 它會一直等待，直到有資料可供讀取，
                    // 或者發生了例外情況（例如，連線關閉、超時等）。
                    // 這就是為什麼在這個 while 迴圈中，
                    // 當沒有資料可供讀取時，它會一直等待。

                    if (bytesRead == 0)
                        break;

                    string receivedMessage = Encoding.ASCII.GetString(message, 0, bytesRead);

                    // 顯示收到的訊息在 UI 上
                    //Action<TextBox, string> reflashUI = (TextBox, strr) =>
                    //{
                    //    TextBox.Text += strr + "\r\n";

                    //    TextBox.SelectionStart = TextBox.Text.Length;
                    //    TextBox.ScrollToCaret();
                    //};
                    //this.Invoke(reflashUI, txt_note, receivedMessage);


                    // 顯示收到的訊息在 UI 上   目前看到最噁的寫法
                    this.Invoke(new Action<TextBox, string>((TextBox, strr) =>
                    {
                        TextBox.Text += strr + "\r\n";

                        TextBox.SelectionStart = TextBox.Text.Length;
                        TextBox.ScrollToCaret();
                    }), txt_note, receivedMessage);


                    //我用了一個 公開變數  放回傳   設一個timer去抓
                    //gg = receivedMessage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving message: {ex.Message}");
            }
        }

        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 關閉客戶端
            client?.Close();
        }

        private void btn_check_device_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Not connected to the server.");
                return;
            }

            string message = "*IDN?";
            message = terminator(message);

            NetworkStream clientStream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientStream.Write(data, 0, data.Length);
            clientStream.Flush();
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Not connected to the server.");
                return;
            }

            string message = txt_send.Text;
            message = terminator(message);

            NetworkStream clientStream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientStream.Write(data, 0, data.Length);
            clientStream.Flush();

            //txt_note.Text = result_str;
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Not connected to the server.");
                return;
            }

            string message = txt_send.Text;
            message = terminator(message);

            NetworkStream clientStream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientStream.Write(data, 0, data.Length);
            clientStream.Flush();
        }
    }
}
