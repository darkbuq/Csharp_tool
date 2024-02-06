using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeV2
{
    public class BAWrapper
    {
        
        const string location = @"../../BA_API_6_12.dll";

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "Connect", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ConnectAPI(string IP, ref bool fwUpgradeNotRequired);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ConnectV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ConnectV2API(string IP, ref byte FWStatus);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ConnectV3", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ConnectV3API(string IP, ref byte FWStatus, ref byte hwMajorVr, ref byte hwMinorVr);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "IsConnected", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IsConnectedAPI();
		
		[return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "HWIsConnected", CallingConvention = CallingConvention.StdCall)]
        //private static extern bool HWIsConnectedAPI();
        public static extern bool HWIsConnectedAPI();//YR

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "Disconnect", CallingConvention = CallingConvention.StdCall)]
        public static extern bool DisconnectAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ChangeIP", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ChangeIPAPI(byte[] IP);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SetBAStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBAStatusAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "GetBAStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetBAStatusAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadBAStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBAStatusAPI(byte[] data);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "WriteBAStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool WriteBAStatusAPI(byte[] data);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SwitchPPGEDOptions", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SwitchPPGEDOptionsAPI(ref bool basic, ref bool multiRate, ref bool OneP5Vpp,
            ref bool FEC, ref bool FiftyThreeG, ref bool isPAM4, ref bool is8Ch);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SwitchPPGEDOptionsV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SwitchPPGEDOptionsV2API(ref bool basic, ref bool multiRate, ref bool OneP5Vpp,
            ref bool FEC, ref bool FiftyThreeG, ref bool isPAM4, ref bool is8Ch, ref bool isMA);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SwitchPPGEDOptionsV3", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SwitchPPGEDOptionsV3API(ref bool basic, ref bool multiRate, ref bool OneP5Vpp,
            ref bool FEC, ref bool FiftyThreeG, ref bool isPAM4, ref bool is8Ch, ref bool isMA, ref bool is25GNRZ);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SwitchPPGEDOptionsV4", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SwitchPPGEDOptionsV4API(byte[] options);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SetBAConfig", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBAConfigAPI(byte signalMode, int dataRate, byte clockDiv,
                                                    byte rxSensitivity, ushort ctleValue);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SetBAConfigAdv", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBAConfigAdvAPI(byte signalMode, int dataRate, byte clockDiv,
                                            byte rxSensitivity, ushort ctleValue, byte mapping, byte preCoding);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SetBAConfigAdvV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBAConfigAdvV2API(byte signalMode, int dataRate, byte clockDiv,
                                    byte rxSensitivity, ushort ctleValue, byte mapping, byte preCoding, short PPMTuneVal);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SetPattern", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetPatternAPI(byte channelIndex, byte patternSelect, UInt64 userPattern, bool isAutoLock, byte fecType);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SeRXPattern", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SeRXPatternAPI(byte channelIndex, byte patternSelect, bool isAutoLock, byte fecType);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ChDisable", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ChDisableAPI(byte channelIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "UpdateTaps", CallingConvention = CallingConvention.StdCall)]
        public static extern bool UpdateTapsAPI(byte channelIndex, double pre, double main, double post,
                double upperEyeHeight, double lowerEyeHeight);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "Update7Taps", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Update7TapsAPI(byte channelIndex,
            double pre1, double pre2, double pre3,
            double main,
            double post1, double post2, double post3,
        double upperEyeHeight, double lowerEyeHeight);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SetCTLE", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetCTLEAPI(byte channelIndex,
            ushort ctleValue);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SetRXSensitivity", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetRXSensitivityAPI(byte channelIndex,
            byte rxSensitivity);


        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SetBERSettings", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetBERSettingsAPI(byte channelIndex, byte BERTType, bool realtimeUpdate,
                int days, int hours, int minutes, int seconds);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "StartBERTest", CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartBERTestAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "StopBERTest", CallingConvention = CallingConvention.StdCall)]
        public static extern bool StopBERTestAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "IsBERTRunning", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IsBERTRunningAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ClearBERTest", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClearBERTestAPI(byte channelIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadBERResult", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultAPI(
                    ref long captureTimeIns,
                    byte[] patternTX,
                    byte[] rxPatternLSB,
                    byte[] rxLockMSB,
                    byte[] rxLockLSB,
                    byte[] rxLock,
                    byte[] rxInvertMSB,
                    byte[] rxInvertLSB,
                    UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
                    UInt64[] bertErrorCount, UInt64[] bertBitCount,
                    double[] realTimer, double[] bertValue,
                    UInt64[] fecCOR, double[] fecBertValues, UInt64[] fecResults
                    );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadBERResultMargin", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultMarginAPI(
            ref long captureTimeIns,
            byte[] patternTX,
            byte[] rxPatternLSB,
            byte[] rxLockMSB,
            byte[] rxLockLSB,
            byte[] rxLock,
            byte[] rxInvertMSB,
            byte[] rxInvertLSB,
            UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
            UInt64[] bertErrorCount, UInt64[] bertBitCount,
            double[] realTimer, double[] bertValue,
            UInt64[] fecCOR, double[] fecBertValues, UInt64[] fecResults,
            double[] margin, double[] marginPct, sbyte[] taps
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadBERResultMarginV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultMarginV2API(
            ref long captureTimeIns,
            byte[] patternTX,
            byte[] rxPatternLSB,
            byte[] rxLockMSB,
            byte[] rxLockLSB,
            byte[] rxLock,
            byte[] rxInvertMSB,
            byte[] rxInvertLSB,
            UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
            UInt64[] bertErrorCount, UInt64[] bertBitCount,
            double[] realTimer, double[] bertValue,
            UInt64[] fecCOR, double[] fecBertValues, UInt64[] fecResults,
            double[] margin, double[] marginPct, sbyte[] taps
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadBERResultMarginV3", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultMarginV3API(
            ref long captureTimeIns,
            byte[] patternTX,
            byte[] rxPatternLSB,
            byte[] rxLockMSB,
            byte[] rxLockLSB,
            byte[] rxLock,
            byte[] rxInvertMSB,
            byte[] rxInvertLSB,
            UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
            UInt64[] bertErrorCount, UInt64[] bertBitCount,
            double[] realTimer, double[] bertValue,
            UInt64[] fecCOR, UInt64[] fecUnCOR, double[] fecBertValues, UInt64[] fecResults,
            double[] margin, double[] marginPct, sbyte[] taps
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadBERResultMarginV4", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultMarginV4API(
        ref long captureTimeIns,
        byte[] patternTX,
        byte[] rxPatternLSB,
        byte[] rxLockMSB,
        byte[] rxLockLSB,
        byte[] rxLock,
        byte[] rxInvertMSB,
        byte[] rxInvertLSB,
        UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
        UInt64[] bertErrorCount, UInt64[] bertBitCount,
        double[] realTimer, double[] bertValue,
        UInt64[] fecCOR, UInt64[] fecUnCOR, double[] cerValues, double[] flrValues, UInt64[] fecResults,
        double[] margin, double[] marginPct, sbyte[] taps
        );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadBERResultMarginV5", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERResultMarginV5API(
        ref long captureTimeIns,
        byte[] patternTX,
        byte[] rxPatternLSB,
        byte[] rxLockMSB,
        byte[] rxLockLSB,
        byte[] rxLock,
        byte[] rxInvertMSB,
        byte[] rxInvertLSB,
        UInt64[] bertErrorCountMSB, UInt64[] bertErrorCountLSB,
        UInt64[] bertErrorCount, UInt64[] bertBitCount,
        double[] realTimer, double[] bertValue,
        UInt64[] fecCOR, UInt64[] fecUnCOR, double[] cerValues, double[] flrValues, UInt64[] fecResults,
        double[] margin, double[] marginPct, sbyte[] taps, double[] SNRResults,
        uint[] histResults, double[] levelResults, double[] eyeHeightResults
        );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadMAPower", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadMAPowerAPI(ref double volgate, ref double current);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadMAModuleStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadMAModuleStatusAPI(byte[] status);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadMAModuleStatusV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadMAModuleStatusV2API(byte[] status);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadSelectedPPGOptions", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadSelectedPPGOptionsAPI(ref bool basic, ref bool multiRate, ref bool OneP5Vpp,
                ref bool FEC, ref bool FiftyThreeG, ref bool isPAM4, ref bool is8Ch, ref bool isMA);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadSelectedPPGOptionsV2", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadSelectedPPGOptionsV2API(ref bool basic, ref bool multiRate, ref bool OneP5Vpp,
        ref bool FEC, ref bool FiftyThreeG, ref bool isPAM4, ref bool is8Ch, ref bool isMA, ref bool is25GNRZ);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadSelectedPPGOptionsV3", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadSelectedPPGOptionsV3API(byte[] options);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadDataRate", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadDataRateAPI(ref byte signalMode, ref int dataRate, ref byte clockDiv);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadDataRateAdv", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadDataRateAdvAPI(ref byte signalMode, ref int dataRate, ref byte clockDiv
            , ref byte mapping, ref byte preCoding);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadPatternData", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadPatternDataAPI(
                byte[] patternTX,
                double[] preCursor,
                double[] amplitude,
                double[] postCursor,
                double[] upperEyeHeight,
                double[] lowerEyeHeight,
                byte[] txInvert,
                byte[] patternRX,
                byte[] patternRXLSB,
                bool[] rxAutoLock,
                byte[] rxInvert,
                byte[] fecModeSelect,
                byte[] rxSensitivity,
                ushort[] ctle
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadPatternData7T", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadPatternData7TAPI(
                ref byte is7Taps,
                byte[] patternTX,
                double[] preCursor1,
                double[] preCursor2,
                double[] preCursor,
                double[] amplitude,
                double[] postCursor,
                double[] postCursor2,
                double[] postCursor3,
                double[] upperEyeHeight,
                double[] lowerEyeHeight,
                byte[] txInvert,
                byte[] patternRX,
                byte[] patternRXLSB,
                bool[] rxAutoLock,
                byte[] rxInvert,
                byte[] fecModeSelect,
                byte[] rxSensitivity,
                ushort[] ctle
            );

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ReadBERTSettings", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadBERTSettingsAPI(ref byte BERTType, ref bool realtimeUpdate, ref double timeSpanInS);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "Relock", CallingConvention = CallingConvention.StdCall)]
        public static extern bool RelockAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ForceRelock", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ForceRelockAPI();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "ErrorInjection", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ErrorInjectionAPI(byte channelIndex,
            byte bitSelect, byte type, byte gap, byte PktCount);



        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MASetStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MASetStatusAPI(byte color, char[] message);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MASetMessage", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MASetMessageAPI(byte line, char[] message);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MASetPower", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MASetPowerAPI(bool enable, double voltage);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAGetPower", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAGetPowerAPI(ref bool isEnabled, ref double voltageSet, ref double voltage, ref double current);


        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CSpeed", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CSpeedAPI(byte speedIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CReadCurrent", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CReadCurrentAPI(ref byte val);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CReadAdr", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CReadAdrAPI(byte adr, ref byte val);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CReadArrayAdr", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CReadArrayAdrAPI(byte[] adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CReadSeq", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CReadSeqAPI(byte adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CWriteAdr", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CWriteAdrAPI(byte adr, byte val);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CWriteArrayAdr", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CWriteArrayAdrAPI(byte[] adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CWriteSeq", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CWriteSeqAPI(byte adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAI2CWRArray", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAI2CWRArrayAPI(byte[] op, byte[] adr, byte[] val, byte count);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "MAIOControl", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MAIOControlAPI(bool read, byte index, ref byte val);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "PPMTune", CallingConvention = CallingConvention.StdCall)]
        public static extern bool PPMTuneAPI(bool read, ref short ppmValue);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "LoadSettings", CallingConvention = CallingConvention.StdCall)]
        public static extern bool LoadSettingsAPI(string filePath);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "SaveSettings", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SaveSettingsAPI(string filePath);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(location , EntryPoint = "HistogramConfig", CallingConvention = CallingConvention.StdCall)]
        public static extern bool HistogramConfigAPI(bool read,ref double eyeHeightBERTarget, byte[] histChEnable);
    }
}
