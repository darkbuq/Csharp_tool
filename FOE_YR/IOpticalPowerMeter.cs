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

        public DigitalMeter_EXFO_1750(IDeviceConnector Connector, int LINS)//_nGBIB_ID = 10;
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
}
