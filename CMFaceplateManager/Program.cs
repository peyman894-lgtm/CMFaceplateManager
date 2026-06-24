using System;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!CMApi.Connect())
            {
                MessageBox.Show(
                    $"Failed to connect to ControlMaestro (rc={CMApi.LastConnectRc}).",
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

            Application.Run(new ApplicationContext());
        }
    }
}