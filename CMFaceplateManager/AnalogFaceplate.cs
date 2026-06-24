using System;
using System.Drawing;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public partial class AnalogFaceplate : Form
    {
        public string TagName { get; }

        private readonly Timer pollTimer;

        public AnalogFaceplate(string tagName)
        {
            TagName = tagName.Trim();

            InitializeComponent();

            Z1_0.Text = TagName;

            pollTimer = new Timer();
            pollTimer.Interval = 1000;
            pollTimer.Tick += PollTimer_Tick;

            Load += FormCreate;
            Activated += FormActivate;
            FormClosed += AnalogFaceplate_FormClosed;
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            ReadAndShowValue();
        }

        private void ReadAndShowValue()
        {
            try
            {
                double value = CMApi.ReadAnalog(TagName);

                Anz_0_X.Text = value.ToString("0.00");
                Anz_0_X.ForeColor = Color.Black;

                int gaugeValue = (int)Math.Max(0, Math.Min(1000, value / 100.0 * 1000.0));
                Gauge0_X.Value = gaugeValue;

                double spHH = CMApi.ReadAnalog(TagName + "_SPHH");
                double spH = CMApi.ReadAnalog(TagName + "_SPH");
                double spL = CMApi.ReadAnalog(TagName + "_SPL");
                double spLL = CMApi.ReadAnalog(TagName + "_SPLL");

                SPHH.Text = spHH.ToString("0.00");
                SPH.Text = spH.ToString("0.00");
                SPL.Text = spL.ToString("0.00");
                SPLL.Text = spLL.ToString("0.00");
            }
            catch (Exception ex)
            {
                Anz_0_X.Text = "ERR";
                Anz_0_X.ForeColor = Color.Red;

                System.Diagnostics.Debug.WriteLine(
                    $"[{TagName}] ReadAndShowValue failed: {ex.Message}");
            }
        }

        private void AnalogFaceplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            pollTimer.Stop();
            pollTimer.Dispose();
        }

        private void E_Regler_Zu(object sender, EventArgs e)
        {
            Close();
        }

        private void Panel1MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"[{TagName}] Panel1MouseDown");
        }

        private void LOClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] LOClick");
        }

        private void ROClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] ROClick");
        }

        private void Parameter_0Click(object sender, EventArgs e)
        {

        }

        private void SP_ButtonClick(object sender, EventArgs e)
        {
            bool showingSP = SP_Panel.Visible;

            SP_Panel.Visible = !showingSP;
            PV_Panel.Visible = showingSP;

            Setpoints.Text = showingSP
                ? "Setpoint"
                : "Process Value";
        }

        private void MOS_ButtonClick(object sender, EventArgs e)
        {
            MOS_PASS.Visible = !MOS_PASS.Visible;

            if (MOS_PASS.Visible)
            {
                MOS_PASS.Focus();
                MOS_PASS.SelectAll();
            }
        }

        private void MOS_SETClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_SETClick");
        }

        private void MOS_RESETClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_RESETClick");
        }

        private void CONF_MOS_S_ButtonClick(object sender, EventArgs e)
        {
            MOS_PASS.Clear();
            MOS_Panel.Visible = !MOS_Panel.Visible;
        }

        private void MOS_SET1Click(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_SET1Click");
        }

        private void MOS_RESET1Click(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_RESET1Click");
        }

        private void CONF_MOS_M_ButtonClick(object sender, EventArgs e)
        {
            MOS_PASS.Clear();
            MOS_Panel.Visible = !MOS_Panel.Visible;
        }

        private void WAR_0KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"[{TagName}] WAR_0KeyDown");
        }

        private void Edit1KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Console.WriteLine($"[{TagName}] Edit1KeyPress");
        }

        private void FormCreate(object sender, EventArgs e)
        {
            ReadAndShowValue();
            pollTimer.Start();
        }

        private void FormActivate(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] FormActivate");
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

            Pin_Button.Text = TopMost ? "Unpin" : "Pin";
            Pin_Button.AccessibleName = TopMost ? "Unpin" : "Pin";
        }

        private void Edit_0_O2_Click(object sender, EventArgs e)
        {

        }

        private void ChartClick(object sender, EventArgs e)
        {
            CMApi.RunMacro(TagName + "_CH");
        }
    }
}