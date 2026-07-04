using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CMFaceplateManager
{
    public partial class DigitalMOSFaceplate : Form
    {
        public string TagName { get; }

        private readonly Timer pollTimer;

        public DigitalMOSFaceplate(string tagName)
        {
            TagName = tagName.Trim();

            InitializeComponent();

            this.Text = TagName;

            pollTimer = new Timer();
            pollTimer.Interval = 1000;
            pollTimer.Tick += PollTimer_Tick;

            Load += FormCreate;
            Activated += FormActivate;
            FormClosed += DigitalMOSFaceplate_FormClosed;
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            // Later: read digital/MOS status here if needed.
        }

        private void DigitalMOSFaceplate_FormClosed(object sender, FormClosedEventArgs e)
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
                workArea.Left,
                workArea.Top);
        }

        private void ROClick(object sender, EventArgs e)
        {
            Console.WriteLine($"[{TagName}] ROClick");

            Screen screen = Screen.FromControl(this);
            Rectangle workArea = screen.WorkingArea;

            this.Location = new Point(
                workArea.Right - this.Width,
                workArea.Top);
        }
        private void LoadTasterMetadata()
        {
            string csvPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Taster.csv");

            try
            {
                var lookup = new TasterLookup(csvPath);

                string processTag = lookup.ProcessTag(TagName);
                string description = lookup.Description(TagName);

                PrcTag.Text = string.IsNullOrWhiteSpace(processTag)
                    ? TagName
                    : processTag;

                Description.Text = string.IsNullOrWhiteSpace(description)
                    ? TagName
                    : description;
            }
            catch (Exception ex)
            {
                PrcTag.Text = TagName;
                Description.Text = TagName;

                System.Diagnostics.Debug.WriteLine(
                    $"[{TagName}] LoadTasterMetadata failed: {ex.Message}");
            }
        }

        private void Parameter_0Click(object sender, EventArgs e)
        {
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
            LoadTasterMetadata();
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

        private void SPL_Click(object sender, EventArgs e)
        {
        }
    }
}