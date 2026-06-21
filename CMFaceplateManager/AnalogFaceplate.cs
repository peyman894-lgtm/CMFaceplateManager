// AnalogFaceplate.cs
// Code-behind for the designer-built AnalogFaceplate form (see
// AnalogFaceplate.Designer.cs for the control layout, translated
// directly from the original Delphi Form3 .dfm).
//
// One instance of this form is created PER TAG by FaceplateManager -
// the tag name is passed into the constructor.
//
// Event handler names match the original Delphi form exactly for easy
// cross-reference with the decompiled .pas/.lst source.

using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CMFaceplateManager
{
    public partial class AnalogFaceplate : Form
    {
        public string TagName { get; }

        private System.Windows.Forms.Timer pollTimer;

        public AnalogFaceplate(string tagName)
        {
            TagName = tagName;
            InitializeComponent();

            // Apply the tag name to the header now that controls exist
            this.Z1_0.Text = tagName;

            pollTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            pollTimer.Tick += PollTimer_Tick;

            this.Load += FormCreate;
            this.Activated += FormActivate;
            this.FormClosed += (s, e) => pollTimer.Stop();
        }

        // ── Polling ───────────────────────────────────────────────────

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                double value = CMApi.ReadAnalog(TagName);
                this.Anz_0_X.Text = value.ToString("0.00");
                this.Anz_0_X.ForeColor = Color.Black;

                // Map engineering value to 0-1000 gauge scale.
                // TODO: replace 0-100 assumption with the tag's actual
                // configured range once available (e.g. via CMGetGateLimits).
                int gaugeVal = (int)Math.Max(0, Math.Min(1000, value / 100.0 * 1000.0));
                this.Gauge0_X.Value = gaugeVal;
            }
            catch (Exception ex)
            {
                this.Anz_0_X.Text = "ERR";
                this.Anz_0_X.ForeColor = Color.Red;
                System.Diagnostics.Debug.WriteLine($"[{TagName}] ReadAnalog failed: {ex.Message}");
            }
        }

        // ── Event handlers — names match original Delphi exactly ──────
        // TODO: wire these to real CM actions (macros / writes) as confirmed.

        private void E_Regler_Zu(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] E_Regler_Zu — close/collapse panel");
            this.Close();
        }

        private void Panel1MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"[{TagName}] Panel1MouseDown");
        }

        private void LOClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] LOClick — scroll left");
        }

        private void ROClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] ROClick — scroll right");
        }

        private void Parameter_0Click(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] Parameter_0Click — show Chart");
        }

        private void SP_ButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] SP_ButtonClick — toggle limits panel");
            bool showingSP = SP_Panel.Visible;

            SP_Panel.Visible = !showingSP;
            PV_Panel.Visible = showingSP;

            Setpoints.Text = showingSP
                ? "Setpoint"
                : "Process Value";
        }

        private void MOS_ButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_ButtonClick — toggle MOS panel");
            
            this.MOS_PASS.Visible = !this.MOS_PASS.Visible;
            MOS_PASS.Focus();
            MOS_PASS.SelectAll();
        }

        private void MOS_SETClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_SETClick — activate MOS Startup override");
        }

        private void MOS_RESETClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_RESETClick — remove MOS Startup override");
        }

        private void CONF_MOS_S_ButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] CONF_MOS_S_ButtonClick — confirm MOS Startup action");
            MOS_PASS.Clear();
            this.MOS_Panel.Visible = !this.MOS_Panel.Visible;
        }

        private void MOS_SET1Click(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_SET1Click — activate MOS Maintenance override");
        }

        private void MOS_RESET1Click(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_RESET1Click — remove MOS Maintenance override");
        }

        private void CONF_MOS_M_ButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] CONF_MOS_M_ButtonClick — confirm MOS Maintenance action");
            MOS_PASS.Clear();
            this.MOS_Panel.Visible = !this.MOS_Panel.Visible;
        }

        private void WAR_0KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"[{TagName}] WAR_0KeyDown — hidden warning/status field triggered");
        }

        private void Edit1KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Console.WriteLine($"[{TagName}] Edit1KeyPress — password submitted");
        }

        // ── Lifecycle ───────────────────────────────────────────────────

        private void FormCreate(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] FormCreate — faceplate opened, starting poll");
            pollTimer.Start();
        }

        private void FormActivate(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] FormActivate — brought to front");
        }

        private void Anz_0_X_Click(object sender, EventArgs e)
        {

        }

        private void Anz_0_X_Click_1(object sender, EventArgs e)
        {

        }

        private void Gauge0_X_Click(object sender, EventArgs e)
        {

        }

        private void Anz_0_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MOS_PASS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            e.Handled = true;

            if (MOS_PASS.Text.Trim() == "MOS")
            {
                MOS_Panel.Visible = true;
                MOS_PASS.Visible = false;
            }
            else
            {
                MOS_PASS.Clear();
                MOS_PASS.Visible = false;
            }
        }

        private void MOS_PASS_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pin_Button_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;

            // Show the action that will happen on the next click
            Pin_Button.Text = TopMost ? "📍" : "📌";
            Pin_Button.AccessibleName = TopMost ? "Unpin" : "Pin";
        }
    }
}
