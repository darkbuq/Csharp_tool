using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FOE_YR
{
    public interface IDCA
    {
        string GetDeviceInfo();
        void autoScale();
        void Run();
        string Query_power();
        string Query_ER();
        string Query_Cross();
        string Query_Jitter();
        string Query_Margin();

        void SaveImageWithPath(string Pathfilename);

        void OpenChannel(int channel);
        void CloseChannel(int channel);
        void SetMask(string file_name);
        void SetAttenuator(string ch, string value);
    }

    public class DCA_Keysight86100D_FlexDCA : IDCA
    {
        private IDeviceConnector _controller;

        public DCA_Keysight86100D_FlexDCA(IDeviceConnector Controller)
        {
            this._controller = Controller;
        }

        public string GetDeviceInfo()
        {
            return _controller.Query("*IDN?\x0A");
        }

        public void autoScale()
        {
            _controller.Write("SYSTem:AUToscale\x0A");
        }

        public void Run()
        {
            _controller.Write("ACQuire:RUN\x0A");

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
            return _controller.Query("MEASure:EYE:APOWer?\x0A");
        }

        public string Query_ER()
        {
            return _controller.Query("MEASure:EYE:ERATio?\x0A");
        }

        public string Query_Cross()
        {
            return _controller.Query("MEASure:EYE:CROSsing?\x0A");
        }

        public string Query_Jitter()
        {
            _controller.Write("MEASure:EYE:JITTer:FORMat PP\x0A");
            return _controller.Query("MEASure:EYE:JITTer?\x0A");
        }

        public string Query_Margin()
        {
            return _controller.Query("MEASure:MTESt1:MARGin?\x0A");
        }

        public void SaveImageWithPath(string Pathfilename)
        {
            //先修改預設路徑 及 檔名 及 可支援的副檔名
            //: DISK: SIMage: FNAMe "D:/ gg.png"
            //再存圖
            //: DISK: SIMage: SAVE

            _controller.Write($":disk:SIMage:FNAMe \"{Pathfilename}\"\x0A");
            Thread.Sleep(200);
            _controller.Write($":DISK:SIMage:SAVE\x0A");
        }

        public void OpenChannel(int channel)
        {
            //"CHAN1A", "CHAN2A", "CHAN3A", "CHAN4A"
            _controller.Write($":CHAN{channel}A:display on \x0A");
        }

        public void CloseChannel(int channel)
        {
            //"CHAN1A", "CHAN2A", "CHAN3A", "CHAN4A"
            _controller.Write($":CHAN{channel}A:display off \x0A");
        }

        public void SetMask(string file_name)
        {
            //bool IObool = true;
            //IObool &= sendCommand(":MTESt1:DISPlay ON");
            //string sPath = $"c:\\scope\\masks\\{file_name}";
            //IObool &= sendCommand(string.Format(":MTESt1:LOAD:FNAMe \"{0}\"", sPath));
            //IObool &= sendCommand(string.Format(":MTESt1:LOAD"));

            _controller.Write(":MTESt1:DISPlay ON\x0A");
            Thread.Sleep(100);
            string sPath = $"c:\\scope\\masks\\{file_name}";
            _controller.Write($":MTESt1:LOAD:FNAMe \"{sPath}\"\x0A");
            Thread.Sleep(100);
            _controller.Write($":MTESt1:LOAD\x0A");
        }

        public void SetAttenuator(string ch, string value)
        {
            //Ch定義   //"CHAN1A", "CHAN2A", "CHAN3A", "CHAN4A"

            _controller.Write($":CHAN{ch}A:ATTenuator:STATe ON\x0A");
            Thread.Sleep(100);
            _controller.Write($":CHAN{ch}A:ATTenuator:DECibels {value}\x0A");
            Thread.Sleep(100);

            //是否要加詢問  在確定有正確設定
            //_controller.Query($":{ch}:ATTenuator:DECibels?\x0A");
        }
    }
}
