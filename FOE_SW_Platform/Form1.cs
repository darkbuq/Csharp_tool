using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using FOE_YR;

namespace FOE_SW_Platform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //#region -- 加密 --
            //ReleaseSigner signer = new ReleaseSigner();

            //// 產生今天的加密特徵碼
            //string signature = signer.Encrypt();

            //this.Text = $"{this.Text}  |  {signature}";

            //signer.SetupContextMenu(this);
            //#endregion
        }

        private void btn_pwd_Click(object sender, EventArgs e)
        {
            if (txt_pwd.Text == $"SW{DateTime.Now.ToString("yyyyMMdd")}")
            {
                txt_Program_type.Enabled = true;
                btn_release.Enabled = true;
            }
        }

        private void btn_SFF_Utility48_Click(object sender, EventArgs e)
        {

        }

        
    }
}
