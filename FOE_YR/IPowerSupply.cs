using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOE_YR
{
    public interface IPowerSupply
    {
        void disconnect();

        string GetDeviceInfo();

        void setPowerState(bool bOn);

        void setVcc(int channel, string vccValue);

        string getVcc(int channel);

        string getICC(int channel);
        
    }

    public class PowerSupply_Dummy : IPowerSupply
    {        
        public void disconnect() { }

        public string GetDeviceInfo() => "The PowerSupply is dummy";

        public void setPowerState(bool bOn) { }

        public void setVcc(int channel, string vccValue) { }

        public string getVcc(int channel) => "NA";

        public string getICC(int channel) => "NA";
    }

    public class PowerSupply_PST3202 : IPowerSupply
    {
        private IDeviceConnector _connector;
        public PowerSupply_PST3202(IDeviceConnector Connector)
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

        public void setPowerState(bool bOn)
        {
            int on_off = bOn ? 1 : 0;
            _connector.Write($":output:state {on_off}\x0A");
        }

        public void setVcc(int channel, string vccValue)
        {
            _connector.Write($":channel{channel} :voltage {vccValue}\x0A");
        }

        public string getVcc(int channel)
        {
            return _connector.Query($":CHANnel{channel}:MEASure:VOLTage ?\x0A");
        }

        public string getICC(int channel)
        {
            return _connector.Query($":channel{channel} :measure:current?\x0A");
        }

    }

    public class PowerSupply_KeySight_E3646A : IPowerSupply
    {
        private IDeviceConnector _connector;
        public PowerSupply_KeySight_E3646A(IDeviceConnector Connector)
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

        public void setPowerState(bool bOn)
        {
            int on_off = bOn ? 1 : 0;
            _connector.Write($"OUTP {on_off}\x0A");
        }

        public void setVcc(int channel, string vccValue)//本身指令只支援預設ch 要控別的ch 要在設備面板上先切換好
        {
            try
            {
                double.Parse(vccValue);
            }
            catch (Exception)
            {
                throw;
            }
            _connector.Write($"VOLT {vccValue}\x0A");
        }

        public string getVcc(int channel)//本身指令只支援預設ch 要控別的ch 要在設備面板上先切換好
        {
            return _connector.Query($"Measure:Voltage?\x0A");
        }


        public string getICC(int channel)//本身指令只支援預設ch 要控別的ch 要在設備面板上先切換好
        {
            return _connector.Query($"Measure:Current?\x0A");
        }
    }
}
