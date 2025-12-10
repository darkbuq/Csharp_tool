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

        double getVcc(int channel);

        double getICC(int channel);
        
    }

    public class PowerSupply_Dummy : IPowerSupply
    {        
        public void disconnect() { }

        public string GetDeviceInfo() => "The PowerSupply is dummy";

        public void setPowerState(bool bOn) { }

        public void setVcc(int channel, string vccValue) { }

        public double getVcc(int channel) => double.NaN;

        public double getICC(int channel) => double.NaN;
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

        public double getVcc(int channel)
        {
            string temp = _connector.Query($":CHANnel{channel}:MEASure:VOLTage ?\x0A");
            return double.Parse(temp);
        }

        public double getICC(int channel)
        {
            string temp = _connector.Query($":channel{channel} :measure:current?\x0A");
            return double.Parse(temp);
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

        public double getVcc(int channel)//本身指令只支援預設ch 要控別的ch 要在設備面板上先切換好
        {
            string temp = _connector.Query($"Measure:Voltage?\x0A");
            return double.Parse(temp);
        }


        public double getICC(int channel)//本身指令只支援預設ch 要控別的ch 要在設備面板上先切換好
        {
            string temp = _connector.Query($"Measure:Current?\x0A");
            return double.Parse(temp);
        }
    }

    public class PowerSupply_GWInstek_GPP1326 : IPowerSupply
    {
        private IDeviceConnector _connector;

        public PowerSupply_GWInstek_GPP1326(IDeviceConnector Connector)
        {
            //IDeviceConnector _connector = new COM_Connector(txt_PowerSupply_comport.Text,115200, Parity.None,8, StopBits.One,500,500);
            this._connector = Connector;
        }

        public void disconnect()
        {
            _connector.disconnect();
        }

        public string GetDeviceInfo()
        {
            return _connector.Query("*IDN?\n");
        }

        public void setPowerState(bool bOn)//目前看起來沒有運作
        {
            //int on_off = bOn ? 1 : 0;
            //_connector.Write($"OUT{on_off}\n");

            if (bOn)
            {
                _connector.Write("ALLOUTON\n");
            }
            else
            {
                _connector.Write("ALLOUTOFF\n");
            }
            
        }

        public void setVcc(int channel, string vccValue)
        {
            _connector.Write($"VSET{channel}:{vccValue}\n");
        }

        public double getVcc(int channel)
        {
            string temp = _connector.Query($"VSET{channel}?\n");
            return double.Parse(temp);
        }

        public double getICC(int channel)
        {
            string temp = _connector.Query($"IOUT{channel}?\n");
            temp = temp.Replace("A", "");
            return double.Parse(temp);
        }
    }
}
