using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public partial class ValveFaceplate : Form
    {
        public string TagName { get; }

        private readonly Timer pollTimer;

        private bool showHH = true;
        private bool showH = true;
        private bool showL = true;
        private bool showLL = true;

        private string valueFormat = "0.00";

        



        

        

        

        private void ValveFaceplate_FormClosed(object sender, FormClosedEventArgs e)
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

        private void OpenClick(object sender, EventArgs e)
        {

        }

        private void CloseClick(object sender, EventArgs e)
        {

        }

        private void CONF_ButtonClick(object sender, EventArgs e)
        {

        }
    }
}