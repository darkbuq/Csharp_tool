using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOE_YR
{
    public interface IPowerSupply
    {
        string GetDeviceInfo();
        //bool connect();
        void setPowerState(bool bOn);

        void setVcc(int channel, string vccValue);
        string getVcc(int channel);


        string getICC(int channel);

        //bool SelectOutputChannel(int channel);
        //void disconnect();
    }

    public class PowerSupply_PST3202 : IPowerSupply
    {
        private IDeviceConnector _controller;
        public PowerSupply_PST3202(IDeviceConnector Controller)
        {
            this._controller = Controller;
        }

        public string GetDeviceInfo()
        {
            return _controller.Query("*IDN?\x0A");
        }

        public void setPowerState(bool bOn)
        {
            int on_off = bOn ? 1 : 0;
            _controller.Write($":output:state {on_off}\x0A");
        }

        public void setVcc(int channel, string vccValue)
        {
            _controller.Write($":channel{channel} :voltage {vccValue}\x0A");
        }

        public string getVcc(int channel)
        {
            return _controller.Query($":CHANnel{channel}:MEASure:VOLTage ?\x0A");
        }

        public string getICC(int channel)
        {
            return _controller.Query($":channel{channel} :measure:current?\x0A");
        }

    }
}
