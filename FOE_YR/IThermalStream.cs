using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FOE_YR
{
    public interface IThermalStream
    {
        void disconnect();
        string GetDeviceInfo();
        void head_down();//吹頭向下
        void head_up();//吹頭向上
        void flowON();//開始吹
        void flowOFF();//不要吹
        void DSNS_type(int type);//設定待測物感測介面
        string DSNS_read();//讀取待測物感測器設定
        void DUTM_ON();//開啟測試物模式
        void DUTM_OFF();//關閉測試物模式
        string read_Dut_Tempature();//讀取待測物溫度值
        void setT(double Temp);//單純機台 設定溫度
        string readSetT();//讀取設定溫度
    }

    public class ThermalStream_Dummy : IThermalStream
    {
        public void disconnect() { }
        public string GetDeviceInfo() { return "It's dummy connector"; }
        public void head_down() { }//吹頭向下
        public void head_up() { }//吹頭向上
        public void flowON() { }//開始吹
        public void flowOFF() { }//不要吹
        public void DSNS_type(int type) { }//設定待測物感測介面
        public string DSNS_read() { return "999"; }//讀取待測物感測器設定
        public void DUTM_ON() { }//開啟測試物模式
        public void DUTM_OFF() { }//關閉測試物模式
        public string read_Dut_Tempature() { return "999"; }//讀取待測物溫度值
        public void setT(double Temp) { }//單純機台 設定溫度
        public string readSetT() { return "999"; }//讀取設定溫度
    }

    public class ThermalStream_TA5000 : IThermalStream
    {
        //protected static string Device_IP = "192.168.1.170";  //one Attenutator only okay
        //protected int Device_Port = 40957;

        private IDeviceConnector _connector;

        public ThermalStream_TA5000(IDeviceConnector connector)
        {
            this._connector = connector;
            Thread.Sleep(500);
            string result = Lonin();
        }

        public string Lonin()
        {
            string result = _connector.Query("LOGIN MPI\x0D\x0A").Replace("?", "");
            Thread.Sleep(1000);
            return result;
        }

        public void disconnect()
        {
            _connector.Write("LOUT\x0D\x0A");
            Thread.Sleep(1000);
            _connector.disconnect();
            _connector = null; // 連線清空   防止重複使用
        }

        public string GetDeviceInfo()
        {
            return _connector.Query("*IDN?\x0D\x0A").Replace("?", "");
        }

        public void head_down()//吹頭向下
        {
            _connector.Write($"HEAD 1\x0D\x0A");
            Thread.Sleep(2000);
        }

        public void head_up()//吹頭向上
        {
            _connector.Write("HEAD 0\x0D\x0A");
            Thread.Sleep(2000);
        }

        public void flowON()//開始吹
        {
            _connector.Write("FLOW 1\x0D\x0A");
            Thread.Sleep(1000);
        }

        public void flowOFF()//不要吹
        {
            _connector.Write("FLOW 0\x0D\x0A");
            Thread.Sleep(1000);
        }

        public void DSNS_type(int type)//設定待測物感測介面
        {
            //0–無連接待測物感測器
            //1–加熱頭K型熱電偶
            //2–加熱頭T型熱電偶
            //3–後端K型熱電偶
            //4–後端T型熱電偶
            _connector.Write($"DSNS {type.ToString()} \x0D\x0A");
        }

        public string DSNS_read()//讀取待測物感測器設定
        {
            return _connector.Query($"SETP?\x0D\x0A").Replace("?", "");
        }

        public void DUTM_ON()//開啟測試物模式
        {
            _connector.Write("DUTM 1\x0D\x0A");
            Thread.Sleep(1000);
        }

        public void DUTM_OFF()//關閉測試物模式
        {
            _connector.Write("DUTM 0\x0D\x0A");
            Thread.Sleep(1000);
        }

        public string read_Dut_Tempature()//讀取待測物溫度值
        {
            return _connector.Query("TMPD?\x0D\x0A").Replace("?", "");//讀取待測物溫度值
        }

        public void setT(double Temp)//單純機台 設定溫度
        {
            _connector.Write($"SETP {Temp.ToString()}\x0D\x0A");  //設溫度
            Thread.Sleep(1000);
        }

        public string readSetT()//讀取設定溫度
        {
            return _connector.Query("SETP?\x0D\x0A").Replace("?", "");//確認溫度有設好
        }


    }
}
