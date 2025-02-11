using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FOE_YR
{
    public interface IBert
    {
        //int getInstance();

        //bool connect();
        void disconnect();
        string setDataRate(double DataRate);
        string setPattern(string PRBS, bool TxInv, bool RxInv);
        //bool Polling_ErrorRate(ref double[] ber_result, UInt32 totaltime, double rate, out bool done);

        void PPG_on();
        void PPG_off();
        void ED_on();
        void ED_off();
        void Set_test_time();
        void test_start();
        string Result(int ch);
    }

    public class BERT_PSS15441_COM : IBert
    {
        private IDeviceConnector _controller;

        public BERT_PSS15441_COM(IDeviceConnector Controller)
        {
            this._controller = Controller;
        }

        public void disconnect()
        {
            _controller.disconnect();
        }

        public string setDataRate(double DataRate)
        {
            string freq = "";
            //datarate = setDataRate;

            freq = DataRate.ToString().Replace('.', 'G');
            string supportedDataRate = "0G622,1G25,2G125,2G488,2G5,3G07,3G125,4G25,5G,6G144,6G25,7G5,8G5,9G95,10G,10G31,10G52,10G7,11G09,11G32,15G";
            if (!supportedDataRate.Contains(freq))
            {
                throw new Exception("Unsupported Data Rate Error");
            }

            _controller.Write($"Source:Speed all " + freq + "\r\n");//發端速率配置
            Thread.Sleep(500);

            string result = "";
            for (int i = 0; i < 4; i++)
            {
                result += _controller.Query($"Source:Speed? {i}\r\n") + ",  ";//確認 發端速率配置
                Thread.Sleep(500);
            }

            return result;
        }

        public string setPattern(string PRBS, bool TxInv, bool RxInv)
        {
            string allPRBS = "PRBS7,PRBS9,PRBS15,PRBS23,PRBS31,PRBS58";

            if (!allPRBS.Contains(PRBS))
            {
                throw new Exception("指定的碼型無支援");
            }

            _controller.Write($"Source:Patter all {PRBS}\r\n");//發送端碼型設置
            Thread.Sleep(500);
            _controller.Write($"Sense:Patter all {PRBS}\r\n");//接收端碼型設置
            Thread.Sleep(500);

            string result = "Source\r\n";
            for (int i = 0; i < 4; i++)
            {
                result += _controller.Query($"Source:Patter? {i}\r\n") + ",  ";//確認 發端速率配置
                Thread.Sleep(500);
            }

            //下面指令  設備不支援
            //result += "Sense\r\n";
            //for (int i = 0; i < 1; i++)
            //{
            //    result += _controller.Query($"Sense:Patter? {i}\r\n") + ",  ";//確認 發端速率配置
            //    Thread.Sleep(500);
            //}

            return result;
        }


        /// <summary>
        /// 碼型發生 啟動  (主要是在發送端)
        /// </summary>
        public void PPG_on()
        {
            _controller.Write($"Source:Start all\r\n");
        }
        /// <summary>
        /// 碼型發生 停止  (主要是在發送端)
        /// </summary>
        public void PPG_off()
        {
            _controller.Write($"Source:Stop all\r\n");
        }

        /// <summary>
        /// 碼型比對 啟動  (主要是在接收端)
        /// </summary>
        public void ED_on()
        {
            _controller.Write($"Sense:Start all\r\n");
        }

        /// <summary>
        /// 碼型比對 停止  (主要是在接收端)
        /// </summary>
        public void ED_off()
        {
            _controller.Write($"Sense:Stop all\r\n");
        }

        /// <summary>
        /// Source:Time 通道號 測試時間   <br/>單位是秒<br/>   
        /// </summary>
        public void Set_test_time()
        {
            _controller.Write($"Source:Time all 0\r\n");//測試時間配置
        }

        public void test_start()
        {
            _controller.Write($"Sense:Clear all \r\n");//清除該通道 誤碼數 碼總數 誤碼狀態
            Thread.Sleep(200);
            _controller.Write($"Sense:Start all\r\n");
        }

        public string Result(int ch)
        {
            return _controller.Query($"Status:Result? {ch}");
        }
    }
}
