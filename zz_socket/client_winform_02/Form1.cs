using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace client_winform_02
{
    public partial class Form1 : Form
    {
        private IDeviceConnector _client;

        public Form1()
        {
            InitializeComponent();
            cbo_endstr.SelectedIndex = 3;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                _client = new TcpDeviceConnector(txt_ip.Text, int.Parse(txt_port.Text));

                //StartReceiving();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btn_check_device_Click(object sender, EventArgs e)
        {
            txt_note.Text = "";
            txt_note.Text += _client.Query("*IDN?\r\n");
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            _client.Write($"{txt_send.Text}\r\n");
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            txt_note.Text= _client.Query($"{txt_send.Text}\r\n");
        }
    }
}
