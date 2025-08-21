using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOE_YR
{
    public interface ISwitch
    {
        void disconnect();

        string GetDeviceInfo();
        void setChannel(int nChannel);
    }

    public class OSwitch_EOS104 : ISwitch
    {
        private IDeviceConnector _connector;
        public OSwitch_EOS104(IDeviceConnector Connector)
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

        public void setChannel(int nChannel)
        {
            //protected string _sCmdSetChannel = "CH{0}\x0A";
            _connector.Write($"CH{nChannel}\x0A");
        }
    }
}
