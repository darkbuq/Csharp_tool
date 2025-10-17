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

        public byte[] Read(byte address, byte length)
        {
            port.Open();

            byte main_code = 0x55; //主USB-ISS指令
            byte device_addr = 0xA1; //設備位址 + R/W位

            //要求的最大資料位元組數不應超過 60
            //以免溢出 USB-ISS 的內部緩衝區
            if (length > 59)
            {
                throw new Exception("要求的最大資料位元組數不應超過 60，以免溢出 USB-ISS 的內部緩衝區");
            }

            byte[] writeCmd = { main_code, device_addr, address, length };

            //發出讀取命令
            port.Write(writeCmd, 0, writeCmd.Length);
            Thread.Sleep(100);

            //接收資料
            int bytesToRead = port.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            port.Read(buffer, 0, buffer.Length);

            

            port.Close();

            return buffer;
        }
    }
}
