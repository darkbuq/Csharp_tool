using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byYR
{
    public class twos_complement
    {
        public virtual int HexStr_to_int_by_2sComplement(string HexStr)
        {
            ushort rawValue = (ushort)Convert.ToInt32(HexStr, 16);

            string half_str = "";
            string one_str = "";
            for (int i = 0; i < HexStr.Length; i++)
            {
                if (i == 0)
                {
                    half_str = "0x8";
                }
                else
                {
                    half_str += "0";
                }

                if (i == 0)
                {
                    one_str = "0x0";
                }
                else if (i == HexStr.Length - 1)
                {
                    one_str = "1";
                }
                else
                {
                    one_str += "0";
                }
            }


            // If a positive value, return it
            int result = Convert.ToInt32(half_str, 16);
            if ((rawValue & result) == 0)
            {
                return rawValue;
            }

            // Otherwise perform the 2's complement math on the value
            int one_int = Convert.ToInt32(one_str, 16);
            return (ushort)(~(rawValue - one_int)) * -1;
        }

        public virtual string int_to_HexStr_by_2scomplement(int int_num, int HexLength)
        {
            if (int_num >= 0)
            {
                return int_num.ToString($"X{HexLength}");
            }
            else
            {
                
                return ((int)(Math.Pow(16, HexLength) + int_num)).ToString("X4");
            }
        }

        public virtual string short_to_HexStr_by_2sComplement(short intt)//還沒想好如何改成自動長度版本
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
