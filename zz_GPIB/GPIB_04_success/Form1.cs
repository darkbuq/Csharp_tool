using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GPIB_04_success
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
        Ivi.Visa.Interop.FormattedIO488 ioobj = new Ivi.Visa.Interop.FormattedIO488();
        private void btn_conn_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                lbl_conn.BackColor = Color.Silver;
                this.Refresh();
                Thread.Sleep(200);

                object[] idnItems;
                string ResourceName = $"{txt_GPIB_port.Text}::{txt_GPIB_address.Text}::INSTR";
                ioobj.IO = (Ivi.Visa.Interop.IMessage)rm.Open(ResourceName, Ivi.Visa.Interop.AccessMode.NO_LOCK, 0, "");

                
                lbl_conn.BackColor = Color.Lime;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
                lbl_conn.BackColor = Color.Red;
                //throw;
            }
            
            
        }

        private void btn_check_device_Click(object sender, EventArgs e)
        {
            try
            {
                ioobj.WriteString("*IDN?", true);

                object[] idnItems = (object[])ioobj.ReadList(Ivi.Visa.Interop.IEEEASCIIType.ASCIIType_Any, ",");

                foreach (object idnItem in idnItems)
                {
                    textBox1.Text = idnItem + "\r\n";
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
                //throw;
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            ioobj.WriteString(textBox2.Text, true);

            object[] idnItems = (object[])ioobj.ReadList(Ivi.Visa.Interop.IEEEASCIIType.ASCIIType_Any, ",");

            textBox1.Text = "";
            foreach (object idnItem in idnItems)
            {
                textBox1.Text = idnItem + "\r\n";
            }
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            ioobj.WriteString(textBox2.Text, true);
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            //Ivi.Visa.Interop.ResourceManager rm2 = new Ivi.Visa.Interop.ResourceManager();
            //Ivi.Visa.Interop.VisaSession visaSession = new Ivi.Visa.Interop.V(rm2);

        }
    }
}
