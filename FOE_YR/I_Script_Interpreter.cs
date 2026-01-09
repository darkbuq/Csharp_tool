using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FOE_YR
{
    public interface I_Script_Interpreter
    {
        string Help_txt();

        string RunScript(string Script);

        byte[] Readpage_128byte(byte device_addr, string address_hex);
    }

    public class Script_Interpreter : I_Script_Interpreter
    {
        I_I2C I2C = null;

        //public Script_Interpreter(I2C_USB_ISS I2C)
        //{
        //    this.I2C = I2C;
        //}

        public Script_Interpreter(I_I2C I2C)
        {
            this.I2C = I2C;
        }

        public enum CommandType
        {
            NoOp,           // 無操作/等待新命令
            ss,          // 寫入
            gg,           // 讀取
            tt,       // 寫bit
            kk,             // compare 一段  比對不一樣 就舉手
            km              // 比對 成功就舉手
        }

        // 寫入單個命令 (ss) 的參數解析狀態
        public enum ss
        {
            LoadPage,
            LoadAddress,
            WriteHexString // 寫完一個字節後回到這個狀態，直到遇到新命令
        }

        // 讀取命令 (gg) 的參數解析狀態
        public enum gg
        {
            LoadPage,
            LoadAddress,
            LoadLength // 讀取完長度後回到 CommandType.NoOp
        }

        public enum tt
        {
            LoadPage,
            LoadAddress,
            LoadMask,
            LoadValue
        }

        public enum kk
        {
            kk_load_page,
            kk_load_address,
            kk_compare_HexString
        }

        public enum km
        {
            km_load_page,
            km_load_address,
            km_compare_HexString
        }


        public string Help_txt()
        {
            return "指令說明\r\ntt[A0][address][mask][vlaue]\r\n後面兩個參數\r\nmask 有1的bit 會把value相對的bit 寫進目標位置\r\n引用C語言 位運算的概念設計";
        }

        public string RunScript(string Script)
        {
            // ... 變數初始化 ...

            // 將狀態機變數替換為 CommandType
            CommandType currentCommand = CommandType.NoOp;
            int internalState = 0; // 用於追蹤 Page -> Address -> Length/Data 的步驟


            byte currentPage = 0;
            byte currentAddress = 0;

            List<byte> Buffer = new List<byte>();

            byte currentMask = 0;
            //byte currentBitValue = 0;


            string result = "";


            // ... checkloop 循環 ...
            for (int i = 0; i < Script.Length; i = i + 2)
            {
                // ... 讀取 runItemVal ...
                string runItemVal = Script.Substring(i, 2);

                // --- 階段 1: 判斷新命令 (只有在 NoOp 時才進行) ---
                if (currentCommand == CommandType.NoOp)
                {
                    if (runItemVal == "ss")
                    {
                        currentCommand = CommandType.ss;
                        internalState = (int)ss.LoadPage; // 設置內部起始狀態
                        continue;
                    }
                    else if (runItemVal == "gg")
                    {
                        currentCommand = CommandType.gg;
                        internalState = (int)gg.LoadPage;
                        continue;
                    }
                    else if (runItemVal == "tt")
                    {
                        currentCommand = CommandType.tt;
                        internalState = (int)tt.LoadPage;
                    }
                    else if (runItemVal == "kk")
                    {
                        currentCommand = CommandType.kk;
                        internalState = (int)kk.kk_load_page;
                    }
                    else if (runItemVal == "km")
                    {
                        currentCommand = CommandType.km;
                        internalState = (int)km.km_load_page;
                    }
                    else if (runItemVal == "ww")
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    else
                    {
                        return "ScriptError: Unknown Command or Data outside of command.";
                    }
                }

                // --- 階段 2: 處理命令參數 (使用 switch 判斷當前命令類型) ---
                else
                {
                    if (currentCommand == CommandType.ss)
                    {
                        switch ((ss)internalState)
                        {
                            case ss.LoadPage:
                                currentPage = Convert.ToByte(runItemVal, 16);
                                internalState = (int)ss.LoadAddress;
                                break;

                            case ss.LoadAddress:
                                currentAddress = Convert.ToByte(runItemVal, 16);
                                internalState = (int)ss.WriteHexString;
                                break;

                            case ss.WriteHexString:
                                // 若不是結束符號，先加進 Buffer
                                if (runItemVal != "ss" && runItemVal != "gg" && runItemVal != "ww")
                                {
                                    Buffer.Add(Convert.ToByte(runItemVal, 16));
                                }

                                if (runItemVal == "ss" || runItemVal == "gg" || i + 2 >= Script.Length)//如果有連續的 `ss` 或 `gg`，可能會進入死循環或跳過資料
                                {
                                    // --- 命令結束 執行動作 重設狀態 ---
                                    I2C.Write(currentPage,currentAddress, Buffer.ToArray());// A1讀A0寫;A3讀A2寫;A5讀A4寫;A7讀A6寫

                                    currentPage = 0;
                                    currentAddress = 0;
                                    Buffer.Clear();

                                    currentCommand = CommandType.NoOp;


                                    if (i + 2 < Script.Length) i -= 2; // 讓下一輪重新處理這個命令標記
                                }

                                break;
                        }
                    }
                    else if (currentCommand == CommandType.gg)
                    {
                        switch ((gg)internalState)
                        {
                            case gg.LoadPage:
                                currentPage = Convert.ToByte(runItemVal, 16);
                                internalState = (int)gg.LoadAddress;
                                break;

                            case gg.LoadAddress:
                                currentAddress = Convert.ToByte(runItemVal, 16);
                                internalState = (int)gg.LoadLength;
                                break;

                            case gg.LoadLength:
                                int length = Convert.ToInt16(runItemVal, 16);

                                byte device_addr = (byte)(currentPage + 1);// A1讀A0寫;A3讀A2寫;A5讀A4寫;A7讀A6寫
                                
                                var readData = I2C.Read(device_addr, currentAddress, length);

                                result += string.Join(" ", readData.Select(v => v.ToString("X2")));

                                currentPage = 0;
                                currentAddress = 0;

                                currentCommand = CommandType.NoOp;
                                break;

                        }
                    }
                    else if (currentCommand == CommandType.tt)
                    {
                        switch ((tt)internalState)
                        {
                            case tt.LoadPage:
                                currentPage = Convert.ToByte(runItemVal, 16);
                                internalState = (int)tt.LoadAddress;
                                break;

                            case tt.LoadAddress:
                                currentAddress = Convert.ToByte(runItemVal, 16);
                                internalState = (int)tt.LoadMask;
                                break;

                            case tt.LoadMask:
                                currentMask = Convert.ToByte(runItemVal, 16);
                                internalState = (int)tt.LoadValue;
                                break;

                            case tt.LoadValue:
                                byte targetBitValue = Convert.ToByte(runItemVal, 16);

                                //動作
                                byte targetValue = I2C.Read((byte)(currentPage+1), currentAddress, 1)[0];// A1讀A0寫;A3讀A2寫;A5讀A4寫;A7讀A6寫

                                for (int bit = 0; bit < 8; bit++)
                                {
                                    // currentMask 有1才動作
                                    if (((currentMask >> bit) & 1) == 1)
                                    {
                                        // 取出 targetBitValue 該位
                                        int bitVal = (targetBitValue >> bit) & 1;

                                        if (bitVal == 1)
                                        {
                                            targetValue |= (byte)(1 << bit);   // 設為1
                                        }
                                        else
                                        {
                                            targetValue &= (byte)~(1 << bit);  // 設為0
                                        }
                                    }
                                }

                                I2C.Write(currentPage,currentAddress, new byte[] { targetValue });

                                break;

                        }
                    }
                    else if (currentCommand == CommandType.kk)
                    {
                        switch ((kk)internalState)
                        {
                            case kk.kk_load_page:
                                currentPage = Convert.ToByte(runItemVal, 16);
                                internalState = (int)kk.kk_load_address;
                                break;

                            case kk.kk_load_address:
                                currentAddress = Convert.ToByte(runItemVal, 16);
                                internalState = (int)kk.kk_compare_HexString;
                                break;

                            case kk.kk_compare_HexString:
                                //這邊不知道怎寫

                                // 讀 EEPROM 一個 byte
                                byte readVal = I2C.Read((byte)(currentPage + 1), currentAddress, 1)[0];// A1讀A0寫;A3讀A2寫;A5讀A4寫;A7讀A6寫

                                // 比對 Hex 字串
                                if (runItemVal.ToUpper() != readVal.ToString("X2"))
                                {
                                    result += $"Compare Fail at pg {currentPage:X2} addr {currentAddress:X2} read val {readVal:X2} ref val {runItemVal}\r\n";
                                }

                                // 地址自增，方便下一個比對 byte
                                currentAddress++;

                                break;

                        }
                    }
                    else if (currentCommand == CommandType.km)
                    {
                        switch ((km)internalState)
                        {
                            case km.km_load_page:
                                currentPage = Convert.ToByte(runItemVal, 16);
                                internalState = (int)km.km_load_address;
                                break;

                            case km.km_load_address:
                                currentAddress = Convert.ToByte(runItemVal, 16);
                                internalState = (int)km.km_compare_HexString;
                                break;

                            case km.km_compare_HexString:
                                //這邊不知道怎寫

                                // 讀 EEPROM 一個 byte
                                byte readVal = I2C.Read((byte)(currentPage + 1), currentAddress, 1)[0];// A1讀A0寫;A3讀A2寫;A5讀A4寫;A7讀A6寫

                                // 比對 Hex 字串
                                if (runItemVal.ToUpper() == readVal.ToString("X2"))
                                {
                                    result += $"Compare Match at pg {currentPage:X2} addr {currentAddress:X2} read val {readVal:X2} ref val {runItemVal}\r\n";
                                }

                                // 地址自增，方便下一個比對 byte
                                currentAddress++;

                                break;

                        }
                    }
                }
            }




            return result;
        }

        public byte[] Readpage_128byte(byte currentPage, string address_hex)// A1讀A0寫;A3讀A2寫;A5讀A4寫;A7讀A6寫
        {
            if (!(address_hex == "00" || address_hex == "80"))
            {
                throw new Exception("只能使用 00 或 80 當起點讀整頁");
            }

            byte startAddress = Convert.ToByte(address_hex, 16);

            byte device_addr = (byte)(currentPage + 1);
            return I2C.Read(device_addr, startAddress, 128);
        }
    }
}
