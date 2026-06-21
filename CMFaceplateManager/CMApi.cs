using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMFaceplateManager
{
    public static class CMApi
    {
        public const ushort WGGV_CURRENT = 0;

        [DllImport("Wizpro.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ushort CMMkClient(
            string ClientName,
            int ClientType,
            IntPtr hWnd,
            ref byte Hook);

        [DllImport("Wizpro.dll", CallingConvention = CallingConvention.StdCall)]
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

        public static byte Hook = 0;

        public static void Connect()
        {
            CMMkClient(
                "CSharpClient",
                1,
                IntPtr.Zero,
                ref Hook
            );
        }

        public static double ReadAnalog(string tagName)
        {
            int gateId = 0;

            CMGetGateId(
                Hook,
                tagName,
                ref gateId
            );

            double value = 0;
            uint seconds = 0;
            ushort msec = 0;

            CMGetGateVal(
                Hook,
                WGGV_CURRENT,
                gateId,
                ref value,
                ref seconds,
                ref msec
            );

            return value;
        }
    }
}
