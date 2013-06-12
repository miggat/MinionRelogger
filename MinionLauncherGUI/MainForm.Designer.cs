using MetroFramework.Forms;

namespace MinionLauncherGUI
{
    partial class MainForm : MetroForm
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pctBoxLogo = new System.Windows.Forms.PictureBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxGlobalSettingsComponents = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnSettings = new MetroFramework.Controls.MetroButton();
            this.metroToggleMinimizeGW2 = new MetroFramework.Controls.MetroToggle();
            this.btnSetExePath = new MetroFramework.Controls.MetroButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstBoxLog = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroTileStartAll = new MetroFramework.Controls.MetroTile();
            this.metroTileStopAll = new MetroFramework.Controls.MetroTile();
            this.metroTileChangeTheme = new MetroFramework.Controls.MetroTile();
            this.metroTileChangeColor = new MetroFramework.Controls.MetroTile();
            this.btnSetPollingDelay = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLogo)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxLogo
            // 
            this.pctBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxLogo.Image = global::MinionLauncherGUI.Properties.Resources.logo;
            this.pctBoxLogo.InitialImage = global::MinionLauncherGUI.Properties.Resources.logo;
            this.pctBoxLogo.Location = new System.Drawing.Point(14, 20);
            this.pctBoxLogo.Name = "pctBoxLogo";
            this.pctBoxLogo.Size = new System.Drawing.Size(326, 72);
            this.pctBoxLogo.TabIndex = 0;
            this.pctBoxLogo.TabStop = false;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage2);
            this.metroTabControl1.Controls.Add(this.tabPage3);
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 109);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(941, 389);
            this.metroTabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.btnSetPollingDelay);
            this.tabPage2.Controls.Add(this.btnLoad);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.metroLabel2);
            this.tabPage2.Controls.Add(this.metroComboBoxGlobalSettingsComponents);
            this.tabPage2.Controls.Add(this.metroLabel1);
            this.tabPage2.Controls.Add(this.btnSettings);
            this.tabPage2.Controls.Add(this.metroToggleMinimizeGW2);
            this.tabPage2.Controls.Add(this.btnSetExePath);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(933, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // btnLoad
            // 
            this.btnLoad.Highlight = true;
            this.btnLoad.Location = new System.Drawing.Point(401, 294);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
            // 
            // btnSave
            // 
            this.btnSave.Highlight = true;
            this.btnSave.Location = new System.Drawing.Point(401, 325);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(242, 114);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(158, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Minimize GW2 Windows?";
            // 
            // metroComboBoxGlobalSettingsComponents
            // 
            this.metroComboBoxGlobalSettingsComponents.FormattingEnabled = true;
            this.metroComboBoxGlobalSettingsComponents.ItemHeight = 23;
            this.metroComboBoxGlobalSettingsComponents.Location = new System.Drawing.Point(152, 8);
            this.metroComboBoxGlobalSettingsComponents.MaxDropDownItems = 15;
            this.metroComboBoxGlobalSettingsComponents.Name = "metroComboBoxGlobalSettingsComponents";
            this.metroComboBoxGlobalSettingsComponents.Size = new System.Drawing.Size(234, 29);
            this.metroComboBoxGlobalSettingsComponents.TabIndex = 6;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(15, 12);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(129, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Global Components:";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(401, 11);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(112, 23);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Open Settings";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettingsClick);
            // 
            // metroToggleMinimizeGW2
            // 
            this.metroToggleMinimizeGW2.AutoSize = true;
            this.metroToggleMinimizeGW2.Location = new System.Drawing.Point(414, 116);
            this.metroToggleMinimizeGW2.Name = "metroToggleMinimizeGW2";
            this.metroToggleMinimizeGW2.Size = new System.Drawing.Size(80, 17);
            this.metroToggleMinimizeGW2.TabIndex = 7;
            this.metroToggleMinimizeGW2.Text = "Off";
            this.metroToggleMinimizeGW2.CheckedChanged += new System.EventHandler(this.MetroToggleMinimizeGW2CheckedChanged);
            // 
            // btnSetExePath
            // 
            this.btnSetExePath.Location = new System.Drawing.Point(401, 48);
            this.btnSetExePath.Name = "btnSetExePath";
            this.btnSetExePath.Size = new System.Drawing.Size(112, 23);
            this.btnSetExePath.TabIndex = 6;
            this.btnSetExePath.Text = "Set GW2 EXE Path";
            this.btnSetExePath.Click += new System.EventHandler(this.BtnSetExePathClick);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.lstBoxLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(933, 360);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            // 
            // lstBoxLog
            // 
            this.lstBoxLog.FormattingEnabled = true;
            this.lstBoxLog.Location = new System.Drawing.Point(3, 4);
            this.lstBoxLog.Name = "lstBoxLog";
            this.lstBoxLog.Size = new System.Drawing.Size(927, 342);
            this.lstBoxLog.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(933, 360);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accounts";
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // metroTileStartAll
            // 
            this.metroTileStartAll.Location = new System.Drawing.Point(436, 20);
            this.metroTileStartAll.Name = "metroTileStartAll";
            this.metroTileStartAll.Size = new System.Drawing.Size(110, 103);
            this.metroTileStartAll.TabIndex = 2;
            this.metroTileStartAll.Text = " Start All";
            this.metroTileStartAll.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileStartAll.TileImage")));
            this.metroTileStartAll.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTileStartAll.UseTileImage = true;
            this.metroTileStartAll.Click += new System.EventHandler(this.MetroTileStartAllClick);
            // 
            // metroTileStopAll
            // 
            this.metroTileStopAll.Location = new System.Drawing.Point(561, 20);
            this.metroTileStopAll.Name = "metroTileStopAll";
            this.metroTileStopAll.Size = new System.Drawing.Size(110, 103);
            this.metroTileStopAll.TabIndex = 3;
            this.metroTileStopAll.Text = " Stop All";
            this.metroTileStopAll.TileImage = global::MinionLauncherGUI.Properties.Resources.halt;
            this.metroTileStopAll.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTileStopAll.UseTileImage = true;
            this.metroTileStopAll.Click += new System.EventHandler(this.MetroTileStopAllClick);
            // 
            // metroTileChangeTheme
            // 
            this.metroTileChangeTheme.Location = new System.Drawing.Point(686, 20);
            this.metroTileChangeTheme.Name = "metroTileChangeTheme";
            this.metroTileChangeTheme.Size = new System.Drawing.Size(110, 103);
            this.metroTileChangeTheme.TabIndex = 4;
            this.metroTileChangeTheme.Text = "Change Theme";
            this.metroTileChangeTheme.TileImage = global::MinionLauncherGUI.Properties.Resources.theme;
            this.metroTileChangeTheme.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTileChangeTheme.UseTileImage = true;
            this.metroTileChangeTheme.Click += new System.EventHandler(this.MetroTileChangeThemeClick);
            // 
            // metroTileChangeColor
            // 
            this.metroTileChangeColor.Location = new System.Drawing.Point(813, 20);
            this.metroTileChangeColor.Name = "metroTileChangeColor";
            this.metroTileChangeColor.Size = new System.Drawing.Size(110, 103);
            this.metroTileChangeColor.TabIndex = 5;
            this.metroTileChangeColor.Text = "Change Color";
            this.metroTileChangeColor.TileImage = global::MinionLauncherGUI.Properties.Resources.paint;
            this.metroTileChangeColor.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTileChangeColor.UseTileImage = true;
            this.metroTileChangeColor.Click += new System.EventHandler(this.MetroTileChangeColorClick);
            // 
            // btnSetPollingDelay
            // 
            this.btnSetPollingDelay.Location = new System.Drawing.Point(402, 81);
            this.btnSetPollingDelay.Name = "btnSetPollingDelay";
            this.btnSetPollingDelay.Size = new System.Drawing.Size(112, 23);
            this.btnSetPollingDelay.TabIndex = 11;
            this.btnSetPollingDelay.Text = "Set Polling Delay";
            this.btnSetPollingDelay.Click += new System.EventHandler(this.BtnSetPollingDelayClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 521);
            this.Controls.Add(this.metroTileChangeColor);
            this.Controls.Add(this.metroTileChangeTheme);
            this.Controls.Add(this.metroTileStopAll);
            this.Controls.Add(this.metroTileStartAll);
            this.Controls.Add(this.pctBoxLogo);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.SystemAeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLogo)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoxLogo;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lstBoxLog;
        private MetroFramework.Controls.MetroTile metroTileStartAll;
        private MetroFramework.Controls.MetroTile metroTileStopAll;
        private MetroFramework.Controls.MetroTile metroTileChangeTheme;
        private MetroFramework.Controls.MetroTile metroTileChangeColor;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroComboBox metroComboBoxGlobalSettingsComponents;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnSettings;
        private MetroFramework.Controls.MetroToggle metroToggleMinimizeGW2;
        private MetroFramework.Controls.MetroButton btnSetExePath;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnSetPollingDelay;
    }
}


