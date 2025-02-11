using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOE_YR
{
    public interface ISwitch
    {
        string GetDeviceInfo();
        void setChannel(int nChannel);
    }

    public class OSwitch_EOS104 : ISwitch
    {
        private IDeviceConnector _controller;
        public OSwitch_EOS104(IDeviceConnector Controller)
        {
            this._controller = Controller;
        }

        public string GetDeviceInfo()
        {
            return _controller.Query("*IDN?\x0A");
        }

        public void setChannel(int nChannel)
        {
            //protected string _sCmdSetChannel = "CH{0}\x0A";
            _controller.Write($"CH{nChannel}\x0A");
        }
    }
}
