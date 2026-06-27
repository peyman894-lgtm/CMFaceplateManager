using System;
using System.Drawing;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!CMApi.Connect())
            {
                MessageBox.Show(
                    $"Failed to connect to ControlMaestro (rc={CMApi.LastConnectRc}).",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.ApplicationExit += (s, e) =>
            {
                CMApi.Disconnect();
            };

            var manager = new FaceplateManager();
            manager.Start();

            // ── Tray icon ──────────────────────────────────────────────────
            using (var trayIcon = new NotifyIcon())
            {
                // Use a built-in system icon so no .ico file is needed.
                // Swap this for your own Icon.FromFile("cm.ico") if you have one.
                trayIcon.Icon = SystemIcons.Application;
                trayIcon.Text = "CMFaceplateManager\nConnected to ControlMaestro";
                trayIcon.Visible = true;

                // Context menu shown on right-click
                var menu = new ContextMenuStrip();

                var statusItem = new ToolStripMenuItem("● Connected to CM")
                {
                    Enabled = false,   // just a label, not clickable
                    ForeColor = Color.Green
                };

                var separatorItem = new ToolStripSeparator();

                var exitItem = new ToolStripMenuItem("Exit CMFaceplateManager");
                exitItem.Click += (s, e) =>
                {
                    manager.Stop();
                    trayIcon.Visible = false;
                    Application.Exit();
                };

                menu.Items.Add(statusItem);
                menu.Items.Add(separatorItem);
                menu.Items.Add(exitItem);

                trayIcon.ContextMenuStrip = menu;

                // Optional: double-click the tray icon to show a status balloon
                trayIcon.DoubleClick += (s, e) =>
                {
                    trayIcon.BalloonTipTitle = "CMFaceplateManager";
                    trayIcon.BalloonTipText = "Running — watching INDICATOR tag.\nRight-click to exit.";
                    trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                    trayIcon.ShowBalloonTip(3000);
                };

                Application.Run(new ApplicationContext());
            }
        }
    }
}