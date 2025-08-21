using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices; //專門用在呼叫 非託管DLL用
using System.Text;
using System.Threading;

namespace FOE_YR
{
    public interface IBert
    {
        //int getInstance();

        //bool connect();
        void disconnect();

        string GetDeviceInfo();

        string setDataRate(double DataRate);
        string setPattern(string PRBS, bool TxInv, bool RxInv);
        //bool Polling_ErrorRate(ref double[] ber_result, UInt32 totaltime, double rate, out bool done);

        void PPG_on();
        void PPG_off();
        void ED_on();
        void ED_off();
        void Set_test_time(uint testTime_sec);
        void test_start();
        string Result(int ch, out double[] result_BER);
    }

    public class BERT_PSS15441_COM : IBert
    {
        private IDeviceConnector _connector;

        public BERT_PSS15441_COM(IDeviceConnector Connector)
        {
            this._connector = Connector;
        }

        public void disconnect()
        {
            _connector.disconnect();
        }

        public string GetDeviceInfo()
        {
            return _connector.Query("*IDN?\x0A");
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

            _connector.Write($"Source:Speed all " + freq + "\r\n");//發端速率配置
            Thread.Sleep(500);

            string result = "";
            for (int i = 0; i < 4; i++)
            {
                result += _connector.Query($"Source:Speed? {i}\r\n") + ",  ";//確認 發端速率配置
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

            _connector.Write($"Source:Patter all {PRBS}\r\n");//發送端碼型設置
            Thread.Sleep(500);
            _connector.Write($"Sense:Patter all {PRBS}\r\n");//接收端碼型設置
            Thread.Sleep(500);

            string result = "Source\r\n";
            for (int i = 0; i < 4; i++)
            {
                result += _connector.Query($"Source:Patter? {i}\r\n") + ",  ";//確認 發端速率配置
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
            _connector.Write($"Source:Start all\r\n");
        }
        /// <summary>
        /// 碼型發生 停止  (主要是在發送端)
        /// </summary>
        public void PPG_off()
        {
            _connector.Write($"Source:Stop all\r\n");
        }

        /// <summary>
        /// 碼型比對 啟動  (主要是在接收端)
        /// </summary>
        public void ED_on()
        {
            _connector.Write($"Sense:Start all\r\n");
        }

        /// <summary>
        /// 碼型比對 停止  (主要是在接收端)
        /// </summary>
        public void ED_off()
        {
            _connector.Write($"Sense:Stop all\r\n");
        }

        /// <summary>
        /// Source:Time 通道號 測試時間   <br/>單位是秒<br/>   
        /// </summary>
        public void Set_test_time(uint testTime_sec)
        {
            _connector.Write($"Source:Time all {testTime_sec}\r\n");//測試時間配置  
            //普賽斯 通常設0 代表一直測下去  由UI層去數秒 再抓結果
        }

        public void test_start()
        {
            _connector.Write($"Sense:Clear all \r\n");//清除該通道 誤碼數 碼總數 誤碼狀態
            Thread.Sleep(200);
            _connector.Write($"Sense:Start all\r\n");
        }

        public string Result(int ch, out double[] result_BER)
        {
            string result_str = _connector.Query($"Status:Result? {ch}");

            result_BER = new double[1];
            result_BER[1] = double.Parse(result_str, System.Globalization.CultureInfo.InvariantCulture);

            return result_str;
        }
    }
    
    public class BERT_MultiLane_ML40004_ML4039 : IBert
    {

        #region -- Multilane_DLL --
        private const string SFF_Multilane_DLL = @"MLBert_API.dll";

        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIConnect")]
        private static extern int apiConnect(byte instance, string ipAddress);


        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIReadBoardID")]
        private static extern int apiReadBoardID(byte instance);


        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIDisconnect")]
        private static extern int apiDisconnect(byte instance);


        //Tx pattern(Patterns: PN7 = 0, PN9 = 1, PN15  = 2, PN23 = 3, PN31 = 4, userDefined = 5, 8:8 pattern = 6)
        //Rx pattern(Patterns: PN7 = 0, PN9 = 1, PN15  = 2, PN23 = 3, PN31 = 4, userDefined = 5, 8:8 pattern = 6, autoDetect = 7)
        [DllImport(SFF_Multilane_DLL, EntryPoint = "APISetPRBSPattern")]
        private static extern bool apiSetPRBSPattern(byte instance, int channel, int txPattern, int rxPattern, int txInvert, int rxInvert);


        //value only 0.00 ~ 1000.00 mV
        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIOutputLevel")]
        private static extern int apiOutputLevel(byte instance, int channel, double Amplitude);

        //value only 0 ~ 100
        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIPostEmphasis")]
        private static extern int apiPostEmphasis(byte instance, int channel, int value);

        //value only 0 ~ 100
        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIPreEmphasis")]
        private static extern int apiPreEmphasis(byte instance, int channel, int value);

        //clockSource, 1 is internal, 0 is external
        [DllImport(SFF_Multilane_DLL, EntryPoint = "APILineRateConfiguration")]
        private static extern int apiLineRateConfiguration(byte instance, double lineRate, int clockSource);

        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIRealTimeBEREnable")]
        private static extern int APIRealTimeBEREnable(byte instance, int enable);

        [DllImport(SFF_Multilane_DLL, EntryPoint = "APISetBERCounter")]
        private static extern int APISetBERCounter(byte instance, UInt32 packetCounter);

        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIDoInstantBER")]
        private static extern int APIDoInstantBER(byte instance, double[] berValues);

        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIReadRealTimeBER")]
        private static extern int apiReadRealTimeBER(byte instance, UInt64[] errorCount, ref UInt32 Time);

        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIConfigureApplication")]
        private static extern int apiConfigureApplication(byte instance, string saveConfig, string saveBathtub, string saveEye, int saveBathtubEnable, int saveEyeEnable);

        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIPRBSVerfication")]
        private static extern int apiPRBSVerfication(byte instacne, int channel);

        [DllImport(SFF_Multilane_DLL, EntryPoint = "APIGetAPIRev")]
        private static extern double apiGetAPIRev();

        #endregion

        private byte _instance;
        //private uint _testtime;
        private double _DataRate;

        //因為要偷塞 測試時間    又要符合interface架構 所以只能在建構子動手腳
        public BERT_MultiLane_ML40004_ML4039(byte instance, string ip)
        {
            _instance = instance;
            int result = apiConnect(_instance, ip);

            if (result != 1)
            {
                throw new Exception("BERT_MultiLane_ML40004_ML4039  連線異常");
            }
        }

        //public BERT_MultiLane_ML40004_ML4039(byte instance, string ip, uint testtime)
        //{
        //    _instance = instance;
        //    _testtime = testtime;

        //    int result = apiConnect(_instance, ip);

        //    if (result != 1)
        //    {
        //        throw new Exception("BERT_MultiLane_ML40004_ML4039  連線異常");
        //    }
        //}

        public void disconnect()
        {
            apiDisconnect(_instance);
        }

        public string GetDeviceInfo()
        {
            string result = "";
            result += $"apiReadBoardID: {apiReadBoardID(_instance)}\r\n";
            result += $"apiGetAPIRev: {apiGetAPIRev()}\r\n";

            return result;
        }

        public string setDataRate(double DataRate)
        {
            _DataRate = DataRate;

            try
            {
                int cmdResult = apiConfigureApplication(_instance, "./clk/", "./bathtubOut/", "./eyeOut/", 0, 0);
                if (cmdResult != 1)
                {
                    throw new Exception("BERT_MultiLane_ML40004_ML4039\r\n use dll apiConfigureApplication to return is !=1");
                }
            }
            catch (Exception)
            {
                throw new Exception("BERT_MultiLane_ML40004_ML4039\r\n use dll apiConfigureApplication 異常");
            }
            


            int clockSource = 1;
            int result = apiLineRateConfiguration(_instance, _DataRate, clockSource);
            if (result != 1)
            {
                string note = "";
                note += "如果第一次設定失敗 → 用外部工具產生時鐘設定檔\r\n";
                note += "啟動一個 multiLane_ClockGenerator.exe \r\n";
                note += "去產生.CLK 檔（時鐘設定檔），放到 / clk 資料夾裡\r\n";
                note += ".CLK 檔是 BERT 內部時鐘晶片的設定檔，會告訴它在指定速率下要怎麼配置時脈\r\n";
                note += "用外部程式產生.CLK 是因為 DLL API 無法直接完成時鐘設定。\r\n";



                System.Diagnostics.Process Proc = new System.Diagnostics.Process();
                string burnpath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "multiLane_ClockGenerator.exe";
                Proc.StartInfo.FileName = @burnpath;

                Proc.StartInfo.UseShellExecute = false;
                Proc.StartInfo.RedirectStandardInput = true;
                Proc.StartInfo.RedirectStandardOutput = true;
                Proc.StartInfo.RedirectStandardError = true;
                Proc.StartInfo.CreateNoWindow = true;

                Proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                Proc.StartInfo.Arguments = " " + _DataRate.ToString();
                try
                {
                    Proc.Start();
                    string sErrorMsg = Proc.StandardOutput.ReadLine();

                    if (!string.IsNullOrEmpty(sErrorMsg) && sErrorMsg.ToLower().Contains("error"))
                    {
                        throw new Exception($"BERT_MultiLane_ML40004_ML4039  setDataRate異常\r\n{note}\r\n{sErrorMsg}");

                    }
                    Proc.WaitForExit();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                //用.CLK 檔再試一次設定速率
                result = apiLineRateConfiguration(_instance, _DataRate, clockSource);
                if (result != 1)
                {
                    string original_note = "原始警告\r\n設定速度失敗:請確認 /clk 資料夾中有對應設定檔: 可用 multiLane_ClockGenerator.exe 產生";
                    throw new Exception($"BERT_MultiLane_ML40004_ML4039  setDataRate異常\r\n用.CLK 檔再試一次設定速率失敗\r\n{original_note}");
                }

            }

            Thread.Sleep(2000); // 等待 PLL 鎖定
            return $"use DLL's apiLineRateConfiguration({_instance}, {_DataRate}, {clockSource})";
        }

        public string setPattern(string PRBS, bool TxInv, bool RxInv)
        {
            if (PRBS.Substring(0,4) != "PRBS")
            {
                throw new Exception($"BERT_MultiLane_ML40004_ML4039\r\nPRBS字串異常：{PRBS} is error");
            }

            string result = "";

            int Pattern = int.Parse(PRBS.Substring(4));
            int int_TxInv = (TxInv == true) ? 1 : 0;
            int int_RxInv = (RxInv == true) ? 1 : 0;

            for (int ch = 0; ch < 4; ch++)
            {
                apiSetPRBSPattern(_instance, ch, Pattern, Pattern, int_TxInv, int_RxInv);
                result += $"apiSetPRBSPattern({_instance}, {ch}, {Pattern}, {Pattern}, {int_TxInv}, {int_RxInv})\r\n";
                Thread.Sleep(200);
            }

            return result;
        }
        //bool Polling_ErrorRate(ref double[] ber_result, UInt32 totaltime, double rate, out bool done);


        public void PPG_on()
        {

        }

        public void PPG_off()
        {

        }

        public void ED_on()
        {

        }

        public void ED_off()
        {

        }


        public void Set_test_time(uint testTime_sec)
        {
            //我要測多久
            int result = APISetBERCounter(_instance, testTime_sec * 1000);

            if (result != 1)
            {
                throw new Exception("BERT_MultiLane_ML40004_ML4039\r\n APISetBERCounter 異常");
            }
        }

        public void test_start()
        {
            APIRealTimeBEREnable(_instance, 0);
            Thread.Sleep(1000);

            //啟動即時 BER 模式
            int result = APIRealTimeBEREnable(_instance, 1);

            if (result != 1)
            {
                throw new Exception("BERT_MultiLane_ML40004_ML4039\r\n APIRealTimeBEREnable異常");
            }
        }

        public string Result(int ch, out double[] result_BER)
        {
            ulong[] errorCount = new ulong[8];
            uint time = 0;

            int result = apiReadRealTimeBER(_instance, errorCount, ref time);
            if (result != 1)
            {
                throw new Exception("BERT_MultiLane_ML40004_ML4039\r\n apiReadRealTimeBER 異常");
            }

            //如果 _DataRate 是 Gbps，那 totalCount 實際上應該要乘 1e9
            double totalCount = time * _DataRate * 1e9;

            string ber_result = $"_DataRate = {_DataRate}\r\n";

            result_BER = new double[8];
            for (int i = 0; i < 8; i++)
            {
                ber_result += $"{ (double)errorCount[i] / totalCount} = {((double)errorCount[i]).ToString("0.000")} / totalCount     time= {time},";

                result_BER[i] = (double)errorCount[i] / totalCount;
            }

            return ber_result;
        }
    }

}
