using System.Windows.Forms;

namespace CMFaceplateManager
{
    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                // PBS_VERTICAL
                cp.Style |= 0x04;

                return cp;
            }
        }
    }
}