// FaceplateManager.cs
// Watches the INDICATOR tag continuously. When it changes to a known
// tag-trigger value, opens (or brings to front) the corresponding
// AnalogFaceplate window for that tag.
//
// This is the C# equivalent of the original STR_Indication.exe's main loop:
// connect once, poll INDICATOR forever, react by opening faceplates.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public class FaceplateManager
    {
        // Maps an INDICATOR value (whatever the field-device/operator sets it to)
        // to the tag name that should be displayed in the analog faceplate.
        // TODO: replace with your actual mapping - this could come from a
        // config file, the Regler.DAT equivalent, or a hardcoded dictionary
        // if the tag set is small and stable.
        private readonly Dictionary<double, string> _indicatorMap = new Dictionary<double, string>
        {
            { 1, "PT_9200_70_1" },
            { 2, "PT_9200_70_2" },
            { 3, "PT_9200_70_3" },
        };

        // Tracks currently-open faceplates so we don't open duplicates
        // and so we can bring an existing one to front instead.
        private readonly Dictionary<string, AnalogFaceplate> _openFaceplates =
            new Dictionary<string, AnalogFaceplate>();

        private System.Windows.Forms.Timer _watchTimer;
        private double _lastIndicatorValue = double.NaN;

        public void Start()
        {
            _watchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _watchTimer.Tick += WatchTimer_Tick;
            _watchTimer.Start();
            Console.WriteLine("FaceplateManager started — watching INDICATOR.");
        }

        public void Stop()
        {
            _watchTimer?.Stop();
        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            double indicatorValue;
            try
            {
                indicatorValue = CMApi.ReadAnalog("INDICATOR");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"INDICATOR read failed: {ex.Message}");
                return;
            }

            // Only react on a CHANGE, not every poll tick - mirrors the
            // original add-on's "trigger on tag value change" behavior.
            if (indicatorValue == _lastIndicatorValue)
                return;

            _lastIndicatorValue = indicatorValue;

            if (_indicatorMap.TryGetValue(indicatorValue, out string tagName))
            {
                OpenOrFocusFaceplate(tagName);
            }
        }

        private void OpenOrFocusFaceplate(string tagName)
        {
            if (_openFaceplates.TryGetValue(tagName, out AnalogFaceplate existing) && !existing.IsDisposed)
            {
                existing.WindowState = FormWindowState.Normal;
                existing.BringToFront();
                existing.Focus();
                return;
            }

            var faceplate = new AnalogFaceplate(tagName);
            faceplate.FormClosed += (s, e) => _openFaceplates.Remove(tagName);
            _openFaceplates[tagName] = faceplate;
            faceplate.Show();

            Console.WriteLine($"Opened AnalogFaceplate for {tagName}");
        }
    }
}
