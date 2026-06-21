using System;
using System.Runtime.InteropServices;

namespace CMFaceplateManager
{
    public static class CMApi
    {
        public const ushort WGGV_CURRENT = 0;
        public const ushort WGGV_CHK_CURRENT = 1;
        public const ushort WPGV_WRITE_NOW = 0;
        public const ushort WPGV_NO_WRITE = 1;

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
        public static extern ushort CMPutGateVal(
            byte Hook,
            int GateId,
            ushort Mode,
            double Value,
            uint Seconds,
            ushort MilliSeconds);

        // ── Connection state ─────────────────────────────────────────

        public static byte Hook = 0;
        public static bool IsConnected { get; private set; } = false;
        public static ushort LastConnectRc { get; private set; }

        /// <summary>
        /// Connects to ControlMaestro. Returns true on success (rc == 0).
        /// </summary>
        public static bool Connect()
        {
            LastConnectRc = CMMkClient("CSharpClient", 1, IntPtr.Zero, ref Hook);
            IsConnected = (LastConnectRc == 0);
            return IsConnected;
        }

        public static void Disconnect()
        {
            if (IsConnected)
            {
                CMRmClient(Hook);
                IsConnected = false;
            }
        }

        // ── Read ──────────────────────────────────────────────────────

        /// <summary>
        /// Reads an analog/numeric tag's engineering value.
        /// Throws if the gate lookup fails; out param rc reports the
        /// CMGetGateVal return code (non-fatal codes like 9 may still
        /// carry a valid value - check ReadAnalogResult.Rc if needed).
        /// </summary>
        public static double ReadAnalog(string tagName)
        {
            return ReadAnalog(tagName, out _, out _, out _);
        }

        public static double ReadAnalog(string tagName, out ushort rc, out uint seconds, out ushort msec)
        {
            int gateId = 0;
            ushort idRc = CMGetGateId(Hook, tagName, ref gateId);
            if (idRc != 0)
            {
                rc = idRc;
                seconds = 0;
                msec = 0;
                throw new InvalidOperationException($"CMGetGateId('{tagName}') failed, rc={idRc}");
            }

            double value = 0;
            uint sec = 0;
            ushort ms = 0;
            rc = CMGetGateVal(Hook, WGGV_CURRENT, gateId, ref value, ref sec, ref ms);
            seconds = sec;
            msec = ms;
            return value;
        }

        // ── Write ─────────────────────────────────────────────────────

        public static ushort WriteAnalog(string tagName, double value)
        {
            int gateId = 0;
            ushort idRc = CMGetGateId(Hook, tagName, ref gateId);
            if (idRc != 0)
                throw new InvalidOperationException($"CMGetGateId('{tagName}') failed, rc={idRc}");

            return CMPutGateVal(Hook, gateId, WPGV_WRITE_NOW, value, 0, 0);
        }
    }
}
