using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MinionLauncher.Forms;
using MinionReloggerGUI.CustomControls;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Core;
using MinionReloggerLib.CustomEventArgs;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Input;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;
using ProtoBuf;

namespace MinionReloggerGUI
{
    public delegate void ReloggerHandler(object sender, ReloggerEventArgs reloggerEventArgs);

    public partial class MainForm : MetroForm
    {
        public static DateTime ExpirationDate = new DateTime(2013, 6, 12, 0, 1, 0);
        internal readonly List<LauncherCustomControl> LauncherCustomControls = new List<LauncherCustomControl>();
        internal MetroThemeStyle CurrentThemeStyle = MetroThemeStyle.Dark;
        private int _newSet;
        private int _totalAccounts;

        public MainForm()
        {
            InitializeComponent();
            FixFormAppearance();
            AddLoggingObject();
            BindEvents();
            StartReloggerWorkerThreads();
            ConfigureFormAppearance();
        }

        private void FixFormAppearance()
        {
            MaximizeBox = false;
            Theme = CurrentThemeStyle;
        }

        private void StartReloggerWorkerThreads()
        {
            ThreadManager.Singleton.Initialize();
            ComponentManager.Singleton.LoadComponents();
        }

        private void ConfigureFormAppearance()
        {
            Config.Singleton.GeneralSettings.SetStyleSetting((int) metroStyleManager.Style);
            Config.Singleton.GeneralSettings.SetThemeSetting((int) metroStyleManager.Theme);
        }

        private void BindEvents()
        {
            Shown += OnShown;
        }

        private void AddLoggingObject()
        {
            Logger.LoggingObject = new Logger.ListBoxLog(logBox);
            logBox.HorizontalScrollbar = true;
        }

        private void OnShown(object sender, EventArgs eventArgs)
        {
            CycleTabsForRenderer();
            CheckExpirationDate();
            FixValues();
        }

        private void FixValues()
        {
            if (!LoadConfig(false))
            {
                SetGW2Path();
                SetPollingDelay();
            }
        }

        private void CheckExpirationDate()
        {
            if ((ExpirationDate - DateTime.Now).TotalSeconds < 1)
            {
                MessageBox.Show("This version of the launcher has expired. Please check the forums for details.",
                                "Launcher has expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
        }

        private void CycleTabsForRenderer()
        {
            metroTabControl1.SelectTab(0);
            metroTabControl1.SelectTab(1);
            metroTabControl1.SelectTab(2);
            metroTabControl1.SelectTab(3);
            metroTabControl1.SelectTab(0);
        }

        public event ReloggerHandler ReloggerEvent;

        protected virtual void OnReloggerEvent(ReloggerEventArgs reloggerEventArgs)
        {
            switch (reloggerEventArgs.Type)
            {
                case ERelogEventArgsType.OnStart:
                    Logger.LoggingObject.Log(ELogType.Debug, "Received OnStart event for: {0}.",
                                             reloggerEventArgs.Account.LoginName);
                    break;
                case ERelogEventArgsType.OnKill:
                    Logger.LoggingObject.Log(ELogType.Debug, "Received OnStop event for: {0}.",
                                             reloggerEventArgs.Account.LoginName);
                    break;
                case ERelogEventArgsType.OnSchedule:
                    Logger.LoggingObject.Log(ELogType.Debug, "Received Scheduler event for: {0}.",
                                             reloggerEventArgs.Account.LoginName);
                    break;
                case ERelogEventArgsType.OnError:
                    Logger.LoggingObject.Log(ELogType.Error, "Received an error event for: {0}.",
                                             reloggerEventArgs.Account.LoginName);
                    break;
                case ERelogEventArgsType.OnCrash:
                    Logger.LoggingObject.Log(ELogType.Critical, "Received a crash event for: {0}.",
                                             reloggerEventArgs.Account.LoginName);
                    break;
                case ERelogEventArgsType.OnUnknown:
                    Logger.LoggingObject.Log(ELogType.Debug, "Received an unidentified event for: {0}.",
                                             reloggerEventArgs.Account.LoginName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ReloggerHandler handler = ReloggerEvent;
            if (handler != null) handler(this, reloggerEventArgs);
        }

        private void SwapTheme()
        {
            CurrentThemeStyle = CurrentThemeStyle == MetroThemeStyle.Light
                                    ? MetroThemeStyle.Dark
                                    : MetroThemeStyle.Light;
            metroStyleManager.Theme = CurrentThemeStyle;
            Config.Singleton.GeneralSettings.SetThemeSetting((int) CurrentThemeStyle);
        }

        private void AddAccountToLauncher(Account account)
        {
            Logger.LoggingObject.Log(ELogType.Info, "Adding new account to the launcher: {0}.", account.LoginName);
            metroStyleManager.UpdateOwnerForm();
            if (_totalAccounts < 100)
            {
                CreateCustomControlForLauncher(account);

                foreach (Account ac in Config.Singleton.AccountSettings.ToArray())
                {
                    double differenceHistory = (DateTime.Now - account.EndTime).TotalSeconds;
                    if (ac.Running)
                    {
                        SetIsRunning(account);
                        if (differenceHistory > 0)
                        {
                            DisableSessionDueToScheduleExpiration(account);
                        }
                        if (!account.ShouldBeRunning)
                        {
                            StopSessionOfExpiredSchedule(account);
                        }
                    }
                    else if (!account.Running && !account.ShouldBeRunning &&
                             LauncherCustomControls[account.Index].BtnStart.Enabled)
                    {
                        if (differenceHistory > 0)
                        {
                            DisableButtonsOfAccount(account);
                        }

                        else
                        {
                            EnableButtonsOfAccount(account);
                        }
                    }
                    else
                    {
                        if (!account.ShouldBeRunning)
                        {
                            SetIsNotRunning(account);
                        }
                        if ((account.EndTime - DateTime.Now).TotalSeconds > 0 &&
                            (DateTime.Now - account.StartTime).TotalSeconds > 0)
                        {
                            EnableButtonsOfAccount(account);
                        }
                        else
                        {
                            DisableButtonsOfAccount(account);
                        }
                    }
                }
            }
            else
            {
                HandleMaxNumberOfPossibleSchedules();
            }
        }

        private static void HandleMaxNumberOfPossibleSchedules()
        {
            MessageBox.Show("You have reached the maximum amount of supported instances!",
                            " Maximum amount of instances reached!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Logger.LoggingObject.Log(ELogType.Error,
                                     "You have reached the maximum amount of supported instances (100)!");
        }

        private void SetIsNotRunning(Account account)
        {
            LauncherCustomControls[account.Index].LblStatus.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].LblStatus.Text = "Not Running"));
        }

        private void EnableButtonsOfAccount(Account account)
        {
            LauncherCustomControls[account.Index].BtnKill.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].BtnKill.Enabled = true));
            LauncherCustomControls[account.Index].BtnStart.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].BtnStart.Enabled = true));
        }

        private void DisableButtonsOfAccount(Account account)
        {
            LauncherCustomControls[account.Index].BtnKill.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].BtnKill.Enabled = false));
            LauncherCustomControls[account.Index].BtnStart.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].BtnStart.Enabled = false));
        }

        private void StopSessionOfExpiredSchedule(Account account)
        {
            Logger.LoggingObject.Log(ELogType.Info,
                                     "Stopping {0}, bot has been running for {1:0.##} minutes.",
                                     account.LoginName,
                                     (DateTime.Now - account.StartTime).TotalMinutes);
            Logger.LoggingObject.Log(ELogType.Info, "Start time: {0}, End time: {0}.",
                                     account.StartTime.ToShortTimeString(),
                                     DateTime.Now);
            account.SetShouldBeRunning(false);
            LauncherCustomControls[account.Index].BtnKill.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].BtnKill.Enabled = false));
            LauncherCustomControls[account.Index].BtnStart.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].BtnStart.Enabled = false));
        }

        private void SetIsRunning(Account account)
        {
            LauncherCustomControls[account.Index].LblStatus.Invoke(
                (MethodInvoker)
                (() => LauncherCustomControls[account.Index].LblStatus.Text = "Running!"));
        }

        private void DisableSessionDueToScheduleExpiration(Account account)
        {
            Logger.LoggingObject.Log(ELogType.Info,
                                     "Stopping {0}, bot has been running for {1:0.##} minutes.",
                                     account.LoginName,
                                     (account.EndTime - account.StartTime).TotalMinutes);
            Logger.LoggingObject.Log(ELogType.Info, "Start time: {0}, End time: {0}.",
                                     account.StartTime.ToShortTimeString(),
                                     account.EndTime.ToShortTimeString());
            account.SetShouldBeRunning(false);
            LauncherCustomControls[account.Index].BtnKill.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].BtnKill.Enabled = false));
            LauncherCustomControls[account.Index].BtnStart.Invoke(
                (MethodInvoker)
                (() =>
                 LauncherCustomControls[account.Index].BtnStart.Enabled = false));
        }

        private void CreateCustomControlForLauncher(Account account)
        {
            _newSet++;
            var newControl = new LauncherCustomControl(metroTabControl2,
                                                       LauncherCustomControls.Count,
                                                       _totalAccounts, _newSet, CurrentThemeStyle, account);
            newControl.StartClick += NewControlOnStartClick;
            newControl.KillClick += NewControlOnKillClick;
            newControl.ScheduleClick += NewControlOnScheduleClick;
            LauncherCustomControls.Add(newControl);
            _totalAccounts++;
            if (_newSet == 10)
            {
                _newSet = 0;
            }
            metroStyleManager.UpdateOwnerForm();
        }

        private void NewControlOnScheduleClick(object sender, ReloggerEventArgs reloggerEventArgs)
        {
            Logger.LoggingObject.Log(ELogType.Info, "Opening shedule form for {0}.", reloggerEventArgs.Account.LoginName);
            Account wanted = Config.Singleton.AccountSettings.FirstOrDefault(
                a =>
                a.PID == reloggerEventArgs.Account.PID && a.LoginName == reloggerEventArgs.Account.LoginName &&
                a.Password == reloggerEventArgs.Account.Password);
            var schedulerForm = new SchedulerForm(this, wanted, StyleManager);
            schedulerForm.ShowDialog();
        }

        private void NewControlOnStartClick(object sender, ReloggerEventArgs reloggerEventArgs)
        {
            Logger.LoggingObject.Log(ELogType.Info, "Activating scheduler for {0}.", reloggerEventArgs.Account.LoginName);
            Account wanted = Config.Singleton.AccountSettings.FirstOrDefault(
                a => a.LoginName == reloggerEventArgs.Account.LoginName);
            if (wanted != null) wanted.SetShouldBeRunning(true);
        }

        private void NewControlOnKillClick(object sender, ReloggerEventArgs reloggerEventArgs)
        {
            Logger.LoggingObject.Log(ELogType.Info, "Deactivating scheduler for {0}.", reloggerEventArgs.Account.LoginName);
            Account wanted = Config.Singleton.AccountSettings.FirstOrDefault(
                a => a.LoginName == reloggerEventArgs.Account.LoginName);
            if (wanted != null)
            {
                wanted.SetShouldBeRunning(false);
                Config.Singleton.AccountSettings.First(a => a.LoginName == wanted.LoginName)
                      .SetShouldBeRunning(false);
            }
        }


        private void TileChangeThemeClick(object sender, EventArgs e)
        {
            SwapTheme();
        }

        private void TileChangeColorClick(object sender, EventArgs e)
        {
            ChangeFormColor();
        }

        private void ChangeFormColor()
        {
            var current = (int) metroStyleManager.Style;
            current++;
            if (current > 13)
                current = 0;
            if (current == 1)
                current++;
            metroStyleManager.Style = (MetroColorStyle) current;
            Config.Singleton.GeneralSettings.SetStyleSetting(current);
        }

        private void TileStartAllClick(object sender, EventArgs e)
        {
            StartAllSchedules();
        }

        private static void StartAllSchedules()
        {
            foreach (Account account in Config.Singleton.AccountSettings.ToArray())
            {
                if ((account.EndTime - DateTime.Now).TotalMinutes > 0)
                {
                    Logger.LoggingObject.Log(ELogType.Info, "Activating scheduler for {0}.", account.LoginName);
                    account.SetShouldBeRunning(true);
                }
            }
        }

        private void TileStopAllClick(object sender, EventArgs e)
        {
            StopAllSchedules();
        }

        private static void StopAllSchedules()
        {
            foreach (Account instance in Config.Singleton.AccountSettings.ToArray())
            {
                Logger.LoggingObject.Log(ELogType.Info, "Deactivating scheduler for {0}.", instance.LoginName);
                if (instance.Running)
                    instance.SetShouldBeRunning(false);
                Config.Singleton.AccountSettings.First(a => a.LoginName == instance.LoginName)
                      .SetShouldBeRunning(false);
            }
        }

        private void BtnLoginClick(object sender, EventArgs e)
        {
            AddNewAccount();
        }

        private void AddNewAccount()
        {
            var ac = new Account();
            ac.SetLoginName(txtBoxLoginName.Text);
            ac.SetPassword(txtBoxPassword.Text);
            ac.SetNoSound(chkBoxSound.Checked);
            if (!string.IsNullOrEmpty(txtBoxLoginName.Text) && !string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                if (!Config.Singleton.AccountExists(ac))
                {
                    Config.Singleton.AddAccount(ac);
                    AddAccountToLauncher(Config.Singleton.AccountSettings.Last());
                    txtBoxLoginName.Text = "";
                    txtBoxPassword.Text = "";
                    chkBoxSound.Checked = false;
                }
                else
                {
                    Logger.LoggingObject.Log(ELogType.Warning,
                                             "You have already added an account with the same login information.");
                }
            }
            else
            {
                Logger.LoggingObject.Log(ELogType.Warning,
                                         "You have left a necessary field empty. Please try again.");
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            EmptyFields();
        }

        private void EmptyFields()
        {
            txtBoxLoginName.Text = "";
            txtBoxPassword.Text = "";
            chkBoxSound.Checked = false;
        }

        private void BtnEditClick(object sender, EventArgs e)
        {
            EditExistingAccount();
        }

        private void EditExistingAccount()
        {
            if (!string.IsNullOrEmpty(txtBoxLoginName.Text) && !string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                Account ac =
                    Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == txtBoxLoginName.Text);
                if (ac != null)
                {
                    if (Config.Singleton.AccountExists(ac))
                    {
                        ac.SetLoginName(txtBoxLoginName.Text);
                        ac.SetPassword(txtBoxPassword.Text);
                        ac.SetNoSound(chkBoxSound.Checked);
                        Logger.LoggingObject.Log(ELogType.Info,
                                                 "Updated {0} with a new password.", ac.LoginName);
                        EmptyFields();
                    }
                    else
                    {
                        Logger.LoggingObject.Log(ELogType.Warning,
                                                 "You have no existing account details with this information.");
                    }
                }
                else
                {
                    Logger.LoggingObject.Log(ELogType.Warning,
                                             "You have no existing account details with this information.");
                }
            }

            else
            {
                Logger.LoggingObject.Log(ELogType.Warning,
                                         "You have left a necessary field empty. Please try again.");
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            SaveSettingsToFile();
        }

        private static void SaveSettingsToFile()
        {
            try
            {
                using (FileStream file = File.Create("Launcher.bin"))
                {
                    Config.Singleton.GeneralSettings.AllowedIPAddressesAsString.Clear();
                    foreach (IPAddress ip in Config.Singleton.GeneralSettings.AllowedIPAddresses)
                    {
                        Config.Singleton.GeneralSettings.AllowedIPAddressesAsString.Add(ip.ToString());
                    }
                    Serializer.Serialize(file, Config.Singleton);
                }
            }
            catch (ProtoException ex)
            {
                Logger.LoggingObject.Log(ELogType.Critical, "An error has occurred during data encryption!");
                Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                Logger.LoggingObject.Log(ELogType.Critical,
                                         "Old save file has been deleted, must have been a different version or corrupt!");
                try
                {
                    File.Delete("Launcher.bin");
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                }
                catch (IOException ex3)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                }
            }
            catch (UnauthorizedAccessException ex2)
            {
                Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
            }
            catch (IOException ex3)
            {
                Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
            }
        }

        private bool LoadConfig(bool manual)
        {
            if (File.Exists("Launcher.bin"))
            {
                CleanupFirstTab();

                try
                {
                    LoadConfigFromFile();
                }
                catch (ProtoException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, "An error has occurred during data encryption!");
                    Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                    Logger.LoggingObject.Log(ELogType.Critical,
                                             "Old save file has been deleted, must have been a different version or corrupt!");
                    try
                    {
                        File.Delete("Launcher.bin");
                    }
                    catch (UnauthorizedAccessException ex2)
                    {
                        Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                    }
                    catch (IOException ex3)
                    {
                        Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                    }
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                }
                catch (IOException ex3)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                }

                SetValuesAccordingToLoadedSettings();

                HandleFixingOfLists();

                DumpIntegersToLog();
                return true;
            }
            if (manual)
            {
                Logger.LoggingObject.Log(ELogType.Error, "Couldn't find a valid save file. Please create a new save file.");
            }
            return false;
        }

        private void DumpIntegersToLog()
        {
            Logger.LoggingObject.Log(ELogType.Verbose, "Polling Delay: {0}, Launch Delay: {1}, Restart Delay: {2}",
                                     Config.Singleton.GeneralSettings.PollingDelay,
                                     Config.Singleton.GeneralSettings.LaunchDelay,
                                     Config.Singleton.GeneralSettings.RestartDelay*1000);
        }

        private void HandleFixingOfLists()
        {
            for (int i = 0; i < Config.Singleton.AccountSettings.Count; i++)
            {
                Config.Singleton.AccountSettings[i].SetPID(uint.MaxValue);
                Config.Singleton.AccountSettings[i].SetIndex(i);
                AddAccountToLauncher(Config.Singleton.AccountSettings[i]);
            }
            for (int i = 0; i < Config.Singleton.AccountSettings.Count; i++)
            {
                Config.Singleton.AccountSettings[i].SetPID(uint.MaxValue);
                Config.Singleton.AccountSettings[i].SetIndex(i);
            }
            foreach (string ipAsString in Config.Singleton.GeneralSettings.AllowedIPAddressesAsString)
            {
                IPAddress final;
                if (IPAddress.TryParse(ipAsString, out final))
                    Config.Singleton.GeneralSettings.AddIP(final);
            }
        }

        private void SetValuesAccordingToLoadedSettings()
        {
            CurrentThemeStyle = (MetroThemeStyle) Config.Singleton.GeneralSettings.ThemeSetting;
            metroStyleManager.Theme = CurrentThemeStyle;
            metroStyleManager.Style = (MetroColorStyle) Config.Singleton.GeneralSettings.StyleSetting;
            chkBoxMinimize.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
            chkBoxNewIp.Checked = Config.Singleton.GeneralSettings.CheckForIP;
        }

        private static void LoadConfigFromFile()
        {
            using (FileStream file = File.OpenRead("Launcher.bin"))
            {
                Config.Singleton = Serializer.Deserialize<Config>(file);
            }
        }

        private void CleanupFirstTab()
        {
            if (_totalAccounts > 0)
            {
                for (int i = 1; i < metroTabControl2.TabPages.Count; i++)
                {
                    metroTabControl2.TabPages.Remove(metroTabControl2.TabPages[i]);
                    i = i - 1;
                }
                metroTabControl2.TabPages[0].Controls.Clear();
                metroTabControl2.TabPages[0].Controls.Add(new MetroLabel
                    {
                        FontWeight = MetroLabelWeight.Bold,
                        Text = "Login Name",
                        Theme = metroStyleManager.Theme,
                        Style = metroStyleManager.Style,
                        Location = new Point(3, 10),
                    });
                _newSet = 0;
                _totalAccounts = 0;
                LauncherCustomControls.Clear();
            }
        }

        private void BtnLoadClick(object sender, EventArgs e)
        {
            LoadConfig(true);
        }

        private void BtnDeleteLoginClick(object sender, EventArgs e)
        {
            DeleteExistingLogin();
        }

        private void DeleteExistingLogin()
        {
            if (!string.IsNullOrEmpty(txtBoxLoginName.Text))
            {
                Account ac =
                    Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == txtBoxLoginName.Text);
                if (ac != null)
                {
                    if (Config.Singleton.AccountExists(ac))
                    {
                        EmptyFields();
                        Config.Singleton.DeleteAccount(ac);
                        Logger.LoggingObject.Log(ELogType.Info,
                                                 "Deleted login {0}.", ac.LoginName);

                        if (_totalAccounts > 0)
                        {
                            for (int i = 1; i < metroTabControl2.TabPages.Count; i++)
                            {
                                metroTabControl2.TabPages.Remove(metroTabControl2.TabPages[i]);
                                i = i - 1;
                            }
                            metroTabControl2.TabPages[0].Controls.Clear();
                            metroTabControl2.TabPages[0].Controls.Add(new MetroLabel
                                {
                                    FontWeight = MetroLabelWeight.Bold,
                                    Text = "Login Name",
                                    Theme = MetroThemeStyle.Dark,
                                    Style = MetroColorStyle.Blue,
                                    Location = new Point(3, 10),
                                });
                            _newSet = 0;
                            _totalAccounts = 0;
                            LauncherCustomControls.Clear();
                        }

                        for (int i = 0; i < Config.Singleton.AccountSettings.Count; i++)
                        {
                            Config.Singleton.AccountSettings[i].SetPID(uint.MaxValue);
                            Config.Singleton.AccountSettings[i].SetIndex(i);
                            AddAccountToLauncher(Config.Singleton.AccountSettings[i]);
                        }
                        for (int i = 0; i < Config.Singleton.AccountSettings.Count; i++)
                        {
                            Config.Singleton.AccountSettings[i].SetPID(uint.MaxValue);
                            Config.Singleton.AccountSettings[i].SetIndex(i);
                            Account account = Config.Singleton.AccountSettings[i];
                            Logger.LoggingObject.Log(ELogType.Debug, "Added new scheduler object.");
                            Logger.LoggingObject.Log(ELogType.Debug,
                                                     "[Start: {0} -- {1}, End: {2} -- {3}, Duration in minutes: {4}].",
                                                     account.StartTime.ToShortDateString(),
                                                     account.StartTime.ToShortTimeString(),
                                                     account.EndTime.ToShortDateString(),
                                                     account.EndTime.ToShortTimeString(),
                                                     (account.EndTime - account.StartTime).TotalMinutes);
                        }
                    }
                    else
                    {
                        Logger.LoggingObject.Log(ELogType.Warning,
                                                 "You have no existing account details with this information.");
                    }
                }
                else
                {
                    Logger.LoggingObject.Log(ELogType.Warning,
                                             "You have no existing account details with this information.");
                }
            }
            else
            {
                Logger.LoggingObject.Log(ELogType.Warning,
                                         "You have left a necessary field empty. Please try again.");
            }
        }

        private void BtnSetPathClick(object sender, EventArgs e)
        {
            SetGW2Path(Config.Singleton.GeneralSettings.GW2Path);
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
            string result = currentValue == 0 ? @"3000" : currentValue.ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 3000 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult = InputBox.ShowInputBox("Polling Delay",
                                                     "Please enter the desired polling delay (!minimum: 3000, in milliseconds!).",
                                                     ref result);
                done = true;
            }

            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.SetPollingDelay(final);
        }

        private void SetRestartDelay(bool mustBeEntered = true, int currentValue = 0)
        {
            int final;
            string result = currentValue == 0 ? @"300000" : (1000*currentValue).ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 0 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult = InputBox.ShowInputBox("Restart Delay",
                                                     "Please enter the desired restart delay (to avoid max key limits) (!in milliseconds!).",
                                                     ref result);
                done = true;
            }
            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.SetRestartDelay(final/1000);
        }

        private void SetLaunchDelay(bool mustBeEntered = true, int currentValue = 0)
        {
            int final;
            string result = currentValue == 0 ? @"20000" : currentValue.ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 20000 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult = InputBox.ShowInputBox("Launch Delay",
                                                     "Please enter the desired delay between GW2 launches (!minimum: 20000, in milliseconds!).",
                                                     ref result);
                done = true;
            }
            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.SetLaunchDelay(final);
        }

        private string SetBotPath(Account scheduler)
        {
            var openFolderDialog = new FolderBrowserDialog();

            MessageBox.Show("Please locate your desired GW2Minion folder.", "Locate GW2Minion folder");
            while (
                openFolderDialog.ShowDialog() !=
                DialogResult.OK || !Directory.Exists(openFolderDialog.SelectedPath)) ;
            scheduler.SetBotPath(openFolderDialog.SelectedPath);
            return openFolderDialog.SelectedPath;
        }

        private void BtnSetDelayClick(object sender, EventArgs e)
        {
            SetPollingDelay(false, Config.Singleton.GeneralSettings.PollingDelay);
        }

        private void BtnSetBotPathClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxLoginName.Text))
            {
                Account account =
                    Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == txtBoxLoginName.Text);
                if (account != null)
                {
                    //if (Config.Singleton.AccountExists(account))
                    {
                        string result = SetBotPath(account);
                        Logger.LoggingObject.Log(ELogType.Info,
                                                 "Updated {0} with a new path [{1}].",  account.LoginName,
                                                 result);
                        txtBoxLoginName.Text = "";
                        txtBoxPassword.Text = "";
                        chkBoxSound.Checked = false;
                    }
                    //else
                    //{
                    //    Logger.LoggingObject.Log(ELogType.Warning,
                    //                             "You have no existing account details with this information.");
                    //}
                }
                else
                {
                    Logger.LoggingObject.Log(ELogType.Warning,
                                             "You have no existing account details with this information.");
                }
            }

            else
            {
                Logger.LoggingObject.Log(ELogType.Warning,
                                         "You have left a necessary field empty. Please try again.");
            }
        }

        private void ChkBoxMinimizeCheckedChanged(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetMinimizeWindows(chkBoxMinimize.Checked);
        }

        private void BtnSetLaunchDelayClick(object sender, EventArgs e)
        {
            SetLaunchDelay(false, Config.Singleton.GeneralSettings.LaunchDelay);
        }

        private void BtnAddIPClick(object sender, EventArgs e)
        {
            IPAddress final;
            string result = "";
            var dialogResult = DialogResult.OK;
            while (!IPAddress.TryParse(result, out final) && (dialogResult == DialogResult.OK))
                dialogResult = InputBox.ShowInputBox("IP To Add", "Please enter the desired IP to add.", ref result);
            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.AddIP(final);
        }

        private void BtnDeleteIpClick(object sender, EventArgs e)
        {
            IPAddress final;
            string result = "";
            var dialogResult = DialogResult.OK;
            while (!IPAddress.TryParse(result, out final) && (dialogResult == DialogResult.OK))
                dialogResult = InputBox.ShowInputBox("IP To Delete", "Please enter the desired IP to delete.",
                                                     ref result);
            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.DeleteIP(final);
        }

        private void ChkBoxNewIpCheckedChanged(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetCheckForIP(chkBoxNewIp.Checked);
        }

        private void BtnSetRestartDelayClick(object sender, EventArgs e)
        {
            SetRestartDelay(false, Config.Singleton.GeneralSettings.RestartDelay);
        }
    }
}