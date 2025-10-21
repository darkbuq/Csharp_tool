using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FOE_YR
{
    interface I_I2C
    {
        void write();

        string read();
    }

    public class I2C_USB_ISS
    {
        SerialPort port = null;

        public I2C_USB_ISS(string portName, int baudRate)
        {
            port = new SerialPort(portName, baudRate);
        }

        public void Write(byte address, byte[] value)
        {
            port.Open();

            byte main_code = 0x55; // 主USB-ISS指令
            byte device_addr = 0xA0; // 設備位址 + R/W位
            const int MAX_CHUNK = 50; // 每次最多寫50 bytes

            int offset = 0;

            while (offset < value.Length)
            {
                // 計算這次要寫入的資料長度
                int chunkSize = Math.Min(MAX_CHUNK, value.Length - offset);
                byte length = (byte)chunkSize;

                // 組出這段要寫入的指令封包
                byte[] writeCmd = new byte[4 + chunkSize];
                writeCmd[0] = main_code;
                writeCmd[1] = device_addr;
                writeCmd[2] = (byte)(address + offset); // 偏移內部位址
                writeCmd[3] = length;

                Array.Copy(value, offset, writeCmd, 4, chunkSize);

                // 寫入資料
                port.Write(writeCmd, 0, writeCmd.Length);
                Thread.Sleep(100); // 稍微延遲，避免溢出

                offset += chunkSize;
            }

            port.Close();
        }

        public void Write(string address, string value)
        {
            //address
            if (address.Length != 2)
            {
                throw new Exception("Write(string address, string value)\r\n address長度錯誤");
            }

            byte b_address;
            try
            {
                b_address = Convert.ToByte(address, 16);
            }
            catch (Exception ex)
            {
                throw new Exception($"Write(string address, string value)\r\n address轉型失敗\r\n{ex.ToString()}");
                return;
            }


            //value
            HexString_transform HexString_transform = new HexString_transform();
            byte[] barr_value = HexString_transform.HexStr_to_byteArr(value);



            Write(b_address, barr_value);
        }

        public byte[] Read(int startAddress, int totalLength)
        {
            if (totalLength >256)
            {
                throw new Exception("長度不可超過256");
            }
            
            const int MAX_READ_PER_TIME = 50;//最大只讀50個   以免L2C溢位
            const int RANGE_BOUNDARY = 128;

            List<byte> result = new List<byte>();

            port.Open();

            int remaining = totalLength;
            int currentAddr = startAddress;

            while (remaining > 0)
            {
                // 每次最多讀50 bytes
                int readLen = Math.Min(remaining, MAX_READ_PER_TIME);

                // 檢查是否跨越 0~127 或 128~255 範圍邊界
                int currentRangeStart = (currentAddr / RANGE_BOUNDARY) * RANGE_BOUNDARY;
                int currentRangeEnd = currentRangeStart + RANGE_BOUNDARY;

                if (currentAddr + readLen > currentRangeEnd)
                {
                    readLen = currentRangeEnd - currentAddr; // 修正避免跨區
                }

                byte main_code = 0x55;   // 主USB-ISS指令
                byte device_addr = 0xA1; // 設備位址 + R/W位

                byte addrByte = (byte)(currentAddr % 256);
                byte lenByte = (byte)readLen;

                byte[] writeCmd = { main_code, device_addr, addrByte, lenByte };

                // 發出命令
                port.Write(writeCmd, 0, writeCmd.Length);
                Thread.Sleep(100);

                // 接收資料
                int bytesToRead = port.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                port.Read(buffer, 0, buffer.Length);

                result.AddRange(buffer);

                // 更新位址與剩餘長度
                currentAddr += readLen;
                remaining -= readLen;
            }

            port.Close();

            return result.ToArray();
        }        

        public void changeBankPage(string page, int delay)
        {
            string tablestr = page.Trim();
            Write(0x7F, new byte[]{ Convert.ToByte(page, 16)});
            Thread.Sleep(delay);

            string pp = Read(0x7F, 1)[0].ToString("X2");
            if (pp != tablestr)
            {
                throw new Exception($"換頁失敗 page={page}");
            }
            Thread.Sleep(delay);
        }


        enum StateMachine
        {
            load_Wpage,
        }

        //public string RunScript(string script, out string help)
        //{
        //    help = $"目前不支援指令串接";

        //    script = script.Replace(" ", string.Empty).Replace("\r", "").Replace("\n", "").Replace("\t", "");



        //    string head = script.Substring(0, 2);

        //    if (head == "ss")
        //    {
        //        string address = script.Substring(2, 2);
        //        string value = script.Substring(4, script.Length-4);

        //        Write(address, value);

        //        return "";
        //    }
        //    else if (head == "gg")
        //    {

        //    }
        //    else
        //    {
        //        throw new Exception("指令錯誤");
        //    }
        //}
    }

    public class Script_Interpreter
    {
        I2C_USB_ISS I2C = null;

        public Script_Interpreter(I2C_USB_ISS I2C)
        {
            this.I2C = I2C;
        }

        public enum CommandType
        {
            NoOp,           // 無操作/等待新命令
            Write,          // ss
            Read,           // gg
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

        public string RunScript(string Script)
        {
            // ... 變數初始化 ...

            // 將狀態機變數替換為 CommandType
            CommandType currentCommand = CommandType.NoOp;
            int internalState = 0; // 用於追蹤 Page -> Address -> Length/Data 的步驟


            byte currentPage = 0;
            byte currentAddress = 0;
            List<byte> Buffer = new List<byte>();

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
                                if (runItemVal != "ss" && runItemVal != "gg")
                                {
                                    Buffer.Add(Convert.ToByte(runItemVal, 16));
                                }

                                if (runItemVal == "ss" || runItemVal == "gg" || i+2 >= Script.Length)//如果有連續的 `ss` 或 `gg`，可能會進入死循環或跳過資料
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
                    
                    
                }
            }




            return result;
        }

        
    }
}
