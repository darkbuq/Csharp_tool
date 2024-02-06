using SampleCodeV2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFF_Utility.Calibrate
{
    public partial class Form_CMIS_MA4000 : Form
    {
        static long captureTimeIns;
        static byte[] patternTX = new byte[9];
        static byte[] rxPatternLSB = new byte[9];
        static byte[] rxLockMSB = new byte[9];
        static byte[] rxLockLSB = new byte[9];
        static byte[] rxLock = new byte[9];
        static byte[] rxInvertMSB = new byte[9];
        static byte[] rxInvertLSB = new byte[9];
        static UInt64[] bertErrorCountMSB = new UInt64[9];
        static UInt64[] bertErrorCountLSB = new UInt64[9];
        static UInt64[] bertErrorCount = new UInt64[9];
        static UInt64[] bertBitCount = new UInt64[9];
        static double[] realTimer = new double[9];
        static double[] bertValue = new double[9];
        static UInt64[] fecCOR = new UInt64[9];
        static double[] fecBertValues = new double[9];
        static UInt64[] fecResults = new UInt64[432];
        static double[] margin = new double[9];
        static double[] marginPct = new double[9];
        static sbyte[] taps = new sbyte[144];

        static bool BERWithMargin = true;

        enum berType
        {
            BERT_TYPE_Timed,
            BERT_TYPE_Repe,
            BERT_TYPE_Infinite
        };

        private void dgvTableGrid_initialize(DataGridView dgv)
        {
            dgv.Columns.Add("_", "#");
            for (int i = 0; i < 16; i++)
            {
                dgv.Columns.Add(i.ToString("X1"), "0" + i.ToString("X1"));
            }
            dgv.RowHeadersWidth = 15;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            for (int i = 0; i < 16; i++)
            {
                dgv.Rows.Add(i.ToString("X1") + "0");
            }
            dgv.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
        }

        

        public Form_CMIS_MA4000()
        {
            InitializeComponent();

            clb_SwitchPPGEDOptionsV4API.SetItemChecked(1, true);
            clb_SwitchPPGEDOptionsV4API.SetItemChecked(2, true);
            clb_SwitchPPGEDOptionsV4API.SetItemChecked(3, true);

            dgvTableGrid_initialize(dgvTableGrid);
            dgvTableGrid_initialize(dgvTableGrid2);
        }               

        private void btn_conn_Click(object sender, EventArgs e)
        {
            lbl_conn.BackColor = Color.White;
            lbl_conn.Refresh();
            Thread.Sleep(1000);

            byte FWStatus = 0;
            if (BAWrapper.ConnectV2API(txt_ip.Text, ref FWStatus))
            {
                lbl_conn.BackColor = Color.Lime;
            }
            else
            {
                lbl_conn.BackColor = Color.Red;
            }

        }

        private void btn_conn2_Click(object sender, EventArgs e)
        {
            lbl_conn2.BackColor = Color.White;
            lbl_conn2.Refresh();
            Thread.Sleep(1000);

            byte FWStatus = 0;
            if (BAWrapper2.ConnectV2API(txt_ip2.Text, ref FWStatus))
            {
                lbl_conn2.BackColor = Color.Lime;
            }
            else
            {
                lbl_conn2.BackColor = Color.Red;
            }

        }

        private void btn_disconn_Click(object sender, EventArgs e)
        {
            lbl_disconn.BackColor = Color.White;
            lbl_disconn.Refresh();
            Thread.Sleep(1000);

            if (BAWrapper.DisconnectAPI())
            {
                lbl_disconn.BackColor = Color.Lime;
            }
            else
            {
                lbl_disconn.BackColor = Color.Red;
            }
        }

        private void btn_IsConnected_Click(object sender, EventArgs e)
        {
            lbl_IsConnected.BackColor = Color.White;
            Application.DoEvents();

            if (BAWrapper.IsConnectedAPI())
            {
                lbl_IsConnected.BackColor = Color.Lime;
            }
            else
            {
                lbl_IsConnected.BackColor = Color.Red;
            }
        }

        private void btn_HWIsConnectedAPI_Click(object sender, EventArgs e)
        {
            lbl_HWIsConnectedAPI.BackColor = Color.White;
            Application.DoEvents();

            if (BAWrapper.HWIsConnectedAPI())
            {
                lbl_HWIsConnectedAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_HWIsConnectedAPI.BackColor = Color.Red;
            }
        }

        private void btn_ChangeIPAPI_Click(object sender, EventArgs e)
        {
            lbl_ChangeIPAPI.BackColor = Color.White;
            lbl_ChangeIPAPI.Refresh();
            Thread.Sleep(1000);

            string[] gg = txt_ChangeIPAPI.Text.Split('.');
            byte[] ipbyte = Array.ConvertAll(gg, s => byte.Parse(s));
            if (BAWrapper.ChangeIPAPI(ipbyte))
            {
                lbl_ChangeIPAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_ChangeIPAPI.BackColor = Color.Red;
            }
        }



        private void btn_SetBAConfigAPI_Click(object sender, EventArgs e)
        {
            lbl_SetBAConfigAPI.BackColor = Color.White;
            lbl_SetBAConfigAPI.Refresh();
            Thread.Sleep(1000);            

            if (BAWrapper.SetBAConfigAdvV2API(0, 26562500, 0, 0, 2, 0, 0, 0))
            {
                lbl_SetBAConfigAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_SetBAConfigAPI.BackColor = Color.Red;
            }
        }

        private void btn_UpdateTapsAPI_Click(object sender, EventArgs e)
        {
            lbl_UpdateTapsAPI.BackColor = Color.White;
            lbl_UpdateTapsAPI.Refresh();
            Thread.Sleep(1000);

            if (BAWrapper.UpdateTapsAPI(0, -4, 800, 0d, 0d, 0d))
            {
                lbl_UpdateTapsAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_UpdateTapsAPI.BackColor = Color.Red;
            }
        }

        private void btn_SetRXSensitivityAPI_Click(object sender, EventArgs e)
        {
            lbl_SetRXSensitivityAPI.BackColor = Color.White;
            lbl_SetRXSensitivityAPI.Refresh();
            Thread.Sleep(1000);

            if (BAWrapper.SetRXSensitivityAPI(0, 0))
            {
                lbl_SetRXSensitivityAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_SetRXSensitivityAPI.BackColor = Color.Red;
            }
        }

        private void btn_SetPatternAPI_Click(object sender, EventArgs e)
        {
            lbl_SetPatternAPI.BackColor = Color.White;
            lbl_SetPatternAPI.Refresh();
            Thread.Sleep(1000);

            //ulong => 0 到 18446744073709551615 整數
            ulong usePattern = ulong.Parse(txt_usePattern.Text);
            byte patternSelect = byte.Parse(txt_patternSelect.Text);
            if (BAWrapper.SetPatternAPI(0, patternSelect, usePattern, true, 1))
            {
                lbl_SetPatternAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_SetPatternAPI.BackColor = Color.Red;
            }
        }

        private void btn_SwitchPPGEDOptionsV4API_Click(object sender, EventArgs e)
        {
            lbl_SwitchPPGEDOptionsV4API.BackColor = Color.White;
            Application.DoEvents();

            List<byte> option_list = new List<byte>();
            txt_SwitchPPGEDOptionsV4API.Text = "";
            for (int i = 0; i < 32; i++)
            {
                if (i < clb_SwitchPPGEDOptionsV4API.Items.Count)
                {
                    if (clb_SwitchPPGEDOptionsV4API.GetItemChecked(i))
                    {
                        txt_SwitchPPGEDOptionsV4API.Text += 1 + " ";
                        option_list.Add(1);
                    }
                    else
                    {
                        txt_SwitchPPGEDOptionsV4API.Text += 0 + " ";
                        option_list.Add(0);
                    }
                }
                else
                {
                    option_list.Add(0);
                }
            }

            byte[] optionArr = option_list.ToArray();

            if (BAWrapper.SwitchPPGEDOptionsV4API(optionArr))
            {
                lbl_SwitchPPGEDOptionsV4API.BackColor = Color.Lime;
            }
            else
            {
                lbl_SwitchPPGEDOptionsV4API.BackColor = Color.Red;
            }
        }

        private void btn_SeRXPatternAPI_Click(object sender, EventArgs e)
        {
            lbl_SeRXPatternAPI.BackColor = Color.White;
            lbl_SeRXPatternAPI.Refresh();
            Thread.Sleep(1000);

            if (BAWrapper.SeRXPatternAPI(0, 18, true, 3))
            {
                lbl_SeRXPatternAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_SeRXPatternAPI.BackColor = Color.Red;
            }
        }

        private void btn_MASetPowerAPI_Click(object sender, EventArgs e)
        {
            lbl_MASetPowerAPI.BackColor = Color.White;
            lbl_MASetPowerAPI.Refresh();
            Thread.Sleep(1000);

            if (BAWrapper.MASetPowerAPI(chb_powerOnOff.Checked, double.Parse(txt_Vcc.Text)))
            {
                lbl_MASetPowerAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_MASetPowerAPI.BackColor = Color.Red;
            }
        }

        private void btn_MASetPowerAPI2_Click(object sender, EventArgs e)
        {
            lbl_MASetPowerAPI2.BackColor = Color.White;
            lbl_MASetPowerAPI2.Refresh();
            Thread.Sleep(1000);

            if (BAWrapper2.MASetPowerAPI(chb_powerOnOff2.Checked, double.Parse(txt_Vcc2.Text)))
            {
                lbl_MASetPowerAPI2.BackColor = Color.Lime;
            }
            else
            {
                lbl_MASetPowerAPI2.BackColor = Color.Red;
            }
        }

        private void btn_SetBERSettingsAPI_Click(object sender, EventArgs e)
        {
            lbl_SetBERSettingsAPI.BackColor = Color.White;
            lbl_SetBERSettingsAPI.Refresh();
            Thread.Sleep(1000);

            var timeArr = txt_SetBERSettingsAPI.Text.Replace(" ", "").Split(',').Select(int.Parse).ToArray();


            if (BAWrapper.SetBERSettingsAPI(0, 0, false, timeArr[0], timeArr[1], timeArr[2], timeArr[3]))
            {
                lbl_SetBERSettingsAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_SetBERSettingsAPI.BackColor = Color.Red;
            }
        }

        private void btn_ClearBERTestAPI_Click(object sender, EventArgs e)
        {
            lbl_ClearBERTestAPI.BackColor = Color.White;
            lbl_ClearBERTestAPI.Refresh();
            Thread.Sleep(500);

            if (BAWrapper.ClearBERTestAPI(0))
            {
                lbl_ClearBERTestAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_ClearBERTestAPI.BackColor = Color.Red;
            }
        }

        private void btn_StartBERTestAPI_Click(object sender, EventArgs e)
        {
            lbl_StartBERTestAPI.BackColor = Color.White;
            lbl_StartBERTestAPI.Refresh();
            Thread.Sleep(500);

            if (BAWrapper.StartBERTestAPI())
            {
                lbl_StartBERTestAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_StartBERTestAPI.BackColor = Color.Red;
            }
        }

        private void btn_StopBERTestAPI_Click(object sender, EventArgs e)
        {
            lbl_StopBERTestAPI.BackColor = Color.White;
            lbl_StopBERTestAPI.Refresh();
            Thread.Sleep(500);

            if (BAWrapper.StopBERTestAPI())
            {
                lbl_StopBERTestAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_StopBERTestAPI.BackColor = Color.Red;
            }
        }

        private void btn_IsBERTRunningAPI_Click(object sender, EventArgs e)
        {
            lbl_IsBERTRunningAPI.BackColor = Color.White;
            lbl_IsBERTRunningAPI.Refresh();
            Thread.Sleep(500);

            if (BAWrapper.IsBERTRunningAPI())
            {
                lbl_IsBERTRunningAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_IsBERTRunningAPI.BackColor = Color.Red;
            }
        }

        
        private void btn_MAI2CReadAdrAPI_Click(object sender, EventArgs e)
        {
            lbl_MAI2CReadAdrAPI.BackColor = Color.White;
            Application.DoEvents();

            byte tempp=0;

            byte adr = (byte)Convert.ToInt32(txt_adr.Text, 16);
            if (BAWrapper.MAI2CReadAdrAPI(adr, ref tempp))
            {
                lbl_MAI2CReadAdrAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_MAI2CReadAdrAPI.BackColor = Color.Red;
            }

            txt_MAI2CReadAdrAPI.Text = tempp.ToString("X2");
        }

        private void btn_MAI2CReadAdrAPI2_Click(object sender, EventArgs e)
        {
            lbl_MAI2CReadAdrAPI2.BackColor = Color.White;
            Application.DoEvents();

            byte tempp = 0;

            byte adr = (byte)Convert.ToInt32(txt_adr2.Text, 16);
            if (BAWrapper2.MAI2CReadAdrAPI(adr, ref tempp))
            {
                lbl_MAI2CReadAdrAPI2.BackColor = Color.Lime;
            }
            else
            {
                lbl_MAI2CReadAdrAPI2.BackColor = Color.Red;
            }

            txt_MAI2CReadAdrAPI2.Text = tempp.ToString("X2");
        }

        private void btn_MAI2CReadArrayAdrAPI_Click(object sender, EventArgs e)
        {
            lbl_MAI2CReadArrayAdrAPI.BackColor = Color.White;
            Application.DoEvents();

            byte startAdr = (byte)Convert.ToInt32(txt_startAdr.Text, 16);
            byte endAdr = (byte)Convert.ToInt32(txt_endAdr.Text, 16);

            //byte[] val = new byte[256];
            //List<byte> add = new List<byte>();
            //for (int i = 0; i < 255 + 1; i++)
            //{
            //    add.Add((byte)i);
            //}

            byte[] val = new byte[256];
            byte[] valUp = new byte[256];

            List<byte> addLow = new List<byte>();
            for (int i = 0; i < 128; i++)
            {
                addLow.Add((byte)i);
            }

            List<byte> addUp = new List<byte>();
            for (int i = 128; i < 256; i++)
            {
                addUp.Add((byte)i);
            }


            try
            {
                //if (BAWrapper.MAI2CReadArrayAdrAPI(add.ToArray(), val, 255))
                //{
                //    lbl_MAI2CReadArrayAdrAPI.BackColor = Color.Lime;
                //}
                //else
                //{
                //    lbl_MAI2CReadArrayAdrAPI.BackColor = Color.Red;
                //}

                if (BAWrapper.MAI2CReadArrayAdrAPI(addLow.ToArray(), val, 128) | BAWrapper.MAI2CReadArrayAdrAPI(addUp.ToArray(), valUp, 128))
                {
                    lbl_MAI2CReadArrayAdrAPI.BackColor = Color.Lime;
                }
                else
                {
                    lbl_MAI2CReadArrayAdrAPI.BackColor = Color.Red;
                }
                this.Refresh();
                Thread.Sleep(50);


                for (int i = 128; i < 256; i++)
                {
                    val[i] = valUp[i - 128];
                }

                for (int i = 0; i < endAdr-startAdr+1; i++)
                {
                    dgvTableGrid[((startAdr+i) % 16) + 1, (i + startAdr) / 16].Value = val[startAdr+i].ToString("X2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btn_MAI2CReadArrayAdrAPI2_Click(object sender, EventArgs e)
        {
            lbl_MAI2CReadArrayAdrAPI2.BackColor = Color.White;
            Application.DoEvents();

            byte startAdr = (byte)Convert.ToInt32(txt_startAdr2.Text, 16);
            byte endAdr = (byte)Convert.ToInt32(txt_endAdr2.Text, 16);

            //byte[] val = new byte[256];
            //List<byte> add = new List<byte>();
            //for (int i = 0; i < 255 + 1; i++)
            //{
            //    add.Add((byte)i);
            //}

            byte[] val = new byte[256];
            byte[] valUp = new byte[256];

            List<byte> addLow = new List<byte>();
            for (int i = 0; i < 128; i++)
            {
                addLow.Add((byte)i);
            }

            List<byte> addUp = new List<byte>();
            for (int i = 128; i < 256; i++)
            {
                addUp.Add((byte)i);
            }


            try
            {
                //if (BAWrapper.MAI2CReadArrayAdrAPI(add.ToArray(), val, 255))
                //{
                //    lbl_MAI2CReadArrayAdrAPI.BackColor = Color.Lime;
                //}
                //else
                //{
                //    lbl_MAI2CReadArrayAdrAPI.BackColor = Color.Red;
                //}

                if (BAWrapper2.MAI2CReadArrayAdrAPI(addLow.ToArray(), val, 128) | BAWrapper2.MAI2CReadArrayAdrAPI(addUp.ToArray(), valUp, 128))
                {
                    lbl_MAI2CReadArrayAdrAPI2.BackColor = Color.Lime;
                }
                else
                {
                    lbl_MAI2CReadArrayAdrAPI2.BackColor = Color.Red;
                }
                this.Refresh();
                Thread.Sleep(50);


                for (int i = 128; i < 256; i++)
                {
                    val[i] = valUp[i - 128];
                }

                for (int i = 0; i < endAdr - startAdr + 1; i++)
                {
                    dgvTableGrid2[((startAdr + i) % 16) + 1, (i + startAdr) / 16].Value = val[startAdr + i].ToString("X2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btn_MAI2CWriteAdrAPI_Click(object sender, EventArgs e)
        {
            lbl_MAI2CWriteAdrAPI.BackColor = Color.White;
            Application.DoEvents();

            byte adr = (byte)Convert.ToInt32(txt_WAdr.Text, 16);
            byte val = (byte)Convert.ToInt32(txt_WVal.Text, 16);
            if (BAWrapper.MAI2CWriteAdrAPI(adr,val))
            {
                lbl_MAI2CWriteAdrAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_MAI2CWriteAdrAPI.BackColor = Color.Red;
            }
        }

        private void btn_MAI2CWriteAdrAPI2_Click(object sender, EventArgs e)
        {
            lbl_MAI2CWriteAdrAPI2.BackColor = Color.White;
            Application.DoEvents();

            byte adr = (byte)Convert.ToInt32(txt_WAdr2.Text, 16);
            byte val = (byte)Convert.ToInt32(txt_WVal2.Text, 16);
            if (BAWrapper2.MAI2CWriteAdrAPI(adr, val))
            {
                lbl_MAI2CWriteAdrAPI2.BackColor = Color.Lime;
            }
            else
            {
                lbl_MAI2CWriteAdrAPI2.BackColor = Color.Red;
            }
        }

        private void btn_MAI2CSpeedAPI_Click(object sender, EventArgs e)
        {
            lbl_MAI2CSpeedAPI.BackColor = Color.White;
            Application.DoEvents();

            if (BAWrapper.MAI2CSpeedAPI(byte.Parse(txt_MAI2CSpeedAPI.Text)))
            {
                lbl_MAI2CSpeedAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_MAI2CSpeedAPI.BackColor = Color.Red;
            }
        }

        private void btn_MAI2CWriteArrayAdrAPI_Click(object sender, EventArgs e)
        {
            if (txt_WvalArr.Text.Length%2 ==1)
            {
                MessageBox.Show("寫入值長度錯誤");
                return;
            }
            
            lbl_MAI2CWriteArrayAdrAPI.BackColor = Color.White;
            Application.DoEvents();

            List<byte> listAdr = new List<byte>();
            byte startnum = (byte)Convert.ToInt32(txt_WstartAdr.Text, 16);
            byte count = (byte)(txt_WvalArr.Text.Length / 2);

            List<byte> listVal = new List<byte>();

            for (byte i = 0; i < count; i++)
            {
                listAdr.Add((byte)(startnum+i));

                string vv = txt_WvalArr.Text.Substring(i*2, 2);
                listVal.Add((byte)Convert.ToInt32(vv, 16));
            }

            if (BAWrapper.MAI2CWriteArrayAdrAPI(listAdr.ToArray(), listVal.ToArray(), count))
            {
                lbl_MAI2CWriteArrayAdrAPI.BackColor = Color.Lime;
            }
            else
            {
                lbl_MAI2CWriteArrayAdrAPI.BackColor = Color.Red;
            }
        }

        private void btn_MAI2CWriteArrayAdrAPI2_Click(object sender, EventArgs e)
        {
            if (txt_WvalArr2.Text.Length % 2 == 1)
            {
                MessageBox.Show("寫入值長度錯誤");
                return;
            }

            lbl_MAI2CWriteArrayAdrAPI2.BackColor = Color.White;
            Application.DoEvents();

            List<byte> listAdr = new List<byte>();
            byte startnum = (byte)Convert.ToInt32(txt_WstartAdr2.Text, 16);
            byte count = (byte)(txt_WvalArr2.Text.Length / 2);

            List<byte> listVal = new List<byte>();

            for (byte i = 0; i < count; i++)
            {
                listAdr.Add((byte)(startnum + i));

                string vv = txt_WvalArr2.Text.Substring(i * 2, 2);
                listVal.Add((byte)Convert.ToInt32(vv, 16));
            }

            if (BAWrapper2.MAI2CWriteArrayAdrAPI(listAdr.ToArray(), listVal.ToArray(), count))
            {
                lbl_MAI2CWriteArrayAdrAPI2.BackColor = Color.Lime;
            }
            else
            {
                lbl_MAI2CWriteArrayAdrAPI2.BackColor = Color.Red;
            }
        }

        private void btn_satPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = fbd.SelectedPath;
            }

            btn_MAI2CReadAdrAPI_Click(sender, e);
        }

        private void btn_satPath2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txt_path2.Text = fbd.SelectedPath;
            }

            btn_MAI2CReadAdrAPI2_Click(sender, e);
        }

        private void btn_saveBin_Click(object sender, EventArgs e)
        {
            txt_adr.Text = "7F";
            Application.DoEvents();

            btn_MAI2CReadAdrAPI_Click(sender, e);

            string file = txt_path.Text + @"\" + txt_binName.Text + "_P" + txt_MAI2CReadAdrAPI.Text + "_" + DateTime.Now.ToString("yyyyMMdd") + ".bin";

            FileStream myFile = File.Open(file, FileMode.OpenOrCreate);
            BinaryWriter myWriter = new BinaryWriter(myFile);

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {

                    if (dgvTableGrid[j + 1, i].Value == null)
                    {
                        myWriter.Write((byte)255);
                    }
                    else
                    {
                        myWriter.Write((byte)Convert.ToInt32(dgvTableGrid[j + 1, i].Value.ToString(), 16));
                    }

                }
            }

            myWriter.Close();
            myFile.Close();
        }

        private void btn_saveBin2_Click(object sender, EventArgs e)
        {
            txt_adr2.Text = "7F";
            Application.DoEvents();

            btn_MAI2CReadAdrAPI2_Click(sender, e);

            string file = txt_path2.Text + @"\" + txt_binName2.Text + "_P" + txt_MAI2CReadAdrAPI2.Text + "_" + DateTime.Now.ToString("yyyyMMdd") + ".bin";

            FileStream myFile = File.Open(file, FileMode.OpenOrCreate);
            BinaryWriter myWriter = new BinaryWriter(myFile);

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {

                    if (dgvTableGrid2[j + 1, i].Value == null)
                    {
                        myWriter.Write((byte)255);
                    }
                    else
                    {
                        myWriter.Write((byte)Convert.ToInt32(dgvTableGrid2[j + 1, i].Value.ToString(), 16));
                    }

                }
            }

            myWriter.Close();
            myFile.Close();
        }

        private void btn_ReadBERResultAPI_Click(object sender, EventArgs e)
        {
            lbl_ReadBERResultAPI.BackColor = Color.White;
            txt_ReadBERResultAPI.Text = "";
            lbl_ReadBERResultAPI.Refresh();
            Thread.Sleep(500);

            if (BAWrapper.ReadBERResultAPI(ref captureTimeIns, patternTX, rxPatternLSB, rxLockMSB, rxLockLSB, rxLock, rxInvertMSB, rxInvertLSB, bertErrorCountMSB, bertErrorCountLSB, bertErrorCount, bertBitCount, realTimer, bertValue, fecCOR, fecBertValues, fecResults))
            {
                lbl_ReadBERResultAPI.BackColor = Color.Lime;

                for (int i = 1; i < 9; i++)
                {
                    txt_ReadBERResultAPI.Text += "Ch" + i + " = " + realTimer[i] + "," + bertErrorCount[i] + "," + bertValue[i] + "," + bertBitCount[i];
                    txt_ReadBERResultAPI.Text += Environment.NewLine;
                }                
                
            }
            else
            {
                lbl_ReadBERResultAPI.BackColor = Color.Red;
            }
        }
    }
}
