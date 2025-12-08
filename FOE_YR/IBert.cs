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
        BertTestResult GetResult();
    }

    public struct BertTestResult
    {
        //bool status, double[] BER, double[] PreBER, double[] PostBER, double[] margin
        public bool status { get; set; }
        public double[] BER { get; set; }
        public double[] PreBER { get; set; }
        public double[] PostBER { get; set; }
        public double[] margin { get; set; }

    }

    public class BERT_Dummy : IBert
    {
        public void disconnect() { }

        public string GetDeviceInfo() { return "It's dummy Bert"; }

        public string setDataRate(double DataRate) { return "It's dummy Bert"; }
        public string setPattern(string PRBS, bool TxInv, bool RxInv) { return "It's dummy Bert"; }
        //bool Polling_ErrorRate(ref double[] ber_result, UInt32 totaltime, double rate, out bool done);

        public void PPG_on() { }
        public void PPG_off() { }
        public void ED_on() { }
        public void ED_off() { }
        public void Set_test_time(uint testTime_sec) { }
        public void test_start() { }
        public string Result(int ch, out double[] result_BER)
        {
            result_BER = new double[] { 0.0 };   // Dummy 回傳內容
            return "It's dummy Bert";
        }

        public BertTestResult GetResult()
        {
            int arraySize = 8; // 假設支援 8 個通道

            return new BertTestResult
            {
                status = true,
                
                BER = new double[arraySize],
                PreBER = new double[arraySize],
                PostBER = new double[arraySize],
                margin = new double[arraySize]
            };
        }
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

        public BertTestResult GetResult()
        {
            // 由於您只顯示一個通道的結果，我們假設 ch 索引從 0 開始
            int arraySize = 1;

            return new BertTestResult
            {
                status = true,

                BER = new double[arraySize],
                PreBER = new double[arraySize],
                PostBER = new double[arraySize],
                margin = new double[arraySize]
            };
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


        public void PPG_on() { }

        public void PPG_off() { }

        public void ED_on() { }

        public void ED_off() { }


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

        public BertTestResult GetResult()
        {
            // 由於您只顯示一個通道的結果，我們假設 ch 索引從 0 開始
            int arraySize = 1;

            return new BertTestResult
            {
                status = true,

                BER = new double[arraySize],
                PreBER = new double[arraySize],
                PostBER = new double[arraySize],
                margin = new double[arraySize]
            };
        }
    }

    public class BERT_EXFO_BA4000 : IBert
    {
        
        #region -- EXFO_BA4000 dll --

        const string location = @"";
        const string dll_name = @"BA_API.dll";

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "Connect", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ConnectAPI(string IP, ref bool fwUpgradeNotRequired);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ConnectV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ConnectV2API(string IP, ref byte FWStatus);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ConnectV3", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ConnectV3API(string IP, ref byte FWStatus, ref byte hwMajorVr, ref byte hwMinorVr);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "IsConnected", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IsConnectedAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "HWIsConnected", CallingConvention = CallingConvention.StdCall)]
        private static extern bool HWIsConnectedAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "Disconnect", CallingConvention = CallingConvention.StdCall)]
        public static extern bool DisconnectAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ChangeIP", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ChangeIPAPI(byte[] IP);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SetBAStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBAStatusAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SetPowerTXRX", CallingConvention = CallingConvention.StdCall)]
        private static extern bool SetPowerTXRXAPI(bool powerOn, byte reloadSettings);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "GetPowerTXRX", CallingConvention = CallingConvention.StdCall)]
        private static extern bool GetPowerTXRXAPI(ref bool powerOn);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "GetBAStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetBAStatusAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SwitchPPGEDOptions", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SwitchPPGEDOptionsAPI(ref bool basic, ref bool multiRate, ref bool OneP5Vpp,
            ref bool FEC, ref bool FiftyThreeG, ref bool isPAM4, ref bool is8Ch);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SwitchPPGEDOptionsV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SwitchPPGEDOptionsV2API(ref bool basic, ref bool multiRate, ref bool OneP5Vpp,
            ref bool FEC, ref bool FiftyThreeG, ref bool isPAM4, ref bool is8Ch, ref bool isMA);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SetBAConfig", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBAConfigAPI(byte signalMode, int dataRate, byte clockDiv,
                                                    byte rxSensitivity, ushort ctleValue);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SetBAConfigAdv", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBAConfigAdvAPI(byte signalMode, int dataRate, byte clockDiv,
                                            byte rxSensitivity, ushort ctleValue, byte mapping, byte preCoding);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SetPattern", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetPatternAPI(byte channelIndex, byte patternSelect, UInt64 userPattern, bool isAutoLock, byte fecType);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SeRXPattern", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SeRXPatternAPI(byte channelIndex, byte patternSelect, bool isAutoLock, byte fecType);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ChDisable", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ChDisableAPI(byte channelIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "UpdateTaps", CallingConvention = CallingConvention.StdCall)]
        public static extern bool UpdateTapsAPI(byte channelIndex, double pre, double main, double post,
                double upperEyeHeight, double lowerEyeHeight);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "Update7Taps", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Update7TapsAPI(byte channelIndex,
            double pre1, double pre2, double pre3,
            double main,
            double post1, double post2, double post3,
        double upperEyeHeight, double lowerEyeHeight);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SetCTLE", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetCTLEAPI(byte channelIndex,
            ushort ctleValue);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SetRXSensitivity", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetRXSensitivityAPI(byte channelIndex,
            byte rxSensitivity);


        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "SetBERSettings", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBERSettingsAPI(byte channelIndex, byte BERTType, bool realtimeUpdate,
                int days, int hours, int minutes, int seconds);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "StartBERTest", CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartBERTestAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "StopBERTest", CallingConvention = CallingConvention.StdCall)]
        public static extern bool StopBERTestAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "IsBERTRunning", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IsBERTRunningAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ClearBERTest", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClearBERTestAPI(byte channelIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadBERResult", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultAPI(
                    ref long captureTimeIns,
                    byte[] patternTX,
                    byte[] rxPatternLSB,
                    byte[] rxLockMSB,
                    byte[] rxLockLSB,
                    byte[] rxLock,
                    byte[] rxInvertMSB,
                    byte[] rxInvertLSB,
                    UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
                    UInt64[] bertErrorCount, UInt64[] bertBitCount,
                    double[] realTimer, double[] bertValue,
                    UInt64[] fecCOR, double[] fecBertValues, UInt64[] fecResults
                    );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadBERResultMargin", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultMarginAPI(
            ref long captureTimeIns,
            byte[] patternTX,
            byte[] rxPatternLSB,
            byte[] rxLockMSB,
            byte[] rxLockLSB,
            byte[] rxLock,
            byte[] rxInvertMSB,
            byte[] rxInvertLSB,
            UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
            UInt64[] bertErrorCount, UInt64[] bertBitCount,
            double[] realTimer, double[] bertValue,
            UInt64[] fecCOR, double[] fecBertValues, UInt64[] fecResults,
            double[] margin, double[] marginPct, sbyte[] taps
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadBERResultMarginV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultMarginV2API(
            ref long captureTimeIns,
            byte[] patternTX,
            byte[] rxPatternLSB,
            byte[] rxLockMSB,
            byte[] rxLockLSB,
            byte[] rxLock,
            byte[] rxInvertMSB,
            byte[] rxInvertLSB,
            UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
            UInt64[] bertErrorCount, UInt64[] bertBitCount,
            double[] realTimer, double[] bertValue,
            UInt64[] fecCOR, double[] fecBertValues, UInt64[] fecResults,
            double[] margin, double[] marginPct, sbyte[] taps
            );



        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadMAPower", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadMAPowerAPI(ref double volgate, ref double current);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadMAModuleStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadMAModuleStatusAPI(byte[] status);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadSelectedPPGOptions", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadSelectedPPGOptionsAPI(ref bool basic, ref bool multiRate, ref bool OneP5Vpp,
                ref bool FEC, ref bool FiftyThreeG, ref bool isPAM4, ref bool is8Ch, ref bool isMA);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadDataRate", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadDataRateAPI(ref byte signalMode, ref int dataRate, ref byte clockDiv);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadDataRateAdv", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadDataRateAdvAPI(ref byte signalMode, ref int dataRate, ref byte clockDiv
            , ref byte mapping, ref byte preCoding);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadPatternData", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadPatternDataAPI(
                byte[] patternTX,
                double[] preCursor,
                double[] amplitude,
                double[] postCursor,
                double[] upperEyeHeight,
                double[] lowerEyeHeight,
                byte[] txInvert,
                byte[] patternRX,
                byte[] patternRXLSB,
                bool[] rxAutoLock,
                byte[] rxInvert,
                byte[] fecModeSelect,
                byte[] rxSensitivity,
                ushort[] ctle
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ReadPatternData7T", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadPatternData7TAPI(
                ref byte is7Taps,
                byte[] patternTX,
                double[] preCursor1,
                double[] preCursor2,
                double[] preCursor,
                double[] amplitude,
                double[] postCursor,
                double[] postCursor2,
                double[] postCursor3,
                double[] upperEyeHeight,
                double[] lowerEyeHeight,
                byte[] txInvert,
                byte[] patternRX,
                byte[] patternRXLSB,
                bool[] rxAutoLock,
                byte[] rxInvert,
                byte[] fecModeSelect,
                byte[] rxSensitivity,
                ushort[] ctle
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "Relock", CallingConvention = CallingConvention.StdCall)]
        public static extern bool RelockAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ForceRelock", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ForceRelockAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "ErrorInjection", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ErrorInjectionAPI(byte channelIndex,
            byte bitSelect, byte type, byte gap, byte PktCount);



        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MASetStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MASetStatusAPI(byte color, char[] message);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MASetMessage", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MASetMessageAPI(byte line, char[] message);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MASetPower", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MASetPowerAPI(bool enable, double voltage);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAGetPower", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAGetPowerAPI(ref bool isEnabled, ref double voltageSet, ref double voltage, ref double current);


        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CSpeed", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CSpeedAPI(byte speedIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CReadCurrent", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CReadCurrentAPI(ref byte val);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CReadAdr", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CReadAdrAPI(byte adr, ref byte val);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CReadArrayAdr", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CReadArrayAdrAPI(byte[] adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CReadSeq", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CReadSeqAPI(byte adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CWriteAdr", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CWriteAdrAPI(byte adr, byte val);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CWriteArrayAdr", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CWriteArrayAdrAPI(byte[] adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CWriteSeq", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CWriteSeqAPI(byte adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAI2CWRArray", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CWRArrayAPI(byte[] op, byte[] adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location + dll_name, EntryPoint = "MAIOControl", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAIOControlAPI(bool read, byte index, ref byte val);

        #endregion



        public BERT_EXFO_BA4000(string ip, out bool pass_fail, ref byte FWStatus, out string helptxt)
        {
            //FWStatus = 0;
            pass_fail = ConnectV2API(ip, ref FWStatus);
            

            //FWStatus : 
            //• Return 2 : Update API / GUI
            //• Return 1 : Use GUI to Upgrade
            //• Return 0 : Not Required

            helptxt = "FWStatus :\r\nReturn 2 : Update API / GUI\r\nReturn 1 : Use GUI to Upgrade\r\nReturn 0 : Not Required";
        }


        public void disconnect()
        {
            try
            {
                DisconnectAPI();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetDeviceInfo() { return "This device does not support this function"; }

        public string setDataRate(double DataRate)
        {
            string result = string.Empty;
            try
            {
                SetBAConfigAdvAPI(1, Convert.ToInt32((DataRate * 1E9)), 2, 0, 0, 1, 0);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                //throw;
            }

            return result;
        }

        public string setPattern(string PRBS, bool TxInv, bool RxInv)
        {
            bool status;

            status = SetPatternAPI(0, 28, 0xFFFF0000, true, 3);
            status &= UpdateTapsAPI(0, 0, 600, 0, 0, 0);  //what is this?

            if (status)
            {
                return "the function pass";
            }
            else
            {
                return "the function fail";
            }
        }
        //bool Polling_ErrorRate(ref double[] ber_result, UInt32 totaltime, double rate, out bool done);

        public void PPG_on() { }

        public void PPG_off() { }

        public void ED_on() { }

        public void ED_off() { }

        public void Set_test_time(uint testTime_sec)
        {
            if (testTime_sec > int.MaxValue)
            {
                throw new Exception($"int time_sec = (int)testTime_sec; \r\n有溢位問題 轉型會不正確");
            }
            
            int time_sec = (int)testTime_sec;
            SetBERSettingsAPI(0, 0, false, 0, 0, 0, time_sec);
        }
        public void test_start()
        {
            for (byte ch = 0; ch < 8; ch++)
            {
                try
                {
                    if (!ClearBERTestAPI(ch))
                    {
                        throw new Exception($"Bert物件  函數ClearBERTestAPI({ch}) 失敗");
                    }
                }
                catch (Exception)
                {
                    throw new Exception($"Bert物件  函數ClearBERTestAPI({ch}) 異常");
                }
                Thread.Sleep(200);
            }

            Thread.Sleep(1000);
            bool status = StartBERTestAPI();
            if (!status)
            {
                throw new Exception($"Bert物件  函數StartBERTestAPI() 失敗");
            }
        }
        public string Result(int ch, out double[] result_BER)
        {
            long captureTimeIns=0;
            byte[] patternTX = new byte[9];
            byte[] rxPatternLSB = new byte[9];

            byte[] rxLockMSB = new byte[9];
            byte[] rxLockLSB = new byte[9];

            byte[] rxLock = new byte[9];

            byte[] rxInvertMSB = new byte[9];
            byte[] rxInvertLSB = new byte[9];

            UInt64[] bertErrorCountMSB = new UInt64[9];
            UInt64[] bertErrorCountLSB = new UInt64[9];

            UInt64[] bertErrorCount = new UInt64[9];
            UInt64[] bertBitCount = new UInt64[9];

            double[] realTimer = new double[9];

            double[] bertValue = new double[9];

            UInt64[] fecCOR = new UInt64[9];

            double[] fecBertValues = new double[9];

            UInt64[] fecResults = new UInt64[432];




            //bertErrorCount  誤碼數
            //bertValue  誤碼率
            //bertBitCount  碼總數
            bool status = ReadBERResultAPI(ref captureTimeIns, patternTX, rxPatternLSB, rxLockMSB, rxLockLSB, rxLock, rxInvertMSB, rxInvertLSB, bertErrorCountMSB, bertErrorCountLSB, bertErrorCount, bertBitCount, realTimer, bertValue, fecCOR, fecBertValues, fecResults);

            if (!status)
            {
                throw new Exception($"Bert物件  函數ReadBERResultAPI 失敗");
            }


            result_BER = new double[8];
            string result = "ch fecBertValues bertValue fecBertValues\r\n";
            for (int i = 1; i < 9; i++)
            {
                result += $"CH{i}, ";
                result += $"{fecBertValues[i]}, ";
                result += $"{bertValue[i].ToString("0.00E00")}, ";
                result += $"{fecBertValues[i].ToString("0.00E00")}, ";
                result += "\r\n";

                result_BER[i - 1] = bertValue[i];
            }

            return result;
        }
        public BertTestResult GetResult()
        {

            var result = MarginResult();

            return new BertTestResult
            {
                status = result.status,

                BER = result.BER,
                PreBER = result.PreBER,
                PostBER = result.PostBER,
                margin = result.margin
            };
        }

        private (bool status, double[] BER, double[] PreBER, double[] PostBER, double[] margin) MarginResult()
        {
            long captureTimeIns=0;
            byte[] patternTX = new byte[9];
            byte[] rxPatternLSB = new byte[9];
            byte[] rxLockMSB = new byte[9];
            byte[] rxLockLSB = new byte[9];
            byte[] rxLock = new byte[9];
            byte[] rxInvertMSB = new byte[9];
            byte[] rxInvertLSB = new byte[9];
            UInt64[] bertErrorCountMSB = new UInt64[9];
            UInt64[] bertErrorCountLSB = new UInt64[9];
            UInt64[] bertErrorCount = new UInt64[9];
            UInt64[] bertBitCount = new UInt64[9];
            double[] realTimer = new double[9];
            double[] bertValue = new double[9];
            ulong[] fecCOR = new ulong[9];
            double[] fecBertValues = new double[9];
            UInt64[] fecResults = new UInt64[432];
            double[] margin = new double[9];
            double[] marginPct = new double[9];
            sbyte[] taps = new sbyte[9];


            bool status;
            status = ReadBERResultMarginAPI(
            ref captureTimeIns,
            patternTX,
            rxPatternLSB,
            rxLockMSB,
            rxLockLSB,
            rxLock,
            rxInvertMSB,
            rxInvertLSB,
            bertErrorCountMSB,
            bertErrorCountLSB,
            bertErrorCount,
            bertBitCount,
            realTimer,
            bertValue,//PreBER
            fecCOR,
            fecBertValues,//PostBER
            fecResults,
            margin,
            marginPct,
            taps
            );


            //BER 自己算
            double[] BER = new double[9];
            for (int i = 0; i < 9; i++)
            {
                if (bertBitCount[i] ==0)
                {
                    BER[i] = 0;
                }
                else
                {
                    BER[i] = bertErrorCount[i] / bertBitCount[i];
                }
            }



            return (status, BER, bertValue, fecBertValues, margin);
        }
    }
}
