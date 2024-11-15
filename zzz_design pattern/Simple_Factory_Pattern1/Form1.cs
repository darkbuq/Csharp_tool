using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple_Factory_Pattern1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_EEPROM_Click(object sender, EventArgs e)
        {
            Worktype wt = SimpleFactory.Creatworktype("EEPROM");
            txt_result.Text = wt.Workresult();
        }

        private void btn_FWsystem_Click(object sender, EventArgs e)
        {
            Worktype wt = SimpleFactory.Creatworktype("FWsystem");
            txt_result.Text = wt.Workresult();
        }

        private void btn_ICinitialize_Click(object sender, EventArgs e)
        {
            Worktype wt = SimpleFactory.Creatworktype("ICinitialize");
            txt_result.Text = wt.Workresult();
        }
    }

    public abstract class Worktype
    {
        public virtual string Workresult()
        {
            return "";
        }
    }

    public class EEPROM : Worktype
    {
        public override string Workresult()
        {
            return "先檢查密碼是不是不能用\r\n再確認其他屎尿";
        }
    }

    public class FWsystem : Worktype
    {
        public override string Workresult()
        {
            return "驗証的找SW\r\n正式發行找Mila";
        }
    }

    public class ICinitialize : Worktype
    {
        public override string Workresult()
        {
            return "FW工程師要提交正式文件\r\n現在已導入BOM表系統\r\n所以要找Shelly & SW";
        }
    }

    public class SimpleFactory
    {
        public static Worktype Creatworktype(string worktype)
        {
            Worktype wt = null;

            if (worktype == "EEPROM")
            {
                wt = new EEPROM();
            }
            else if (worktype == "FWsystem")
            {
                wt = new FWsystem();
            }
            else if (worktype == "ICinitialize")
            {
                wt = new ICinitialize();
            }

            return wt;
        }
    }
}
