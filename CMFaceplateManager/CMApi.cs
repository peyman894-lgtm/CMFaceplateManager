using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public static class CMApi
    {
        public const ushort WGGV_CURRENT = 0;

        // This is the mode that worked in your Python test:
        // CMGetGateStr(hook, 11, gate_id, buffer, 0, 0)
        public const ushort WGGV_STRING_CURRENT = 11;

        [DllImport("Wizpro.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern ushort CMMkClient(
            string ClientName,
            int ClientType,
            IntPtr hWnd,
            ref byte Hook);

        [DllImport("Wizpro.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ushort CMRmClient(byte Hook);

        [DllImport("Wizpro.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern ushort CMGetGateId(
            byte Hook,
            string GateName,
            ref int GateId);

        [DllImport("Wizpro.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ushort CMGetGateVal(
            byte Hook,
            ushort Mode,
            int GateId,
            ref double Value,
            ref uint Seconds,
            ref ushort MilliSeconds);

        [DllImport("Wizpro.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ushort CMGetGateStr(
            byte Hook,
            ushort Mode,
            int GateId,
            byte[] Value,
            uint Seconds,
            ushort MilliSeconds);

        [DllImport("WIZ5API.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern ushort CMRunMacroByName(
            byte Hook,
            string MacroName);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct LAYER_STAT
        {
            public ushort Att;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string Name;
        }

        [DllImport("WIZ5API.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern ushort CMSetLayersStatus(
          byte Hook,
          int VpId,
          int LayersQuant,
          [In] LAYER_STAT[] LayersList);

        [DllImport("WIZ5API.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern ushort CMGetVpId(
          byte Hook,
          int usType,
          string VpName,
          out int pVpId);

        [DllImport("Wizpro.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern ushort CMPutGateVal(
          byte Hook,
          int GateId,
          ushort Mode,
          double GateVal,
          uint Seconds,
          ushort MilliSeconds);

        public static byte Hook = 0;
        public static bool IsConnected { get; private set; } = false;
        public static ushort LastConnectRc { get; private set; }

        public static bool Connect()
        {
            LastConnectRc = CMMkClient("FaceplateManager", 1, IntPtr.Zero, ref Hook);
            IsConnected = LastConnectRc == 0;
            return IsConnected;
        }

        public static void Disconnect()
        {
            if (!IsConnected)
                return;

            CMRmClient(Hook);
            IsConnected = false;
        }

        public static double ReadAnalog(string tagName)
        {
            int gateId = GetGateId(tagName);

            double value = 0;
            uint seconds = 0;
            ushort milliseconds = 0;

            ushort rc = CMGetGateVal(
                Hook,
                WGGV_CURRENT,
                gateId,
                ref value,
                ref seconds,
                ref milliseconds);

            System.Diagnostics.Debug.WriteLine(
                $"ReadAnalog('{tagName}') rc={rc}, value={value}");


            return value;
        }

        public static string ReadString(string tagName)
        {
            int gateId = GetGateId(tagName);

            byte[] buffer = new byte[256];

            ushort rc = CMGetGateStr(
                Hook,
                WGGV_STRING_CURRENT,
                gateId,
                buffer,
                0,
                0);

            if (rc != 0)
                throw new InvalidOperationException($"CMGetGateStr('{tagName}') failed, rc={rc}");

            int length = Array.IndexOf(buffer, (byte)0);
            if (length < 0)
                length = buffer.Length;

            return Encoding.Default.GetString(buffer, 0, length).Trim();
        }

        private static int GetGateId(string tagName)
        {
            int gateId = 0;

            ushort rc = CMGetGateId(Hook, tagName, ref gateId);

            if (rc != 0)
                throw new InvalidOperationException($"CMGetGateId('{tagName}') failed, rc={rc}");

            return gateId;
        }

        public static ushort RunMacro(string macroName)
        {
            ushort rc = CMRunMacroByName(Hook, macroName);

            System.Diagnostics.Debug.WriteLine(
                $"RunMacro('{macroName}') rc={rc}");

            return rc;
        }

        public static int GetVpId(string VpName)
        {
            int VpId;

            ushort rc = CMGetVpId(Hook, 2, VpName, out VpId);

            return VpId;
        }
        public static ushort SetLayersStatus(ushort LayerNumber)
        {
            int VpIdMain = GetVpId("FaG");
            int VpIdEdit = GetVpId("Edit_FaG");

            int LayersQuant = 30;

            LAYER_STAT[] LayersList = new LAYER_STAT[]
            {
                new LAYER_STAT { Name ="DFI" },
                new LAYER_STAT { Name ="MDFI" },
                new LAYER_STAT { Name ="BDFI" },
                new LAYER_STAT { Name ="DGC" },
                new LAYER_STAT { Name ="MDGC" },
                new LAYER_STAT { Name ="BDGC" },
                new LAYER_STAT { Name ="DSI" },
                new LAYER_STAT { Name ="MDSI" },
                new LAYER_STAT { Name ="BDSI" },
                new LAYER_STAT { Name ="MCP" },
                new LAYER_STAT { Name ="MMCP" },
                new LAYER_STAT { Name ="BMCP" },
                new LAYER_STAT { Name ="DGT" },
                new LAYER_STAT { Name ="MDGT" },
                new LAYER_STAT { Name ="BDGT" },
                new LAYER_STAT { Name ="MOV" },
                new LAYER_STAT { Name ="MMOV" },
                new LAYER_STAT { Name ="BMOV" },
                new LAYER_STAT { Name ="MCS" },
                new LAYER_STAT { Name ="MMCS" },
                new LAYER_STAT { Name ="BMCS" },
                new LAYER_STAT { Name ="ADV" },
                new LAYER_STAT { Name ="MADV" },
                new LAYER_STAT { Name ="BADV" },
                new LAYER_STAT { Name ="ADVA" },
                new LAYER_STAT { Name ="MADVA" },
                new LAYER_STAT { Name ="BADVA" },
                new LAYER_STAT { Name ="LIH" },
                new LAYER_STAT { Name ="MLIH" },
                new LAYER_STAT { Name ="BLIH" },
            };

            for (int i = 1; i <= 10; i++)
            {

                if (LayerNumber == i)
                {
                    for (int j = 0; j <= 29; j++)
                    {
                        //hide all layer
                        LayersList[j].Att = 2;
                    }
                    for (int k = i * 3 - 3; k <= i * 3 - 1; k++)
                    {
                        //show layer ith
                        LayersList[k].Att = 3;
                    }
                    break;
                }
            }

            ushort LayerMain = CMSetLayersStatus(Hook, VpIdMain, LayersQuant, LayersList);

            ushort Layer = CMSetLayersStatus(Hook, VpIdEdit, LayersQuant, LayersList);

            return LayerMain;
        }
        public static ushort PutGateVal(string tagName, double Gatevalue)
        {
            int gateId = GetGateId(tagName);
            uint seconds = 0;
            ushort milliseconds = 0;

            ushort rc = CMPutGateVal(
                Hook,
                gateId,
                1,
                Gatevalue,
                seconds,
                milliseconds);

            return rc;
        }
    }
}
