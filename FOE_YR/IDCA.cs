using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FOE_YR
{
    public interface IDCA
    {
        void disconnect();

        string GetDeviceInfo();
        void autoScale();
        void Run();
        string Query_power();
        string Query_ER();
        string Query_Cross();
        string Query_Jitter();
        string Query_Margin();
        string Query_result(string test_items);

        void SaveImageWithPath(string Pathfilename);

        void OpenChannel(int channel);
        void CloseChannel(int channel);
        void SetMask(string file_name);
        void SetAttenuator(string ch, string value);
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

        public string Query_Cross()
        {
            return _connector.Query("MEASure:EYE:CROSsing?\x0A");
        }

        public string Query_Jitter()
        {
            _connector.Write("MEASure:EYE:JITTer:FORMat PP\x0A");
            return _connector.Query("MEASure:EYE:JITTer?\x0A");
        }

        public string Query_Margin()
        {
            return _connector.Query("MEASure:MTESt1:MARGin?\x0A");
        }

        public string Query_result(string test_items)
        {
            return "";
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
        public string Query_Cross()
        {
            return _connector.Query("MEASure:EYE:CROSsing?\x0A");
        }
        public string Query_Jitter()
        {
            _connector.Write("MEASure:EYE:JITTer:FORMat PP\x0A");
            return _connector.Query("MEASure:EYE:JITTer?\x0A");
        }
        public string Query_Margin()
        {
            return _connector.Query("MEASure:MTESt1:MARGin?\x0A");
        }
        public string Query_result(string test_items)
        {
            return "undone";
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
        public string Query_Cross()
        {
            return "";
        }
        public string Query_Jitter()
        {
            return "";
        }
        public string Query_Margin()
        {
            return "";
        }

        public string Query_result(string test_items)
        {
            string command;

            if (test_items=="TDECQ")
            {
                //:FETCh: AMPLitude: TDEC[:CURRent][:{ CHA | CHB | CHC | CHD | ALL}]?   //文件查到的
                //string strCmd = blTEQ ? ":FETCh:AMPLitude:TEQualizer:TDECQ?" : ":FETCh:AMPLitude:TDECQ?";//舊的程式

                command = ":FETCh:AMPLitude:TEQualizer:TDECQ:ALL?\x0A";
            }
            else if (test_items == "RLM")
            {
                //:FETCh:AMPLitude[:TEQualizer]:LINearity[:CURRent][:{CHA|CHB|CHC|CHD|ALL}]?   //文件查到的
                //string strCmd = blTEQ ? ":FETCh:AMPLitude:TEQualizer:LINearity?" : ":FETCh:AMPLitude:LINearity?";  //舊的程式
                command = ":FETCh:AMPLitude:TEQualizer:LINearity:ALL?\x0A";
            }
            else if (test_items == "power")
            {
                command = ":FETCh:AMPLitude:AVEPower:DBM:ALL?\x0A";
            }
            else if (test_items == "OOMA")
            {
                //:FETCh:AMPLitude[:TEQualizer]:OOMA:DBM[:CURRent][:{CHA|CHB|CHC|CHD|ALL}]?
                command = ":FETCh:AMPLitude:TEQualizer:OOMA:DBM:ALL?\x0A";
            }
            //else if (test_items == "OMA_TQ")  //這是 OMA減TDECQ
            //{
            //    command = "";
            //}
            else if (test_items == "OER")
            {
                //:FETCh:AMPLitude[:TEQualizer]:OER[:CURRent][:{CHA|CHB|CHC|CHD|ALL}]?
                command = ":FETCh:AMPLitude:TEQualizer:OER:ALL?\x0A";
            }
            else if (test_items == "Eye23")
            {
                //:FETCh:AMPLitude[:TEQualizer]:EYE[0|1|2]:HEIGht[:CURRent][:{CHA|CHB|CHC|CHD|ALL}]?
                command = ":FETCh:AMPLitude:TEQualizer:EYE2:HEIGht:ALL?\x0A";
            }
            else if (test_items == "Eye12")
            {
                //:FETCh:AMPLitude[:TEQualizer]:EYE[0|1|2]:HEIGht[:CURRent][:{CHA|CHB|CHC|CHD|ALL}]?
                command = ":FETCh:AMPLitude:TEQualizer:EYE1:HEIGht:ALL?\x0A";
            }
            else if (test_items == "Eye01")
            {
                //:FETCh:AMPLitude[:TEQualizer]:EYE[0|1|2]:HEIGht[:CURRent][:{CHA|CHB|CHC|CHD|ALL}]?
                command = ":FETCh:AMPLitude:TEQualizer:EYE0:HEIGht:ALL?\x0A";
            }
            else
            {
                throw new Exception("物件 DCA_Anritsu_MP2110A 函數Query_result()  參數有問題");
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
