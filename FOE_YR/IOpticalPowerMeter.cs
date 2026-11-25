using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FOE_YR
{
    public interface IOpticalPowerMeter
    {
        void disconnect();

        string GetDeviceInfo();

        string readOpticalPower();

        //void setOffset(int ch, double offset);

        //double getOffset(int ch);
    }

    public class DigitalMeter_EXFO_1750 : IOpticalPowerMeter
    {
        //參考資料
        //_sCmdWave = "LINS{0}:SENS:POW:WAV {1} NM\x0A";//":sense:power:wavelength 1,1,1, {0}\x0A";
        //_sCmdAttVale = "x0A";
        //_sCmdSetOffset = "LINS{0}:SENSE:CORR:OFFS:MAGN {1}  \x0A";//"sense:power:offset 1,1,1, {0}\x0A";
        ////_sCmdOutStatus = "LINS{0}:OUTP:STAT {1}\x0A";//":output:bblock 1,3,1, {0}\x0A";
        //_sCmdPwrUnit = "LINS{0}:UNIT:POW DBM\x0A";
        //_sCmdReadPwr = "LINS{0}:READ:SCAL:POW:DC?\x0A";//":Read:Power? 1,1,1\x0A";            

        //_sCmdSetOffsetChan = "LINS{0}:SENS{1}:CORR:OFFS:MAGN {2}  \x0A";
        //_sCmdPwrUnitChan = "LINS{0}:UNIT{1}:POW DBM\x0A";
        //_sCmdReadPwrChan = "LINS{0}:READ{1}:SCAL:POW:DC?\x0A";//":Read:Power? 1,1,1\x0A";            


        //Machine_IP_inConfigID = "Exfo_PM_IP";
        //Machine_LINS_inConfigID = "Exfo_PM_LINS_Offset";

        private IDeviceConnector _connector;
        private int _lins;

        public DigitalMeter_EXFO_1750(IDeviceConnector Connector, int LINS)
        {
            this._connector = Connector;

            _lins = LINS;
        }

        public void disconnect()
        {
            _connector.disconnect();
        }

        public string GetDeviceInfo()
        {
            return _connector.Query("*IDN?\x0A").Replace("READY>", "");
        }

        public string readOpticalPower()
        {
            //_sCmdReadPwrChan = "LINS{0}:READ{1}:SCAL:POW:DC?\x0A";//":Read:Power? 1,1,1\x0A"; 

            string result = "";
            for (int i = 1; i < 5; i++)
            {
                result += _connector.Query($"LINS{_lins}:READ{i}:SCAL:POW:DC?\x0A").Replace("READY>","").Trim()+"\r\n";
                Thread.Sleep(200);
            }

            return result;
        }
    }

    public class DigitalMeter_EXFO_1750_8ch : IOpticalPowerMeter //兩台4ch 共組成一台8ch物件
    {
        //private IDeviceConnector _connector1;
        //private int _lins1;

        //private IDeviceConnector _connector2;
        //private int _lins2;

        DigitalMeter_EXFO_1750 _EXFO1750_1 = null;
        DigitalMeter_EXFO_1750 _EXFO1750_2 = null;

        public DigitalMeter_EXFO_1750_8ch(DigitalMeter_EXFO_1750 EXFO1750_1, DigitalMeter_EXFO_1750 EXFO1750_2)
        {
            //this._connector1 = Connector1;
            //_lins1 = LINS1;

            //this._connector2 = Connector2;
            //_lins2 = LINS2;

            this._EXFO1750_1 = EXFO1750_1;
            this._EXFO1750_2 = EXFO1750_2;
        }

        public void disconnect()
        {
            //_connector1.disconnect();
            //_connector2.disconnect();

            _EXFO1750_1.disconnect();
            _EXFO1750_2.disconnect();
        }

        public string GetDeviceInfo()
        {
            //string result1 = _connector1.Query("*IDN?\x0A").Replace("READY>", "");
            //string result2 = _connector2.Query("*IDN?\x0A").Replace("READY>", "");

            //return $"\r\n{result1}\r\n{result2}\r\n";

            string result1 = _EXFO1750_1.GetDeviceInfo();
            string result2 = _EXFO1750_2.GetDeviceInfo();

            return $"\r\n{result1}\r\n{result2}\r\n";
        }

        public string readOpticalPower()
        {
            //_sCmdReadPwrChan = "LINS{0}:READ{1}:SCAL:POW:DC?\x0A";//":Read:Power? 1,1,1\x0A"; 

            //string result1 = "";
            //string result2 = "";
            //for (int i = 1; i < 5; i++)
            //{
            //    result1 += _connector1.Query($"LINS{_lins1}:READ{i}:SCAL:POW:DC?\x0A").Replace("READY>", "").Trim() + "\r\n";
            //    result2 += _connector2.Query($"LINS{_lins2}:READ{i}:SCAL:POW:DC?\x0A").Replace("READY>", "").Trim() + "\r\n";
            //    Thread.Sleep(200);
            //}

            //return $"\r\n{result1}\r\n{result2}\r\n";

            string result1 = _EXFO1750_1.readOpticalPower();
            string result2 = _EXFO1750_2.readOpticalPower();

            return $"\r\n{result1}\r\n{result2}\r\n";
        }
    }

    public class DigitalMeter_PSS_OPM8 : IOpticalPowerMeter
    {
        private IDeviceConnector _connector;
        private int _lins;

        public DigitalMeter_PSS_OPM8(IDeviceConnector Connector)
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

        public string readOpticalPower()
        {
            return "";
        }
    }

}
