using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FOE_YR;

namespace WinForms_device_PSS_DCA10021
{
    public partial class Form1 : Form
    {
        private IDCA myDCA = null;
        private IDeviceConnector IDeviceConnector = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_new_PSS_DCA10021_Click(object sender, EventArgs e)
        {
            IDeviceConnector = new LAN_Connector(txt_ip.Text, 5001);

            myDCA = new DCA_PSS_DCA10021(IDeviceConnector);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (myDCA != null)
            {
                myDCA.disconnect();
                myDCA = null;
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            if (myDCA != null)
            {
                myDCA.disconnect();
                myDCA = null;
            }
        }

        private void btn_queryInfo_Click(object sender, EventArgs e)
        {
            txt_result.Text = myDCA.GetDeviceInfo();
        }

        private void btn_autoScale_Click(object sender, EventArgs e)
        {
            myDCA.autoScale();
        }

        private void btn_queryPower_Click(object sender, EventArgs e)
        {
            txt_result.Text = myDCA.Query_power();
        }

        private void btn_queryER_Click(object sender, EventArgs e)
        {
            txt_result.Text = myDCA.Query_ER();
        }

        private void btn_queryCrossing_Click(object sender, EventArgs e)
        {
            txt_result.Text = myDCA.Query_Cross().ToString("0.000");
        }

        private void btn_queryJitter_Click(object sender, EventArgs e)
        {
            var jitter = myDCA.Query_Jitter();

            txt_result.Text = $"PP = {(jitter.Jitter_ps_PP * 1e12).ToString("0.00")}ps\r\nRMS = {(jitter.Jitter_ps_RMS * 1e12).ToString("0.00")}ps";
        }

        private void btn_queryMargin_Click(object sender, EventArgs e)
        {
            txt_result.Text = myDCA.Query_Margin().ToString("0.000");
        }

        private void btn_saveImage_Click(object sender, EventArgs e)
        {
            myDCA.SaveImageWithPath(txt_saveImage_pathfilename.Text);
        }

        private void btn_setMask1_Click(object sender, EventArgs e)
        {
            myDCA.SetMask(txt_setMask1.Text);
        }

        private void btn_setMask2_Click(object sender, EventArgs e)
        {
            myDCA.SetMask(txt_setMask2.Text);
        }


    }
}
