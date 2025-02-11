using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOE_YR
{
    public interface IDigitalMeter
    {
        string readVoltage();
    }

    public class DigitalMeterHP34401 : IDigitalMeter
    {
        private IDeviceConnector _controller;

        public DigitalMeterHP34401(IDeviceConnector Controller)//_nGBIB_ID = 10;
        {
            this._controller = Controller;
        }

        public string readVoltage()
        {
            return _controller.Query("Read?\x0A");
        }
    }
}
