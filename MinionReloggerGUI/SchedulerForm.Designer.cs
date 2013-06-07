using MetroFramework;
using MetroFramework.Controls;

namespace MinionLauncher.Forms
{
    partial class SchedulerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(MetroThemeStyle theme, MetroColorStyle style)
        {
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblLogin = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnManageBreaks = new MetroFramework.Controls.MetroButton();
            this.lblTimeInMinutes = new MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();

            this.metroStyleManager.Style = metroStyleManager.Style;
            this.metroStyleManager.Theme = metroStyleManager.Theme;
            this.metroStyleManager.OwnerForm = this;
            metroStyleManager.UpdateOwnerForm();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.CustomForeColor = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(24, 17);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(94, 19);
            this.metroLabel1.Style = metroStyleManager.Style;
            this.metroLabel1.StyleManager = metroStyleManager;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Login Name:";
            this.metroLabel1.Theme = metroStyleManager.Theme;
            this.metroLabel1.UseStyleColors = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.CustomBackground = false;
            this.metroLabel2.CustomForeColor = false;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel2.Location = new System.Drawing.Point(24, 40);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 19);
            this.metroLabel2.Style = metroStyleManager.Style;
            this.metroLabel2.StyleManager = metroStyleManager;
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Password:";
            this.metroLabel2.Theme = metroStyleManager.Theme;
            this.metroLabel2.UseStyleColors = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.CustomBackground = false;
            this.lblLogin.CustomForeColor = false;
            this.lblLogin.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblLogin.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.lblLogin.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblLogin.Location = new System.Drawing.Point(115, 16);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(41, 19);
            this.lblLogin.Style = metroStyleManager.Style;
            this.lblLogin.StyleManager = metroStyleManager;
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Login";
            this.lblLogin.Theme = metroStyleManager.Theme;
            this.lblLogin.UseStyleColors = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.CustomBackground = false;
            this.lblPassword.CustomForeColor = false;
            this.lblPassword.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblPassword.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.lblPassword.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblPassword.Location = new System.Drawing.Point(115, 40);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 19);
            this.lblPassword.Style = metroStyleManager.Style;
            this.lblPassword.StyleManager = metroStyleManager;
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            this.lblPassword.Theme = metroStyleManager.Theme;
            this.lblPassword.UseStyleColors = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(139, 78);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.CustomBackground = false;
            this.metroLabel3.CustomForeColor = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel3.Location = new System.Drawing.Point(24, 78);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 19);
            this.metroLabel3.Style = metroStyleManager.Style;
            this.metroLabel3.StyleManager = metroStyleManager;
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Start Time:";
            this.metroLabel3.Theme = metroStyleManager.Theme;
            this.metroLabel3.UseStyleColors = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.CustomBackground = false;
            this.metroLabel4.CustomForeColor = false;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel4.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel4.Location = new System.Drawing.Point(24, 111);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(72, 19);
            this.metroLabel4.Style = metroStyleManager.Style;
            this.metroLabel4.StyleManager = metroStyleManager;
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Stop Time:";
            this.metroLabel4.Theme = metroStyleManager.Theme;
            this.metroLabel4.UseStyleColors = false;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker3.Location = new System.Drawing.Point(139, 110);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker3.TabIndex = 7;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(139, 150);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(94, 20);
            this.numericUpDown1.TabIndex = 8;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.CustomBackground = false;
            this.metroLabel5.CustomForeColor = false;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel5.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel5.Location = new System.Drawing.Point(24, 150);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(109, 19);
            this.metroLabel5.Style = metroStyleManager.Style;
            this.metroLabel5.StyleManager = metroStyleManager;
            this.metroLabel5.TabIndex = 9;
            this.metroLabel5.Text = "Days (24h cycles):";
            this.metroLabel5.Theme = metroStyleManager.Theme;
            this.metroLabel5.UseStyleColors = false;
            ///
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.CustomBackground = false;
            this.metroLabel6.CustomForeColor = false;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel6.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel6.Location = new System.Drawing.Point(24, 183);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(150, 19);
            this.metroLabel6.Style = metroStyleManager.Style;
            this.metroLabel6.StyleManager = metroStyleManager;
            this.metroLabel6.TabIndex = 159;
            this.metroLabel6.Text = "Time in minutes:";
            this.metroLabel6.Theme = metroStyleManager.Theme;
            this.metroLabel6.UseStyleColors = false;
            // 
            ///
            this.lblTimeInMinutes.AutoSize = true;
            this.lblTimeInMinutes.CustomBackground = false;
            this.lblTimeInMinutes.CustomForeColor = false;
            this.lblTimeInMinutes.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblTimeInMinutes.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.lblTimeInMinutes.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblTimeInMinutes.Location = new System.Drawing.Point(139, 183);
            this.lblTimeInMinutes.Name = "metroLabel7";
            this.lblTimeInMinutes.Size = new System.Drawing.Size(109, 19);
            this.lblTimeInMinutes.Style = metroStyleManager.Style;
            this.lblTimeInMinutes.StyleManager = metroStyleManager;
            this.lblTimeInMinutes.TabIndex = 13679;
            this.lblTimeInMinutes.Text = "0";
            this.lblTimeInMinutes.Theme = metroStyleManager.Theme;
            this.lblTimeInMinutes.UseStyleColors = false;
            // 
            // btnOK
            // 
            this.btnOK.Highlight = false;
            this.btnOK.Location = new System.Drawing.Point(207, 227);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = metroStyleManager.Style;
            this.btnOK.StyleManager = metroStyleManager;
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Save";
            this.btnOK.Theme = metroStyleManager.Theme;
            // 
            // btnCancel
            // 
            this.btnCancel.Highlight = false;
            this.btnCancel.Location = new System.Drawing.Point(10, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = metroStyleManager.Style;
            this.btnCancel.StyleManager = metroStyleManager;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Theme = metroStyleManager.Theme;
            // 
            // btnManageBreaks
            // 
            this.btnManageBreaks.Highlight = false;
            this.btnManageBreaks.Location = new System.Drawing.Point(100, 227);
            this.btnManageBreaks.Name = "btnManageBreaks";
            this.btnManageBreaks.Size = new System.Drawing.Size(90, 23);
            this.btnManageBreaks.Style = metroStyleManager.Style;
            this.btnManageBreaks.StyleManager = metroStyleManager;
            this.btnManageBreaks.TabIndex = 11;
            this.btnManageBreaks.Text = "Manage Breaks";
            this.btnManageBreaks.Theme = metroStyleManager.Theme;
            // 
            // SchedulerForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnManageBreaks);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.lblTimeInMinutes);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(292, 273);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(292, 273);
            this.Name = "SchedulerForm";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel lblTimeInMinutes;
        private MetroFramework.Controls.MetroLabel lblLogin;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton btnOK;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnManageBreaks;
    }
}