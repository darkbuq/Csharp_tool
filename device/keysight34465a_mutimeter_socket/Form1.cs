using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace keysight34465a_mutimeter_socket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        My_keysight34465a_MutiMeter_Class MyMutiMeter = new My_keysight34465a_MutiMeter_Class();
        private void btn_start_Click(object sender, EventArgs e)
        {
            //MyMutiMeter.connect();

            if (MyMutiMeter.connect())
            {
                label5.BackColor = Color.Lime;
            }
            else
            {
                label5.BackColor = Color.Red;
            }

            txt_note.Text += MyMutiMeter.return_message;
            
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            double dVol = 0;
            MyMutiMeter.readVoltage(out dVol);

            txt_note.Text += "\r\n" + dVol.ToString("0.00000");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyMutiMeter.disconnect();
        }
    }
}
