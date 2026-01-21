using MathNet.Numerics;

using System;
using System.Collections.Generic;
using System.Globalization;
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

        public (double predictedY, double rSquared) simple_regression_setX_findY_findR2(double[] xdata, double[] ydata, double setX)
        {
            // 線性回歸 (degree = 1)
            var coefficient = Fit.Polynomial(xdata, ydata, 1);

            // 計算指定 X 的預測 Y
            double predictedY = coefficient[1] * setX + coefficient[0];

            // 計算所有點的預測值
            var yPred = xdata.Select(x => coefficient[1] * x + coefficient[0]);

            // 計算 R²
            double rSquared = GoodnessOfFit.RSquared(yPred, ydata);

            return (predictedY, rSquared);
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

    public class HexString_transform
    {
        public byte[] HexStr_to_byteArr(string hex_str)
        {
            hex_str = hex_str.Trim();

            if (hex_str.Length % 2 != 0)
            {
                throw new FormatException("hex string 長度必須是偶數");
            }

            int byteCount = hex_str.Length / 2;
            byte[] byte_arr = new byte[byteCount];

            for (int i = 0; i < byteCount; i++)
            {
                string hexPair = hex_str.Substring(i * 2, 2);  // 例如 "A1"
                byte_arr[i] = Convert.ToByte(hexPair, 16);    // 轉成 byte
            }

            return byte_arr;
        }
    }

    public class Twos_complement//常用在帶負號整數
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
    
    public class Custom_binary_encoding_1
    {

        /// <summary>
        /// 無負數
        /// 整數部分（小數點左邊） → 轉成二進制 → 轉成十六進位
        /// 小數部分（小數點右邊） → 轉成二進制（用 2 的負次方加總） → 再轉成十六進位表示
        /// </summary>
        public string float_to_2byte(float number)
        {
            if (number < 0 || number >= 256)
                throw new ArgumentOutOfRangeException("Number must be between 0 and less than 256");

            int integerPart = (int)Math.Floor(number);       // 取整數部分
            float decimalPart = number - integerPart;        // 小數部分
            int decimalByte = (int)Math.Round(decimalPart * 256);  // 轉成 0~255

            if (decimalByte == 256) // 四捨五入會超過 1.0，要進位
            {
                integerPart += 1;
                decimalByte = 0;
                if (integerPart >= 256)
                    throw new ArgumentOutOfRangeException("Rounded result exceeds 16-bit format");
            }

            // 轉成十六進位字串
            return $"{integerPart:X2}{decimalByte:X2}";
        }
    }

    public class IEEE754
    {
        public byte[] FloatToIEEE754(float value)
        {
            //C# 的 float 內部本來就就是 IEEE 754 single precision
            //BitConverter.GetBytes(float)
            //只是把「這個 IEEE754 的 bit pattern」直接拿出來

            byte[] bytes = BitConverter.GetBytes(value);
            return bytes;

            //1.00256 轉 IEEE754 為 3F8053E3

            //Big-Endian 大端序 為  3F 80 53 E3
            //高位元組存放在低記憶體位址（PowerPC 或網路傳輸標準常用）

            //Little-Endian 小端序 為  E3 53 80 3F
            //低位元組存放在低記憶體位址（Intel/AMD 常用）
        }

        public byte[] IEEE754_To_BigEndian(byte[] IEEE754)
        {
            byte[] copy = (byte[])IEEE754.Clone();

            Array.Reverse(copy);
            return copy;
        }

        public float IEEE754ToFloat(byte[] ieee754LittleEndian)// IEEE754 → float（輸入必須是 Little-Endian）
        {
            if (ieee754LittleEndian.Length != 4)
                throw new ArgumentException("IEEE754 single precision must be 4 bytes");

            return BitConverter.ToSingle(ieee754LittleEndian, 0);
        }
    }

    public class Q_0_8_8 //定點數（Fixed-point number） 固定整數位數表達分數的格式 可以有負號  也可以無負號  此類無負號
    {
        private const double ScalingFactor = 256.0;

        public double MSB_LSB_toDouble(string MSB_LSB)
        {
            if (string.IsNullOrEmpty(MSB_LSB)) return 0;

            // 1. 將 16 進位字串轉為 無符號 16 位元整數 (0 ~ 65535)
            // 例如 "0100" 轉為 256
            ushort rawValue = ushort.Parse(MSB_LSB, NumberStyles.HexNumber);

            // 2. 除以 256 得到實際數值
            return rawValue / ScalingFactor;
        }

        public string Double_toMSBLSB(double value)
        {
            // 1. 限制範圍（Unsigned 8.8 範圍為 0 到 255.996...）
            if (value < 0) throw new Exception("This class has no negative sign.");
            if (value > (65535 / ScalingFactor)) value = 65535 / ScalingFactor;

            // 2. 放大 256 倍並四捨五入取最接近的整數
            ushort rawValue = (ushort)Math.Round(value * ScalingFactor);

            // 3. 轉回 4 位 16 進位字串，不足補 0
            return rawValue.ToString("X4");
        }
    }

    public class Q_1_15_0 // 定點數：1 位符號位，15 位整數，0 位小數 (即有符號 16 位元整數)
    {
        /// <summary>
        /// 將 16 進位字串 (例如 "FD00") 轉換為十進位 double
        /// </summary>
        public short MSB_LSB_toShort(string MSB_LSB)
        {
            if (string.IsNullOrEmpty(MSB_LSB)) return 0;

            // 1. 解析為有符號 16 位元整數 (short)
            // Parse 時先轉 int 再轉 short，能自動處理 2 的補數 (2's Complement)
            // 例如 "FD00" 會正確識別為 -768
            short rawValue = (short)int.Parse(MSB_LSB, NumberStyles.HexNumber);

            // 2. 因為 Q1.15.0 小數點在最後一位之後，所以直接回傳整數值
            return rawValue;
        }

        /// <summary>
        /// 將 double 數值轉換為 16 進位字串 (例如 -768 -> "FD00")
        /// </summary>
        public string Short_toMSBLSB(short value)
        {
            // 1. 範圍限制：
            // 既然輸入已經是 short，它天生就限制在 -32768 到 32767 之間
            // 所以原先的 if (value < -32768) 判斷在 short 型別下是多餘的。

            // 2. 四捨五入：
            // 因為輸入已經是整數型別 (short)，Math.Round 是不需要的。

            // 3. 轉為 4 位 16 進位大寫字串
            // 使用 (ushort) 強制轉型是為了確保得到補數表示法 (如 "FD00")
            return ((ushort)value).ToString("X4");
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


        public double SenOMA(double Sensitivity_dBm, double ER_dB)
        {
            double Sensitivity_mW = dBm_to_mW(Sensitivity_dBm);

            double ER_lin = dBm_to_mW(ER_dB);//換成線性 比值

            double SenOMA_mW = ((2 * Sensitivity_mW) / (ER_lin + 1)) * (ER_lin - 1);

            return mW_to_dBm(SenOMA_mW);
        }
    }


}
