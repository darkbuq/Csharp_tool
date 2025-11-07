using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using FOE_YR;

namespace CMIS_forPRBSmode_readBER
{
    public partial class Form1 : Form
    {
        UI_dgv UI_dgv = new UI_dgv();
        I2C_USB_ISS I2C = null;
        Script_Interpreter script_obj = null;
        C_CMIS C_CMIS = new C_CMIS();

        private System.Windows.Forms.Timer timer_1 = new System.Windows.Forms.Timer(); // ← 宣告成欄位


        private void Initialize_dgv_Host(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;

            string[] colname = "page,Wcode,btn,Description".Split(',');
            string[] coltxt = "page,Wcode,btn,Description".Split(',');
            string[] coltype = "txt,txt,btn,txt".Split(',');
            int[] colW = { 50, 200, 50, 200};

            UI_dgv.Add_dgv_col(dgv, colname, coltxt, coltype, colW);

            dgv.Rows.Add("0x13","ssA090FF", null, "Host PRBS Generator");
            dgv.Rows.Add("0x13", "ssA0A0FF", null, "Host PRBS checker");
            dgv.Rows.Add("0x13", "ttA0B11010", null, "open refresh");
            dgv.Rows.Add("0x13", "ttA0B10E08", null, "set refresh");
            dgv.Rows.Add("0x14", "ssA08001", null, "display result");
        }

        private void Initialize_dgv_Media(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;

            string[] colname = "page,Wcode,btn,Description".Split(',');
            string[] coltxt = "page,Wcode,btn,Description".Split(',');
            string[] coltype = "txt,txt,btn,txt".Split(',');
            int[] colW = { 50, 200, 50, 200 };

            UI_dgv.Add_dgv_col(dgv, colname, coltxt, coltype, colW);

            dgv.Rows.Add("0x13", "ssA098FF", null, "Media PRBS Generator");
            dgv.Rows.Add("0x13", "ssA0A8FF", null, "Media PRBS checker");
            dgv.Rows.Add("0x13", "ttA0B11010", null, "open refresh");
            dgv.Rows.Add("0x13", "ttA0B10E08", null, "set refresh");
            dgv.Rows.Add("0x14", "ssA08001", null, "display result");
        }

        private void Initialize_dgv_BER_result(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;

            string[] colname = "ch,L_add,LSB_v,M_add,MSB_v,left_zero_padding,BER".Split(',');
            string[] coltxt = "ch,L_add,LSB_v,M_add,MSB_v,left_zero_padding,BER".Split(',');
            string[] coltype = "txt,txt,txt,txt,txt,txt,txt".Split(',');
            int[] colW = { 40, 55, 55, 55, 55, 140, 100 };

            UI_dgv.Add_dgv_col(dgv, colname, coltxt, coltype, colW);

            for (int i = 0; i < 8; i++)
            {
                dgv.Rows.Add($"ch{i+1}");
            }
        }        

        private void Initialize_dgv_DDMI_result(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;

            string[] colname = "Item,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch7".Split(',');
            string[] coltxt = "Item,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch7".Split(',');
            string[] coltype = "txt,txt,txt,txt,txt,txt,txt,txt,txt".Split(',');
            int[] colW = { 63, 63, 63, 63, 63, 63, 63, 63, 63 };
            UI_dgv.Add_dgv_col(dgv, colname, coltxt, coltype, colW);

            dgv.Rows.Add($"T");
            dgv.Rows.Add($"Vcc");
            dgv.Rows.Add($"Bias");
            dgv.Rows.Add($"TxP_dBm");
            dgv.Rows.Add($"RxP_dBm");

        }

        private void Initialize_dgv_DDMI2_result(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;

            string[] colname = "Item,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch7".Split(',');
            string[] coltxt = "Item,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch7".Split(',');
            string[] coltype = "txt,txt,txt,txt,txt,txt,txt,txt,txt".Split(',');
            int[] colW = { 90, 100, 100, 100, 100, 100, 100, 100, 100 };
            UI_dgv.Add_dgv_col(dgv, colname, coltxt, coltype, colW);

            dgv.Rows.Add($"T");
            dgv.Rows.Add($"Vcc");
            dgv.Rows.Add($"Bias");
            dgv.Rows.Add($"TxP_dBm");
            dgv.Rows.Add($"RxP_dBm");
            dgv.Rows.Add($"BER");
        }

        public Form1()
        {
            InitializeComponent();

            UI_dgv.Dgv_EEPROM_initialize(dgv_EEPROM, "", 0, 16);

            Initialize_dgv_Host(dgv_Host);
            Initialize_dgv_Media(dgv_Media);
            Initialize_dgv_BER_result(dgv_BER_result);

            Initialize_dgv_DDMI_result(dgv_DDMI);
            Initialize_dgv_DDMI2_result(dgv_DDMI2);
            


            timer_1.Tick += Timer_Tick;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            I2C.Disconnect();
            I2C = null;
        }

        private void btn_new_SerialPort_Click(object sender, EventArgs e)
        {
            I2C = new I2C_USB_ISS(txt_port.Text, int.Parse(txt_baudRate.Text));

            script_obj = new Script_Interpreter(I2C);
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            if (I2C == null)
            {
                MessageBox.Show("need create I2C物件");
                return;
            }

            //txt_value.Text = string.Join(" ",I2C.Read(Convert.ToInt16(txt_address.Text,16), 1).Select(v => v.ToString("X2")));

            txt_value.Text = script_obj.RunScript($"ggA0{txt_address.Text}01");
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            if (I2C == null)
            {
                MessageBox.Show("need create I2C物件");
                return;
            }

            script_obj.RunScript($"ssA0{txt_address.Text}{txt_value.Text}");
        }

        private void btn_read_256byte_Click(object sender, EventArgs e)
        {
            UI_dgv.Reset_dgvValue(dgv_EEPROM);
            dgv_EEPROM.Refresh();
            Thread.Sleep(500);

            
            if (I2C == null)
            {
                MessageBox.Show("need create I2C物件");
                return;
            }


            byte[] read_result = I2C.Read(0x00, 256);


            UI_dgv.Set_EEPROM_Value_to_Dgv(dgv_EEPROM, read_result, 0);
        }

        private void btn_script_set_Click(object sender, EventArgs e)
        {
            txt_result.Text = script_obj.RunScript(txt_script.Text);
        }

        private void dgv_Host_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 將 sender 轉換回 DataGridView 類型
            DataGridView dgv = sender as DataGridView;

            if (!(e.ColumnIndex == dgv.Columns["btn"].Index & e.RowIndex != -1))//反相邏輯  不做事
            {
                return;
            }
            //以上 反相邏輯  不做事


            #region -- 換頁及確認 --

            string page = dgv.Rows[e.RowIndex].Cells["page"].Value.ToString().Replace("0x", "");

            try
            {
                ChangePage("00", page, script_obj);
            }
            catch (Exception)
            {
                throw;
            }

            #endregion


            #region -- 實際動作 --

            string Wcode = dgv.Rows[e.RowIndex].Cells["Wcode"].Value.ToString().Trim();
            script_obj.RunScript(Wcode);

            #endregion
        }

        private void dgv_Media_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 將 sender 轉換回 DataGridView 類型
            DataGridView dgv = sender as DataGridView;

            if (!(e.ColumnIndex == dgv.Columns["btn"].Index & e.RowIndex != -1))//反相邏輯  不做事
            {
                return;
            }
            //以上 反相邏輯  不做事


            #region -- 換頁及確認 --

            string page = dgv.Rows[e.RowIndex].Cells["page"].Value.ToString().Replace("0x", "");

            try
            {
                ChangePage("00", page, script_obj);
            }
            catch (Exception)
            {
                throw;
            }

            #endregion


            #region -- 實際動作 --

            string Wcode = dgv.Rows[e.RowIndex].Cells["Wcode"].Value.ToString().Trim();
            script_obj.RunScript(Wcode);

            #endregion
        }

        void ChangePage(string bank, string page, Script_Interpreter script)
        {
            script.RunScript($"ssA07E{bank}{page}");
            Thread.Sleep(200);

            var temp = script.RunScript("ggA07E02").Split(' ');

            if (temp[0] != bank)
            {
                throw new Exception($"bank 錯誤");
            }

            if (temp[1] != page)
            {
                throw new Exception($"page 錯誤");
            }
        }

        private void cbo_Host_Media_SelectedIndexChanged(object sender, EventArgs e)
        {
            //同步兩頁控件
            cbo_Host_Media_2.SelectedIndex = cbo_Host_Media.SelectedIndex;



            if (cbo_Host_Media.Text == "Host")
            {
                for (int i = 0; i < dgv_BER_result.RowCount; i++)
                {
                    dgv_BER_result.Rows[i].Cells["L_add"].Value = $"C{(i * 2).ToString("X1")}";
                    dgv_BER_result.Rows[i].Cells["M_add"].Value = $"C{(i * 2 + 1).ToString("X1")}";
                }
            }
            else if (cbo_Host_Media.Text == "Media")
            {
                for (int i = 0; i < dgv_BER_result.RowCount; i++)
                {
                    dgv_BER_result.Rows[i].Cells["L_add"].Value = $"D{(i * 2).ToString("X1")}";
                    dgv_BER_result.Rows[i].Cells["M_add"].Value = $"D{(i * 2 + 1).ToString("X1")}";
                }
            }
            else
            {
                throw new Exception("cbo_Host_Media 下拉選單錯誤");
            }

            for (int i = 0; i < dgv_BER_result.RowCount; i++)
            {
                dgv_BER_result.Rows[i].Cells["LSB_v"].Value = string.Empty;
                dgv_BER_result.Rows[i].Cells["MSB_v"].Value = string.Empty;

                dgv_BER_result.Rows[i].Cells["left_zero_padding"].Value = string.Empty;
                dgv_BER_result.Rows[i].Cells["BER"].Value = string.Empty;
            }
        }

        private void btn_read_once_Click(object sender, EventArgs e)
        {
            if (cbo_Host_Media.SelectedIndex == -1)
            {
                MessageBox.Show("cbo_Host_Media 下拉選單要選");
                return;
            }


            #region -- 換頁 --
            try
            {
                ChangePage("00", "14", script_obj); //依文件 是在page = 14h 讀值
            }
            catch (Exception)
            {
                throw;
            }
            #endregion


            #region -- 做事 --
            byte[] P_14h = script_obj.Readpage_128byte("80");

            for (int i = 0; i < dgv_BER_result.RowCount; i++)
            {
                var address_temp1 = Convert.ToByte(dgv_BER_result.Rows[i].Cells["L_add"].Value.ToString(), 16);
                byte LSB = P_14h[address_temp1 - 128];
                dgv_BER_result.Rows[i].Cells["LSB_v"].Value = LSB.ToString("X2");

                var address_temp2 = Convert.ToByte(dgv_BER_result.Rows[i].Cells["M_add"].Value.ToString(), 16);
                byte MSB = P_14h[address_temp2 - 128];
                dgv_BER_result.Rows[i].Cells["MSB_v"].Value = MSB.ToString("X2");


                //var s =(byte)(Convert.ToByte("72", 16) >> 3); //看起來 係數項只需要右移三位  通常位運算底層會自動升型 所以要強制再轉回來
                byte s = (byte)(LSB >> 3);
                dgv_BER_result.Rows[i].Cells["left_zero_padding"].Value = $"{Convert.ToString(s, 2)} ";

                byte high = (byte)((byte)(LSB << 5) >> 5);
                byte low = MSB;
                ushort m = (ushort)((high << 8) | low);
                dgv_BER_result.Rows[i].Cells["left_zero_padding"].Value += $"{Convert.ToString(m, 2)}";


                dgv_BER_result.Rows[i].Cells["BER"].Value = (m*Math.Pow(10,s-24)).ToString("E3");
            } 
            #endregion
        }

        private void btn_I2C_cmd_Click(object sender, EventArgs e)
        {
            var result = I2C.Query(txt_cmd.Text);
            txt_result.Text = string.Join(" ", result.Select(v => v.ToString("X2")));
        }

        private void btn_RealTime_ON_Click(object sender, EventArgs e)
        {
            if (cbo_Host_Media.SelectedIndex == -1)
            {
                MessageBox.Show("cbo_Host_Media 下拉選單要選");
                return;
            }

            //關閉部分按鍵
            btn_I2C_cmd.Enabled = false;

            btn_read_256byte.Enabled = false;
            btn_script_set.Enabled = false;

            cbo_Host_Media.Enabled = false;
            btn_read_once.Enabled = false;

            btn_RealTime_ON.Enabled = false;



            timer_1.Interval = 2 * 1000; // 每 ? 秒觸發一次

            timer_1.Start(); // 開始
        }

        private void btn_RealTime_OFF_Click(object sender, EventArgs e)
        {
            timer_1.Stop(); // 停止


            //解凍部分按鍵
            btn_I2C_cmd.Enabled = true;

            btn_read_256byte.Enabled = true;
            btn_script_set.Enabled = true;

            cbo_Host_Media.Enabled = true;
            btn_read_once.Enabled = true;

            btn_RealTime_ON.Enabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 這裡放你的即時讀取或顯示邏輯


            if (cbo_Host_Media.SelectedIndex == -1)
            {
                MessageBox.Show("cbo_Host_Media 下拉選單要選");
                timer_1.Stop(); // 停止
            }


            #region -- 換頁 --
            try
            {
                ChangePage("00", "14", script_obj); //依文件 是在page = 14h 讀值
            }
            catch (Exception)
            {
                throw;
            }
            #endregion


            #region -- dgv BER --
            byte[] P_14h = script_obj.Readpage_128byte("80");

            for (int i = 0; i < dgv_BER_result.RowCount; i++)
            {
                var address_temp1 = Convert.ToByte(dgv_BER_result.Rows[i].Cells["L_add"].Value.ToString(), 16);
                byte LSB = P_14h[address_temp1 - 128];
                dgv_BER_result.Rows[i].Cells["LSB_v"].Value = LSB.ToString("X2");

                var address_temp2 = Convert.ToByte(dgv_BER_result.Rows[i].Cells["M_add"].Value.ToString(), 16);
                byte MSB = P_14h[address_temp2 - 128];
                dgv_BER_result.Rows[i].Cells["MSB_v"].Value = MSB.ToString("X2");


                //var s =(byte)(Convert.ToByte("72", 16) >> 3); //看起來 係數項只需要右移三位  通常位運算底層會自動升型 所以要強制再轉回來
                byte s = (byte)(LSB >> 3);
                dgv_BER_result.Rows[i].Cells["left_zero_padding"].Value = $"{Convert.ToString(s, 2)} ";

                byte high = (byte)((byte)(LSB << 5) >> 5);
                byte low = MSB;
                ushort m = (ushort)((high << 8) | low);
                dgv_BER_result.Rows[i].Cells["left_zero_padding"].Value += $"{Convert.ToString(m, 2)}";


                dgv_BER_result.Rows[i].Cells["BER"].Value = (m * Math.Pow(10, s - 24)).ToString("E2");

                dgv_DDMI2.Rows[dgv_DDMI2.RowCount-1].Cells[i+1].Value = (m * Math.Pow(10, s - 24)).ToString("E2");
            }
            #endregion



            #region -- dgv_DDMI refresh --
            byte[] A0L = script_obj.Readpage_128byte("00");

            try
            {
                ChangePage("00", "11", script_obj); //依文件 是在page = 14h 讀值
                Thread.Sleep(100);
            }
            catch (Exception)
            {
                throw;
            }
            byte[] P_11h = script_obj.Readpage_128byte("80");



            //C_CMIS.A0L = A0L;
            //C_CMIS.B00P11 = P_11h;

            double real_T = C_CMIS.EEPROM_real_T(A0L);
            dgv_DDMI.Rows[0].Cells[1].Value = real_T.ToString("0.00");
            dgv_DDMI2.Rows[0].Cells[1].Value = real_T.ToString("0.00");

            double real_V = C_CMIS.EEPROM_real_Vcc(A0L);
            dgv_DDMI.Rows[1].Cells[1].Value = real_V.ToString("0.00");
            dgv_DDMI2.Rows[1].Cells[1].Value = real_V.ToString("0.00");


            double[] real_Bias = C_CMIS.EEPROM_real_Bias(P_11h);
            double[] real_TxP = C_CMIS.EEPROM_Txpwr_dBm(P_11h);
            double[] real_RxP = C_CMIS.EEPROM_Rxpwr_dBm(P_11h);

            for (int i = 0; i < 8; i++)
            {
                dgv_DDMI.Rows[2].Cells[i + 1].Value = real_Bias[i].ToString();
                dgv_DDMI.Rows[3].Cells[i + 1].Value = real_TxP[i].ToString("0.00");
                dgv_DDMI.Rows[4].Cells[i + 1].Value = real_RxP[i].ToString("0.00");

                dgv_DDMI2.Rows[2].Cells[i + 1].Value = real_Bias[i].ToString();
                dgv_DDMI2.Rows[3].Cells[i + 1].Value = real_TxP[i].ToString("0.00");
                dgv_DDMI2.Rows[4].Cells[i + 1].Value = real_RxP[i].ToString("0.00");
            }
            #endregion
        }

        private void btn_Host_pattern_Click(object sender, EventArgs e)
        {
            ComboBox cbo = cbo_Host_pattern;

            if (cbo.SelectedIndex == -1)
            {
                MessageBox.Show("下拉選單要選");
                return;
            }

            string address = "94";
            string value=cbo.Text.Split(',')[0].Replace("0x", "");

            script_obj.RunScript($"ssA0{address}{value}{value}{value}{value}");
        }

        private void btn_Media_pattern_Click(object sender, EventArgs e)
        {
            ComboBox cbo = cbo_Media_pattern;

            if (cbo.SelectedIndex == -1)
            {
                MessageBox.Show("下拉選單要選");
                return;
            }

            string address = "9C";
            string value = cbo.Text.Split(',')[0].Replace("0x", "");

            script_obj.RunScript($"ssA0{address}{value}{value}{value}{value}");
        }

        private void btn_RealTime_ON2_Click(object sender, EventArgs e)
        {
            btn_RealTime_ON_Click(sender, e);
        }

        private void btn_RealTime_OFF2_Click(object sender, EventArgs e)
        {
            btn_RealTime_OFF_Click(sender, e);
        }

        private void cbo_Host_Media_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_Host_Media.SelectedIndex = cbo_Host_Media_2.SelectedIndex;
        }
    }
}
