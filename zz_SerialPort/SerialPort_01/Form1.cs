using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SerialPort_01
{
    public partial class Form1 : Form
    {

        private SerialPort serialPort = new SerialPort();
        //string receivedData = "";
        public Form1()
        {
            InitializeComponent();

            // 設置串口參數
            serialPort.PortName = "COM1";  // 更換為您的串口名稱
            serialPort.BaudRate = 115200;    // 波特率
            serialPort.DataBits = 8;        // 數據位
            serialPort.Parity = Parity.None; // 奇偶校驗
            serialPort.StopBits = StopBits.One; // 停止位

            // 設置串口數據接收事件處理程序
            //serialPort.DataReceived += SerialPort_DataReceived;

            
        }

        private void btn_conn_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == true)
            {
                serialPort.Close();
                Thread.Sleep(1000);
            }
            // 開啟串口（在需要的地方調用）
            serialPort.Open();
            Thread.Sleep(1000);
        }

        private string SerialPort_DataReceived(int delaytime)
        {
            Thread.Sleep(delaytime);

            // 在這裡處理接收到的數據
            return serialPort.ReadExisting();
            // 可以將receivedData顯示在UI上，例如使用Invoke方法更新UI控件
            // textBoxReceivedData.Invoke((MethodInvoker)delegate { textBoxReceivedData.Text += receivedData; });

           
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            serialPort.Write("*IDN?" + "\r\n");
            
            txt_result.Text += SerialPort_DataReceived(1000) + "\r\n";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }

        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            serialPort.Write(txt_SCPI.Text + "\r\n");

            txt_result.Text += SerialPort_DataReceived(1000) + "\r\n";
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            serialPort.Write(txt_SCPI.Text + "\r\n");
        }
    }
}
