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

        byte[] Readpage_128byte(string address_hex);
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
            Write,          // ss
            Read,           // gg
            WriteBit        // tt
        }

        // 寫入單個命令 (ss) 的參數解析狀態
        public enum WriteState
        {
            LoadPage,
            LoadAddress,
            WriteHexString // 寫完一個字節後回到這個狀態，直到遇到新命令
        }

        // 讀取命令 (gg) 的參數解析狀態
        public enum ReadState
        {
            LoadPage,
            LoadAddress,
            LoadLength // 讀取完長度後回到 CommandType.NoOp
        }

        public enum WriteBitState
        {
            LoadPage,
            LoadAddress,
            LoadMask,
            LoadValue
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
                        currentCommand = CommandType.Write;
                        internalState = (int)WriteState.LoadPage; // 設置內部起始狀態
                        continue;
                    }
                    else if (runItemVal == "gg")
                    {
                        currentCommand = CommandType.Read;
                        internalState = (int)ReadState.LoadPage;
                        continue;
                    }
                    else if (runItemVal == "tt")
                    {
                        currentCommand = CommandType.WriteBit;
                        internalState = (int)WriteBitState.LoadPage;
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
                    if (currentCommand == CommandType.Write)
                    {
                        switch ((WriteState)internalState)
                        {
                            case WriteState.LoadPage:
                                currentPage = Convert.ToByte(runItemVal, 16);
                                internalState = (int)WriteState.LoadAddress;
                                break;

                            case WriteState.LoadAddress:
                                currentAddress = Convert.ToByte(runItemVal, 16);
                                internalState = (int)WriteState.WriteHexString;
                                break;

                            case WriteState.WriteHexString:
                                // 若不是結束符號，先加進 Buffer
                                if (runItemVal != "ss" && runItemVal != "gg" && runItemVal != "ww")
                                {
                                    Buffer.Add(Convert.ToByte(runItemVal, 16));
                                }

                                if (runItemVal == "ss" || runItemVal == "gg" || i + 2 >= Script.Length)//如果有連續的 `ss` 或 `gg`，可能會進入死循環或跳過資料
                                {
                                    // --- 命令結束 執行動作 重設狀態 ---
                                    I2C.Write(currentAddress, Buffer.ToArray());

                                    currentPage = 0;
                                    currentAddress = 0;
                                    Buffer.Clear();

                                    currentCommand = CommandType.NoOp;


                                    if (i + 2 < Script.Length) i -= 2; // 讓下一輪重新處理這個命令標記
                                }

                                break;
                        }
                    }
                    else if (currentCommand == CommandType.Read)
                    {
                        switch ((ReadState)internalState)
                        {
                            case ReadState.LoadPage:
                                currentPage = Convert.ToByte(runItemVal, 16);
                                internalState = (int)ReadState.LoadAddress;
                                break;

                            case ReadState.LoadAddress:
                                currentAddress = Convert.ToByte(runItemVal, 16);
                                internalState = (int)ReadState.LoadLength;
                                break;

                            case ReadState.LoadLength:
                                int length = Convert.ToInt16(runItemVal, 16);
                                var readData = I2C.Read(currentAddress, length);

                                result += string.Join(" ", readData.Select(v => v.ToString("X2")));

                                currentPage = 0;
                                currentAddress = 0;

                                currentCommand = CommandType.NoOp;
                                break;

                        }
                    }
                    else if (currentCommand == CommandType.WriteBit)
                    {
                        switch ((WriteBitState)internalState)
                        {
                            case WriteBitState.LoadPage:
                                currentPage = Convert.ToByte(runItemVal, 16);
                                internalState = (int)WriteBitState.LoadAddress;
                                break;

                            case WriteBitState.LoadAddress:
                                currentAddress = Convert.ToByte(runItemVal, 16);
                                internalState = (int)WriteBitState.LoadMask;
                                break;

                            case WriteBitState.LoadMask:
                                currentMask = Convert.ToByte(runItemVal, 16);
                                internalState = (int)WriteBitState.LoadValue;
                                break;

                            case WriteBitState.LoadValue:
                                byte targetBitValue = Convert.ToByte(runItemVal, 16);

                                //動作
                                byte targetValue = I2C.Read(currentAddress, 1)[0];

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

                                I2C.Write(currentAddress, new byte[] { targetValue });

                                break;

                        }
                    }

                }
            }




            return result;
        }

        public byte[] Readpage_128byte(string address_hex)
        {
            if (!(address_hex == "00" || address_hex == "80"))
            {
                throw new Exception("只能使用 00 或 80 當起點讀整頁");
            }

            byte startAddress = Convert.ToByte(address_hex, 16);

            return I2C.Read(startAddress, 128);
        }
    }
}
