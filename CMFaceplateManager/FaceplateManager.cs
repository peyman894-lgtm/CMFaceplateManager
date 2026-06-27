using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public class FaceplateManager
    {
        private readonly Dictionary<string, AnalogFaceplate> _openFaceplates =
            new Dictionary<string, AnalogFaceplate>();

        private Timer _watchTimer;
        private string _lastIndicatorValue = "";

        public void Start()
        {
            _watchTimer = new Timer();
            _watchTimer.Interval = 500;
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
            if (_openFaceplates.TryGetValue(tagName, out AnalogFaceplate existing))
            {
                if (!existing.IsDisposed)
                {
                    existing.WindowState = FormWindowState.Normal;
                    existing.BringToFront();
                    existing.Activate();
                    existing.Focus();
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
            faceplate.BringToFront();
            faceplate.Activate();
            faceplate.Focus();
        }
    }
}