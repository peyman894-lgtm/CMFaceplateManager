using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public class FaceplateManager
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr processId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        private readonly Dictionary<string, AnalogFaceplate> _openAnalogFaceplates =
            new Dictionary<string, AnalogFaceplate>();

        private readonly Dictionary<string, ValveFaceplate> _openValveFaceplates =
            new Dictionary<string, ValveFaceplate>();

        private readonly Dictionary<string, DigitalMOSFaceplate> _openDigitalMosFaceplates =
            new Dictionary<string, DigitalMOSFaceplate>();

        private Timer _watchTimer;

        private string _lastIndicatorValue = "";
        private string _lastValveValue = "";
        private string _lastDigitalMosValue = "";

        public void Start()
        {
            _watchTimer = new Timer();
            _watchTimer.Interval = 100;
            _watchTimer.Tick += WatchTimer_Tick;
            _watchTimer.Start();
        }

        public void Stop()
        {
            _watchTimer?.Stop();
        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            WatchAnalogIndicator();
            WatchValveIndicator();
            WatchDigitalMosIndicator();
        }

        private void WatchAnalogIndicator()
        {
            string tagName;

            try
            {
                tagName = CMApi.ReadString("INDICATOR").Trim();
            }
            catch
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(tagName))
                return;

            if (tagName == _lastIndicatorValue)
                return;

            _lastIndicatorValue = tagName;

            if (string.Equals(tagName, "X", StringComparison.OrdinalIgnoreCase))
                return;

            OpenOrFocusAnalogFaceplate(tagName);
        }

        private void WatchValveIndicator()
        {
            string tagName;

            try
            {
                tagName = CMApi.ReadString("VALVE").Trim();
            }
            catch
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(tagName))
                return;

            if (tagName == _lastValveValue)
                return;

            _lastValveValue = tagName;

            if (string.Equals(tagName, "X", StringComparison.OrdinalIgnoreCase))
                return;

            OpenOrFocusValveFaceplate(tagName);
        }

        private void WatchDigitalMosIndicator()
        {
            string tagName;

            try
            {
                tagName = CMApi.ReadString("DIGITALMOS").Trim();
            }
            catch
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(tagName))
                return;

            if (tagName == _lastDigitalMosValue)
                return;

            _lastDigitalMosValue = tagName;

            if (string.Equals(tagName, "X", StringComparison.OrdinalIgnoreCase))
                return;

            OpenOrFocusDigitalMosFaceplate(tagName);
        }

        private void OpenOrFocusAnalogFaceplate(string tagName)
        {
            OpenOrFocusFaceplate(
                tagName,
                _openAnalogFaceplates,
                name => new AnalogFaceplate(name));
        }

        private void OpenOrFocusValveFaceplate(string tagName)
        {
            OpenOrFocusFaceplate(
                tagName,
                _openValveFaceplates,
                name => new ValveFaceplate(name));
        }

        private void OpenOrFocusDigitalMosFaceplate(string tagName)
        {
            OpenOrFocusFaceplate(
                tagName,
                _openDigitalMosFaceplates,
                name => new DigitalMOSFaceplate(name));
        }

        private void OpenOrFocusFaceplate<TForm>(
            string tagName,
            Dictionary<string, TForm> openFaceplates,
            Func<string, TForm> createFaceplate)
            where TForm : Form
        {
            if (openFaceplates.TryGetValue(tagName, out TForm existing))
            {
                if (!existing.IsDisposed)
                {
                    existing.WindowState = FormWindowState.Normal;
                    ForceToFront(existing);
                    return;
                }

                openFaceplates.Remove(tagName);
            }

            TForm faceplate = createFaceplate(tagName);

            faceplate.FormClosed += (s, e) =>
            {
                openFaceplates.Remove(tagName);
            };

            openFaceplates[tagName] = faceplate;

            faceplate.Show();
            faceplate.WindowState = FormWindowState.Normal;

            ForceToFront(faceplate);
        }

        private static void ForceToFront(Form form)
        {
            if (form == null || form.IsDisposed)
                return;

            IntPtr hWnd = form.Handle;

            IntPtr foregroundWnd = GetForegroundWindow();
            uint foregroundThread = GetWindowThreadProcessId(foregroundWnd, IntPtr.Zero);
            uint currentThread = GetCurrentThreadId();

            bool attached = false;

            if (foregroundThread != currentThread)
                attached = AttachThreadInput(currentThread, foregroundThread, true);

            try
            {
                SetForegroundWindow(hWnd);
                form.BringToFront();
                form.Activate();
                form.Focus();
            }
            finally
            {
                if (attached)
                    AttachThreadInput(currentThread, foregroundThread, false);
            }
        }
    }
}