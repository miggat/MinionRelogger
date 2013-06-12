using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Core;
using MinionReloggerLib.Helpers.Input;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionLauncherGUI
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            Logger.Initialize(lstBoxLog);
            ComponentManager.Singleton.LoadComponents();
            ThreadManager.Singleton.Initialize();
            PopulateGlobalSettings();
            CycleTabsForRenderer();
            if (!LoadConfig(false) || !File.Exists(Config.Singleton.GeneralSettings.GW2Path))
                SetGW2Path();

            var test = new Account();
            test.SetBotPath(AppDomain.CurrentDomain.BaseDirectory);
            test.SetEndTime(DateTime.Now.AddMinutes(1337));
            test.SetLoginName("robert.vd.boorn@gmail.com");
            test.SetManuallyScheduled(false);
            test.SetShouldBeRunning(true);
            test.SetNoSound(true);
            test.SetPassword("minion-bot");
            test.SetSchedulingEnabled(false);
            test.SetStartTime(DateTime.Now.AddSeconds(30));
            test.SetSchedulingEnabled(true);
            var test2 = new BreakObject();
            test.SetBreak(test2);
            test.BreakObject.Interval = 1;
            test.BreakObject.BreakDuration = 1;
            test.BreakObject.IntervalDelay = 1;
            test.BreakObject.BreakDurationDelay = 1;
            test.BreakObject.BreakEnabled = true;
            Config.Singleton.AddAccount(test);
            test.BreakObject.Update();


            var test3 = new Account();
            test3.SetSchedulingEnabled(true);
            test3.SetBotPath(AppDomain.CurrentDomain.BaseDirectory);
            test3.SetEndTime(DateTime.Now.AddMinutes(1337));
            test3.SetLoginName("mmopewpew@gmail.com");
            test3.SetManuallyScheduled(false);
            test3.SetNoSound(true);
            test3.SetPassword("mmominion");
            test3.SetSchedulingEnabled(true);
            test3.SetShouldBeRunning(true);
            test3.SetStartTime(DateTime.Now.AddSeconds(120));
            var test4 = new BreakObject();
            test3.SetBreak(test4);
            test3.BreakObject.Interval = 1;
            test3.BreakObject.BreakDuration = 1;
            test3.BreakObject.IntervalDelay = 1;
            test3.BreakObject.BreakDurationDelay = 1;
            test3.BreakObject.BreakEnabled = true;
            Config.Singleton.AddAccount(test3);
            test3.BreakObject.Update();
        }

        private void MetroTileStartAllClick(object sender, EventArgs e)
        {
            foreach (var account in Config.Singleton.AccountSettings)
            {
                account.SetShouldBeRunning(true);
            }
        }

        private void MetroTileStopAllClick(object sender, EventArgs e)
        {
            foreach (var account in Config.Singleton.AccountSettings)
            {
                account.SetShouldBeRunning(false);
            }
        }

        private void MetroTileChangeThemeClick(object sender, EventArgs e)
        {
            var rng = new Random();
            ICollection<string> themes = MetroStyleManager.Styles.Themes.Keys;
            while (true)
            {
                string newTheme = themes.ElementAt(rng.Next(themes.Count));
                if (newTheme == metroStyleManager.Theme) continue;
                metroStyleManager.Theme = newTheme;
                Config.Singleton.GeneralSettings.SetTheme(newTheme);
                return;
            }
        }

        private void MetroTileChangeColorClick(object sender, EventArgs e)
        {
            var rng = new Random();
            ICollection<string> styles = MetroStyleManager.Styles.Styles.Keys;
            while (true)
            {
                string newStyle = styles.ElementAt(rng.Next(styles.Count));
                if (newStyle == metroStyleManager.Style || newStyle == "White") continue;
                metroStyleManager.Style = newStyle;
                Config.Singleton.GeneralSettings.SetStyle(metroStyleManager.Style);
                return;
            }
        }


        private void BtnSettingsClick(object sender, EventArgs e)
        {
            if (metroComboBoxGlobalSettingsComponents.SelectedIndex != -1)
                ComponentManager.Singleton.OpenSettingsForm(
                    ComponentManager.Singleton.GetGlobalSettingsComponentNames()[
                        metroComboBoxGlobalSettingsComponents.SelectedIndex]);
        }

        private void MetroToggleMinimizeGW2CheckedChanged(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetMinimizeWindows(metroToggleMinimizeGW2.Checked);
        }

        private void BtnLoadClick(object sender, EventArgs e)
        {
            LoadConfig(true);
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            Config.SaveSettingsToFile();
        }

        private void BtnSetExePathClick(object sender, EventArgs e)
        {
            SetGW2Path(Config.Singleton.GeneralSettings.GW2Path);
        }

        private void BtnSetPollingDelayClick(object sender, EventArgs e)
        {
            SetPollingDelay(false, Config.Singleton.GeneralSettings.PollingDelay);
        }

        private void CycleTabsForRenderer()
        {
            metroTabControl1.SelectTab(0);
            metroTabControl1.SelectTab(1);
            metroTabControl1.SelectTab(2);
            metroTabControl1.SelectTab(0);
        }

        private void PopulateGlobalSettings()
        {
            metroComboBoxGlobalSettingsComponents.Items.Clear();
            foreach (string component in ComponentManager.Singleton.GetGlobalSettingsComponentNames())
            {
                metroComboBoxGlobalSettingsComponents.Items.Add(component);
            }
        }

        private void SetGW2Path(string path = "")
        {
            var openFileDialog = new OpenFileDialog();


            openFileDialog.Filter = "Guild Wars 2 Executables (.exe)|GW2.exe|Executables (.exe)|*.exe";
            if (path != "")
                openFileDialog.InitialDirectory = path;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            MessageBox.Show("Please locate your GW2 executable.", "Locate GW2 Executable");
            while (
                openFileDialog.ShowDialog() !=
                DialogResult.OK || !File.Exists(openFileDialog.FileName)) ;
            Config.Singleton.GeneralSettings.SetGW2Path(openFileDialog.FileName);
        }

        private void SetPollingDelay(bool mustBeEntered = true, int currentValue = 0)
        {
            int final;
            string result = currentValue == 0 ? @"3" : currentValue.ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 3 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult = InputBox.ShowInputBox("Polling Delay",
                                                     "Please enter the desired polling delay (!minimum: 3, in seconds!).",
                                                     ref result);
                done = true;
            }

            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.SetPollingDelay(final);
        }


        private bool LoadConfig(bool manual)
        {
            if (Config.LoadConfig(manual))
            {
                metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
                metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
                metroToggleMinimizeGW2.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
                return true;
            }
            return false;
        }
    }
}