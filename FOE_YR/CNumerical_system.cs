using MathNet.Numerics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOE_YR
{
    public class CNumerical_system
    {
    }

    public class linear_regression
    {
        /// <summary>
        /// double[] xdata = new double[] { -5, 25, 75 };
        /// double[] ydata = new double[] { 9162.2049, 10471.28548, 6591.738952 };
        /// use => Fit.Polynomial(xdata, ydata, degree)
        /// return array is from low coefficient to high coefficient..
        /// </summary>
        /// <param name="xdata"></param>
        /// <param name="ydata"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public double[] regression(double[] xdata, double[] ydata, int degree)
        {
            return Fit.Polynomial(xdata, ydata, degree);
        }

        public double regression_setX_findY(double[] xdata, double[] ydata, int degree, double setX)
        {
            // 計算多項式回歸係數
            var coefficients = Fit.Polynomial(xdata, ydata, degree);

            // 使用回歸係數計算指定 X 值的預測 Y 值
            double predictedY = 0;
            for (int i = 0; i <= degree; i++)
            {
                predictedY += coefficients[i] * Math.Pow(setX, i);
            }

            return predictedY;
        }

        public double simple_regression_setX_findY(double[] xdata, double[] ydata, double setX)
        {
            var coefficient = Fit.Polynomial(xdata, ydata, 1);
            return coefficient[1] * setX + coefficient[0];
        }
    }

    public class Binary_control
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex_str"></param>
        /// <param name="set_value"></param>
        /// <param name="bit_left_right">"bit76 or bit44"</param>
        /// <returns></returns>
        public string Bit_value_swapping_in_hex(string hex_str, byte set_value, string bit_left_right)
        {
            // 將十六進位字串轉換為 byte
            byte original_byte = (byte)Convert.ToInt32(hex_str, 16);


            //需要置換的bit位置由大到小
            int rightBit = int.Parse(bit_left_right.Replace("bit", "").Substring(1, 1));
            int leftBit = int.Parse(bit_left_right.Replace("bit", "").Substring(0, 1));

            // 创建一个遮罩，用于清除要置换的位元 是一個範圍
            int clearMask = ((1 << (leftBit + 1)) - 1) & ~((1 << rightBit) - 1);


            // 清除要置换的位元，并将 set_value 左移到正确的位置
            //byte resultByte = (byte)((original_byte & ~clearMask) | (set_value << rightBit));
            byte resultByte = (byte)((original_byte & ~clearMask) | ((set_value << rightBit) & clearMask));

            // 将结果转回十六进位字串
            return resultByte.ToString("X2");
        }

        public int ByteValue_cutbit_toInt(byte bytenum, string bit_left_right)
        {
            // 需要提取的 bit 位置 (由大到小)
            int rightBit = int.Parse(bit_left_right.Replace("bit", "").Substring(1, 1));
            int leftBit = int.Parse(bit_left_right.Replace("bit", "").Substring(0, 1));

            // 建立遮罩：範圍內的位元設為 1，其他位元設為 0
            int mask = ((1 << (leftBit + 1)) - 1) & ~((1 << rightBit) - 1);

            // 使用遮罩提取指定位元範圍的值，並將其右移到最低位
            int extractedValue = (bytenum & mask) >> rightBit;

            // 回傳整數值（轉成字串）
            return extractedValue;
        }

        public bool Get_Bit_value_in_hex(string hex_str, int bitindex)
        {
            // 驗證輸入是否為合法的十六進位字串
            if (string.IsNullOrWhiteSpace(hex_str))
                throw new ArgumentException("Hex string cannot be null or empty.");

            // 將十六進位字串轉換為整數
            long value;
            try
            {
                value = Convert.ToInt64(hex_str, 16);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid hexadecimal string.");
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Hexadecimal value is too large for Int64.");
            }

            // 驗證位索引是否有效
            if (bitindex < 0 || bitindex >= 64) // Int64 最大支持 64 位
                throw new ArgumentOutOfRangeException(nameof(bitindex), "Bit index must be between 0 and 63.");

            // 判斷指定位是否為 1
            return (value & (1L << bitindex)) != 0;
        }
    }

    public class Twos_complement
    {
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

    public class Optical_transform
    {
        public double dBm_to_mW(double dBm)
        {
            return Math.Pow(10, (dBm / 10));
        }

        public double mW_to_dBm(double mW)
        {
            return 10*(Math.Log10(mW));
        }

        public double SenOMA(double Sensitivity_dBm, double ER)
        {
            double Sensitivity_mW = dBm_to_mW(Sensitivity_dBm);

            double SenOMA_mW = ((2 * Sensitivity_mW) / (ER + 1)) * (ER - 1);

            return mW_to_dBm(SenOMA_mW);
        }
    }
}
