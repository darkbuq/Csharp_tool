using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOE_YR
{
    public interface IAttenuator
    {
        void disconnect();

        string GetDeviceInfo();

        void SetValueByChanel(double dAttValue, int ch, out string cmd);

        void SetOffsetByChanel(double dOffset, int ch, out string cmd);

        string GetValueByChanel(int ch, out string cmd);

        string GetOffsetByChanel(int ch, out string cmd);
    }

    public class Attenuator_EXFO_IQS610P_IQS3150 : IAttenuator
    {
        private IDeviceConnector _connector;

        public Attenuator_EXFO_IQS610P_IQS3150(IDeviceConnector Connector)
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

        public void SetValueByChanel(double dAttValue, int ch, out string cmd)
        {
            //_sCmdAttVale = "LINS{0}{1}:INP:ATT {2} DB\x0A";//":output:attenuation 1,3,1, {0}\x0A";

            int _nDeviceID = 1;
            int Lins = ch;
            cmd = $"LINS{_nDeviceID}{Lins}:INP:ATT {dAttValue.ToString("F3")} DB\x0A";
            _connector.Write(cmd);
        }

        public void SetOffsetByChanel(double dOffset, int ch, out string cmd)
        {
            //_sCmdSetOffset = "LINS{0}{1}:INP:OFFS {2} DB\x0A";//":output:attenuation:offset 1,3,1,{0}\x0A";

            int _nDeviceID = 1;
            int Lins = ch;
            cmd = $"LINS{_nDeviceID}{Lins}:INP:OFFS {dOffset.ToString("F3")} DB\x0A";
            _connector.Write(cmd);
        }

        public string GetValueByChanel(int ch, out string cmd)
        {
            //_sCmdAtt = "LINS{0}{1}:INP:ATT?\x0A";

            int _nDeviceID = 1;
            int Lins = ch;
            cmd = $"LINS{_nDeviceID}{Lins}:INP:ATT?\x0A";
            return _connector.Query(cmd);
        }

        public string GetOffsetByChanel(int ch, out string cmd)
        {
            //_sCmdGetOffset = "LINS{0}{1}:INP:OFFS?\x0A";

            int _nDeviceID = 1;
            int Lins = ch;
            cmd = $"LINS{_nDeviceID}{Lins}:INP:OFFS?\x0A";
            return _connector.Query(cmd);
        }
    }
}
