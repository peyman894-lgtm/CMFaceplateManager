// AnalogFaceplate.Designer.cs
// Direct translation of the original Delphi Form3 (.dfm) control hierarchy,
// positions, and sizes into WinForms designer-style InitializeComponent().
// This IS editable/visible in the Visual Studio Designer view.
//
// Original Delphi form: Form3 : TForm3 (analog faceplate - gauge, limits, chart)
//
// NOTE: TGauge (Delphi gauge control) has no exact WinForms stock equivalent;
// ported here as a vertical ProgressBar. Visit the Designer after pasting
// this in to confirm nesting/positions render as expected, then adjust
// visually if anything looks off - a 60+ control hand-transcription is a
// good first draft, not guaranteed pixel-perfect.

namespace CMFaceplateManager
{
    partial class AnalogFaceplate
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel P_0;
        private System.Windows.Forms.Panel Panel3;

        private System.Windows.Forms.Panel PV_Panel;
        private System.Windows.Forms.Label DT_0_X;
        private System.Windows.Forms.Panel F_0_X;
        private System.Windows.Forms.Panel Panel6;
        private System.Windows.Forms.Label Anz_0_X;

        private System.Windows.Forms.Panel SP_Panel;
        private System.Windows.Forms.Label DT_0_O2;
        private System.Windows.Forms.Label DT_0_O1;
        private System.Windows.Forms.Label DT_0_U1;
        private System.Windows.Forms.Label DT_0_U2;
        private System.Windows.Forms.Panel PO2_0;
        private System.Windows.Forms.Label SPHH;
        private System.Windows.Forms.Panel PO1_0;
        private System.Windows.Forms.Label SPH;
        private System.Windows.Forms.Panel PU1_0;
        private System.Windows.Forms.Label SPL;
        private System.Windows.Forms.Panel PU2_0;
        private System.Windows.Forms.Label SPLL;

        private System.Windows.Forms.TextBox WAR_0;

        private System.Windows.Forms.Panel Panel4;
        private System.Windows.Forms.Panel P_100;
        private System.Windows.Forms.Panel P_90;
        private System.Windows.Forms.Panel P_80;
        private System.Windows.Forms.Panel P_10;
        private System.Windows.Forms.Panel P_20;
        private System.Windows.Forms.Panel P_30;
        private System.Windows.Forms.Panel P_40;
        private System.Windows.Forms.Panel P_50;
        private System.Windows.Forms.Panel P_60;
        private System.Windows.Forms.Panel P_70;
        private System.Windows.Forms.Panel markerHH;
        private System.Windows.Forms.Panel markerH;
        private System.Windows.Forms.Panel markerL;
        private System.Windows.Forms.Panel markerLL;

        private System.Windows.Forms.Panel Panel8;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label PrcTag;

        private System.Windows.Forms.Button Chart;

        private System.Windows.Forms.Panel Panel5;
        private System.Windows.Forms.Label Span;

        private System.Windows.Forms.Button Setpoints;
        private System.Windows.Forms.Button MOS_Button;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.TextBox Edit1;

        private System.Windows.Forms.Panel MOS_Panel;
        private System.Windows.Forms.Label StaticText1;
        private System.Windows.Forms.Button MOS_SET;
        private System.Windows.Forms.Button MOS_RESET;
        private System.Windows.Forms.Button CONF_MOS_S_Button;
        private System.Windows.Forms.Button CONF_MOS_M_Button;
        private System.Windows.Forms.Button MOS_Reset3;
        private System.Windows.Forms.Button MOS_Set3;
        private System.Windows.Forms.Label StaticText2;

        private System.Windows.Forms.Panel MOS1;
        private System.Windows.Forms.Button Confirm1;
        private System.Windows.Forms.Button MOS_RESET1;
        private System.Windows.Forms.Button MOS_SET1;
        private System.Windows.Forms.Label StaticText4;

        private System.Windows.Forms.Button LO;
        private System.Windows.Forms.Button RO;

        private void InitializeComponent()
        {
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LO = new System.Windows.Forms.Button();
            this.RO = new System.Windows.Forms.Button();
            this.Pin_Button = new System.Windows.Forms.Button();
            this.P_0 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.MOS_Panel = new System.Windows.Forms.Panel();
            this.StaticText1 = new System.Windows.Forms.Label();
            this.MOS_SET = new System.Windows.Forms.Button();
            this.MOS_RESET = new System.Windows.Forms.Button();
            this.CONF_MOS_S_Button = new System.Windows.Forms.Button();
            this.StaticText2 = new System.Windows.Forms.Label();
            this.MOS_Set3 = new System.Windows.Forms.Button();
            this.MOS_Reset3 = new System.Windows.Forms.Button();
            this.CONF_MOS_M_Button = new System.Windows.Forms.Button();
            this.MOS_PASS = new System.Windows.Forms.TextBox();
            this.PV_Panel = new System.Windows.Forms.Panel();
            this.DT_0_X = new System.Windows.Forms.Label();
            this.F_0_X = new System.Windows.Forms.Panel();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.Anz_0_X = new System.Windows.Forms.Label();
            this.SP_Panel = new System.Windows.Forms.Panel();
            this.DT_0_O2 = new System.Windows.Forms.Label();
            this.DT_0_O1 = new System.Windows.Forms.Label();
            this.DT_0_U1 = new System.Windows.Forms.Label();
            this.DT_0_U2 = new System.Windows.Forms.Label();
            this.PO2_0 = new System.Windows.Forms.Panel();
            this.SPHH = new System.Windows.Forms.Label();
            this.PO1_0 = new System.Windows.Forms.Panel();
            this.SPH = new System.Windows.Forms.Label();
            this.PU1_0 = new System.Windows.Forms.Panel();
            this.SPL = new System.Windows.Forms.Label();
            this.PU2_0 = new System.Windows.Forms.Panel();
            this.SPLL = new System.Windows.Forms.Label();
            this.WAR_0 = new System.Windows.Forms.TextBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.P_100 = new System.Windows.Forms.Panel();
            this.P_90 = new System.Windows.Forms.Panel();
            this.P_80 = new System.Windows.Forms.Panel();
            this.P_70 = new System.Windows.Forms.Panel();
            this.P_60 = new System.Windows.Forms.Panel();
            this.P_50 = new System.Windows.Forms.Panel();
            this.P_40 = new System.Windows.Forms.Panel();
            this.P_30 = new System.Windows.Forms.Panel();
            this.P_20 = new System.Windows.Forms.Panel();
            this.P_10 = new System.Windows.Forms.Panel();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.PrcTag = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.Chart = new System.Windows.Forms.Button();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Span = new System.Windows.Forms.Label();
            this.Setpoints = new System.Windows.Forms.Button();
            this.MOS_Button = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Edit1 = new System.Windows.Forms.TextBox();
            this.MOS1 = new System.Windows.Forms.Panel();
            this.StaticText4 = new System.Windows.Forms.Label();
            this.MOS_SET1 = new System.Windows.Forms.Button();
            this.MOS_RESET1 = new System.Windows.Forms.Button();
            this.Confirm1 = new System.Windows.Forms.Button();
            this.Gauge0_X = new CMFaceplateManager.VerticalProgressBar();
            this.Panel1.SuspendLayout();
            this.P_0.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.MOS_Panel.SuspendLayout();
            this.PV_Panel.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.SP_Panel.SuspendLayout();
            this.PO2_0.SuspendLayout();
            this.PO1_0.SuspendLayout();
            this.PU1_0.SuspendLayout();
            this.PU2_0.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.MOS1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.LO);
            this.Panel1.Controls.Add(this.RO);
            this.Panel1.Controls.Add(this.Pin_Button);
            this.Panel1.Controls.Add(this.P_0);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(226, 840);
            this.Panel1.TabIndex = 0;
            this.Panel1.Click += new System.EventHandler(this.E_Regler_Zu);
            this.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseDown);
            // 
            // LO
            // 
            this.LO.Location = new System.Drawing.Point(0, 0);
            this.LO.Margin = new System.Windows.Forms.Padding(4);
            this.LO.Name = "LO";
            this.LO.Size = new System.Drawing.Size(36, 26);
            this.LO.TabIndex = 1;
            this.LO.Text = "<";
            this.LO.Click += new System.EventHandler(this.LOClick);
            // 
            // RO
            // 
            this.RO.Location = new System.Drawing.Point(191, 0);
            this.RO.Margin = new System.Windows.Forms.Padding(4);
            this.RO.Name = "RO";
            this.RO.Size = new System.Drawing.Size(36, 26);
            this.RO.TabIndex = 2;
            this.RO.Text = ">";
            this.RO.Click += new System.EventHandler(this.ROClick);
            // 
            // Pin_Button
            // 
            this.Pin_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pin_Button.Location = new System.Drawing.Point(100, 0);
            this.Pin_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Pin_Button.Name = "Pin_Button";
            this.Pin_Button.Size = new System.Drawing.Size(30, 26);
            this.Pin_Button.TabIndex = 3;
            this.Pin_Button.Text = "🔓";
            this.Pin_Button.Click += new System.EventHandler(this.Pin_Button_Click);
            // 
            // P_0
            // 
            this.P_0.BackColor = System.Drawing.Color.Black;
            this.P_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.P_0.Controls.Add(this.Panel3);
            this.P_0.Controls.Add(this.MOS1);
            this.P_0.Location = new System.Drawing.Point(9, 16);
            this.P_0.Margin = new System.Windows.Forms.Padding(4);
            this.P_0.Name = "P_0";
            this.P_0.Size = new System.Drawing.Size(199, 800);
            this.P_0.TabIndex = 0;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Gray;
            this.Panel3.Controls.Add(this.MOS_Panel);
            this.Panel3.Controls.Add(this.MOS_PASS);
            this.Panel3.Controls.Add(this.PV_Panel);
            this.Panel3.Controls.Add(this.SP_Panel);
            this.Panel3.Controls.Add(this.WAR_0);
            this.Panel3.Controls.Add(this.Panel4);
            this.Panel3.Controls.Add(this.Panel8);
            this.Panel3.Controls.Add(this.Chart);
            this.Panel3.Controls.Add(this.Panel5);
            this.Panel3.Controls.Add(this.Setpoints);
            this.Panel3.Controls.Add(this.MOS_Button);
            this.Panel3.Controls.Add(this.Button2);
            this.Panel3.Controls.Add(this.Edit1);
            this.Panel3.Location = new System.Drawing.Point(17, 16);
            this.Panel3.Margin = new System.Windows.Forms.Padding(4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(165, 769);
            this.Panel3.TabIndex = 0;
            this.Panel3.Click += new System.EventHandler(this.E_Regler_Zu);
            // 
            // MOS_Panel
            // 
            this.MOS_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MOS_Panel.Controls.Add(this.StaticText1);
            this.MOS_Panel.Controls.Add(this.MOS_SET);
            this.MOS_Panel.Controls.Add(this.MOS_RESET);
            this.MOS_Panel.Controls.Add(this.CONF_MOS_S_Button);
            this.MOS_Panel.Controls.Add(this.StaticText2);
            this.MOS_Panel.Controls.Add(this.MOS_Set3);
            this.MOS_Panel.Controls.Add(this.MOS_Reset3);
            this.MOS_Panel.Controls.Add(this.CONF_MOS_M_Button);
            this.MOS_Panel.Location = new System.Drawing.Point(3, 411);
            this.MOS_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.MOS_Panel.Name = "MOS_Panel";
            this.MOS_Panel.Size = new System.Drawing.Size(158, 356);
            this.MOS_Panel.TabIndex = 11;
            this.MOS_Panel.Visible = false;
            // 
            // StaticText1
            // 
            this.StaticText1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StaticText1.Location = new System.Drawing.Point(3, 6);
            this.StaticText1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StaticText1.Name = "StaticText1";
            this.StaticText1.Size = new System.Drawing.Size(143, 25);
            this.StaticText1.TabIndex = 0;
            this.StaticText1.Text = "MOS-Startup";
            this.StaticText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MOS_SET
            // 
            this.MOS_SET.Location = new System.Drawing.Point(11, 39);
            this.MOS_SET.Margin = new System.Windows.Forms.Padding(4);
            this.MOS_SET.Name = "MOS_SET";
            this.MOS_SET.Size = new System.Drawing.Size(129, 41);
            this.MOS_SET.TabIndex = 1;
            this.MOS_SET.Text = "activate";
            this.MOS_SET.Click += new System.EventHandler(this.MOS_SETClick);
            // 
            // MOS_RESET
            // 
            this.MOS_RESET.Location = new System.Drawing.Point(11, 79);
            this.MOS_RESET.Margin = new System.Windows.Forms.Padding(4);
            this.MOS_RESET.Name = "MOS_RESET";
            this.MOS_RESET.Size = new System.Drawing.Size(129, 41);
            this.MOS_RESET.TabIndex = 2;
            this.MOS_RESET.Text = "remove";
            this.MOS_RESET.Click += new System.EventHandler(this.MOS_RESETClick);
            // 
            // CONF_MOS_S_Button
            // 
            this.CONF_MOS_S_Button.Location = new System.Drawing.Point(11, 128);
            this.CONF_MOS_S_Button.Margin = new System.Windows.Forms.Padding(4);
            this.CONF_MOS_S_Button.Name = "CONF_MOS_S_Button";
            this.CONF_MOS_S_Button.Size = new System.Drawing.Size(129, 41);
            this.CONF_MOS_S_Button.TabIndex = 3;
            this.CONF_MOS_S_Button.Text = "confirm";
            this.CONF_MOS_S_Button.Click += new System.EventHandler(this.CONF_MOS_S_ButtonClick);
            // 
            // StaticText2
            // 
            this.StaticText2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StaticText2.Location = new System.Drawing.Point(3, 183);
            this.StaticText2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StaticText2.Name = "StaticText2";
            this.StaticText2.Size = new System.Drawing.Size(143, 25);
            this.StaticText2.TabIndex = 4;
            this.StaticText2.Text = "MOS-Maintenance";
            this.StaticText2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MOS_Set3
            // 
            this.MOS_Set3.Location = new System.Drawing.Point(11, 217);
            this.MOS_Set3.Margin = new System.Windows.Forms.Padding(4);
            this.MOS_Set3.Name = "MOS_Set3";
            this.MOS_Set3.Size = new System.Drawing.Size(129, 41);
            this.MOS_Set3.TabIndex = 5;
            this.MOS_Set3.Text = "activate";
            this.MOS_Set3.Click += new System.EventHandler(this.MOS_SET1Click);
            // 
            // MOS_Reset3
            // 
            this.MOS_Reset3.Location = new System.Drawing.Point(11, 256);
            this.MOS_Reset3.Margin = new System.Windows.Forms.Padding(4);
            this.MOS_Reset3.Name = "MOS_Reset3";
            this.MOS_Reset3.Size = new System.Drawing.Size(129, 41);
            this.MOS_Reset3.TabIndex = 6;
            this.MOS_Reset3.Text = "remove";
            this.MOS_Reset3.Click += new System.EventHandler(this.MOS_RESET1Click);
            // 
            // CONF_MOS_M_Button
            // 
            this.CONF_MOS_M_Button.Location = new System.Drawing.Point(11, 305);
            this.CONF_MOS_M_Button.Margin = new System.Windows.Forms.Padding(4);
            this.CONF_MOS_M_Button.Name = "CONF_MOS_M_Button";
            this.CONF_MOS_M_Button.Size = new System.Drawing.Size(129, 41);
            this.CONF_MOS_M_Button.TabIndex = 7;
            this.CONF_MOS_M_Button.Text = "confirm";
            this.CONF_MOS_M_Button.Click += new System.EventHandler(this.CONF_MOS_M_ButtonClick);
            // 
            // MOS_PASS
            // 
            this.MOS_PASS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MOS_PASS.Location = new System.Drawing.Point(34, 677);
            this.MOS_PASS.Name = "MOS_PASS";
            this.MOS_PASS.Size = new System.Drawing.Size(107, 34);
            this.MOS_PASS.TabIndex = 12;
            this.MOS_PASS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MOS_PASS.UseSystemPasswordChar = true;
            this.MOS_PASS.Visible = false;
            this.MOS_PASS.TextChanged += new System.EventHandler(this.MOS_PASS_TextChanged);
            this.MOS_PASS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MOS_PASS_KeyDown);
            // 
            // PV_Panel
            // 
            this.PV_Panel.BackColor = System.Drawing.Color.Gray;
            this.PV_Panel.Controls.Add(this.DT_0_X);
            this.PV_Panel.Controls.Add(this.F_0_X);
            this.PV_Panel.Controls.Add(this.Panel6);
            this.PV_Panel.Location = new System.Drawing.Point(1, 408);
            this.PV_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.PV_Panel.Name = "PV_Panel";
            this.PV_Panel.Size = new System.Drawing.Size(161, 169);
            this.PV_Panel.TabIndex = 0;
            this.PV_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Anz_0_Paint);
            // 
            // DT_0_X
            // 
            this.DT_0_X.Font = new System.Drawing.Font("Arial", 9.75F);
            this.DT_0_X.Location = new System.Drawing.Point(13, 48);
            this.DT_0_X.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DT_0_X.Name = "DT_0_X";
            this.DT_0_X.Size = new System.Drawing.Size(12, 21);
            this.DT_0_X.TabIndex = 0;
            this.DT_0_X.Text = "X";
            // 
            // F_0_X
            // 
            this.F_0_X.BackColor = System.Drawing.Color.Maroon;
            this.F_0_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.F_0_X.Location = new System.Drawing.Point(9, 68);
            this.F_0_X.Margin = new System.Windows.Forms.Padding(4);
            this.F_0_X.Name = "F_0_X";
            this.F_0_X.Size = new System.Drawing.Size(21, 7);
            this.F_0_X.TabIndex = 1;
            // 
            // Panel6
            // 
            this.Panel6.BackColor = System.Drawing.Color.White;
            this.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel6.Controls.Add(this.Anz_0_X);
            this.Panel6.Location = new System.Drawing.Point(35, 41);
            this.Panel6.Margin = new System.Windows.Forms.Padding(4);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(112, 31);
            this.Panel6.TabIndex = 2;
            // 
            // Anz_0_X
            // 
            this.Anz_0_X.BackColor = System.Drawing.Color.White;
            this.Anz_0_X.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Anz_0_X.Font = new System.Drawing.Font("Arial", 10.5F);
            this.Anz_0_X.Location = new System.Drawing.Point(0, 0);
            this.Anz_0_X.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Anz_0_X.Name = "Anz_0_X";
            this.Anz_0_X.Size = new System.Drawing.Size(108, 27);
            this.Anz_0_X.TabIndex = 0;
            this.Anz_0_X.Text = "Anz_0_X";
            this.Anz_0_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Anz_0_X.Click += new System.EventHandler(this.Anz_0_X_Click_1);
            // 
            // SP_Panel
            // 
            this.SP_Panel.BackColor = System.Drawing.Color.Gray;
            this.SP_Panel.Controls.Add(this.DT_0_O2);
            this.SP_Panel.Controls.Add(this.DT_0_O1);
            this.SP_Panel.Controls.Add(this.DT_0_U1);
            this.SP_Panel.Controls.Add(this.DT_0_U2);
            this.SP_Panel.Controls.Add(this.PO2_0);
            this.SP_Panel.Controls.Add(this.PO1_0);
            this.SP_Panel.Controls.Add(this.PU1_0);
            this.SP_Panel.Controls.Add(this.PU2_0);
            this.SP_Panel.Location = new System.Drawing.Point(3, 409);
            this.SP_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.SP_Panel.Name = "SP_Panel";
            this.SP_Panel.Size = new System.Drawing.Size(161, 169);
            this.SP_Panel.TabIndex = 1;
            this.SP_Panel.Visible = false;
            // 
            // DT_0_O2
            // 
            this.DT_0_O2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.DT_0_O2.Location = new System.Drawing.Point(7, 9);
            this.DT_0_O2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DT_0_O2.Name = "DT_0_O2";
            this.DT_0_O2.Size = new System.Drawing.Size(24, 21);
            this.DT_0_O2.TabIndex = 0;
            this.DT_0_O2.Text = "H2";
            // 
            // DT_0_O1
            // 
            this.DT_0_O1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.DT_0_O1.Location = new System.Drawing.Point(7, 48);
            this.DT_0_O1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DT_0_O1.Name = "DT_0_O1";
            this.DT_0_O1.Size = new System.Drawing.Size(24, 21);
            this.DT_0_O1.TabIndex = 1;
            this.DT_0_O1.Text = "H1";
            // 
            // DT_0_U1
            // 
            this.DT_0_U1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.DT_0_U1.Location = new System.Drawing.Point(7, 89);
            this.DT_0_U1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DT_0_U1.Name = "DT_0_U1";
            this.DT_0_U1.Size = new System.Drawing.Size(21, 21);
            this.DT_0_U1.TabIndex = 2;
            this.DT_0_U1.Text = "L1";
            // 
            // DT_0_U2
            // 
            this.DT_0_U2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.DT_0_U2.Location = new System.Drawing.Point(7, 128);
            this.DT_0_U2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DT_0_U2.Name = "DT_0_U2";
            this.DT_0_U2.Size = new System.Drawing.Size(21, 21);
            this.DT_0_U2.TabIndex = 3;
            this.DT_0_U2.Text = "L2";
            // 
            // PO2_0
            // 
            this.PO2_0.BackColor = System.Drawing.Color.White;
            this.PO2_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PO2_0.Controls.Add(this.SPHH);
            this.PO2_0.Location = new System.Drawing.Point(35, 0);
            this.PO2_0.Margin = new System.Windows.Forms.Padding(4);
            this.PO2_0.Name = "PO2_0";
            this.PO2_0.Size = new System.Drawing.Size(112, 32);
            this.PO2_0.TabIndex = 4;
            // 
            // SPHH
            // 
            this.SPHH.BackColor = System.Drawing.Color.White;
            this.SPHH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPHH.Font = new System.Drawing.Font("Arial", 10.5F);
            this.SPHH.Location = new System.Drawing.Point(0, 0);
            this.SPHH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SPHH.Name = "SPHH";
            this.SPHH.Size = new System.Drawing.Size(108, 28);
            this.SPHH.TabIndex = 0;
            this.SPHH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SPHH.Click += new System.EventHandler(this.Edit_0_O2_Click);
            // 
            // PO1_0
            // 
            this.PO1_0.BackColor = System.Drawing.Color.White;
            this.PO1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PO1_0.Controls.Add(this.SPH);
            this.PO1_0.Location = new System.Drawing.Point(35, 41);
            this.PO1_0.Margin = new System.Windows.Forms.Padding(4);
            this.PO1_0.Name = "PO1_0";
            this.PO1_0.Size = new System.Drawing.Size(112, 31);
            this.PO1_0.TabIndex = 5;
            // 
            // SPH
            // 
            this.SPH.BackColor = System.Drawing.Color.White;
            this.SPH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPH.Font = new System.Drawing.Font("Arial", 10.5F);
            this.SPH.Location = new System.Drawing.Point(0, 0);
            this.SPH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SPH.Name = "SPH";
            this.SPH.Size = new System.Drawing.Size(108, 27);
            this.SPH.TabIndex = 0;
            this.SPH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PU1_0
            // 
            this.PU1_0.BackColor = System.Drawing.Color.White;
            this.PU1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PU1_0.Controls.Add(this.SPL);
            this.PU1_0.Location = new System.Drawing.Point(35, 80);
            this.PU1_0.Margin = new System.Windows.Forms.Padding(4);
            this.PU1_0.Name = "PU1_0";
            this.PU1_0.Size = new System.Drawing.Size(112, 32);
            this.PU1_0.TabIndex = 6;
            // 
            // SPL
            // 
            this.SPL.BackColor = System.Drawing.Color.White;
            this.SPL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPL.Font = new System.Drawing.Font("Arial", 10.5F);
            this.SPL.Location = new System.Drawing.Point(0, 0);
            this.SPL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SPL.Name = "SPL";
            this.SPL.Size = new System.Drawing.Size(108, 28);
            this.SPL.TabIndex = 0;
            this.SPL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PU2_0
            // 
            this.PU2_0.BackColor = System.Drawing.Color.White;
            this.PU2_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PU2_0.Controls.Add(this.SPLL);
            this.PU2_0.Location = new System.Drawing.Point(35, 121);
            this.PU2_0.Margin = new System.Windows.Forms.Padding(4);
            this.PU2_0.Name = "PU2_0";
            this.PU2_0.Size = new System.Drawing.Size(112, 31);
            this.PU2_0.TabIndex = 7;
            // 
            // SPLL
            // 
            this.SPLL.BackColor = System.Drawing.Color.White;
            this.SPLL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPLL.Font = new System.Drawing.Font("Arial", 10.5F);
            this.SPLL.Location = new System.Drawing.Point(0, 0);
            this.SPLL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SPLL.Name = "SPLL";
            this.SPLL.Size = new System.Drawing.Size(108, 27);
            this.SPLL.TabIndex = 0;
            this.SPLL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WAR_0
            // 
            this.WAR_0.Location = new System.Drawing.Point(217, 633);
            this.WAR_0.Margin = new System.Windows.Forms.Padding(4);
            this.WAR_0.Name = "WAR_0";
            this.WAR_0.Size = new System.Drawing.Size(16, 22);
            this.WAR_0.TabIndex = 2;
            this.WAR_0.Text = "WAR_0";
            this.WAR_0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WAR_0KeyDown);
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.Black;
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel4.Controls.Add(this.Gauge0_X);
            this.Panel4.Controls.Add(this.P_100);
            this.Panel4.Controls.Add(this.P_90);
            this.Panel4.Controls.Add(this.P_80);
            this.Panel4.Controls.Add(this.P_70);
            this.Panel4.Controls.Add(this.P_60);
            this.Panel4.Controls.Add(this.P_50);
            this.Panel4.Controls.Add(this.P_40);
            this.Panel4.Controls.Add(this.P_30);
            this.Panel4.Controls.Add(this.P_20);
            this.Panel4.Controls.Add(this.P_10);
            this.Panel4.Location = new System.Drawing.Point(13, 73);
            this.Panel4.Margin = new System.Windows.Forms.Padding(4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(139, 303);
            this.Panel4.TabIndex = 3;
            // 
            // P_100
            // 
            this.P_100.BackColor = System.Drawing.Color.White;
            this.P_100.Location = new System.Drawing.Point(128, 2);
            this.P_100.Margin = new System.Windows.Forms.Padding(4);
            this.P_100.Name = "P_100";
            this.P_100.Size = new System.Drawing.Size(12, 1);
            this.P_100.TabIndex = 1;
            // 
            // P_90
            // 
            this.P_90.BackColor = System.Drawing.Color.White;
            this.P_90.Location = new System.Drawing.Point(128, 30);
            this.P_90.Margin = new System.Windows.Forms.Padding(4);
            this.P_90.Name = "P_90";
            this.P_90.Size = new System.Drawing.Size(12, 2);
            this.P_90.TabIndex = 2;
            // 
            // P_80
            // 
            this.P_80.BackColor = System.Drawing.Color.White;
            this.P_80.Location = new System.Drawing.Point(128, 60);
            this.P_80.Margin = new System.Windows.Forms.Padding(4);
            this.P_80.Name = "P_80";
            this.P_80.Size = new System.Drawing.Size(12, 1);
            this.P_80.TabIndex = 3;
            // 
            // P_70
            // 
            this.P_70.BackColor = System.Drawing.Color.White;
            this.P_70.Location = new System.Drawing.Point(128, 90);
            this.P_70.Margin = new System.Windows.Forms.Padding(4);
            this.P_70.Name = "P_70";
            this.P_70.Size = new System.Drawing.Size(12, 2);
            this.P_70.TabIndex = 4;
            // 
            // P_60
            // 
            this.P_60.BackColor = System.Drawing.Color.White;
            this.P_60.Location = new System.Drawing.Point(128, 121);
            this.P_60.Margin = new System.Windows.Forms.Padding(4);
            this.P_60.Name = "P_60";
            this.P_60.Size = new System.Drawing.Size(12, 1);
            this.P_60.TabIndex = 5;
            // 
            // P_50
            // 
            this.P_50.BackColor = System.Drawing.Color.White;
            this.P_50.Location = new System.Drawing.Point(128, 150);
            this.P_50.Margin = new System.Windows.Forms.Padding(4);
            this.P_50.Name = "P_50";
            this.P_50.Size = new System.Drawing.Size(12, 2);
            this.P_50.TabIndex = 6;
            // 
            // P_40
            // 
            this.P_40.BackColor = System.Drawing.Color.White;
            this.P_40.Location = new System.Drawing.Point(128, 180);
            this.P_40.Margin = new System.Windows.Forms.Padding(4);
            this.P_40.Name = "P_40";
            this.P_40.Size = new System.Drawing.Size(12, 2);
            this.P_40.TabIndex = 7;
            // 
            // P_30
            // 
            this.P_30.BackColor = System.Drawing.Color.White;
            this.P_30.Location = new System.Drawing.Point(128, 210);
            this.P_30.Margin = new System.Windows.Forms.Padding(4);
            this.P_30.Name = "P_30";
            this.P_30.Size = new System.Drawing.Size(12, 1);
            this.P_30.TabIndex = 8;
            // 
            // P_20
            // 
            this.P_20.BackColor = System.Drawing.Color.White;
            this.P_20.Location = new System.Drawing.Point(128, 240);
            this.P_20.Margin = new System.Windows.Forms.Padding(4);
            this.P_20.Name = "P_20";
            this.P_20.Size = new System.Drawing.Size(12, 2);
            this.P_20.TabIndex = 9;
            // 
            // P_10
            // 
            this.P_10.BackColor = System.Drawing.Color.White;
            this.P_10.Location = new System.Drawing.Point(128, 270);
            this.P_10.Margin = new System.Windows.Forms.Padding(4);
            this.P_10.Name = "P_10";
            this.P_10.Size = new System.Drawing.Size(12, 2);
            this.P_10.TabIndex = 10;
            // 
            // Panel8
            // 
            this.Panel8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel8.Controls.Add(this.PrcTag);
            this.Panel8.Controls.Add(this.Description);
            this.Panel8.Location = new System.Drawing.Point(5, 9);
            this.Panel8.Margin = new System.Windows.Forms.Padding(4);
            this.Panel8.Name = "Panel8";
            this.Panel8.Size = new System.Drawing.Size(157, 56);
            this.Panel8.TabIndex = 4;
            // 
            // PrcTag
            // 
            this.PrcTag.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrcTag.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.PrcTag.Location = new System.Drawing.Point(0, 5);
            this.PrcTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PrcTag.Name = "PrcTag";
            this.PrcTag.Size = new System.Drawing.Size(157, 26);
            this.PrcTag.TabIndex = 0;
            this.PrcTag.Text = "LIRA-0900";
            this.PrcTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Description
            // 
            this.Description.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold);
            this.Description.Location = new System.Drawing.Point(0, 31);
            this.Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(157, 26);
            this.Description.TabIndex = 1;
            this.Description.Text = "Sammelbeh. B0900";
            this.Description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Chart
            // 
            this.Chart.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Chart.Location = new System.Drawing.Point(27, 624);
            this.Chart.Margin = new System.Windows.Forms.Padding(4);
            this.Chart.Name = "Chart";
            this.Chart.Size = new System.Drawing.Size(121, 33);
            this.Chart.TabIndex = 5;
            this.Chart.Text = "Chart";
            this.Chart.Click += new System.EventHandler(this.ChartClick);
            // 
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel5.Controls.Add(this.Span);
            this.Panel5.Location = new System.Drawing.Point(5, 380);
            this.Panel5.Margin = new System.Windows.Forms.Padding(4);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(157, 25);
            this.Panel5.TabIndex = 6;
            // 
            // Span
            // 
            this.Span.BackColor = System.Drawing.Color.Yellow;
            this.Span.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Span.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold);
            this.Span.Location = new System.Drawing.Point(0, 0);
            this.Span.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Span.Name = "Span";
            this.Span.Size = new System.Drawing.Size(157, 25);
            this.Span.TabIndex = 0;
            this.Span.Text = "0 - 100 %";
            this.Span.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Setpoints
            // 
            this.Setpoints.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Setpoints.Location = new System.Drawing.Point(27, 585);
            this.Setpoints.Margin = new System.Windows.Forms.Padding(4);
            this.Setpoints.Name = "Setpoints";
            this.Setpoints.Size = new System.Drawing.Size(121, 32);
            this.Setpoints.TabIndex = 7;
            this.Setpoints.Text = "Setpoints";
            this.Setpoints.Click += new System.EventHandler(this.SP_ButtonClick);
            // 
            // MOS_Button
            // 
            this.MOS_Button.Font = new System.Drawing.Font("Arial", 9.75F);
            this.MOS_Button.Location = new System.Drawing.Point(27, 665);
            this.MOS_Button.Margin = new System.Windows.Forms.Padding(4);
            this.MOS_Button.Name = "MOS_Button";
            this.MOS_Button.Size = new System.Drawing.Size(121, 57);
            this.MOS_Button.TabIndex = 8;
            this.MOS_Button.Text = "MOS";
            this.MOS_Button.Click += new System.EventHandler(this.MOS_ButtonClick);
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Button2.Location = new System.Drawing.Point(27, 729);
            this.Button2.Margin = new System.Windows.Forms.Padding(4);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(121, 32);
            this.Button2.TabIndex = 9;
            this.Button2.Text = "close VIEW";
            this.Button2.Click += new System.EventHandler(this.E_Regler_Zu);
            // 
            // Edit1
            // 
            this.Edit1.Location = new System.Drawing.Point(32, 670);
            this.Edit1.Margin = new System.Windows.Forms.Padding(4);
            this.Edit1.Name = "Edit1";
            this.Edit1.PasswordChar = '*';
            this.Edit1.Size = new System.Drawing.Size(107, 22);
            this.Edit1.TabIndex = 10;
            this.Edit1.Visible = false;
            this.Edit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Edit1KeyPress);
            // 
            // MOS1
            // 
            this.MOS1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MOS1.Controls.Add(this.StaticText4);
            this.MOS1.Controls.Add(this.MOS_SET1);
            this.MOS1.Controls.Add(this.MOS_RESET1);
            this.MOS1.Controls.Add(this.Confirm1);
            this.MOS1.Location = new System.Drawing.Point(28, 591);
            this.MOS1.Margin = new System.Windows.Forms.Padding(4);
            this.MOS1.Name = "MOS1";
            this.MOS1.Size = new System.Drawing.Size(147, 187);
            this.MOS1.TabIndex = 1;
            this.MOS1.Visible = false;
            // 
            // StaticText4
            // 
            this.StaticText4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StaticText4.Location = new System.Drawing.Point(3, 6);
            this.StaticText4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StaticText4.Name = "StaticText4";
            this.StaticText4.Size = new System.Drawing.Size(143, 25);
            this.StaticText4.TabIndex = 0;
            this.StaticText4.Text = "MOS-Maint.";
            this.StaticText4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MOS_SET1
            // 
            this.MOS_SET1.Location = new System.Drawing.Point(11, 39);
            this.MOS_SET1.Margin = new System.Windows.Forms.Padding(4);
            this.MOS_SET1.Name = "MOS_SET1";
            this.MOS_SET1.Size = new System.Drawing.Size(129, 41);
            this.MOS_SET1.TabIndex = 1;
            this.MOS_SET1.Text = "activate";
            this.MOS_SET1.Click += new System.EventHandler(this.MOS_SET1Click);
            // 
            // MOS_RESET1
            // 
            this.MOS_RESET1.Location = new System.Drawing.Point(11, 79);
            this.MOS_RESET1.Margin = new System.Windows.Forms.Padding(4);
            this.MOS_RESET1.Name = "MOS_RESET1";
            this.MOS_RESET1.Size = new System.Drawing.Size(129, 41);
            this.MOS_RESET1.TabIndex = 2;
            this.MOS_RESET1.Text = "remove";
            this.MOS_RESET1.Click += new System.EventHandler(this.MOS_RESET1Click);
            // 
            // Confirm1
            // 
            this.Confirm1.Location = new System.Drawing.Point(11, 128);
            this.Confirm1.Margin = new System.Windows.Forms.Padding(4);
            this.Confirm1.Name = "Confirm1";
            this.Confirm1.Size = new System.Drawing.Size(129, 41);
            this.Confirm1.TabIndex = 3;
            this.Confirm1.Text = "Confirm";
            this.Confirm1.Click += new System.EventHandler(this.CONF_MOS_M_ButtonClick);
            // 
            // Gauge0_X
            // 
            this.Gauge0_X.ForeColor = System.Drawing.Color.Red;
            this.Gauge0_X.Location = new System.Drawing.Point(83, 1);
            this.Gauge0_X.Margin = new System.Windows.Forms.Padding(4);
            this.Gauge0_X.Maximum = 300;
            this.Gauge0_X.Name = "Gauge0_X";
            this.Gauge0_X.Size = new System.Drawing.Size(21, 303);
            this.Gauge0_X.TabIndex = 0;
            this.Gauge0_X.Click += new System.EventHandler(this.Gauge0_X_Click);
            // 
            // AnalogFaceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(228, 863);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnalogFaceplate";
            this.Text = "Analog Faceplate";
            this.Panel1.ResumeLayout(false);
            this.P_0.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.MOS_Panel.ResumeLayout(false);
            this.PV_Panel.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.SP_Panel.ResumeLayout(false);
            this.PO2_0.ResumeLayout(false);
            this.PO1_0.ResumeLayout(false);
            this.PU1_0.ResumeLayout(false);
            this.PU2_0.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.MOS1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox MOS_PASS;
        private System.Windows.Forms.Button Pin_Button;
        private VerticalProgressBar Gauge0_X;
    }
}
