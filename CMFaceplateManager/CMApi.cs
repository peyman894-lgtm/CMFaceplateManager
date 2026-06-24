using System;
using System.Runtime.InteropServices;
using System.Text;

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
    }
}