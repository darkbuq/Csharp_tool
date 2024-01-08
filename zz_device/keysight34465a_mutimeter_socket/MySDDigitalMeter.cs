using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace keysight34465a_mutimeter_socket
{
    public interface SDDMeterInterface
    {
        //public string return_message = "";//這行會報錯

        bool connect();
        bool disconnect();
        bool readVoltage(out double dVol);
        string getErrorMsg();

    }

    class MySDDigitalMeter
    {
    }

    public class My_keysight34465a_MultiMeter_Class : SDDMeterInterface
    {
        public string IP = "192.168.7.60";
        public int port = 5024;
        double dVol = 0;

        Thread receiveThread;
        TcpClient client;

        public string return_message = "";

        protected virtual void ReceiveMessages()
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    return_message = "not connect..";
                    return;
                }


                NetworkStream clientStream = client.GetStream();
                byte[] message = new byte[4096];
                int bytesRead;
                while (true)
                {
                    bytesRead = 0;

                    bytesRead = clientStream.Read(message, 0, 4096);
                    // NetworkStream.Read 方法是一個阻塞的方法，
                    // 它會一直等待，直到有資料可供讀取，
                    // 或者發生了例外情況（例如，連線關閉、超時等）。
                    // 這就是為什麼在這個 while 迴圈中，
                    // 當沒有資料可供讀取時，它會一直等待。

                    if (bytesRead == 0)
                        break;

                    string receivedMessage = Encoding.ASCII.GetString(message, 0, bytesRead);
                    return_message = receivedMessage;
                }
            }
            catch (Exception ex)
            {
                return_message = $"Error receiving message: {ex.Message}";
            }
        }

        public virtual bool connect()
        {
            bool TF = true;

            try
            {
                client = new TcpClient(IP, port);                
            }
            catch (Exception ex)
            {
                throw;
            }
            

            receiveThread = new Thread(ReceiveMessages);
            receiveThread.Start();


            Thread.Sleep(2000);
            if (return_message.Contains("34460A"))
            {
                TF = true;
            }
            else
            {
                TF = false;
            }

            return TF;
        }

        public virtual bool disconnect()
        {
            receiveThread.Abort();//這執行緒還活著  但呼叫不到

            client?.Close();
            bool TF = true;
            return TF;
        }

        public virtual bool readVoltage(out double dVol)
        {
            dVol = 0;

            NetworkStream clientStream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes($"READ?\r\n");
            clientStream.Write(data, 0, data.Length);
            clientStream.Flush();
            Thread.Sleep(1500);

            dVol = double.Parse(return_message.Split('E')[0].Replace("+",""));
            bool TF = true;
            return TF;
        }

        public virtual string getErrorMsg()
        {
            return return_message;
        }
    }
}
