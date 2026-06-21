// Program.cs
// Entry point for FaceplateManager.exe.
//
// Architecture:
//   ControlMaestro Runtime --writes--> INDICATOR
//   FaceplateManager.exe   --reads INDICATOR continuously-->
//       opens AnalogFaceplate(Tag1) / (Tag2) / (Tag3) as needed
//
// Connects to CM once at startup and stays alive for the lifetime
// of the application (no per-faceplate reconnection).
//
// Build: Windows Forms App (.NET Framework 4.8), Platform target: x86

using System;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            bool connected = CMApi.Connect();
            if (!connected)
            {
                MessageBox.Show(
                    $"Failed to connect to ControlMaestro (rc={CMApi.LastConnectRc}).\n" +
                    "FaceplateManager will now exit.",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += (s, e) => CMApi.Disconnect();

            var manager = new FaceplateManager();
            manager.Start();
            var test = new AnalogFaceplate("PT_9200_70_1");
            test.Show();
            // No main window - this runs as a background watcher, exactly
            // like the original addon's Application.FShowMainForm := False.
            // ApplicationContext keeps the message loop alive without a
            // visible form; Application.Run(Form) would require one.
            Application.Run(new ApplicationContext());
        }
    }
}
