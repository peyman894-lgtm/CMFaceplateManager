using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public class LayerManager
    {

        private Timer _watchTimer;

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
            ushort layerNumber;
            ushort rc;

            try
            {
                layerNumber =(ushort) CMApi.ReadAnalog("LAYER");
      
            }
            catch
            {
                return;
            }

            if (layerNumber == 0)
                return;

            rc = (ushort)CMApi.PutGateVal("LAYER_ANZ", (double)layerNumber);

            CMApi.SetLayersStatus(layerNumber);

            rc = (ushort)CMApi.PutGateVal("LAYER", 0);
        }
    }
}