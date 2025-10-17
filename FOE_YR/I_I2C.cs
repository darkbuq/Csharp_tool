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

            byte main_code = 0x55; //主USB-ISS指令
            byte device_addr = 0xA0; //設備位址 + R/W位

            //要求的最大資料位元組數不應超過 60
            //以免溢出 USB-ISS 的內部緩衝區
            if (value.Length >59)
            {
                throw new Exception("要求的最大資料位元組數不應超過 60，以免溢出 USB-ISS 的內部緩衝區");
            }
            byte length = (byte)value.Length;


            byte[] writeCmd = { main_code, device_addr, address, length};

            writeCmd = writeCmd.Concat(value).ToArray();


            port.Write(writeCmd, 0, writeCmd.Length);
            Thread.Sleep(100);

            port.Close();
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
