using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FOE_YR
{
    public interface I_I2C
    {
        void Write(byte address, byte[] value);

        byte[] Read(int startAddress, int totalLength);
    }

    public class I2C_USB_ISS : I_I2C
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

        

    }

    
}
