using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FOE_YR
{
    //原則上 不同的站都使用不同的DCA功能  
    //所以 會有   到底 interface要改   還是  做個萬用的查詢 多的都塞進去

    public enum DCA_QueryResultType
    {
        TDECQ,
        RLM,
        OOMA,
        OER,
        Eye23,
        Eye12,
        Eye01,

        Amplitude,
        TxRiseT,
        TxFallT,
        EyeWidth
    }

    public interface IDCA
    {
        void disconnect();

        string GetDeviceInfo();

        void autoScale();

        void Run();

        string Query_power();

        string Query_ER();

        double Query_Cross();

        (double Jitter_ps_PP, double Jitter_ps_RMS) Query_Jitter();//單位都以ps  皮秒 

        double Query_Margin();

        string Query_result(DCA_QueryResultType Query_result_type);

        void SaveImageWithPath(string Pathfilename);

        void OpenChannel(int channel);

        void CloseChannel(int channel);

        void SetMask(string file_name);

        void SetAttenuator(string ch, string value);
    }

    public class DCA_Dummy : IDCA
    {
        public void disconnect() { }

        public string GetDeviceInfo() { return "The DCA is dummy"; }

        public void autoScale() => Thread.Sleep(500);

        public void Run() => Thread.Sleep(500);

        public string Query_power() => "NA";

        public string Query_ER() => "NA";

        public double Query_Cross() => double.NaN;

        public (double Jitter_ps_PP, double Jitter_ps_RMS) Query_Jitter() => (double.NaN, double.NaN);//單位都以ps  皮秒 

        public double Query_Margin() => double.NaN;

        public string Query_result(DCA_QueryResultType Query_result_type) => "NA";

        public void SaveImageWithPath(string Pathfilename) { }

        public void OpenChannel(int channel) { }

        public void CloseChannel(int channel) { }

        public void SetMask(string file_name) { }

        public void SetAttenuator(string ch, string value) { }

    }

    public class DCA_Keysight86100D_FlexDCA : IDCA
    {
        private IDeviceConnector _connector;

        public DCA_Keysight86100D_FlexDCA(IDeviceConnector Connector)
        {
            this._connector = Connector;
        }

        public void disconnect()
        {
            _connector.disconnect();
            _connector = null; // 連線清空   防止重複使用
        }

        public string GetDeviceInfo()
        {
            return _connector.Query("*IDN?\x0A");
        }

        public void autoScale()
        {
            _connector.Write("SYSTem:AUToscale\x0A");
        }

        public void Run()
        {
            _connector.Write("ACQuire:RUN\x0A");

            //string str_tmp = "0";
            //do
            //{
            //    str_tmp = _controller.Query("*OPC?\x0A");
            //    Thread.Sleep(500);
            //} while (str_tmp != "1\n");
            //return true;
        }

        public string Query_power()
        {
            return _connector.Query("MEASure:EYE:APOWer?\x0A");
        }

        public string Query_ER()
        {
            return _connector.Query("MEASure:EYE:ERATio?\x0A");
        }

        public double Query_Cross()
        {
            return double.Parse(_connector.Query("MEASure:EYE:CROSsing?\x0A"));
        }

        public (double Jitter_ps_PP, double Jitter_ps_RMS) Query_Jitter()
        {
            _connector.Write("MEASure:EYE:JITTer:FORMat PP\x0A");
            double Jitter_PP = double.Parse(_connector.Query("MEASure:EYE:JITTer?\x0A")) * 1E12;

            Thread.Sleep(200);

            _connector.Write("MEASure:EYE:JITTer:FORMat RMS\x0A");
            double Jitter_RMS = double.Parse(_connector.Query("MEASure:EYE:JITTer?\x0A")) * 1E12;

            return (Jitter_PP, Jitter_RMS);
        }

        public double Query_Margin()
        {
            return double.Parse(_connector.Query("MEASure:MTESt1:MARGin?\x0A"));
        }

        public string Query_result(DCA_QueryResultType queryType)
        {
            throw new Exception("物件 DCA_Keysight86100D_FlexDCA 函數Query_result()  無支援");
        }

        public void SaveImageWithPath(string Pathfilename)
        {
            //先修改預設路徑 及 檔名 及 可支援的副檔名
            //: DISK: SIMage: FNAMe "D:/ gg.png"
            //再存圖
            //: DISK: SIMage: SAVE

            _connector.Write($":disk:SIMage:FNAMe \"{Pathfilename}\"\x0A");
            Thread.Sleep(200);
            _connector.Write($":DISK:SIMage:SAVE\x0A");
        }

        public void OpenChannel(int channel)
        {
            //"CHAN1A", "CHAN2A", "CHAN3A", "CHAN4A"
            _connector.Write($":CHAN{channel}A:display on \x0A");
        }

        public void CloseChannel(int channel)
        {
            //"CHAN1A", "CHAN2A", "CHAN3A", "CHAN4A"
            _connector.Write($":CHAN{channel}A:display off \x0A");
        }

        public void SetMask(string file_name)
        {
            //bool IObool = true;
            //IObool &= sendCommand(":MTESt1:DISPlay ON");
            //string sPath = $"c:\\scope\\masks\\{file_name}";
            //IObool &= sendCommand(string.Format(":MTESt1:LOAD:FNAMe \"{0}\"", sPath));
            //IObool &= sendCommand(string.Format(":MTESt1:LOAD"));

            _connector.Write(":MTESt1:DISPlay ON\x0A");
            Thread.Sleep(100);
            string sPath = $"c:\\scope\\masks\\{file_name}";
            _connector.Write($":MTESt1:LOAD:FNAMe \"{sPath}\"\x0A");
            Thread.Sleep(100);
            _connector.Write($":MTESt1:LOAD\x0A");
        }

        public void SetAttenuator(string ch, string value)
        {
            //Ch定義   //"CHAN1A", "CHAN2A", "CHAN3A", "CHAN4A"

            _connector.Write($":CHAN{ch}A:ATTenuator:STATe ON\x0A");
            Thread.Sleep(100);
            _connector.Write($":CHAN{ch}A:ATTenuator:DECibels {value}\x0A");
            Thread.Sleep(100);

            //是否要加詢問  在確定有正確設定
            //_controller.Query($":{ch}:ATTenuator:DECibels?\x0A");
        }
    }

    public class DCA_Keysight_DCA_M_N1092A_USBconnPC : IDCA
    {
        private IDeviceConnector _connector;

        public DCA_Keysight_DCA_M_N1092A_USBconnPC(IDeviceConnector Connector)
        {
            this._connector = Connector;
        }

        public void disconnect()
        {
            _connector.disconnect();
            _connector = null; // 連線清空   防止重複使用
        }

        public string GetDeviceInfo()
        {
            return _connector.Query("*IDN?\x0A");
        }

        public void autoScale()
        {
            _connector.Write("SYSTem:AUToscale\x0A");
        }

        public void Run()
        {
            _connector.Write("ACQuire:RUN\x0A");
        }

        public string Query_power()
        {
            return _connector.Query("MEASure:EYE:APOWer?\x0A");
        }

        public string Query_ER()
        {
            return _connector.Query("MEASure:EYE:ERATio?\x0A");
        }

        public double Query_Cross()
        {
            return double.Parse(_connector.Query("MEASure:EYE:CROSsing?\x0A"));
        }

        public (double Jitter_ps_PP, double Jitter_ps_RMS) Query_Jitter()
        {
            _connector.Write("MEASure:EYE:JITTer:FORMat PP\x0A");
            double Jitter_PP = double.Parse(_connector.Query("MEASure:EYE:JITTer?\x0A")) * 1E12;

            Thread.Sleep(200);

            _connector.Write("MEASure:EYE:JITTer:FORMat RMS\x0A");
            double Jitter_RMS = double.Parse(_connector.Query("MEASure:EYE:JITTer?\x0A")) * 1E12;

            return (Jitter_PP, Jitter_RMS);
        }

        public double Query_Margin()
        {
            return double.Parse(_connector.Query("MEASure:MTESt1:MARGin?\x0A"));
        }

        public string Query_result(DCA_QueryResultType queryType)
        {

            if (queryType == DCA_QueryResultType.OOMA)
            {
                double ER = double.Parse(Query_ER());
                double AveragePower_dBm = double.Parse(Query_power());

                Optical_transform O_transform = new Optical_transform();
                string OMA = O_transform.SenOMA(AveragePower_dBm, ER).ToString();

                string result = $"ER = {ER}\r\nPower_dBm = {AveragePower_dBm}\r\nOMA = {OMA}";

                //return result;
                return OMA;
            }
            else if (queryType == DCA_QueryResultType.Amplitude)
            {
                return _connector.Query(":MEASure:EYE:AMPLitude?\x0A");
            }
            else if (queryType == DCA_QueryResultType.TxRiseT)
            {
                return _connector.Query(":MEASure:EYE:RISetime?\x0A");
            }
            else if (queryType == DCA_QueryResultType.TxFallT)
            {
                return _connector.Query(":MEASure:EYE:FALLtime?\x0A");
            }
            else if (queryType == DCA_QueryResultType.EyeWidth)
            {
                return _connector.Query(":MEASure:EYE:EWIDth?\x0A");
            }
            else
            {
                throw new NotSupportedException($"Test item {queryType} is not supported on this device.");
            }


        }

        public void SaveImageWithPath(string Pathfilename)
        {
            //先修改預設路徑 及 檔名 及 可支援的副檔名
            //: DISK: SIMage: FNAMe "D:/ gg.png"
            //再存圖
            //: DISK: SIMage: SAVE

            _connector.Write($":disk:SIMage:FNAMe \"{Pathfilename}\"\x0A");
            Thread.Sleep(200);
            _connector.Write($":DISK:SIMage:SAVE\x0A");
        }

        public void OpenChannel(int channel)
        {

        }

        public void CloseChannel(int channel)
        {

        }

        public void SetMask(string file_name)
        {
            //bool IObool = true;
            //IObool &= sendCommand(":MTESt1:DISPlay ON");
            //string sPath = $"c:\\scope\\masks\\{file_name}";
            //IObool &= sendCommand(string.Format(":MTESt1:LOAD:FNAMe \"{0}\"", sPath));
            //IObool &= sendCommand(string.Format(":MTESt1:LOAD"));

            _connector.Write(":MTESt1:DISPlay ON\x0A");
            Thread.Sleep(100);
            string sPath = $"c:\\scope\\masks\\{file_name}";
            _connector.Write($":MTESt1:LOAD:FNAMe \"{sPath}\"\x0A");
            Thread.Sleep(100);
            _connector.Write($":MTESt1:LOAD\x0A");
        }

        public void SetAttenuator(string ch, string value)
        {
            //Ch定義   //"CHAN1A", "CHAN2A", "CHAN3A", "CHAN4A"

            _connector.Write($":CHAN1A:ATTenuator:STATe ON\x0A");
            Thread.Sleep(100);
            _connector.Write($":CHAN1A:ATTenuator:DECibels {value}\x0A");
            Thread.Sleep(100);

            //是否要加詢問  在確定有正確設定
            //_controller.Query($":{ch}:ATTenuator:DECibels?\x0A");
        }
    }

    public class DCA_Anritsu_MP2110A : IDCA
    {
        private IDeviceConnector _connector;

        public DCA_Anritsu_MP2110A(IDeviceConnector Connector)
        {
            this._connector = Connector;
        }

        public void disconnect()
        {
            _connector.disconnect();
            _connector = null; // 連線清空   防止重複使用
        }

        public string GetDeviceInfo()
        {
            return _connector.Query("*IDN?\x0A");
        }

        public void autoScale()
        {
            bool passs = true;

            _connector.Write(":DISPlay:WINDow:SCALe:AUTOscale BOTH\x0A");//autoScale
            Thread.Sleep(1000);

            _connector.Write(":CONFigure:MEASure:PAM:TEQualizer:CALCulate:ALL\x0A");//Calculate
            Thread.Sleep(1000);

            //passs &= sendCommand(":SCOP:SAMP:STAT RUN");//Sampling
            //Thread.Sleep(1000);

        }

        public void Run()
        {
            try
            {
                _connector.Write(":SENSe:SAMPling:STATus RUN\x0A");
            }
            catch (Exception)
            {
                throw new Exception("物件 DCA_Anritsu_MP2110A 函數Run()  有問題");
            }

        }

        public string Query_power()
        {
            return "";
        }

        public string Query_ER()
        {
            return "";
        }

        public double Query_Cross()
        {
            throw new NotSupportedException("This device does not support Query_Cross()");
        }

        public (double Jitter_ps_PP, double Jitter_ps_RMS) Query_Jitter()
        {
            throw new NotSupportedException("This device does not support Query_Jitter()");
        }

        public double Query_Margin()
        {
            throw new NotSupportedException("This device does not support Query_Margin()");
        }

        public string Query_result(DCA_QueryResultType queryType)
        {
            string command;


            switch (queryType)
            {
                case DCA_QueryResultType.TDECQ:
                    command = ":FETCh:AMPLitude:TEQualizer:TDECQ:ALL?\x0A";
                    break;
                case DCA_QueryResultType.RLM:
                    command = ":FETCh:AMPLitude:TEQualizer:LINearity:ALL?\x0A";
                    break;
                case DCA_QueryResultType.OOMA:
                    command = ":FETCh:AMPLitude:TEQualizer:OOMA:DBM:ALL?\x0A";
                    break;
                case DCA_QueryResultType.OER:
                    command = ":FETCh:AMPLitude:TEQualizer:OER:ALL?\x0A";
                    break;
                case DCA_QueryResultType.Eye23:
                    command = ":FETCh:AMPLitude:TEQualizer:EYE2:HEIGht:ALL?\x0A";
                    break;
                case DCA_QueryResultType.Eye12:
                    command = ":FETCh:AMPLitude:TEQualizer:EYE1:HEIGht:ALL?\x0A";
                    break;
                case DCA_QueryResultType.Eye01:
                    command = ":FETCh:AMPLitude:TEQualizer:EYE0:HEIGht:ALL?\x0A";
                    break;
                default:
                    throw new NotSupportedException($"Test item {queryType} is not supported on this device.");
            }



            string result = "";
            try
            {
                result= _connector.Query(command);
            }
            catch (Exception)
            {
                throw new Exception("物件 DCA_Anritsu_MP2110A 函數Query_result()  有問題");
            }

            return result;
        }

        public void SaveImageWithPath(string Pathfilename)
        {
            var path_name = Pathfilename.Split(',');
            //":SYSTem:PRINt:COPY \"TempScreen.png\",\"C:\\Screen Copy\"" //以前開發文件查到的
            string command = $":SYSTem:PRINt:COPY \"{path_name[1]}\",\"{path_name[0]}\"\x0A";
            try
            {
                _connector.Write(command);
            }
            catch (Exception)
            {
                throw new Exception("物件 DCA_Anritsu_MP2110A 函數SaveImageWithPath()  有問題");
            }
        }

        public void OpenChannel(int channel)
        {

        }

        public void CloseChannel(int channel)
        {

        }

        public void SetMask(string file_name)
        {

        }

        public void SetAttenuator(string ch, string value)
        {

        }
    }

}
