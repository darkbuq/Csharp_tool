using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIS_DDM_YR
{
    public class CMIS_DDM_calculate
    {
        //自動建構子
        public enum SFF8636_DDMI
        {
            Temp_High_Alarm = 128,
            Temp_Low_Alarm = 130,
            Temp_High_Warning = 132,
            Temp_Low_Warning = 134,

            Vcc_High_Alarm = 144,
            Vcc_Low_Alarm = 146,
            Vcc_High_Warning = 148,
            Vcc_Low_Warning = 150,

            Rx_Power_High_Alarm = 176,
            Rx_Power_Low_Alarm = 178,
            Rx_Power_High_Warning = 180,
            Rx_Power_Low_Warning = 182,

            Tx_Bias_High_Alarm = 184,
            Tx_Bias_Low_Alarm = 186,
            Tx_Bias_High_Warning = 188,
            Tx_Bias_Low_Warning = 190,

            Tx_Power_High_Alarm = 192,
            Tx_Power_Low_Alarm = 194,
            Tx_Power_High_Warning = 196,
            Tx_Power_Low_Warning = 198,
        }
        
        public float calculate_T(string MsbLsb)
        {
            //Internally measured temperature: signed 2’s
            //complement in 1 / 256 degree Celsius increments
            //NOTE: Temp can be below 0.

            float gg = (float)HexStr_TwoComplement_Int(MsbLsb);
            return (gg / 256);
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

        public float calculate_Vcc(string MsbLsb)
        {
            return ((float)Convert.ToInt32(MsbLsb, 16)) / 10000;
        }

        public float calculate_Bias(string MsbLsb)
        {
            return ((float)Convert.ToInt32(MsbLsb, 16)) / 500;
        }

        public double calculate_Txpwr_dBm(string MsbLsb)
        {
            //2個Hex 範圍0~65536 一格為 0.1uW
            //65535 = 65535*0.1uW = 65535*0.1*0.001mW
            
            double mW = (double)Convert.ToInt32(MsbLsb, 16)/10000;
            double dBm = 10 * Math.Log10(mW);

            if (dBm<-40)
            {
                dBm = -40;
            }

            return dBm;
        }

        public double calculate_Rxpwr_dBm(string MsbLsb)
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

        private void dgv_DDMI_initialize(DataGridView dgv)
        {
            dgv.RowTemplate.Height = 20;


            //.Rows //.Columns
            dgv.Columns.Add("_", "#");

            dgv.Columns.Add("A_H", "A_H");
            dgv.Columns.Add("A_L", "A_L");
            dgv.Columns.Add("W_H", "W_H");
            dgv.Columns.Add("W_L", "W_L");

            dgv.Rows.Add("T");
            dgv.Rows.Add("V");
            dgv.Rows.Add("Bs");
            dgv.Rows.Add("Rx");
            dgv.Rows.Add("Tx");


            dgv.RowHeadersWidth = 5;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgv.Columns[0].Width = 20;
            dgv.Columns[1].Width = 40;
            dgv.Columns[2].Width = 40;
            dgv.Columns[3].Width = 40;
            dgv.Columns[4].Width = 40;


            dgv.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
            dgv.EnableHeadersVisualStyles = false;


            foreach (DataGridViewColumn column in dgv.Columns) //禁用排序
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
