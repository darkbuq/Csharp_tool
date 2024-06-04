using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byYR_number_system
{
    public class twos_complement
    {
        // 二補數   2's complement
        // -1000 = FC18
        // -1 = FFFF
        // 0 = 0000
        // 1000 = 03E8
        public int HexStr_TwoComplement_Int(string HexStr)//對於hex的長度沒有限制 且比較好懂
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


        public string short_to_HexStr_by_2sComplement(short intt)//還沒想好如何改成自動長度版本
        {
            if (intt >= 0)
            {
                return intt.ToString("X4");
            }
            else
            {
                return (65536 + intt).ToString("X4");
            }
        }
    }
}
