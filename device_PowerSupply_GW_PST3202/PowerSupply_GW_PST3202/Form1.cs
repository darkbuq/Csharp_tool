using FOE_YR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerSupply_GW_PST3202
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IDeviceConnector _connector = null;
        IPowerSupply IPowerSupply = null;        

        private void btn_new_PST3202_Click(object sender, EventArgs e)
        {
            _connector = new GPIB_Connector("GPIB0", "9");

            IPowerSupply = new PowerSupply_PST3202(_connector);
        }

        private void btn_device_info_Click(object sender, EventArgs e)
        {
            txt_result.Text = IPowerSupply.GetDeviceInfo();
        }

        private void btn_power_on_Click(object sender, EventArgs e)
        {
            IPowerSupply.setPowerState(true);
        }

        private void btn_power_off_Click(object sender, EventArgs e)
        {
            IPowerSupply.setPowerState(false);
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            IPowerSupply.disconnect();
        }

        private void btn_setV_Click(object sender, EventArgs e)
        {
            IPowerSupply.setVcc(1, txt_setV.Text);
        }

   
    }
}
