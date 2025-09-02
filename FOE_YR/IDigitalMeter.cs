using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOE_YR
{
    public interface IDigitalMeter
    {
        void disconnect();

        string GetDeviceInfo();

        string readVoltage();
    }

    public class DigitalMeter_Dummy : IDigitalMeter
    {
        public DigitalMeter_Dummy() { }

        public void disconnect() { }

        public string GetDeviceInfo() => "The DigitalMeter is Dummy";

        public string readVoltage() => "NA";
    }

    public class DigitalMeterHP34401 : IDigitalMeter
    {
        private IDeviceConnector _connector;

        public DigitalMeterHP34401(IDeviceConnector Connector)//_nGBIB_ID = 10;
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

        public string readVoltage()
        {
            return _connector.Query("Read?\x0A");
        }
    }
}
