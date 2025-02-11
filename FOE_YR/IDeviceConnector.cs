using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;



namespace FOE_YR
{
    public interface IDeviceConnector
    {
        //bool connect();

        /// <summary>
        /// 結尾字符 由物件自行加上
        /// </summary>
        /// <param name="command"></param>
        void Write(string command);

        /// <summary>
        /// 結尾字符 由物件自行加上
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        string Query(string command);
        void disconnect();
    }

    interface IDeviceConnector2
    {
        //bool connect();
        void Write(string command);
        string Query_terminator(string command, string terminator);//terminator 為命令結束符
    }

    public class Dummy_connector : IDeviceConnector
    {
        public void disconnect() { }
        public void Write(string command) { }
        public string Query(string command) { return "It's dummy connector"; }
    }

    public class GPIB_Connector : IDeviceConnector
    {
        Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
        Ivi.Visa.Interop.FormattedIO488 ioobj = new Ivi.Visa.Interop.FormattedIO488();

        public GPIB_Connector(string GPIB_port, string GPIB_address)
        {
            string ResourceName = $"{GPIB_port}::{GPIB_address}::INSTR";
            ioobj.IO = (Ivi.Visa.Interop.IMessage)rm.Open(ResourceName, Ivi.Visa.Interop.AccessMode.NO_LOCK, 0, "");
        }

        public void disconnect()
        {
            if (ioobj.IO != null)
            {
                ioobj.IO.Close(); // 關閉 GPIB 通信通道
            }
        }

        public void Write(string command)
        {
            ioobj.WriteString(command, true);
        }

        public string Query(string command)
        {
            ioobj.WriteString(command, true);

            object[] idnItems = (object[])ioobj.ReadList(Ivi.Visa.Interop.IEEEASCIIType.ASCIIType_Any, ",");

            string result = "";
            foreach (object idnItem in idnItems)
            {
                result = idnItem + "\r\n";
            }

            return result;
        }
    }

    public class COM_Connector : IDeviceConnector
    {
        SerialPort serialPort;

        public COM_Connector(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, int readtimeout, int writetimeout)
        {
            // 初始化 SerialPort
            serialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = baudRate,
                Parity = parity,
                DataBits = dataBits,
                StopBits = stopBits,
                ReadTimeout = readtimeout,
                WriteTimeout = writetimeout
            };

            try
            {
                // 開啟 SerialPort
                serialPort.Open();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"無法打開 COM 埠 {portName}: {ex.Message}");
            }
        }

        public void Write(string command)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(command + "\r\n"); // 加入結尾符號 (例如 CRLF)
            }
            else
            {
                throw new InvalidOperationException("SerialPort 尚未打開！");
            }
        }

        public string Query(string command)
        {
            if (serialPort.IsOpen)
            {
                // 寫入命令
                Write(command);

                // 等待回應
                try
                {
                    string response = serialPort.ReadLine(); // 假設設備回傳以換行符號結束
                    return response;
                }
                catch (TimeoutException)
                {
                    throw new TimeoutException("讀取超時，未收到設備回應！");
                }
            }
            else
            {
                throw new InvalidOperationException("SerialPort 尚未打開！");
            }
        }

        public void disconnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }

    public class LAN_Connector : IDeviceConnector, IDeviceConnector2
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private ManualResetEvent _receiveCompletedEvent;
        private Thread _receiveThread;
        private string _response;

        public LAN_Connector(string ip, int port)
        {
            _client = new TcpClient(ip, port);
            _stream = _client.GetStream();
            _receiveCompletedEvent = new ManualResetEvent(false);
        }

        public void disconnect()
        {
            if (_stream != null)
            {
                _stream.Close();
                _stream = null;
            }
            if (_client != null)
            {
                _client.Close();
                _client = null;
            }
        }

        public void Write(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command);
            _stream.Write(data, 0, data.Length);
            _stream.Flush();
        }

        public string Query(string command)
        {
            //Write(command);

            //// 重置事件和接收狀態
            //_receiveCompletedEvent.Reset();
            //_response = null;

            //// 啟動接收執行緒
            //_receiveThread = new Thread(ReceiveMessages);
            //_receiveThread.Start();


            //// 等待接收完成
            //bool received = _receiveCompletedEvent.WaitOne(5000); // 等待 5 秒超時

            //if (!received)
            //{
            //    throw new TimeoutException("Timeout waiting for response.");
            //}

            //return _response;

            return Query_terminator(command, "\n");
        }

        private void ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead = _stream.Read(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                {
                    _response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                }
            }
            catch (Exception ex)
            {
                _response = $"Error: {ex.Message}";
            }
            finally
            {
                // 標記接收完成
                _receiveCompletedEvent.Set();
            }
        }


        public string Query_terminator(string command, string terminator)
        {
            Write(command);
            Thread.Sleep(2000);

            // 重置事件和接收狀態
            _receiveCompletedEvent.Reset();
            _response = null;

            // 启动接收线程
            ThreadPool.QueueUserWorkItem(_ =>
            {
                ReceiveMessages(terminator);

            });


            // 等待接收完成
            bool received = _receiveCompletedEvent.WaitOne(5000); // 等待 5 秒超時

            if (!received)
            {
                throw new TimeoutException("Timeout waiting for response.");
            }

            return _response;
        }


        private void ReceiveMessages(string End_marker)
        {
            StringBuilder messageBuilder = new StringBuilder();

            while (true)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    // 將讀取到的數據追加到 StringBuilder
                    string receivedPart = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    messageBuilder.Append(receivedPart);

                    // 檢查是否包含結束符，這裡假設 "\n" 為結束符  // 检查是否包含结束符，避免频繁调用 ToString()
                    if (receivedPart.Contains(End_marker) || messageBuilder.ToString().EndsWith(End_marker))
                    {
                        _response = messageBuilder.ToString();
                        break;
                    }
                }
                else
                {
                    // 如果 bytesRead 為 0，表示流已經關閉或無法再讀取
                    throw new IOException("Stream closed or no more data available.");
                }
            }

            // 標記接收完成
            _receiveCompletedEvent.Set();
        }
    }
}
