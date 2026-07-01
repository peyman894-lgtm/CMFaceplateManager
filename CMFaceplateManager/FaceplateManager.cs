using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public class FaceplateManager
    {
        // Win32: force a window to the foreground even from a background process
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        // Win32: attach/detach thread input queues so foreground promotion works
        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr processId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        private readonly Dictionary<string, AnalogFaceplate> _openFaceplates =
            new Dictionary<string, AnalogFaceplate>();

        private Timer _watchTimer;
        private string _lastIndicatorValue = "";

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

            OpenOrFocusFaceplate(tagName);
        }

        private void OpenOrFocusFaceplate(string tagName)
        {
            if (string.Equals(tagName, "X", StringComparison.OrdinalIgnoreCase))
                return;
            if (_openFaceplates.TryGetValue(tagName, out AnalogFaceplate existing))
            {
                if (!existing.IsDisposed)
                {
                    existing.WindowState = FormWindowState.Normal;
                    ForceToFront(existing);
                    return;
                }

                _openFaceplates.Remove(tagName);
            }

            var faceplate = new AnalogFaceplate(tagName);

            faceplate.FormClosed += (s, e) =>
            {
                _openFaceplates.Remove(tagName);
            };

            _openFaceplates[tagName] = faceplate;

            faceplate.Show();
            faceplate.WindowState = FormWindowState.Normal;

            ForceToFront(faceplate);
        }

        /// <summary>
        /// Brings a form to the foreground reliably, even when the calling
        /// process does not currently own the foreground window.
        /// 
        /// Windows blocks SetForegroundWindow() for background processes.
        /// The workaround is to temporarily attach our thread's input queue
        /// to the foreground thread's queue, which grants us foreground
        /// promotion rights for the duration of that attachment.
        /// </summary>
        private static void ForceToFront(Form form)
        {
            if (form == null || form.IsDisposed)
                return;

            IntPtr hWnd = form.Handle;

            // Get the thread that owns the current foreground window
            IntPtr foregroundWnd = GetForegroundWindow();
            uint foregroundThread = GetWindowThreadProcessId(foregroundWnd, IntPtr.Zero);
            uint currentThread = GetCurrentThreadId();

            // Attach input queues so Windows grants us foreground rights
            bool attached = false;
            if (foregroundThread != currentThread)
            {
                attached = AttachThreadInput(currentThread, foregroundThread, true);
            }

            try
            {
                SetForegroundWindow(hWnd);
                form.BringToFront();
                form.Activate();
                form.Focus();
            }
            finally
            {
                // Always detach — leaving queues attached causes input bugs
                if (attached)
                    AttachThreadInput(currentThread, foregroundThread, false);
            }
        }
    }
}