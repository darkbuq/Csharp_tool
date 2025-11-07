using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FOE_YR
{
    interface IEEPROM
    {
    }

    public class CSFF8472
    {
        public byte[] _A0 = new byte[256];
        public byte[] _A2 = new byte[256];

        public void clear_A0to00()
        {
            for (int i = 0; i < _A0.Length; i++)
            {
                _A0[i] = 0;
            }
        }

        public void clear_A2to00()
        {
            for (int i = 0; i < _A2.Length; i++)
            {
                _A2[i] = 0;
            }
        }

        public static string HexStringToAscii(string hexString)
        {
            // Ensure the hex string has an even length
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException("Hex string must have an even length.");
            }

            // Convert hex string to byte array
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
            {
                string hexByte = hexString.Substring(i, 2);
                bytes[i / 2] = Convert.ToByte(hexByte, 16);
            }

            // Convert byte array to ASCII string
            return Encoding.ASCII.GetString(bytes);
        }

        public Tuple<string, byte[]> GetIdentifier()
        {
            int start_address = 0;
            string connStr = "Server=dataserver;Database=MFG_SN;User Id=sa;Password=dsc;";
            string sSql = $"Select * from [MFG_SN].[dbo].[EEPROMspec2] where [spec] ='SFF-8472 Rev 12.4' and [page_table] = 'A0' and [byte] = '{start_address.ToString("X2")}'";

            DataTable vDt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sSql, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(vDt);
                }
            }

            //DataTable vDt = MyOleAccess.getTableOnDB(sSql, "");

            string result = "";
            string[] allLines = vDt.Rows[0][5].ToString().Split('#');
            for (int i = 1; i < allLines.Length - 1; i++)
            {
                if (allLines[i].Substring(0, 2) == _A0[start_address].ToString("X2"))
                {
                    result = allLines[i].Split('_')[1];

                    break;
                }
            }

            byte[] arr = new byte[] { _A0[start_address] };

            return Tuple.Create(result, arr);
        }

        public Tuple<string, byte[]> GetConnector()
        {
            int start_address = 2;
            string connStr = "Server=dataserver;Database=MFG_SN;User Id=sa;Password=dsc;";
            string sSql = $"Select * from [MFG_SN].[dbo].[EEPROMspec2] where [spec] ='SFF-8472 Rev 12.4' and [page_table] = 'A0' and [byte] = '{start_address.ToString("X2")}'";

            DataTable vDt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sSql, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(vDt);
                }
            }
            //DataTable vDt = MyOleAccess.getTableOnDB(sSql, "");

            string result = "";
            string[] allLines = vDt.Rows[0][5].ToString().Split('#');
            for (int i = 1; i < allLines.Length - 1; i++)
            {
                if (allLines[i].Substring(0, 2) == _A0[start_address].ToString("X2"))
                {
                    result = allLines[i].Split('_')[1];

                    break;
                }
            }

            byte[] arr = new byte[] { _A0[start_address] };

            return Tuple.Create(result, arr);
        }

        public Tuple<string, byte[]> GetVN()
        {
            int start_address = 20;
            int byte_length = 16;

            string result = string.Empty;
            byte[] arr = new byte[byte_length];
            for (int i = 0; i < byte_length; i++)
            {
                arr[i] = _A0[start_address + i];
                result += HexStringToAscii(_A0[start_address + i].ToString("X2"));
            }

            return Tuple.Create(result, arr);
        }

        public string GetOUI()
        {
            int start_address = 37;
            int byte_length = 3;

            string result = string.Empty;
            for (int i = 0; i < byte_length; i++)
            {
                result += _A0[start_address + i].ToString("X2") + ",";
            }

            return result;
        }

        public Tuple<string, byte[]> GetPN()
        {
            int start_address = 40;
            int byte_length = 16;

            string result = string.Empty;
            byte[] arr = new byte[byte_length];
            for (int i = 0; i < byte_length; i++)
            {
                arr[i] = _A0[start_address + i];
                result += HexStringToAscii(_A0[start_address + i].ToString("X2"));
            }

            return Tuple.Create(result, arr);
        }

        public Tuple<string, byte[]> GetVRevision()
        {
            int start_address = 56;
            int byte_length = 4;

            string result = string.Empty;
            byte[] arr = new byte[byte_length];
            for (int i = 0; i < byte_length; i++)
            {
                arr[i] = _A0[start_address + i];
                result += HexStringToAscii(_A0[start_address + i].ToString("X2"));
            }

            return Tuple.Create(result, arr);
        }

        public Tuple<string, byte[]> GetSN()
        {
            int start_address = 68;
            int byte_length = 16;

            string result = string.Empty;
            byte[] arr = new byte[byte_length];
            for (int i = 0; i < byte_length; i++)
            {
                arr[i] = _A0[start_address + i];
                result += HexStringToAscii(_A0[start_address + i].ToString("X2"));
            }

            return Tuple.Create(result, arr);
        }

        public Tuple<string, byte[]> GetDC()
        {
            int start_address = 84;
            int byte_length = 8;

            string result = string.Empty;
            byte[] arr = new byte[byte_length];
            for (int i = 0; i < byte_length; i++)
            {
                arr[i] = _A0[start_address + i];
                result += HexStringToAscii(_A0[start_address + i].ToString("X2"));
            }

            return Tuple.Create(result, arr);
        }

        public short Cal_Sum(byte[] table, int start, int end)
        {
            Int64 Allsum = 0;
            for (int i = start; i <= end; i++)//20240628 wen 修正=號
            {
                Allsum += table[i];
            }
            short shortCalcChecksum = (short)(Allsum &= 0xFF);

            return shortCalcChecksum;
        }

        public short A0_Sum1()
        {
            return Cal_Sum(_A0, 0, 62);
        }

        public short A0_Sum2()
        {
            return Cal_Sum(_A0, 64, 94);
        }

        public short A2_Sum()
        {
            return Cal_Sum(_A2, 0, 94);
        }

        public int HexStr_TwoComplement_Int(string HexStr)
        {
            int result;

            string binaryStr = Convert.ToString(Convert.ToInt64(HexStr, 16), 2).PadLeft(HexStr.Length * 4, '0');

            if (binaryStr[0] == '1')
            {
                string revertBinary = "";
                foreach (var item in binaryStr)
                {
                    if (item == '1')
                    {
                        revertBinary += "0";
                    }
                    else
                    {
                        revertBinary += "1";
                    }
                }
                result = (Convert.ToInt32(revertBinary, 2) + 1) * (-1);

            }
            else
            {
                result = Convert.ToInt32(binaryStr, 2);
            }

            return result;
        }

        public float Calculate_T(string MsbLsb)
        {
            //Internally measured temperature: signed 2’s
            //complement in 1 / 256 degree Celsius increments
            //NOTE: Temp can be below 0.

            float gg = (float)HexStr_TwoComplement_Int(MsbLsb);
            return (gg / 256);
        }

        public double Calculate_Vcc(string MsbLsb)
        {
            return ((double)Convert.ToInt32(MsbLsb, 16)) / 10000;
        }

        public double Calculate_Bias(string MsbLsb)
        {
            return ((double)Convert.ToInt32(MsbLsb, 16)) / 500;
        }

        public double Calculate_Txpwr_dBm(string MsbLsb)
        {
            //2個Hex 範圍0~65536 一格為 0.1uW
            //65535 = 65535*0.1uW = 65535*0.1*0.001mW

            double mW = (double)Convert.ToInt32(MsbLsb, 16) / 10000;
            double dBm = 10 * Math.Log10(mW);

            if (dBm < -40)
            {
                dBm = -40;
            }

            return dBm;
        }

        public double Calculate_Rxpwr_dBm(string MsbLsb)
        {
            //2個Hex 範圍0~65536 一格為 0.1uW
            //65535 = 65535*0.1uW = 65535*0.1*0.001mW

            double mW = (double)Convert.ToInt32(MsbLsb, 16) / 10000;
            double dBm = 10 * Math.Log10(mW);

            if (dBm < -40)
            {
                dBm = -40;
            }

            return dBm;
        }

        public double[] GetDDMI_T()//High Alarm, Low Alarm, High Warning, Low Warning
        {
            int start_add = 0;

            double[] temp = new double[4];
            for (int i = 0; i < 4; i++)
            {
                int add = start_add + i * 2;
                temp[i] = Calculate_T(_A2[add].ToString("X2") + _A2[add + 1].ToString("X2"));
            }

            return temp;
        }

        public double[] GetDDMI_V()//High Alarm, Low Alarm, High Warning, Low Warning
        {
            int start_add = 8;

            double[] temp = new double[4];
            for (int i = 0; i < 4; i++)
            {
                int add = start_add + i * 2;
                temp[i] = Calculate_Vcc(_A2[add].ToString("X2") + _A2[add + 1].ToString("X2"));
            }

            return temp;
        }

        public double[] GetDDMI_Bias()//High Alarm, Low Alarm, High Warning, Low Warning
        {
            int start_add = 16;

            double[] temp = new double[4];
            for (int i = 0; i < 4; i++)
            {
                int add = start_add + i * 2;
                temp[i] = Calculate_Bias(_A2[add].ToString("X2") + _A2[add + 1].ToString("X2"));
            }

            return temp;
        }

        public double[] GetDDMI_TxP()//High Alarm, Low Alarm, High Warning, Low Warning
        {
            int start_add = 24;

            double[] temp = new double[4];
            for (int i = 0; i < 4; i++)
            {
                int add = start_add + i * 2;
                temp[i] = Calculate_Txpwr_dBm(_A2[add].ToString("X2") + _A2[add + 1].ToString("X2"));
            }

            return temp;
        }

        public double[] GetDDMI_RxP()//High Alarm, Low Alarm, High Warning, Low Warning
        {
            int start_add = 32;

            double[] temp = new double[4];
            for (int i = 0; i < 4; i++)
            {
                int add = start_add + i * 2;
                temp[i] = Calculate_Rxpwr_dBm(_A2[add].ToString("X2") + _A2[add + 1].ToString("X2"));
            }

            return temp;
        }
    }

    public class CSFF8472toUI
    {
        public void SetUI_Identifier(CSFF8472 sff8472, TextBox txt)
        {
            sff8472.GetIdentifier();

            txt.Text = sff8472.GetIdentifier().Item1;
            if (sff8472.GetIdentifier().Item2[0].ToString("X2") != "03")
            {
                txt.BackColor = Color.Pink;
            }
            else
            {
                txt.BackColor = Color.Empty;
            }
        }

        public void SetUI_Connector(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.GetConnector().Item1;
        }

        public void SetUI_VN(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.GetVN().Item1;

            bool error = true;
            for (int i = 0; i < sff8472.GetVN().Item2.Length; i++)
            {
                if (sff8472.GetVN().Item2[i] == 0)
                {
                    error &= false;
                }
            }

            if (error)
            {
                txt.BackColor = Color.Empty;
            }
            else
            {
                txt.BackColor = Color.Pink;
            }
        }

        public void SetUI_OUI(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.GetOUI();
        }

        public void SetUI_PN(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.GetPN().Item1;

            bool error = true;
            for (int i = 0; i < sff8472.GetPN().Item2.Length; i++)
            {
                if (sff8472.GetPN().Item2[i] == 0)
                {
                    error &= false;
                }
            }

            if (error)
            {
                txt.BackColor = Color.Empty;
            }
            else
            {
                txt.BackColor = Color.Pink;
            }
        }

        public void SetUI_VRevision(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.GetVRevision().Item1;

            bool error = true;
            for (int i = 0; i < sff8472.GetVRevision().Item2.Length; i++)
            {
                if (sff8472.GetVRevision().Item2[i] == 0)
                {
                    error &= false;
                }
            }

            if (error)
            {
                txt.BackColor = Color.Empty;
            }
            else
            {
                txt.BackColor = Color.Pink;
            }
        }

        public void SetUI_SN(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.GetSN().Item1;

            bool error = true;
            for (int i = 0; i < sff8472.GetSN().Item2.Length; i++)
            {
                if (sff8472.GetSN().Item2[i] == 0)
                {
                    error &= false;
                }
            }

            if (error)
            {
                txt.BackColor = Color.Empty;
            }
            else
            {
                txt.BackColor = Color.Pink;
            }
        }

        public void SetUI_DC(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.GetDC().Item1;

            bool error = true;
            for (int i = 0; i < sff8472.GetDC().Item2.Length; i++)
            {
                if (sff8472.GetDC().Item2[i] == 0)
                {
                    error &= false;
                }
            }

            if (error)
            {
                txt.BackColor = Color.Empty;
            }
            else
            {
                txt.BackColor = Color.Pink;
            }
        }

        public void SetUI_A0_sum1(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.A0_Sum1().ToString("X2");
            if (sff8472.A0_Sum1() == sff8472._A0[63])
            {
                txt.BackColor = Color.PaleGreen;
            }
            else
            {
                txt.BackColor = Color.Pink;
            }
        }

        public void SetUI_A0_sum2(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.A0_Sum2().ToString("X2");
            if (sff8472.A0_Sum2() == sff8472._A0[95])
            {
                txt.BackColor = Color.PaleGreen;
            }
            else
            {
                txt.BackColor = Color.Pink;
            }
        }

        public void SetUI_A2_sum(CSFF8472 sff8472, TextBox txt)
        {
            txt.Text = sff8472.A2_Sum().ToString("X2");
            if (sff8472.A2_Sum() == sff8472._A2[95])
            {
                txt.BackColor = Color.PaleGreen;
            }
            else
            {
                txt.BackColor = Color.Pink;
            }
        }

        public void SetUI_DDMI_T(CSFF8472 sff8472, DataGridView dgv)
        {
            var arr = sff8472.GetDDMI_T();
            for (int i = 0; i < 4; i++)
            {
                dgv.Rows[0].Cells[i + 1].Value = arr[i].ToString("0.00");
            }
        }

        public void SetUI_DDMI_V(CSFF8472 sff8472, DataGridView dgv)
        {
            var arr = sff8472.GetDDMI_V();
            for (int i = 0; i < 4; i++)
            {
                dgv.Rows[1].Cells[i + 1].Value = arr[i].ToString("0.00");
            }
        }

        public void SetUI_DDMI_Bias(CSFF8472 sff8472, DataGridView dgv)
        {
            var arr = sff8472.GetDDMI_Bias();
            for (int i = 0; i < 4; i++)
            {
                dgv.Rows[2].Cells[i + 1].Value = arr[i].ToString("0.00");
            }
        }

        public void SetUI_DDMI_RxP(CSFF8472 sff8472, DataGridView dgv)
        {
            var arr = sff8472.GetDDMI_RxP();
            for (int i = 0; i < 4; i++)
            {
                dgv.Rows[3].Cells[i + 1].Value = arr[i].ToString("0.00");
            }
        }

        public void SetUI_DDMI_TxP(CSFF8472 sff8472, DataGridView dgv)
        {
            var arr = sff8472.GetDDMI_TxP();
            for (int i = 0; i < 4; i++)
            {
                dgv.Rows[4].Cells[i + 1].Value = arr[i].ToString("0.00");
            }
        }
    }

    public class C_CMIS
    {
        public byte[] A0L = new byte[128];
        public byte[] P00 = new byte[128];  // Vendor Info
        public byte[] P01 = new byte[128];  // Module Capability
        public byte[] P02 = new byte[128];  // Alarm Warning Info


        public byte[] B00P10 = new byte[128];
        public byte[] B00P11 = new byte[128];


        EEPROM_calcualate eeprom_cal = new EEPROM_calcualate();

        I_Script_Interpreter script = null;

        public C_CMIS(I_Script_Interpreter script)
        {
            this.script = script;
        }

        public void Update_CMISpage(int delay_time)
        {
            //A0L
            A0L = script.Readpage_128byte("00");
            Thread.Sleep(delay_time);

            //P00
            ChangePage("00", "00", script, delay_time);
            P00 = script.Readpage_128byte("80");
            Thread.Sleep(delay_time);

            //P01
            ChangePage("00", "01", script, delay_time);
            P01 = script.Readpage_128byte("80");
            Thread.Sleep(delay_time);

            //P02
            ChangePage("00", "02", script, delay_time);
            P02 = script.Readpage_128byte("80");
            Thread.Sleep(delay_time);

            //B00P10
            ChangePage("00", "10", script, delay_time);
            B00P10 = script.Readpage_128byte("80");
            Thread.Sleep(delay_time);

            //B00P11
            ChangePage("00", "11", script, delay_time);
            B00P11 = script.Readpage_128byte("80");
            Thread.Sleep(delay_time);
        }

        private void ChangePage(string bank, string page, I_Script_Interpreter script, int delay_time)
        {
            script.RunScript($"ssA07E{bank}{page}");
            Thread.Sleep(delay_time);

            var temp = script.RunScript("ggA07E02").Split(' ');

            if (temp[0] != bank)
            {
                throw new Exception($"bank={bank}h 錯誤");
            }

            if (temp[1] != page)
            {
                throw new Exception($"page={page}h 錯誤");
            }
        }

        public double EEPROM_real_T(byte[] A0L)
        {
            int add = 14;
            double val = eeprom_cal.MsbLsb_T(A0L[add].ToString("X2") + A0L[add + 1].ToString("X2"));

            return val;
        }        

        public double EEPROM_real_Vcc(byte[] A0L)
        {
            int add = 16;
            double val = eeprom_cal.MsbLsb_Vcc(A0L[add].ToString("X2") + A0L[add + 1].ToString("X2"));

            return val;
        }        

        public double[] EEPROM_real_Bias(byte[] B00P11)
        {
            double[] val = new double[8];
            for (int i = 0; i < 8; i++)
            {
                int add = 170 + i * 2 - 128;
                val[i] = eeprom_cal.MsbLsb_Bias(B00P11[add].ToString("X2") + B00P11[add + 1].ToString("X2"));
            }
            return val;
        }        

        public double[] EEPROM_Txpwr_dBm(byte[] B00P11)
        {
            double[] val = new double[8];
            for (int i = 0; i < 8; i++)
            {
                int add = 154 + i * 2 - 128;
                val[i] = eeprom_cal.MsbLsb_TxRxPwr_dBm(B00P11[add].ToString("X2") + B00P11[add + 1].ToString("X2"));
            }
            return val;
        }               

        public double[] EEPROM_Rxpwr_dBm(byte[] B00P11)
        {
            double[] val = new double[8];
            for (int i = 0; i < 8; i++)
            {
                int add = 186 + i * 2 - 128;
                val[i] = eeprom_cal.MsbLsb_TxRxPwr_dBm(B00P11[add].ToString("X2") + B00P11[add + 1].ToString("X2"));
            }
            return val;
        }

        public void SetSN(string new_SN)
        {
            EEPROM_calcualate EEPROM_calcualate = new EEPROM_calcualate();

            string asciiString = new_SN.Trim().PadRight(16);
            string result = EEPROM_calcualate.AsciiToHex(asciiString);


            for (int i = 0; i < 16; i++)
            {
                P00[i + 166 - 128] = Convert.ToByte(result.Substring(i * 2, 2), 16);
            }
        }

        public (double realval, double alarmL, double alarmH, double warningL, double warningH, bool[] flag) GetTemp()
        {
            int add = 14;
            double realval = eeprom_cal.MsbLsb_T(A0L[add].ToString("X2") + A0L[add + 1].ToString("X2"));

            add = 130-128;
            double alarmL = eeprom_cal.MsbLsb_T(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 128-128;
            double alarmH = eeprom_cal.MsbLsb_T(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 134-128;
            double warningL = eeprom_cal.MsbLsb_T(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 132-128;
            double warningH = eeprom_cal.MsbLsb_T(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 9;
            bool[] flag = new bool[4];
            flag[0] = ((A0L[add] >> 1) & 1) == 1;  //bit1 = AlarmL
            flag[1] = ((A0L[add]) & 1) == 1;  //bit0 = AlarmH
            flag[2] = ((A0L[add] >> 3) & 1) == 1;  //bit3 = WarningL
            flag[3] = ((A0L[add] >> 2) & 1) == 1;  //bit2 = WarningH

            return (realval, alarmL, alarmH, warningL, warningH, flag);
        }

        public (double realval, double alarmL, double alarmH, double warningL, double warningH, bool[] flag) GetVcc()
        {
            int add = 16;
            double realval = eeprom_cal.MsbLsb_Vcc(A0L[add].ToString("X2") + A0L[add + 1].ToString("X2"));

            add = 138 - 128;
            double alarmL = eeprom_cal.MsbLsb_Vcc(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 136 - 128;
            double alarmH = eeprom_cal.MsbLsb_Vcc(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 142 - 128;
            double warningL = eeprom_cal.MsbLsb_Vcc(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 140 - 128;
            double warningH = eeprom_cal.MsbLsb_Vcc(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 9;
            bool[] flag = new bool[4];
            flag[0] = ((A0L[add] >> 5) & 1) == 1;  //bit5 = AlarmL
            flag[1] = ((A0L[add] >> 4) & 1) == 1;  //bit4 = AlarmH
            flag[2] = ((A0L[add] >> 7) & 1) == 1;  //bit7 = WarningL
            flag[3] = ((A0L[add] >> 6) & 1) == 1;  //bit6 = WarningH

            return (realval, alarmL, alarmH, warningL, warningH, flag);
        }

        public (double[] realval, double alarmL, double alarmH, double warningL, double warningH, List<bool[]> flagList_AWLH_ch) GetBias()
        {
            double[] realval = new double[8];
            int add = 170;
            for (int i = 0; i < 8; i++)
            {
                string MSB = B00P11[(add + i * 2) - 128].ToString("X2");
                string LSB = B00P11[(add + i * 2) - 128 + 1].ToString("X2");
                realval[i] = eeprom_cal.MsbLsb_Bias($"{MSB}{LSB}");
            }


            add = 186 - 128;
            double alarmL = eeprom_cal.MsbLsb_Bias(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 184 - 128;
            double alarmH = eeprom_cal.MsbLsb_Bias(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 190 - 128;
            double warningL = eeprom_cal.MsbLsb_Bias(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 188 - 128;
            double warningH = eeprom_cal.MsbLsb_Bias(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));



            //AlarmL  AlarmH  WarningL  WarningH

            List<bool[]> flagList = new List<bool[]>();

            int[] add_arr = new int[] { 144, 143, 146, 145 };

            for (int i = 0; i < 4; i++)
            {
                add = add_arr[i] - 128;
                bool[] flag = new bool[8];
                for (int ch = 0; ch < 8; ch++)
                {
                    flag[ch] = ((B00P11[add] >> ch) & 1) == 1;  //AlarmL
                }
                flagList.Add(flag);
            }

            return (realval, alarmL, alarmH, warningL, warningH, flagList);
        }

        public (double[] realval, double alarmL, double alarmH, double warningL, double warningH, List<bool[]> flagList_AWLH_ch) GetTxP()
        {
            double[] realval = new double[8];
            int add = 154;
            for (int i = 0; i < 8; i++)
            {
                string MSB = B00P11[(add + i * 2) - 128].ToString("X2");
                string LSB = B00P11[(add + i * 2) - 128 + 1].ToString("X2");
                realval[i] = eeprom_cal.MsbLsb_TxRxPwr_dBm($"{MSB}{LSB}");
            }


            add = 178 - 128;
            double alarmL = eeprom_cal.MsbLsb_TxRxPwr_dBm(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 176 - 128;
            double alarmH = eeprom_cal.MsbLsb_TxRxPwr_dBm(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 182 - 128;
            double warningL = eeprom_cal.MsbLsb_TxRxPwr_dBm(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 180 - 128;
            double warningH = eeprom_cal.MsbLsb_TxRxPwr_dBm(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));



            //AlarmL  AlarmH  WarningL  WarningH

            List<bool[]> flagList = new List<bool[]>();

            int[] add_arr = new int[] { 140, 139, 142, 141 };

            for (int i = 0; i < 4; i++)
            {
                add = add_arr[i] - 128;
                bool[] flag = new bool[8];
                for (int ch = 0; ch < 8; ch++)
                {
                    flag[ch] = ((B00P11[add] >> ch) & 1) == 1;  //AlarmL
                }
                flagList.Add(flag);
            }

            return (realval, alarmL, alarmH, warningL, warningH, flagList);
        }

        public (double[] realval, double alarmL, double alarmH, double warningL, double warningH, List<bool[]> flagList_AWLH_ch) GetRxP()
        {
            double[] realval = new double[8];
            int add = 186;
            for (int i = 0; i < 8; i++)
            {
                string MSB = B00P11[(add + i * 2) - 128].ToString("X2");
                string LSB = B00P11[(add + i * 2) - 128 + 1].ToString("X2");
                realval[i] = eeprom_cal.MsbLsb_TxRxPwr_dBm($"{MSB}{LSB}");
            }


            add = 194 - 128;
            double alarmL = eeprom_cal.MsbLsb_TxRxPwr_dBm(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 192 - 128;
            double alarmH = eeprom_cal.MsbLsb_TxRxPwr_dBm(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 198 - 128;
            double warningL = eeprom_cal.MsbLsb_TxRxPwr_dBm(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));

            add = 196 - 128;
            double warningH = eeprom_cal.MsbLsb_TxRxPwr_dBm(P02[add].ToString("X2") + P02[add + 1].ToString("X2"));



            //AlarmL  AlarmH  WarningL  WarningH

            List<bool[]> flagList = new List<bool[]>();

            int[] add_arr = new int[] { 150, 149, 152, 151 };

            for (int i = 0; i < 4; i++)
            {
                add = add_arr[i] - 128;
                bool[] flag = new bool[8];
                for (int ch = 0; ch < 8; ch++)
                {
                    flag[ch] = ((B00P11[add] >> ch) & 1) == 1;  //AlarmL
                }
                flagList.Add(flag);
            }

            return (realval, alarmL, alarmH, warningL, warningH, flagList);
        }

        public (bool[] RxLOS, bool[] RxLOL) GetRx_LOS_LOL()
        {
            bool[] LOS = new bool[8];
            for (int ch = 0; ch < 8; ch++)
            {
                LOS[ch] = ((B00P11[147 - 128] >> ch) & 1) == 1;
            }

            bool[] LOL = new bool[8];
            for (int ch = 0; ch < 8; ch++)
            {
                LOL[ch] = ((B00P11[148 - 128] >> ch) & 1) == 1;
            }

            return (LOS, LOL);
        }

        public (bool[] TxLOS, bool[] TxLOL) GetTx_LOS_LOL()
        {
            bool[] LOS = new bool[8];
            for (int ch = 0; ch < 8; ch++)
            {
                LOS[ch] = ((B00P11[136 - 128] >> ch) & 1) == 1;
            }

            bool[] LOL = new bool[8];
            for (int ch = 0; ch < 8; ch++)
            {
                LOL[ch] = ((B00P11[137 - 128] >> ch) & 1) == 1;
            }

            return (LOS, LOL);
        }
    }

    public class C_SFF8636
    {
        public byte[] A0L = new byte[128];  

        public byte[] P00 = new byte[128];  // Module Capability
        public byte[] P03 = new byte[128];  // Alarm Warning Info

        EEPROM_calcualate eeprom_cal = new EEPROM_calcualate();

        public void getTemp(out double RealTemp, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealTemp = eeprom_cal.MsbLsb_T(A0L[22].ToString("X2") + A0L[23].ToString("X2"));//需要刷新機制

            AlarmH = eeprom_cal.MsbLsb_T(P03[128-128].ToString("X2") + P03[129-128].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_T(P03[130 - 128].ToString("X2") + P03[131 - 128].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_T(P03[132 - 128].ToString("X2") + P03[133 - 128].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_T(P03[134 - 128].ToString("X2") + P03[135 - 128].ToString("X2"));
        }

        public void getVolt(out double RealVolt, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealVolt = eeprom_cal.MsbLsb_Vcc(A0L[26].ToString("X2") + A0L[27].ToString("X2"));//需要刷新機制

            AlarmH = eeprom_cal.MsbLsb_Vcc(P03[144 - 128].ToString("X2") + P03[145 - 128].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_Vcc(P03[146 - 128].ToString("X2") + P03[147 - 128].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_Vcc(P03[148 - 128].ToString("X2") + P03[149 - 128].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_Vcc(P03[150 - 128].ToString("X2") + P03[151 - 128].ToString("X2"));
        }

        public void getBias(out double[] RealBias, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealBias = new double[4];
            int RealBias_start = 42;
            for (int i = 0; i < 4; i++)
            {
                int MSB = RealBias_start + i * 2;
                int LSB = RealBias_start + i * 2 + 1;

                RealBias[i] = eeprom_cal.MsbLsb_Bias(A0L[MSB].ToString("X2") + A0L[LSB].ToString("X2"));//需要刷新機制
            }

            AlarmH = eeprom_cal.MsbLsb_Bias(P03[184 - 128].ToString("X2") + P03[185 - 128].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_Bias(P03[186 - 128].ToString("X2") + P03[187 - 128].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_Bias(P03[188 - 128].ToString("X2") + P03[189 - 128].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_Bias(P03[190 - 128].ToString("X2") + P03[191 - 128].ToString("X2"));
        }

        public void getTxP(out double[] RealTxP, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealTxP = new double[4];
            int RealBias_start = 50;
            for (int i = 0; i < 4; i++)
            {
                int MSB = RealBias_start + i * 2;
                int LSB = RealBias_start + i * 2 + 1;

                RealTxP[i] = eeprom_cal.MsbLsb_TxRxPwr_dBm(A0L[MSB].ToString("X2") + A0L[LSB].ToString("X2"));//需要刷新機制
            }

            AlarmH = eeprom_cal.MsbLsb_TxRxPwr_dBm(P03[192 - 128].ToString("X2") + P03[193 - 128].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_TxRxPwr_dBm(P03[194 - 128].ToString("X2") + P03[195 - 128].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_TxRxPwr_dBm(P03[196 - 128].ToString("X2") + P03[197 - 128].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_TxRxPwr_dBm(P03[198 - 128].ToString("X2") + P03[199 - 128].ToString("X2"));
        }

        public void getRxP(out double[] RealRxP, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealRxP = new double[4];
            int RealBias_start = 34;
            for (int i = 0; i < 4; i++)
            {
                int MSB = RealBias_start + i * 2;
                int LSB = RealBias_start + i * 2 + 1;

                RealRxP[i] = eeprom_cal.MsbLsb_TxRxPwr_dBm(A0L[MSB].ToString("X2") + A0L[LSB].ToString("X2"));//需要刷新機制
            }

            AlarmH = eeprom_cal.MsbLsb_TxRxPwr_dBm(P03[176 - 128].ToString("X2") + P03[177 - 128].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_TxRxPwr_dBm(P03[178 - 128].ToString("X2") + P03[179 - 128].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_TxRxPwr_dBm(P03[180 - 128].ToString("X2") + P03[181 - 128].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_TxRxPwr_dBm(P03[182 - 128].ToString("X2") + P03[183 - 128].ToString("X2"));
        }

        public bool getCCBASE(out byte correct_checksum)
        {
            correct_checksum = eeprom_cal.Cal_checksum(P00, 128-128, 190-128);
            byte real_checksum = P00[191-128];

            if (correct_checksum == real_checksum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool getCCEXT(out byte correct_checksum)
        {
            correct_checksum = eeprom_cal.Cal_checksum(P00, 192-128, 222-128);
            byte real_checksum = P00[223-128];

            if (correct_checksum == real_checksum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getVN()
        {
            byte[] target = P00.Skip(148-128).Take(16).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getPN()
        {
            byte[] target = P00.Skip(168 - 128).Take(16).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getOUI()
        {
            byte[] target = P00.Skip(165 - 128).Take(3).ToArray();

            string hexString = string.Join(" ", target.Select(b => b.ToString("X2")));

            return hexString;
        }

        public string getSN()
        {
            byte[] target = P00.Skip(196 - 128).Take(16).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getDC()
        {
            byte[] target = P00.Skip(212 - 128).Take(8).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getVver()
        {
            byte[] target = P00.Skip(184 - 128).Take(2).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getVver_hexstring()
        {
            byte[] target = P00.Skip(184 - 128).Take(2).ToArray();

            string hexString = string.Join(" ", target.Select(b => b.ToString("X2")));

            return hexString;
        }
    }

    public class C_SFF8472
    {
        public byte[] A0 = new byte[256];
        public byte[] A2 = new byte[256];

        EEPROM_calcualate eeprom_cal = new EEPROM_calcualate();

        public void getTemp(out double RealTemp, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealTemp = eeprom_cal.MsbLsb_T(A2[96].ToString("X2") + A2[97].ToString("X2"));//需要刷新機制

            AlarmH = eeprom_cal.MsbLsb_T(A2[0].ToString("X2") + A2[1].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_T(A2[2].ToString("X2") + A2[3].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_T(A2[4].ToString("X2") + A2[5].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_T(A2[6].ToString("X2") + A2[7].ToString("X2"));
        }

        public void getVolt(out double RealVolt, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealVolt = eeprom_cal.MsbLsb_Vcc(A2[98].ToString("X2") + A2[99].ToString("X2"));//需要刷新機制

            AlarmH = eeprom_cal.MsbLsb_Vcc(A2[8].ToString("X2") + A2[9].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_Vcc(A2[10].ToString("X2") + A2[11].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_Vcc(A2[12].ToString("X2") + A2[13].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_Vcc(A2[14].ToString("X2") + A2[15].ToString("X2"));
        }

        public void getBias(out double RealBias, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealBias = eeprom_cal.MsbLsb_Vcc(A2[100].ToString("X2") + A2[101].ToString("X2"));//需要刷新機制

            AlarmH = eeprom_cal.MsbLsb_Bias(A2[16].ToString("X2") + A2[17].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_Bias(A2[18].ToString("X2") + A2[19].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_Bias(A2[20].ToString("X2") + A2[21].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_Bias(A2[22].ToString("X2") + A2[23].ToString("X2"));
        }

        public void getTxP(out double RealTxP, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealTxP = eeprom_cal.MsbLsb_Vcc(A2[102].ToString("X2") + A2[103].ToString("X2"));//需要刷新機制

            AlarmH = eeprom_cal.MsbLsb_TxRxPwr_dBm(A2[24].ToString("X2") + A2[25].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_TxRxPwr_dBm(A2[26].ToString("X2") + A2[27].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_TxRxPwr_dBm(A2[28].ToString("X2") + A2[29].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_TxRxPwr_dBm(A2[30].ToString("X2") + A2[31].ToString("X2"));
        }

        public void getRxP(out double RealRxP, out double AlarmH, out double AlarmL, out double WarnH, out double WarnL)
        {
            RealRxP = eeprom_cal.MsbLsb_Vcc(A2[104].ToString("X2") + A2[105].ToString("X2"));//需要刷新機制

            AlarmH = eeprom_cal.MsbLsb_TxRxPwr_dBm(A2[32].ToString("X2") + A2[33].ToString("X2"));
            AlarmL = eeprom_cal.MsbLsb_TxRxPwr_dBm(A2[34].ToString("X2") + A2[35].ToString("X2"));
            WarnH = eeprom_cal.MsbLsb_TxRxPwr_dBm(A2[36].ToString("X2") + A2[37].ToString("X2"));
            WarnL = eeprom_cal.MsbLsb_TxRxPwr_dBm(A2[38].ToString("X2") + A2[39].ToString("X2"));
        }

        public bool getCCBASE(out byte correct_checksum)
        {
            correct_checksum = eeprom_cal.Cal_checksum(A0, 0, 62);
            byte real_checksum = A0[63];

            if (correct_checksum == real_checksum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool getCCEXT(out byte correct_checksum)
        {
            correct_checksum = eeprom_cal.Cal_checksum(A0, 64, 94);
            byte real_checksum = A0[95];

            if (correct_checksum == real_checksum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool getCCDMI(out byte correct_checksum)
        {
            correct_checksum = eeprom_cal.Cal_checksum(A2, 0, 94);
            byte real_checksum = A2[95];

            if (correct_checksum == real_checksum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getVN()
        {
            byte[] target = A0.Skip(20).Take(16).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getPN()
        {
            byte[] target = A0.Skip(40).Take(16).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getOUI()
        {
            byte[] target = A0.Skip(37).Take(3).ToArray();

            string hexString = string.Join(" ", target.Select(b => b.ToString("X2")));

            return hexString;
        }

        public string getSN()
        {
            byte[] target = A0.Skip(68).Take(16).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getDC()
        {
            byte[] target = A0.Skip(84).Take(8).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getVver()
        {
            byte[] target = A0.Skip(56).Take(4).ToArray();

            // 轉成 ASCII 字串
            string result = System.Text.Encoding.ASCII.GetString(target);

            //// 移除尾端的 null 或空白（常見於固定長度的 ASCII 區）
            //return vendorName.TrimEnd('\0', ' ');

            return result;
        }

        public string getVver_hexstring()
        {
            byte[] target = A0.Skip(56).Take(4).ToArray();

            string hexString = string.Join(" ", target.Select(b => b.ToString("X2")));

            return hexString;
        }
    }

    public class EEPROM_calcualate
    {
        public double MsbLsb_T(string MsbLsb)
        {
            //Internally measured temperature: signed 2’s
            //complement in 1 / 256 degree Celsius increments
            //NOTE: Temp can be below 0.

            Twos_complement Twos_complement = new Twos_complement();
            double gg = (double)Twos_complement.HexStr_TwoComplement_Int(MsbLsb);
            return (gg / 256);
        }

        public double MsbLsb_Vcc(string MsbLsb)
        {
            return ((float)Convert.ToInt32(MsbLsb, 16)) / 10000;
        }

        public double MsbLsb_Bias(string MsbLsb)
        {
            return ((float)Convert.ToInt32(MsbLsb, 16)) * 0.002;  //每單位是 2 µA = 0.002 mA
        }

        public double MsbLsb_TxRxPwr_dBm(string MsbLsb)
        {
            //2個Hex 範圍0~65536 一格為 0.1uW
            //65535 = 65535*0.1uW = 65535*0.1*0.001mW

            double mW = (double)Convert.ToInt32(MsbLsb, 16) / 10000;
            double dBm = 10 * Math.Log10(mW);

            if (dBm < -40)
            {
                dBm = -40;
            }

            return dBm;
        }

        public byte Cal_checksum(byte[] data, int start_byte, int end_byte)
        {
            byte checksum = 0;

            // 邊界檢查
            if (data == null || start_byte < 0 || end_byte >= data.Length || start_byte > end_byte)
                throw new ArgumentException("Invalid range or data");

            for (int i = start_byte; i <= end_byte; i++)
            {
                checksum += data[i]; // 或用 ^= data[i]; 做 XOR checksum
            }

            return checksum;
        }

        public static string AsciiToHex(string asciiString)
        {
            StringBuilder hex = new StringBuilder();

            foreach (char c in asciiString)
            {
                hex.Append(((int)c).ToString("X2"));
            }

            return hex.ToString();
        }

        public static string HexToAscii(string hexStr)
        {
            // 去掉输入字符串中的所有空格
            hexStr = hexStr.Replace(" ", string.Empty);

            // 检查输入字符串长度是否为偶数
            if (hexStr.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid length of the hexadecimal string.");
            }

            // 创建一个 StringBuilder 来存储结果
            StringBuilder asciiStr = new StringBuilder(hexStr.Length / 2);

            // 逐个字节地将十六进制转换为字符
            for (int i = 0; i < hexStr.Length; i += 2)
            {
                // 解析两个十六进制字符为一个字节
                string hexByte = hexStr.Substring(i, 2);
                byte byteValue = Convert.ToByte(hexByte, 16);

                // 将字节转换为字符并附加到结果中
                asciiStr.Append((char)byteValue);
            }

            return asciiStr.ToString();
        }
    }
}
