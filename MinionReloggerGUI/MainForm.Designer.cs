
namespace MinionReloggerGUI
{
    partial class MainForm
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
            MetroFramework.Controls.MetroButton btnSave;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSetBotPath = new MetroFramework.Controls.MetroButton();
            this.btnDeleteLogin = new MetroFramework.Controls.MetroButton();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.txtBoxLoginName = new MetroFramework.Controls.MetroTextBox();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager();
            this.lblLogin = new MetroFramework.Controls.MetroLabel();
            this.btnEdit = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.txtBoxPassword = new MetroFramework.Controls.MetroTextBox();
            this.chkBoxSound = new MetroFramework.Controls.MetroCheckBox();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.btnSetRestartDelay = new MetroFramework.Controls.MetroButton();
            this.btnDeleteIp = new MetroFramework.Controls.MetroButton();
            this.btnAddIP = new MetroFramework.Controls.MetroButton();
            this.chkBoxNewIp = new MetroFramework.Controls.MetroCheckBox();
            this.btnSetLaunchDelay = new MetroFramework.Controls.MetroButton();
            this.chkBoxMinimize = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton13 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.logBox = new System.Windows.Forms.ListBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton12 = new MetroFramework.Controls.MetroButton();
            this.metroButton11 = new MetroFramework.Controls.MetroButton();
            this.metroButton10 = new MetroFramework.Controls.MetroButton();
            this.metroButton9 = new MetroFramework.Controls.MetroButton();
            this.metroButton8 = new MetroFramework.Controls.MetroButton();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.btnHelp1 = new MetroFramework.Controls.MetroButton();
            this.picBoxLogoMinion = new System.Windows.Forms.PictureBox();
            this.tileChangeTheme = new MetroFramework.Controls.MetroTile();
            this.tileChangeColor = new MetroFramework.Controls.MetroTile();
            this.tileStartAll = new MetroFramework.Controls.MetroTile();
            this.tileStopAll = new MetroFramework.Controls.MetroTile();
            btnSave = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogoMinion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Highlight = true;
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.Style = MetroFramework.MetroColorStyle.Blue;
            btnSave.StyleManager = null;
            btnSave.Theme = MetroFramework.MetroThemeStyle.Dark;
            btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel1.Controls.Add(this.btnSetBotPath);
            this.splitContainer2.Panel1.Controls.Add(this.btnDeleteLogin);
            this.splitContainer2.Panel1.Controls.Add(this.btnLogin);
            this.splitContainer2.Panel1.Controls.Add(this.txtBoxLoginName);
            this.splitContainer2.Panel1.Controls.Add(this.lblLogin);
            this.splitContainer2.Panel1.Controls.Add(this.btnEdit);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer2.Panel2.Controls.Add(this.txtBoxPassword);
            this.splitContainer2.Panel2.Controls.Add(this.chkBoxSound);
            this.splitContainer2.Panel2.Controls.Add(this.lblPassword);
            // 
            // btnSetBotPath
            // 
            resources.ApplyResources(this.btnSetBotPath, "btnSetBotPath");
            this.btnSetBotPath.Highlight = false;
            this.btnSetBotPath.Name = "btnSetBotPath";
            this.btnSetBotPath.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnSetBotPath.StyleManager = null;
            this.btnSetBotPath.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSetBotPath.Click += new System.EventHandler(this.BtnSetBotPathClick);
            // 
            // btnDeleteLogin
            // 
            this.btnDeleteLogin.Highlight = false;
            resources.ApplyResources(this.btnDeleteLogin, "btnDeleteLogin");
            this.btnDeleteLogin.Name = "btnDeleteLogin";
            this.btnDeleteLogin.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnDeleteLogin.StyleManager = null;
            this.btnDeleteLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDeleteLogin.Click += new System.EventHandler(this.BtnDeleteLoginClick);
            // 
            // btnLogin
            // 
            this.btnLogin.Highlight = false;
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnLogin.StyleManager = null;
            this.btnLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLogin.Click += new System.EventHandler(this.BtnLoginClick);
            // 
            // txtBoxLoginName
            // 
            this.txtBoxLoginName.CustomBackground = false;
            this.txtBoxLoginName.CustomForeColor = false;
            this.txtBoxLoginName.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txtBoxLoginName.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            resources.ApplyResources(this.txtBoxLoginName, "txtBoxLoginName");
            this.txtBoxLoginName.Multiline = false;
            this.txtBoxLoginName.Name = "txtBoxLoginName";
            this.txtBoxLoginName.SelectedText = "";
            this.txtBoxLoginName.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBoxLoginName.StyleManager = this.metroStyleManager;
            this.txtBoxLoginName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtBoxLoginName.UseStyleColors = false;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.OwnerForm = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblLogin
            // 
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.CustomBackground = false;
            this.lblLogin.CustomForeColor = false;
            this.lblLogin.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblLogin.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.lblLogin.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblLogin.StyleManager = this.metroStyleManager;
            this.lblLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblLogin.UseStyleColors = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Highlight = false;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnEdit.StyleManager = null;
            this.btnEdit.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Highlight = false;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnCancel.StyleManager = null;
            this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.CustomBackground = false;
            this.txtBoxPassword.CustomForeColor = false;
            this.txtBoxPassword.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txtBoxPassword.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            resources.ApplyResources(this.txtBoxPassword, "txtBoxPassword");
            this.txtBoxPassword.Multiline = false;
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.SelectedText = "";
            this.txtBoxPassword.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBoxPassword.StyleManager = this.metroStyleManager;
            this.txtBoxPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtBoxPassword.UseStyleColors = false;
            // 
            // chkBoxSound
            // 
            resources.ApplyResources(this.chkBoxSound, "chkBoxSound");
            this.chkBoxSound.CustomBackground = false;
            this.chkBoxSound.CustomForeColor = false;
            this.chkBoxSound.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkBoxSound.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkBoxSound.Name = "chkBoxSound";
            this.chkBoxSound.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkBoxSound.StyleManager = this.metroStyleManager;
            this.chkBoxSound.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkBoxSound.UseStyleColors = false;
            this.chkBoxSound.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.CustomBackground = false;
            this.lblPassword.CustomForeColor = false;
            this.lblPassword.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblPassword.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.lblPassword.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblPassword.StyleManager = this.metroStyleManager;
            this.lblPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblPassword.UseStyleColors = false;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage5);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.CustomBackground = false;
            this.metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Medium;
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Light;
            resources.ApplyResources(this.metroTabControl1, "metroTabControl1");
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabControl1.StyleManager = this.metroStyleManager;
            this.metroTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            resources.ApplyResources(this.metroTabPage1, "metroTabPage1");
            this.metroTabPage1.BackColor = System.Drawing.Color.Transparent;
            this.metroTabPage1.Controls.Add(this.metroTabControl2);
            this.metroTabPage1.CustomBackground = false;
            this.metroTabPage1.ForeColor = System.Drawing.Color.Black;
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = true;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage1.StyleManager = this.metroStyleManager;
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = true;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Controls.Add(this.metroTabPage4);
            this.metroTabControl2.CustomBackground = false;
            this.metroTabControl2.FontSize = MetroFramework.MetroTabControlSize.Medium;
            this.metroTabControl2.FontWeight = MetroFramework.MetroTabControlWeight.Light;
            resources.ApplyResources(this.metroTabControl2, "metroTabControl2");
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 0;
            this.metroTabControl2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabControl2.StyleManager = null;
            this.metroTabControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTabControl2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl2.UseStyleColors = true;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.BackColor = System.Drawing.Color.Transparent;
            this.metroTabPage4.Controls.Add(this.metroLabel1);
            this.metroTabPage4.CustomBackground = false;
            this.metroTabPage4.ForeColor = System.Drawing.Color.Black;
            this.metroTabPage4.HorizontalScrollbar = false;
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.metroTabPage4, "metroTabPage4");
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage4.StyleManager = null;
            this.metroTabPage4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage4.VerticalScrollbar = false;
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.CustomForeColor = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = this.metroStyleManager;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = false;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.btnSetRestartDelay);
            this.metroTabPage2.Controls.Add(this.btnDeleteIp);
            this.metroTabPage2.Controls.Add(this.btnAddIP);
            this.metroTabPage2.Controls.Add(this.chkBoxNewIp);
            this.metroTabPage2.Controls.Add(this.btnSetLaunchDelay);
            this.metroTabPage2.Controls.Add(this.chkBoxMinimize);
            this.metroTabPage2.Controls.Add(this.metroButton13);
            this.metroTabPage2.Controls.Add(this.metroButton1);
            this.metroTabPage2.Controls.Add(this.btnLoad);
            this.metroTabPage2.Controls.Add(btnSave);
            this.metroTabPage2.Controls.Add(this.splitContainer2);
            this.metroTabPage2.CustomBackground = false;
            this.metroTabPage2.HorizontalScrollbar = false;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.metroTabPage2, "metroTabPage2");
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage2.StyleManager = this.metroStyleManager;
            this.metroTabPage2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage2.VerticalScrollbar = false;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // btnSetRestartDelay
            // 
            this.btnSetRestartDelay.Highlight = false;
            resources.ApplyResources(this.btnSetRestartDelay, "btnSetRestartDelay");
            this.btnSetRestartDelay.Name = "btnSetRestartDelay";
            this.btnSetRestartDelay.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnSetRestartDelay.StyleManager = null;
            this.btnSetRestartDelay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSetRestartDelay.Click += new System.EventHandler(this.BtnSetRestartDelayClick);
            // 
            // btnDeleteIp
            // 
            this.btnDeleteIp.Highlight = false;
            resources.ApplyResources(this.btnDeleteIp, "btnDeleteIp");
            this.btnDeleteIp.Name = "btnDeleteIp";
            this.btnDeleteIp.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnDeleteIp.StyleManager = null;
            this.btnDeleteIp.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDeleteIp.Click += new System.EventHandler(this.BtnDeleteIpClick);
            // 
            // btnAddIP
            // 
            this.btnAddIP.Highlight = false;
            resources.ApplyResources(this.btnAddIP, "btnAddIP");
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnAddIP.StyleManager = null;
            this.btnAddIP.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAddIP.Click += new System.EventHandler(this.BtnAddIPClick);
            // 
            // chkBoxNewIp
            // 
            resources.ApplyResources(this.chkBoxNewIp, "chkBoxNewIp");
            this.chkBoxNewIp.CustomBackground = false;
            this.chkBoxNewIp.CustomForeColor = false;
            this.chkBoxNewIp.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkBoxNewIp.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkBoxNewIp.Name = "chkBoxNewIp";
            this.chkBoxNewIp.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkBoxNewIp.StyleManager = null;
            this.chkBoxNewIp.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkBoxNewIp.UseStyleColors = false;
            this.chkBoxNewIp.UseVisualStyleBackColor = true;
            this.chkBoxNewIp.CheckedChanged += new System.EventHandler(this.ChkBoxNewIpCheckedChanged);
            // 
            // btnSetLaunchDelay
            // 
            this.btnSetLaunchDelay.Highlight = false;
            resources.ApplyResources(this.btnSetLaunchDelay, "btnSetLaunchDelay");
            this.btnSetLaunchDelay.Name = "btnSetLaunchDelay";
            this.btnSetLaunchDelay.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnSetLaunchDelay.StyleManager = null;
            this.btnSetLaunchDelay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSetLaunchDelay.Click += new System.EventHandler(this.BtnSetLaunchDelayClick);
            // 
            // chkBoxMinimize
            // 
            resources.ApplyResources(this.chkBoxMinimize, "chkBoxMinimize");
            this.chkBoxMinimize.CustomBackground = false;
            this.chkBoxMinimize.CustomForeColor = false;
            this.chkBoxMinimize.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkBoxMinimize.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkBoxMinimize.Name = "chkBoxMinimize";
            this.chkBoxMinimize.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkBoxMinimize.StyleManager = null;
            this.chkBoxMinimize.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkBoxMinimize.UseStyleColors = false;
            this.chkBoxMinimize.UseVisualStyleBackColor = true;
            this.chkBoxMinimize.CheckedChanged += new System.EventHandler(this.ChkBoxMinimizeCheckedChanged);
            // 
            // metroButton13
            // 
            this.metroButton13.Highlight = false;
            resources.ApplyResources(this.metroButton13, "metroButton13");
            this.metroButton13.Name = "metroButton13";
            this.metroButton13.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton13.StyleManager = null;
            this.metroButton13.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton13.Click += new System.EventHandler(this.BtnSetDelayClick);
            // 
            // metroButton1
            // 
            this.metroButton1.Highlight = false;
            resources.ApplyResources(this.metroButton1, "metroButton1");
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.StyleManager = null;
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.Click += new System.EventHandler(this.BtnSetPathClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Highlight = true;
            resources.ApplyResources(this.btnLoad, "btnLoad");
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnLoad.StyleManager = null;
            this.btnLoad.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.BackColor = System.Drawing.Color.Transparent;
            this.metroTabPage5.Controls.Add(this.logBox);
            this.metroTabPage5.CustomBackground = false;
            this.metroTabPage5.HorizontalScrollbar = false;
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.metroTabPage5, "metroTabPage5");
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage5.StyleManager = null;
            this.metroTabPage5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage5.VerticalScrollbar = false;
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 10;
            // 
            // logBox
            // 
            this.logBox.FormattingEnabled = true;
            resources.ApplyResources(this.logBox, "logBox");
            this.logBox.Name = "logBox";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroButton12);
            this.metroTabPage3.Controls.Add(this.metroButton11);
            this.metroTabPage3.Controls.Add(this.metroButton10);
            this.metroTabPage3.Controls.Add(this.metroButton9);
            this.metroTabPage3.Controls.Add(this.metroButton8);
            this.metroTabPage3.Controls.Add(this.metroButton7);
            this.metroTabPage3.Controls.Add(this.metroButton6);
            this.metroTabPage3.Controls.Add(this.metroButton5);
            this.metroTabPage3.Controls.Add(this.metroButton4);
            this.metroTabPage3.Controls.Add(this.metroButton3);
            this.metroTabPage3.Controls.Add(this.metroButton2);
            this.metroTabPage3.Controls.Add(this.btnHelp1);
            this.metroTabPage3.CustomBackground = false;
            this.metroTabPage3.HorizontalScrollbar = false;
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.metroTabPage3, "metroTabPage3");
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage3.StyleManager = this.metroStyleManager;
            this.metroTabPage3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage3.VerticalScrollbar = false;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroButton12
            // 
            this.metroButton12.Highlight = false;
            resources.ApplyResources(this.metroButton12, "metroButton12");
            this.metroButton12.Name = "metroButton12";
            this.metroButton12.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton12.StyleManager = null;
            this.metroButton12.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton11
            // 
            this.metroButton11.Highlight = false;
            resources.ApplyResources(this.metroButton11, "metroButton11");
            this.metroButton11.Name = "metroButton11";
            this.metroButton11.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton11.StyleManager = null;
            this.metroButton11.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton10
            // 
            this.metroButton10.Highlight = false;
            resources.ApplyResources(this.metroButton10, "metroButton10");
            this.metroButton10.Name = "metroButton10";
            this.metroButton10.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton10.StyleManager = null;
            this.metroButton10.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton9
            // 
            this.metroButton9.Highlight = false;
            resources.ApplyResources(this.metroButton9, "metroButton9");
            this.metroButton9.Name = "metroButton9";
            this.metroButton9.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton9.StyleManager = null;
            this.metroButton9.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton8
            // 
            this.metroButton8.Highlight = false;
            resources.ApplyResources(this.metroButton8, "metroButton8");
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton8.StyleManager = null;
            this.metroButton8.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton7
            // 
            this.metroButton7.Highlight = false;
            resources.ApplyResources(this.metroButton7, "metroButton7");
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton7.StyleManager = null;
            this.metroButton7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton6
            // 
            this.metroButton6.Highlight = false;
            resources.ApplyResources(this.metroButton6, "metroButton6");
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton6.StyleManager = null;
            this.metroButton6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton5
            // 
            this.metroButton5.Highlight = false;
            resources.ApplyResources(this.metroButton5, "metroButton5");
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton5.StyleManager = null;
            this.metroButton5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton4
            // 
            this.metroButton4.Highlight = false;
            resources.ApplyResources(this.metroButton4, "metroButton4");
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton4.StyleManager = null;
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton3
            // 
            this.metroButton3.Highlight = false;
            resources.ApplyResources(this.metroButton3, "metroButton3");
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton3.StyleManager = null;
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton2
            // 
            this.metroButton2.Highlight = false;
            resources.ApplyResources(this.metroButton2, "metroButton2");
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton2.StyleManager = null;
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnHelp1
            // 
            this.btnHelp1.Highlight = false;
            resources.ApplyResources(this.btnHelp1, "btnHelp1");
            this.btnHelp1.Name = "btnHelp1";
            this.btnHelp1.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnHelp1.StyleManager = null;
            this.btnHelp1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // picBoxLogoMinion
            // 
            this.picBoxLogoMinion.Image = global::MinionReloggerGUI.Properties.Resources.header__1_;
            resources.ApplyResources(this.picBoxLogoMinion, "picBoxLogoMinion");
            this.picBoxLogoMinion.Name = "picBoxLogoMinion";
            this.picBoxLogoMinion.TabStop = false;
            // 
            // tileChangeTheme
            // 
            this.tileChangeTheme.ActiveControl = null;
            this.tileChangeTheme.CustomBackground = false;
            this.tileChangeTheme.CustomForeColor = false;
            resources.ApplyResources(this.tileChangeTheme, "tileChangeTheme");
            this.tileChangeTheme.Name = "tileChangeTheme";
            this.tileChangeTheme.PaintTileCount = true;
            this.tileChangeTheme.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileChangeTheme.StyleManager = this.metroStyleManager;
            this.tileChangeTheme.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileChangeTheme.TileCount = 0;
            this.tileChangeTheme.Click += new System.EventHandler(this.TileChangeThemeClick);
            // 
            // tileChangeColor
            // 
            this.tileChangeColor.ActiveControl = null;
            this.tileChangeColor.CustomBackground = false;
            this.tileChangeColor.CustomForeColor = false;
            resources.ApplyResources(this.tileChangeColor, "tileChangeColor");
            this.tileChangeColor.Name = "tileChangeColor";
            this.tileChangeColor.PaintTileCount = true;
            this.tileChangeColor.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileChangeColor.StyleManager = this.metroStyleManager;
            this.tileChangeColor.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileChangeColor.TileCount = 0;
            this.tileChangeColor.Click += new System.EventHandler(this.TileChangeColorClick);
            // 
            // tileStartAll
            // 
            this.tileStartAll.ActiveControl = null;
            this.tileStartAll.CustomBackground = false;
            this.tileStartAll.CustomForeColor = false;
            resources.ApplyResources(this.tileStartAll, "tileStartAll");
            this.tileStartAll.Name = "tileStartAll";
            this.tileStartAll.PaintTileCount = true;
            this.tileStartAll.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileStartAll.StyleManager = this.metroStyleManager;
            this.tileStartAll.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileStartAll.TileCount = 0;
            this.tileStartAll.Click += new System.EventHandler(this.TileStartAllClick);
            // 
            // tileStopAll
            // 
            this.tileStopAll.ActiveControl = null;
            this.tileStopAll.CustomBackground = false;
            this.tileStopAll.CustomForeColor = false;
            resources.ApplyResources(this.tileStopAll, "tileStopAll");
            this.tileStopAll.Name = "tileStopAll";
            this.tileStopAll.PaintTileCount = true;
            this.tileStopAll.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileStopAll.StyleManager = this.metroStyleManager;
            this.tileStopAll.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileStopAll.TileCount = 0;
            this.tileStopAll.Click += new System.EventHandler(this.TileStopAllClick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileStopAll);
            this.Controls.Add(this.tileStartAll);
            this.Controls.Add(this.tileChangeColor);
            this.Controls.Add(this.tileChangeTheme);
            this.Controls.Add(this.picBoxLogoMinion);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "MainForm";
            this.Resizable = false;
            this.StyleManager = this.metroStyleManager;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage4.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage5.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogoMinion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroLabel lblLogin;
        private MetroFramework.Controls.MetroTextBox txtBoxLoginName;
        private MetroFramework.Controls.MetroTextBox txtBoxPassword;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroCheckBox chkBoxSound;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.PictureBox picBoxLogoMinion;
        internal System.Windows.Forms.SplitContainer splitContainer2;
        internal MetroFramework.Controls.MetroTabControl metroTabControl1;
        internal MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroTile tileChangeTheme;
        private MetroFramework.Controls.MetroTile tileChangeColor;
        private MetroFramework.Controls.MetroTile tileStopAll;
        private MetroFramework.Controls.MetroTile tileStartAll;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private System.Windows.Forms.ListBox logBox;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnEdit;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroButton btnDeleteLogin;
        private MetroFramework.Controls.MetroButton metroButton12;
        private MetroFramework.Controls.MetroButton metroButton11;
        private MetroFramework.Controls.MetroButton metroButton10;
        private MetroFramework.Controls.MetroButton metroButton9;
        private MetroFramework.Controls.MetroButton metroButton8;
        private MetroFramework.Controls.MetroButton metroButton7;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton btnHelp1;
        private MetroFramework.Controls.MetroButton metroButton13;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnSetBotPath;
        private MetroFramework.Controls.MetroCheckBox chkBoxMinimize;
        private MetroFramework.Controls.MetroButton btnSetLaunchDelay;
        private MetroFramework.Controls.MetroButton btnDeleteIp;
        private MetroFramework.Controls.MetroButton btnAddIP;
        private MetroFramework.Controls.MetroCheckBox chkBoxNewIp;
        private MetroFramework.Controls.MetroButton btnSetRestartDelay;
    }
}

