using FOE_YR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMIS_forPRBSmode_readBER_02
{
    public partial class Form1 : Form
    {
        Color _resetC = Color.Silver;
        Color _runC = Color.Gold;
        Color _finishC = Color.Lime;
        Color _passC = Color.Lime;
        Color _failC = Color.Red;


        UI_dgv UI_dgv = new UI_dgv();
        I_I2C I2C = null;
        I_Script_Interpreter script_obj = null;
        C_CMIS C_CMIS = null;


        private System.Windows.Forms.Timer timer_BER = new System.Windows.Forms.Timer(); // ← 宣告成欄位
        private System.Windows.Forms.Timer timer_DDMI = new System.Windows.Forms.Timer(); // ← 宣告成欄位


        private void Initialize_dgv_BER_result(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;

            string[] colname = "ch,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch8".Split(',');
            string[] coltxt = "ch,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch8".Split(',');
            string[] coltype = "txt,txt,txt,txt,txt,txt,txt,txt,txt".Split(',');
            int[] colW = { 50, 110, 110, 110, 110, 110, 110, 110, 110 };

            UI_dgv.Add_dgv_col(dgv, colname, coltxt, coltype, colW);

            dgv.Rows.Add($"BER");

            
        }


        public Form1()
        {
            InitializeComponent();

            UI_dgv.Dgv_EEPROM_initialize(dgv_EEPROM, "", 0, 16);

            Initialize_dgv_BER_result(dgv_BER_result);

            timer_BER.Tick += Timer_BER_Tick;
            timer_DDMI.Tick += Timer_DDMI_Tick;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (I2C != null)
            {
                I2C.Disconnect();
                I2C = null;
            }
            
        }

        private void ChangePage(string bank, string page, I_Script_Interpreter script)
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

        private void btn_new_SerialPort_Click(object sender, EventArgs e)
        {
            I2C = new I2C_USB_ISS(txt_port.Text, int.Parse(txt_baudRate.Text));

            script_obj = new Script_Interpreter(I2C);
            C_CMIS = new C_CMIS(script_obj);

            lbl_new_SerialPort.BackColor = _finishC;
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

        private void btn_read_Click(object sender, EventArgs e)
        {
            if (I2C == null)
            {
                MessageBox.Show("need create I2C物件");
                return;
            }

            txt_value.Text = script_obj.RunScript($"ggA0{txt_address.Text}01");
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


            //byte[] read_result = I2C.Read(0x00, 256);
            byte[] LP = script_obj.Readpage_128byte($"00");
            Thread.Sleep(200);
            byte[] UP = script_obj.Readpage_128byte($"80");
            byte[] read_result = LP.Concat(UP).ToArray();


            UI_dgv.Set_EEPROM_Value_to_Dgv(dgv_EEPROM, read_result, 0);
        }

        private void btn_script_set_Click(object sender, EventArgs e)
        {
            txt_result.Text = script_obj.RunScript(txt_script.Text);
        }

        private void btn_I2C_cmd_Click(object sender, EventArgs e)
        {
            var result = I2C.Query(txt_cmd.Text);
            txt_result.Text = string.Join(" ", result.Select(v => v.ToString("X2")));
        }

        

        private void btn_Host_PRBS_Generator_ON_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ssA090FF");
        }

        private void btn_Host_PRBS_Generator_OFF_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ssA09000");
        }

        private void btn_Media_PRBS_Generator_ON_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ssA098FF");
        }

        private void btn_Media_PRBS_Generator_OFF_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ssA09800");
        }

        private void btn_Host_pattern_Click(object sender, EventArgs e)
        {
            if (cbo_Host_pattern.SelectedIndex == -1)
            {
                MessageBox.Show("下拉選單要選");
                return;
            }
            
            ChangePage("00", "13", script_obj);

            string value = cbo_Host_pattern.Text.Split(',')[0].Replace("0x", "");
            script_obj.RunScript($"ssA094{value}{value}{value}{value}");
        }

        private void btn_Media_pattern_Click(object sender, EventArgs e)
        {
            if (cbo_Media_pattern.SelectedIndex == -1)
            {
                MessageBox.Show("下拉選單要選");
                return;
            }

            ChangePage("00", "13", script_obj);

            string value = cbo_Media_pattern.Text.Split(',')[0].Replace("0x", "");
            script_obj.RunScript($"ssA09C{value}{value}{value}{value}");
        }

        private void btn_Host_PRBS_checker_ON_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ssA0A0FF");
        }

        private void btn_Host_PRBS_checker_OFF_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ssA0A000");
        }

        private void btn_Media_PRBS_checker_ON_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ssA0A8FF");
        }

        private void btn_Media_PRBS_checker_OFF_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ssA0A800");
        }

        private void btn_AutoRestart_Enable_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ttA0B11010");
        }

        private void btn_AutoRestart_Disable_Click(object sender, EventArgs e)
        {
            ChangePage("00", "13", script_obj);
            script_obj.RunScript("ttA0B11000");
        }

        private void btn_Set_MeasureTime_Click(object sender, EventArgs e)
        {
            if (cbo_Measure_Time.SelectedIndex == -1)
            {
                MessageBox.Show("下拉選單要選");
                return;
            }

            ChangePage("00", "13", script_obj);

            string value = cbo_Measure_Time.Text.Split(':')[0].Replace("b","0");
            string hex = Convert.ToByte(value, 2).ToString("X2");

            string mask = Convert.ToByte("1110", 2).ToString("X2");

            script_obj.RunScript($"ssA0B1{mask}{hex}");
        }

        private void btn_BER_Reading_ON_Click(object sender, EventArgs e)
        {
            ChangePage("00", "14", script_obj);
            script_obj.RunScript("ssA08001");
        }

        private void btn_BER_Reading_OFF_Click(object sender, EventArgs e)
        {
            ChangePage("00", "14", script_obj);
            script_obj.RunScript("ssA08000");
        }

        private void btn_BER_read_once_Click(object sender, EventArgs e)
        {
            double[] result;
            try
            {
                result = Refresh_BER(cbo_Host_Media);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



            for (int i = 0; i < 8; i++)
            {
                dgv_BER_result.Rows[0].Cells[i + 1].Value = result[i].ToString("E3");
            }
            
        }

        private double[] Refresh_BER(ComboBox cbo)
        {
            if (cbo.SelectedIndex == -1)
            {
                throw new Exception("Choose a value form cbo_Host_Media !!");
            }


            ChangePage("00", "14", script_obj);
            byte[] P_14h = script_obj.Readpage_128byte("80");



            string address_head;
            if (cbo.Text == "Host")
            {
                address_head = "C";
            }
            else if (cbo.Text == "Media")
            {
                address_head = "D";
            }
            else
            {
                throw new Exception("Choose a vlaue form cbo_Host_Media!!");
            }


            double[] BER_value = new double[8];
            for (int ch = 0; ch < 8; ch++)
            {
                string address_hexstr = $"{address_head}{(ch * 2).ToString("X1")}";
                var address_temp = Convert.ToByte(address_hexstr, 16);

                byte LSB = P_14h[address_temp - 128];
                byte MSB = P_14h[address_temp - 128 + 1];



                //var s =(byte)(Convert.ToByte("72", 16) >> 3); //看起來 係數項只需要右移三位  通常位運算底層會自動升型 所以要強制再轉回來
                byte s = (byte)(LSB >> 3);

                byte high = (byte)((byte)(LSB << 5) >> 5);
                byte low = MSB;
                ushort m = (ushort)((high << 8) | low);

                BER_value[ch] = (m * Math.Pow(10, s - 24));
            }

            return BER_value;
        }

        private List<Control> controlList_forBER;

        private void btn_BER_RealTime_ON_Click(object sender, EventArgs e)
        {
            if (cbo_Host_Media.SelectedIndex == -1)
            {
                MessageBox.Show("Choose a value form cbo_Host_Media !!");
                return;
            }


            //關閉部分按鍵
            controlList_forBER = new List<Control>()
            {
                btn_I2C_cmd,

                btn_read_256byte,
                btn_script_set,

                cbo_Host_Media,

                btn_BER_read_once,
                btn_DDMI_read_once,

                btn_BER_RealTime_ON,

                btn_DDMI_RealTime_ON,
                btn_DDMI_RealTime_OFF,

                //調整區
                btn_Host_PRBS_Generator_ON,
                btn_Host_PRBS_Generator_OFF,
                btn_Media_PRBS_Generator_ON,
                btn_Media_PRBS_Generator_OFF,

                cbo_Host_pattern,
                btn_Host_pattern,
                cbo_Media_pattern,
                btn_Media_pattern,

                btn_Host_PRBS_checker_ON,
                btn_Host_PRBS_checker_OFF,
                btn_Media_PRBS_checker_ON,
                btn_Media_PRBS_checker_OFF,

                btn_AutoRestart_Enable,
                btn_AutoRestart_Disable,

                btn_Set_MeasureTime,

                btn_BER_Reading_ON,
                btn_BER_Reading_OFF
            };

            foreach (var ctrl in controlList_forBER)
            {
                ctrl.Enabled = false;
            }



            timer_BER.Interval = 2 * 1000; // 每 ? 秒觸發一次
            timer_BER.Start(); // 開始
        }

        private void btn_BER_RealTime_OFF_Click(object sender, EventArgs e)
        {
            timer_BER.Stop(); // 停止


            //關閉部分按鍵
            foreach (var ctrl in controlList_forBER)
            {
                ctrl.Enabled = true;
            }
        }

        private void Timer_BER_Tick(object sender, EventArgs e)
        {
            double[] result = Refresh_BER(cbo_Host_Media);

            for (int i = 0; i < 8; i++)
            {
                dgv_BER_result.Rows[0].Cells[i + 1].Value = result[i].ToString("E3");
            }
        }

        private void btn_read_once_Click(object sender, EventArgs e)
        {
            try
            {
                Update_DDMI();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Update_DDMI()
        {
            if (C_CMIS == null)
            {
                throw new Exception($"CMIS object is null !!");
            }



            C_CMIS.Update_CMISpage(100);



            #region -- temperature --
            var temp = C_CMIS.GetTemp();

            txt_DDMI_Temp_real.Text = temp.realval.ToString("0.00");

            txt_DDMI_Temp_LA.Text = temp.alarmL.ToString("0.00");
            txt_DDMI_Temp_HA.Text = temp.alarmH.ToString("0.00");
            txt_DDMI_Temp_LW.Text = temp.warningL.ToString("0.00");
            txt_DDMI_Temp_HW.Text = temp.warningH.ToString("0.00");

            //falg
            lbl_Temp_LA.BackColor = temp.flag[0] ? _failC : _passC;
            lbl_Temp_HA.BackColor = temp.flag[1] ? _failC : _passC;
            lbl_Temp_LW.BackColor = temp.flag[2] ? _failC : _passC;
            lbl_Temp_HW.BackColor = temp.flag[3] ? _failC : _passC;
            #endregion


            #region -- Vcc --
            var vcc = C_CMIS.GetVcc();

            txt_DDMI_Vcc_real.Text = vcc.realval.ToString("0.00");

            txt_DDMI_Vcc_LA.Text = vcc.alarmL.ToString("0.00");
            txt_DDMI_Vcc_HA.Text = vcc.alarmH.ToString("0.00");
            txt_DDMI_Vcc_LW.Text = vcc.warningL.ToString("0.00");
            txt_DDMI_Vcc_HW.Text = vcc.warningH.ToString("0.00");

            //falg
            lbl_Vcc_LA.BackColor = vcc.flag[0] ? _failC : _passC;
            lbl_Vcc_HA.BackColor = vcc.flag[1] ? _failC : _passC;
            lbl_Vcc_LW.BackColor = vcc.flag[2] ? _failC : _passC;
            lbl_Vcc_HW.BackColor = vcc.flag[3] ? _failC : _passC;
            #endregion


            #region -- TxBias --
            var bias = C_CMIS.GetBias();

            txt_DDMI_BiasCH1_real.Text = bias.realval[0].ToString("0.00");
            txt_DDMI_BiasCH2_real.Text = bias.realval[1].ToString("0.00");
            txt_DDMI_BiasCH3_real.Text = bias.realval[2].ToString("0.00");
            txt_DDMI_BiasCH4_real.Text = bias.realval[3].ToString("0.00");
            txt_DDMI_BiasCH5_real.Text = bias.realval[4].ToString("0.00");
            txt_DDMI_BiasCH6_real.Text = bias.realval[5].ToString("0.00");
            txt_DDMI_BiasCH7_real.Text = bias.realval[6].ToString("0.00");
            txt_DDMI_BiasCH8_real.Text = bias.realval[7].ToString("0.00");



            txt_DDMI_Bias_LA.Text = bias.alarmL.ToString("0.00");
            txt_DDMI_Bias_HA.Text = bias.alarmH.ToString("0.00");
            txt_DDMI_Bias_LW.Text = bias.warningL.ToString("0.00");
            txt_DDMI_Bias_HW.Text = bias.warningH.ToString("0.00");

            //falg
            lbl_TxB_ch1_LA.BackColor = bias.flagList_AWLH_ch[0][0] ? _failC : _passC;
            lbl_TxB_ch1_HA.BackColor = bias.flagList_AWLH_ch[1][0] ? _failC : _passC;
            lbl_TxB_ch1_LW.BackColor = bias.flagList_AWLH_ch[2][0] ? _failC : _passC;
            lbl_TxB_ch1_HW.BackColor = bias.flagList_AWLH_ch[3][0] ? _failC : _passC;

            lbl_TxB_ch2_LA.BackColor = bias.flagList_AWLH_ch[0][1] ? _failC : _passC;
            lbl_TxB_ch2_HA.BackColor = bias.flagList_AWLH_ch[1][1] ? _failC : _passC;
            lbl_TxB_ch2_LW.BackColor = bias.flagList_AWLH_ch[2][1] ? _failC : _passC;
            lbl_TxB_ch2_HW.BackColor = bias.flagList_AWLH_ch[3][1] ? _failC : _passC;

            lbl_TxB_ch3_LA.BackColor = bias.flagList_AWLH_ch[0][2] ? _failC : _passC;
            lbl_TxB_ch3_HA.BackColor = bias.flagList_AWLH_ch[1][2] ? _failC : _passC;
            lbl_TxB_ch3_LW.BackColor = bias.flagList_AWLH_ch[2][2] ? _failC : _passC;
            lbl_TxB_ch3_HW.BackColor = bias.flagList_AWLH_ch[3][2] ? _failC : _passC;

            lbl_TxB_ch4_LA.BackColor = bias.flagList_AWLH_ch[0][3] ? _failC : _passC;
            lbl_TxB_ch4_HA.BackColor = bias.flagList_AWLH_ch[1][3] ? _failC : _passC;
            lbl_TxB_ch4_LW.BackColor = bias.flagList_AWLH_ch[2][3] ? _failC : _passC;
            lbl_TxB_ch4_HW.BackColor = bias.flagList_AWLH_ch[3][3] ? _failC : _passC;

            lbl_TxB_ch5_LA.BackColor = bias.flagList_AWLH_ch[0][4] ? _failC : _passC;
            lbl_TxB_ch5_HA.BackColor = bias.flagList_AWLH_ch[1][4] ? _failC : _passC;
            lbl_TxB_ch5_LW.BackColor = bias.flagList_AWLH_ch[2][4] ? _failC : _passC;
            lbl_TxB_ch5_HW.BackColor = bias.flagList_AWLH_ch[3][4] ? _failC : _passC;

            lbl_TxB_ch6_LA.BackColor = bias.flagList_AWLH_ch[0][5] ? _failC : _passC;
            lbl_TxB_ch6_HA.BackColor = bias.flagList_AWLH_ch[1][5] ? _failC : _passC;
            lbl_TxB_ch6_LW.BackColor = bias.flagList_AWLH_ch[2][5] ? _failC : _passC;
            lbl_TxB_ch6_HW.BackColor = bias.flagList_AWLH_ch[3][5] ? _failC : _passC;

            lbl_TxB_ch7_LA.BackColor = bias.flagList_AWLH_ch[0][6] ? _failC : _passC;
            lbl_TxB_ch7_HA.BackColor = bias.flagList_AWLH_ch[1][6] ? _failC : _passC;
            lbl_TxB_ch7_LW.BackColor = bias.flagList_AWLH_ch[2][6] ? _failC : _passC;
            lbl_TxB_ch7_HW.BackColor = bias.flagList_AWLH_ch[3][6] ? _failC : _passC;

            lbl_TxB_ch8_LA.BackColor = bias.flagList_AWLH_ch[0][7] ? _failC : _passC;
            lbl_TxB_ch8_HA.BackColor = bias.flagList_AWLH_ch[1][7] ? _failC : _passC;
            lbl_TxB_ch8_LW.BackColor = bias.flagList_AWLH_ch[2][7] ? _failC : _passC;
            lbl_TxB_ch8_HW.BackColor = bias.flagList_AWLH_ch[3][7] ? _failC : _passC;

            #endregion


            #region -- TxP --
            var txp = C_CMIS.GetTxP();

            txt_DDMI_TxpCH1_real.Text = txp.realval[0].ToString("0.00");
            txt_DDMI_TxpCH2_real.Text = txp.realval[1].ToString("0.00");
            txt_DDMI_TxpCH3_real.Text = txp.realval[2].ToString("0.00");
            txt_DDMI_TxpCH4_real.Text = txp.realval[3].ToString("0.00");
            txt_DDMI_TxpCH5_real.Text = txp.realval[4].ToString("0.00");
            txt_DDMI_TxpCH6_real.Text = txp.realval[5].ToString("0.00");
            txt_DDMI_TxpCH7_real.Text = txp.realval[6].ToString("0.00");
            txt_DDMI_TxpCH8_real.Text = txp.realval[7].ToString("0.00");



            txt_DDMI_TxP_LA.Text = txp.alarmL.ToString("0.00");
            txt_DDMI_TxP_HA.Text = txp.alarmH.ToString("0.00");
            txt_DDMI_TxP_LW.Text = txp.warningL.ToString("0.00");
            txt_DDMI_TxP_HW.Text = txp.warningH.ToString("0.00");

            //falg
            lbl_TxP_ch1_LA.BackColor = txp.flagList_AWLH_ch[0][0] ? _failC : _passC;
            lbl_TxP_ch1_HA.BackColor = txp.flagList_AWLH_ch[1][0] ? _failC : _passC;
            lbl_TxP_ch1_LW.BackColor = txp.flagList_AWLH_ch[2][0] ? _failC : _passC;
            lbl_TxP_ch1_HW.BackColor = txp.flagList_AWLH_ch[3][0] ? _failC : _passC;

            lbl_TxP_ch2_LA.BackColor = txp.flagList_AWLH_ch[0][1] ? _failC : _passC;
            lbl_TxP_ch2_HA.BackColor = txp.flagList_AWLH_ch[1][1] ? _failC : _passC;
            lbl_TxP_ch2_LW.BackColor = txp.flagList_AWLH_ch[2][1] ? _failC : _passC;
            lbl_TxP_ch2_HW.BackColor = txp.flagList_AWLH_ch[3][1] ? _failC : _passC;

            lbl_TxP_ch3_LA.BackColor = txp.flagList_AWLH_ch[0][2] ? _failC : _passC;
            lbl_TxP_ch3_HA.BackColor = txp.flagList_AWLH_ch[1][2] ? _failC : _passC;
            lbl_TxP_ch3_LW.BackColor = txp.flagList_AWLH_ch[2][2] ? _failC : _passC;
            lbl_TxP_ch3_HW.BackColor = txp.flagList_AWLH_ch[3][2] ? _failC : _passC;

            lbl_TxP_ch4_LA.BackColor = txp.flagList_AWLH_ch[0][3] ? _failC : _passC;
            lbl_TxP_ch4_HA.BackColor = txp.flagList_AWLH_ch[1][3] ? _failC : _passC;
            lbl_TxP_ch4_LW.BackColor = txp.flagList_AWLH_ch[2][3] ? _failC : _passC;
            lbl_TxP_ch4_HW.BackColor = txp.flagList_AWLH_ch[3][3] ? _failC : _passC;

            lbl_TxP_ch5_LA.BackColor = txp.flagList_AWLH_ch[0][4] ? _failC : _passC;
            lbl_TxP_ch5_HA.BackColor = txp.flagList_AWLH_ch[1][4] ? _failC : _passC;
            lbl_TxP_ch5_LW.BackColor = txp.flagList_AWLH_ch[2][4] ? _failC : _passC;
            lbl_TxP_ch5_HW.BackColor = txp.flagList_AWLH_ch[3][4] ? _failC : _passC;

            lbl_TxP_ch6_LA.BackColor = txp.flagList_AWLH_ch[0][5] ? _failC : _passC;
            lbl_TxP_ch6_HA.BackColor = txp.flagList_AWLH_ch[1][5] ? _failC : _passC;
            lbl_TxP_ch6_LW.BackColor = txp.flagList_AWLH_ch[2][5] ? _failC : _passC;
            lbl_TxP_ch6_HW.BackColor = txp.flagList_AWLH_ch[3][5] ? _failC : _passC;

            lbl_TxP_ch7_LA.BackColor = txp.flagList_AWLH_ch[0][6] ? _failC : _passC;
            lbl_TxP_ch7_HA.BackColor = txp.flagList_AWLH_ch[1][6] ? _failC : _passC;
            lbl_TxP_ch7_LW.BackColor = txp.flagList_AWLH_ch[2][6] ? _failC : _passC;
            lbl_TxP_ch7_HW.BackColor = txp.flagList_AWLH_ch[3][6] ? _failC : _passC;

            lbl_TxP_ch8_LA.BackColor = txp.flagList_AWLH_ch[0][7] ? _failC : _passC;
            lbl_TxP_ch8_HA.BackColor = txp.flagList_AWLH_ch[1][7] ? _failC : _passC;
            lbl_TxP_ch8_LW.BackColor = txp.flagList_AWLH_ch[2][7] ? _failC : _passC;
            lbl_TxP_ch8_HW.BackColor = txp.flagList_AWLH_ch[3][7] ? _failC : _passC;

            #endregion


            #region -- RxP --
            var rxp = C_CMIS.GetRxP();

            txt_DDMI_RxpCH1_real.Text = rxp.realval[0].ToString("0.00");
            txt_DDMI_RxpCH2_real.Text = rxp.realval[1].ToString("0.00");
            txt_DDMI_RxpCH3_real.Text = rxp.realval[2].ToString("0.00");
            txt_DDMI_RxpCH4_real.Text = rxp.realval[3].ToString("0.00");
            txt_DDMI_RxpCH5_real.Text = rxp.realval[4].ToString("0.00");
            txt_DDMI_RxpCH6_real.Text = rxp.realval[5].ToString("0.00");
            txt_DDMI_RxpCH7_real.Text = rxp.realval[6].ToString("0.00");
            txt_DDMI_RxpCH8_real.Text = rxp.realval[7].ToString("0.00");



            txt_DDMI_RxP_LA.Text = rxp.alarmL.ToString("0.00");
            txt_DDMI_RxP_HA.Text = rxp.alarmH.ToString("0.00");
            txt_DDMI_RxP_LW.Text = rxp.warningL.ToString("0.00");
            txt_DDMI_RxP_HW.Text = rxp.warningH.ToString("0.00");

            //falg
            lbl_RxP_ch1_LA.BackColor = rxp.flagList_AWLH_ch[0][0] ? _failC : _passC;
            lbl_RxP_ch1_HA.BackColor = rxp.flagList_AWLH_ch[1][0] ? _failC : _passC;
            lbl_RxP_ch1_LW.BackColor = rxp.flagList_AWLH_ch[2][0] ? _failC : _passC;
            lbl_RxP_ch1_HW.BackColor = rxp.flagList_AWLH_ch[3][0] ? _failC : _passC;

            lbl_RxP_ch2_LA.BackColor = rxp.flagList_AWLH_ch[0][1] ? _failC : _passC;
            lbl_RxP_ch2_HA.BackColor = rxp.flagList_AWLH_ch[1][1] ? _failC : _passC;
            lbl_RxP_ch2_LW.BackColor = rxp.flagList_AWLH_ch[2][1] ? _failC : _passC;
            lbl_RxP_ch2_HW.BackColor = rxp.flagList_AWLH_ch[3][1] ? _failC : _passC;

            lbl_RxP_ch3_LA.BackColor = rxp.flagList_AWLH_ch[0][2] ? _failC : _passC;
            lbl_RxP_ch3_HA.BackColor = rxp.flagList_AWLH_ch[1][2] ? _failC : _passC;
            lbl_RxP_ch3_LW.BackColor = rxp.flagList_AWLH_ch[2][2] ? _failC : _passC;
            lbl_RxP_ch3_HW.BackColor = rxp.flagList_AWLH_ch[3][2] ? _failC : _passC;

            lbl_RxP_ch4_LA.BackColor = rxp.flagList_AWLH_ch[0][3] ? _failC : _passC;
            lbl_RxP_ch4_HA.BackColor = rxp.flagList_AWLH_ch[1][3] ? _failC : _passC;
            lbl_RxP_ch4_LW.BackColor = rxp.flagList_AWLH_ch[2][3] ? _failC : _passC;
            lbl_RxP_ch4_HW.BackColor = rxp.flagList_AWLH_ch[3][3] ? _failC : _passC;

            lbl_RxP_ch5_LA.BackColor = rxp.flagList_AWLH_ch[0][4] ? _failC : _passC;
            lbl_RxP_ch5_HA.BackColor = rxp.flagList_AWLH_ch[1][4] ? _failC : _passC;
            lbl_RxP_ch5_LW.BackColor = rxp.flagList_AWLH_ch[2][4] ? _failC : _passC;
            lbl_RxP_ch5_HW.BackColor = rxp.flagList_AWLH_ch[3][4] ? _failC : _passC;

            lbl_RxP_ch6_LA.BackColor = rxp.flagList_AWLH_ch[0][5] ? _failC : _passC;
            lbl_RxP_ch6_HA.BackColor = rxp.flagList_AWLH_ch[1][5] ? _failC : _passC;
            lbl_RxP_ch6_LW.BackColor = rxp.flagList_AWLH_ch[2][5] ? _failC : _passC;
            lbl_RxP_ch6_HW.BackColor = rxp.flagList_AWLH_ch[3][5] ? _failC : _passC;

            lbl_RxP_ch7_LA.BackColor = rxp.flagList_AWLH_ch[0][6] ? _failC : _passC;
            lbl_RxP_ch7_HA.BackColor = rxp.flagList_AWLH_ch[1][6] ? _failC : _passC;
            lbl_RxP_ch7_LW.BackColor = rxp.flagList_AWLH_ch[2][6] ? _failC : _passC;
            lbl_RxP_ch7_HW.BackColor = rxp.flagList_AWLH_ch[3][6] ? _failC : _passC;

            lbl_RxP_ch8_LA.BackColor = rxp.flagList_AWLH_ch[0][7] ? _failC : _passC;
            lbl_RxP_ch8_HA.BackColor = rxp.flagList_AWLH_ch[1][7] ? _failC : _passC;
            lbl_RxP_ch8_LW.BackColor = rxp.flagList_AWLH_ch[2][7] ? _failC : _passC;
            lbl_RxP_ch8_HW.BackColor = rxp.flagList_AWLH_ch[3][7] ? _failC : _passC;

            #endregion


            #region -- Rx LOS LOL --
            var Rx_LOS_LOL = C_CMIS.GetRx_LOS_LOL();

            lbl_Rx_LOS1.BackColor = Rx_LOS_LOL.RxLOS[0] ? _failC : _passC;
            lbl_Rx_LOS2.BackColor = Rx_LOS_LOL.RxLOS[1] ? _failC : _passC;
            lbl_Rx_LOS3.BackColor = Rx_LOS_LOL.RxLOS[2] ? _failC : _passC;
            lbl_Rx_LOS4.BackColor = Rx_LOS_LOL.RxLOS[3] ? _failC : _passC;
            lbl_Rx_LOS5.BackColor = Rx_LOS_LOL.RxLOS[4] ? _failC : _passC;
            lbl_Rx_LOS6.BackColor = Rx_LOS_LOL.RxLOS[5] ? _failC : _passC;
            lbl_Rx_LOS7.BackColor = Rx_LOS_LOL.RxLOS[6] ? _failC : _passC;
            lbl_Rx_LOS8.BackColor = Rx_LOS_LOL.RxLOS[7] ? _failC : _passC;

            lbl_Rx_LOL1.BackColor = Rx_LOS_LOL.RxLOL[0] ? _failC : _passC;
            lbl_Rx_LOL2.BackColor = Rx_LOS_LOL.RxLOL[1] ? _failC : _passC;
            lbl_Rx_LOL3.BackColor = Rx_LOS_LOL.RxLOL[2] ? _failC : _passC;
            lbl_Rx_LOL4.BackColor = Rx_LOS_LOL.RxLOL[3] ? _failC : _passC;
            lbl_Rx_LOL5.BackColor = Rx_LOS_LOL.RxLOL[4] ? _failC : _passC;
            lbl_Rx_LOL6.BackColor = Rx_LOS_LOL.RxLOL[5] ? _failC : _passC;
            lbl_Rx_LOL7.BackColor = Rx_LOS_LOL.RxLOL[6] ? _failC : _passC;
            lbl_Rx_LOL8.BackColor = Rx_LOS_LOL.RxLOL[7] ? _failC : _passC;
            #endregion


            #region -- Tx LOS LOL --
            var Tx_LOS_LOL = C_CMIS.GetTx_LOS_LOL();

            lbl_Tx_LOS1.BackColor = Tx_LOS_LOL.TxLOS[0] ? _failC : _passC;
            lbl_Tx_LOS2.BackColor = Tx_LOS_LOL.TxLOS[1] ? _failC : _passC;
            lbl_Tx_LOS3.BackColor = Tx_LOS_LOL.TxLOS[2] ? _failC : _passC;
            lbl_Tx_LOS4.BackColor = Tx_LOS_LOL.TxLOS[3] ? _failC : _passC;
            lbl_Tx_LOS5.BackColor = Tx_LOS_LOL.TxLOS[4] ? _failC : _passC;
            lbl_Tx_LOS6.BackColor = Tx_LOS_LOL.TxLOS[5] ? _failC : _passC;
            lbl_Tx_LOS7.BackColor = Tx_LOS_LOL.TxLOS[6] ? _failC : _passC;
            lbl_Tx_LOS8.BackColor = Tx_LOS_LOL.TxLOS[7] ? _failC : _passC;

            lbl_Tx_LOL1.BackColor = Tx_LOS_LOL.TxLOL[0] ? _failC : _passC;
            lbl_Tx_LOL2.BackColor = Tx_LOS_LOL.TxLOL[1] ? _failC : _passC;
            lbl_Tx_LOL3.BackColor = Tx_LOS_LOL.TxLOL[2] ? _failC : _passC;
            lbl_Tx_LOL4.BackColor = Tx_LOS_LOL.TxLOL[3] ? _failC : _passC;
            lbl_Tx_LOL5.BackColor = Tx_LOS_LOL.TxLOL[4] ? _failC : _passC;
            lbl_Tx_LOL6.BackColor = Tx_LOS_LOL.TxLOL[5] ? _failC : _passC;
            lbl_Tx_LOL7.BackColor = Tx_LOS_LOL.TxLOL[6] ? _failC : _passC;
            lbl_Tx_LOL8.BackColor = Tx_LOS_LOL.TxLOL[7] ? _failC : _passC;
            #endregion


        }

        private List<Control> controlList_forDDMI;

        private void btn_DDMI_RealTime_ON_Click(object sender, EventArgs e)
        {
            if (C_CMIS == null)
            {
                MessageBox.Show("Please connect Dongle !!");
                return;
            }


            //關閉部分按鍵
            controlList_forDDMI = new List<Control>()
            {
                btn_I2C_cmd,

                btn_read_256byte,
                btn_script_set,

                cbo_Host_Media,

                btn_BER_read_once,
                btn_DDMI_read_once,

                btn_BER_RealTime_ON,
                btn_BER_RealTime_OFF,

                btn_DDMI_RealTime_ON,
                

                //調整區
                btn_Host_PRBS_Generator_ON,
                btn_Host_PRBS_Generator_OFF,
                btn_Media_PRBS_Generator_ON,
                btn_Media_PRBS_Generator_OFF,

                cbo_Host_pattern,
                btn_Host_pattern,
                cbo_Media_pattern,
                btn_Media_pattern,

                btn_Host_PRBS_checker_ON,
                btn_Host_PRBS_checker_OFF,
                btn_Media_PRBS_checker_ON,
                btn_Media_PRBS_checker_OFF,

                btn_AutoRestart_Enable,
                btn_AutoRestart_Disable,

                btn_Set_MeasureTime,

                btn_BER_Reading_ON,
                btn_BER_Reading_OFF
            };

            foreach (var ctrl in controlList_forDDMI)
            {
                ctrl.Enabled = false;
            }

            timer_DDMI.Interval = 2 * 1000; // 每 ? 秒觸發一次
            timer_DDMI.Start(); // 開始
        }

        private void btn_DDMI_RealTime_OFF_Click(object sender, EventArgs e)
        {
            timer_DDMI.Stop(); // 停止


            //關閉部分按鍵
            foreach (var ctrl in controlList_forDDMI)
            {
                ctrl.Enabled = true;
            }
        }

        private void Timer_DDMI_Tick(object sender, EventArgs e)
        {
            try
            {
                Update_DDMI();
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
