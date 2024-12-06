using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace client_winform_02
{
    interface IDeviceConnector
    {
        void Write(string command);
        string Query(string command);
        //void StartReceiving(Action<string> onMessageReceived);
        //void StopReceiving();
    }

    class TcpDeviceConnector : IDeviceConnector
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private ManualResetEvent _receiveCompletedEvent;
        private Thread _receiveThread;
        private string _response;


        public TcpDeviceConnector(string ipAddress, int port)
        {
            _client = new TcpClient(ipAddress, port);
            _stream = _client.GetStream();
            _receiveCompletedEvent = new ManualResetEvent(false);
        }

        public void Write(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command);
            _stream.Write(data, 0, data.Length);
            _stream.Flush();
        }

        public string Query(string command)
        {
            Write(command);

            // 重置事件和接收狀態
            _receiveCompletedEvent.Reset();
            _response = null;

            // 啟動接收執行緒
            _receiveThread = new Thread(ReceiveMessages);
            _receiveThread.Start();


            // 等待接收完成
            bool received = _receiveCompletedEvent.WaitOne(5000); // 等待 5 秒超時

            if (!received)
            {
                throw new TimeoutException("Timeout waiting for response.");
            }

            return _response;
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

    }
}
