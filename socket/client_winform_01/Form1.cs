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
        


        public Form1()
        {
            InitializeComponent();
            cbo_endstr.SelectedIndex = 1;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(txt_ip.Text, int.Parse(txt_port.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


            StartReceiving();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving message: {ex.Message}");
            }
        }

        #endregion

        

        private void btn_send_Click(object sender, EventArgs e)
        {
            string message;
            if (cbo_endstr.Text=="\\r")
            {
                message = txt_send.Text + "\r";
            }
            else if (cbo_endstr.Text == "\\n")
            {
                message = txt_send.Text + "\n";
            }
            else if (cbo_endstr.Text == "\\r\\n")
            {
                message = txt_send.Text + "\r\n";
            }
            else
            {
                message = txt_send.Text;
            }

            if (client == null || !client.Connected)
            {
                MessageBox.Show("Not connected to the server.");
                return;
            }

            NetworkStream clientStream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientStream.Write(data, 0, data.Length);
            clientStream.Flush();
        }

        private void cbo_select_SCPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_select_SCPI.Text=="訪問")
            {
                txt_send.Text = "*IDN?";
            }
            else if (cbo_select_SCPI.Text == "讀電壓")
            {
                txt_send.Text = "READ?";
            }
            else
            {
                MessageBox.Show("error SCPI");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 關閉客戶端
            client?.Close();
        }
    }
}
