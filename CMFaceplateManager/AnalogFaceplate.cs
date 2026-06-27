using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public partial class AnalogFaceplate : Form
    {
        public string TagName { get; }

        private readonly Timer pollTimer;

        private bool showHH = true;
        private bool showH = true;
        private bool showL = true;
        private bool showLL = true;

        private string valueFormat = "0.00";

        public AnalogFaceplate(string tagName)
        {
            TagName = tagName.Trim();

            InitializeComponent();

            PrcTag.Text = TagName;
            this.Text = TagName;
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

                Anz_0_X.Text = value.ToString(valueFormat);
                Anz_0_X.ForeColor = Color.Black;

                int processValue = (int)Math.Round(value);

                if (processValue < ProcessBar.Minimum)
                    processValue = ProcessBar.Minimum;

                if (processValue > ProcessBar.Maximum)
                    processValue = ProcessBar.Maximum;

                ProcessBar.Value = processValue;
                ProcessBar.Invalidate();

                double spHH = CMApi.ReadAnalog(TagName + "_SPHH");
                double spH = CMApi.ReadAnalog(TagName + "_SPH");
                double spL = CMApi.ReadAnalog(TagName + "_SPL");
                double spLL = CMApi.ReadAnalog(TagName + "_SPLL");

                if (showHH)
                {
                    SPHH.Text = spHH.ToString(valueFormat);
                    ProcessBar.SPHH = ClampToBarRange(spHH);
                }
                else
                {
                    ProcessBar.SPHH = null;
                }

                if (showH)
                {
                    SPH.Text = spH.ToString(valueFormat);
                    ProcessBar.SPH = ClampToBarRange(spH);
                }
                else
                {
                    ProcessBar.SPH = null;
                }

                if (showL)
                {
                    SPL.Text = spL.ToString(valueFormat);
                    ProcessBar.SPL = ClampToBarRange(spL);
                }
                else
                {
                    ProcessBar.SPL = null;
                }

                if (showLL)
                {
                    SPLL.Text = spLL.ToString(valueFormat);
                    ProcessBar.SPLL = ClampToBarRange(spLL);
                }
                else
                {
                    ProcessBar.SPLL = null;
                }

                ProcessBar.Invalidate();
            }
            catch (Exception ex)
            {
                Anz_0_X.Text = "ERR";
                Anz_0_X.ForeColor = Color.Red;

                System.Diagnostics.Debug.WriteLine(
                    $"[{TagName}] ReadAndShowValue failed: {ex.Message}");
            }
        }

        private int ClampToBarRange(double value)
        {
            int intValue = (int)Math.Round(value);

            if (intValue < ProcessBar.Minimum)
                return ProcessBar.Minimum;

            if (intValue > ProcessBar.Maximum)
                return ProcessBar.Maximum;

            return intValue;
        }

        private void LoadTagMetadata()
        {
            string csvPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Regler.csv");

            try
            {
                var lookup = new TagLookup(csvPath);

                valueFormat = BuildNumberFormat(lookup.Format(TagName));

                showHH = lookup.ShowHH(TagName);
                showH = lookup.ShowH(TagName);
                showL = lookup.ShowL(TagName);
                showLL = lookup.ShowLL(TagName);

                SPHH.Visible = showHH;
                SPH.Visible = showH;
                SPL.Visible = showL;
                SPLL.Visible = showLL;

                string description = lookup.Description(TagName);
                string Range = lookup.Range(TagName);
                string ProcessTag = lookup.TAG(TagName);

                Description.Text = string.IsNullOrWhiteSpace(description)
                      ? TagName
                      : description;

                Span.Text = string.IsNullOrWhiteSpace(Range)
                    ? string.Empty
                    : Range;
                PrcTag.Text = string.IsNullOrWhiteSpace(ProcessTag)
                    ? string.Empty
                    : ProcessTag;
                int min;
                int max;

                if (int.TryParse(lookup.LR(TagName), out min) &&
                    int.TryParse(lookup.HR(TagName), out max) &&
                    max > min)
                {
                    ProcessBar.Minimum = min;
                    ProcessBar.Maximum = max;
                }
                else
                {
                    ProcessBar.Minimum = 0;
                    ProcessBar.Maximum = 100;
                }

                ProcessBar.Invalidate();
            }
            catch (Exception ex)
            {
                Description.Text = TagName;
                Span.Text = string.Empty;
                PrcTag.Text = TagName;
                ProcessBar.Minimum = 0;
                ProcessBar.Maximum = 100;

                System.Diagnostics.Debug.WriteLine(
                    $"[{TagName}] LoadTagMetadata failed: {ex.Message}");
            }
        }

        private string BuildNumberFormat(string formatText)
        {
            if (string.IsNullOrWhiteSpace(formatText))
                return "0.00";

            string[] parts = formatText.Trim().Split('.');

            if (parts.Length != 2)
                return "0.00";

            int beforeDecimal;
            int afterDecimal;

            if (!int.TryParse(parts[0], out beforeDecimal))
                beforeDecimal = 1;

            if (!int.TryParse(parts[1], out afterDecimal))
                afterDecimal = 2;

            if (beforeDecimal < 1)
                beforeDecimal = 1;

            if (afterDecimal < 0)
                afterDecimal = 0;

            string before = new string('#', beforeDecimal - 1) + "0";

            if (afterDecimal == 0)
                return before;

            string after = new string('0', afterDecimal);

            return before + "." + after;
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
            Screen screen = Screen.FromControl(this);
            Rectangle workArea = screen.WorkingArea;

            this.Location = new Point(
                workArea.Left,   // flush to left edge
                workArea.Top     // flush to top edge
            );
        }

        private void ROClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] ROClick");
            Screen screen = Screen.FromControl(this);
            Rectangle workArea = screen.WorkingArea;

            this.Location = new Point(
                workArea.Right - this.Width,   // flush to right edge
                workArea.Top                   // flush to top edge
            );
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
            CMApi.RunMacro(TagName + "_OSS");
        }

        private void MOS_RESETClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_RESETClick");
            CMApi.RunMacro(TagName + "_OSR");
        }

        private void CONF_MOS_S_ButtonClick(object sender, EventArgs e)
        {
            MOS_PASS.Clear();
            MOS_Panel.Visible = !MOS_Panel.Visible;
        }

        private void MOS_SET1Click(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_SET1Click");
            CMApi.RunMacro(TagName + "_OSS");
        }

        private void MOS_RESET1Click(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] MOS_RESET1Click");
            CMApi.RunMacro(TagName + "_OSR");
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
            LoadTagMetadata();
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

            Pin_Button.Text = TopMost ? "🔒" : "🔓";
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