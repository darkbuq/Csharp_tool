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

        My_keysight34465a_MultiMeter_Class MyMultiMeter = new My_keysight34465a_MultiMeter_Class();
        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                MyMultiMeter.connect();
                label5.BackColor = Color.Lime;
                ((Button)sender).ForeColor = Color.Lime;
            }
            catch (Exception ex)
            {
                txt_note.Text += "\r\n"+ex.Message;
                //throw;
                label5.BackColor = Color.Red;
                ((Button)sender).ForeColor = Color.Red;
            }



            txt_note.Text += "\r\n" + MyMultiMeter.return_message;

            txt_note.SelectionStart = txt_note.Text.Length;
            txt_note.ScrollToCaret();
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            double dVol = 0;
            MyMultiMeter.readVoltage(out dVol);

            txt_note.Text += "\r\n" + dVol.ToString("0.00000");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyMultiMeter.disconnect();
        }
    }
}
