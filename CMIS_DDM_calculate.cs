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
    }
}
