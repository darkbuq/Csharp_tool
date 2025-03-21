using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
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

        //public C_CMIS(byte[] A0L, byte[] P00, byte[] P01, byte[] P02, byte[] B00P11)
        //{
        //    this.A0L = A0L;
        //    this.P00 = P00;
        //    this.P01 = P01;
        //    this.P02 = P02;
        //    this.B00P11 = B00P11;
        //}

        public double MsbLsb_T(string MsbLsb)
        {
            //Internally measured temperature: signed 2’s
            //complement in 1 / 256 degree Celsius increments
            //NOTE: Temp can be below 0.

            double gg = (double)HexStr_TwoComplement_Int(MsbLsb);
            return (gg / 256);
        }

        public double EEPROM_real_T(byte[] A0L)
        {
            int add = 14;
            double val = MsbLsb_T(A0L[add].ToString("X2") + A0L[add + 1].ToString("X2"));

            return val;
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

        public double MsbLsb_Vcc(string MsbLsb)
        {
            return ((float)Convert.ToInt32(MsbLsb, 16)) / 10000;
        }

        public double EEPROM_real_Vcc(byte[] A0L)
        {
            int add = 16;
            double val = MsbLsb_Vcc(A0L[add].ToString("X2") + A0L[add + 1].ToString("X2"));

            return val;
        }

        public double MsbLsb_Bias(string MsbLsb)
        {
            return ((float)Convert.ToInt32(MsbLsb, 16)) / 500;
        }

        public double[] EEPROM_real_Bias(byte[] B00P11)
        {
            double[] val = new double[8];
            for (int i = 0; i < 8; i++)
            {
                int add = 170 + i * 2 - 128;
                val[i] = MsbLsb_Bias(B00P11[add].ToString("X2") + B00P11[add + 1].ToString("X2"));
            }
            return val;
        }

        public double MsbLsb_Txpwr_dBm(string MsbLsb)
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

        public double[] EEPROM_Txpwr_dBm(byte[] B00P11)
        {
            double[] val = new double[8];
            for (int i = 0; i < 8; i++)
            {
                int add = 154 + i * 2 - 128;
                val[i] = MsbLsb_Txpwr_dBm(B00P11[add].ToString("X2") + B00P11[add + 1].ToString("X2"));
            }
            return val;
        }

        public double MsbLsb_Rxpwr_dBm(string MsbLsb)
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

        public double[] EEPROM_Rxpwr_dBm(byte[] B00P11)
        {
            double[] val = new double[8];
            for (int i = 0; i < 8; i++)
            {
                int add = 186 + i * 2 - 128;
                val[i] = MsbLsb_Rxpwr_dBm(B00P11[add].ToString("X2") + B00P11[add + 1].ToString("X2"));
            }
            return val;
        }
    }
}
