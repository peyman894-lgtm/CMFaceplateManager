// ValveFaceplate.Designer.cs
// Direct translation of the original Delphi Form3 (.dfm) control hierarchy,
// positions, and sizes into WinForms designer-style InitializeComponent().
// This IS editable/visible in the Visual Studio Designer view.
//
//
// NOTE: TGauge (Delphi gauge control) has no exact WinForms stock equivalent;
// ported here as a vertical ProgressBar. Visit the Designer after pasting
// this in to confirm nesting/positions render as expected, then adjust
// visually if anything looks off - a 60+ control hand-transcription is a
// good first draft, not guaranteed pixel-perfect.

namespace CMFaceplateManager
{
    partial class ValveFaceplate
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

        private System.Windows.Forms.TextBox WAR_0;
        private System.Windows.Forms.Panel markerHH;
        private System.Windows.Forms.Panel markerH;
        private System.Windows.Forms.Panel markerL;
        private System.Windows.Forms.Panel markerLL;

        private System.Windows.Forms.Panel Panel8;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label PrcTag;
        private System.Windows.Forms.Button Button2;

        private System.Windows.Forms.Panel Command_Panel;
        private System.Windows.Forms.Button CONF_Button;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OpenButton;
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
            this.Command_Panel = new System.Windows.Forms.Panel();
            this.StaticText2 = new System.Windows.Forms.Label();
            this.OpenButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CONF_Button = new System.Windows.Forms.Button();
            this.WAR_0 = new System.Windows.Forms.TextBox();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.PrcTag = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.MOS1 = new System.Windows.Forms.Panel();
            this.StaticText4 = new System.Windows.Forms.Label();
            this.MOS_SET1 = new System.Windows.Forms.Button();
            this.MOS_RESET1 = new System.Windows.Forms.Button();
            this.Confirm1 = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.P_0.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Command_Panel.SuspendLayout();
            this.Panel8.SuspendLayout();
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
            this.Panel3.Controls.Add(this.Command_Panel);
            this.Panel3.Controls.Add(this.WAR_0);
            this.Panel3.Controls.Add(this.Panel8);
            this.Panel3.Controls.Add(this.Button2);
            this.Panel3.Location = new System.Drawing.Point(17, 16);
            this.Panel3.Margin = new System.Windows.Forms.Padding(4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(165, 769);
            this.Panel3.TabIndex = 0;
            this.Panel3.Click += new System.EventHandler(this.E_Regler_Zu);
            // 
            // Command_Panel
            // 
            this.Command_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Command_Panel.Controls.Add(this.StaticText2);
            this.Command_Panel.Controls.Add(this.OpenButton);
            this.Command_Panel.Controls.Add(this.CloseButton);
            this.Command_Panel.Controls.Add(this.CONF_Button);
            this.Command_Panel.Location = new System.Drawing.Point(4, 122);
            this.Command_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Command_Panel.Name = "Command_Panel";
            this.Command_Panel.Size = new System.Drawing.Size(157, 370);
            this.Command_Panel.TabIndex = 11;
            // 
            // StaticText2
            // 
            this.StaticText2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StaticText2.Location = new System.Drawing.Point(3, 183);
            this.StaticText2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StaticText2.Name = "StaticText2";
            this.StaticText2.Size = new System.Drawing.Size(143, 25);
            this.StaticText2.TabIndex = 4;
            this.StaticText2.Text = "Command";
            this.StaticText2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(11, 217);
            this.OpenButton.Margin = new System.Windows.Forms.Padding(4);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(129, 41);
            this.OpenButton.TabIndex = 5;
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenClick);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(11, 256);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(129, 41);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Close";
            this.CloseButton.Click += new System.EventHandler(this.CloseClick);
            // 
            // CONF_Button
            // 
            this.CONF_Button.Location = new System.Drawing.Point(11, 305);
            this.CONF_Button.Margin = new System.Windows.Forms.Padding(4);
            this.CONF_Button.Name = "CONF_Button";
            this.CONF_Button.Size = new System.Drawing.Size(129, 41);
            this.CONF_Button.TabIndex = 7;
            this.CONF_Button.Text = "confirm";
            this.CONF_Button.Click += new System.EventHandler(this.CONF_ButtonClick);
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
            // Confirm1
            // 
            this.Confirm1.Location = new System.Drawing.Point(11, 128);
            this.Confirm1.Margin = new System.Windows.Forms.Padding(4);
            this.Confirm1.Name = "Confirm1";
            this.Confirm1.Size = new System.Drawing.Size(129, 41);
            this.Confirm1.TabIndex = 3;
            this.Confirm1.Text = "Confirm";
            
            // 
            // ValveFaceplate
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
            this.Name = "ValveFaceplate";
            this.Text = "Valve Faceplate";
            this.Panel1.ResumeLayout(false);
            this.P_0.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Command_Panel.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.MOS1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Pin_Button;
    }
}
