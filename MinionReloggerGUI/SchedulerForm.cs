using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using MinionReloggerGUI;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionLauncher.Forms
{
    internal partial class SchedulerForm : MetroForm
    {
        private readonly Account _account;
        private readonly MainForm _form;

        internal SchedulerForm(MainForm mainForm, Account account, MetroStyleManager styleManager)
        {
            InitializeComponent(styleManager.Theme, styleManager.Style);
            _account = account;
            _form = mainForm;
            StyleManager = styleManager;
            SetControlText(account);
            SetTimeFields();
            numericUpDown1.Value = 0;
            BindEvents();
            numericUpDown1.ReadOnly = true;
            SetTotalValue();
            UpdateFormAppearance(styleManager);
        }

        private void UpdateFormAppearance(MetroStyleManager styleManager)
        {
            metroStyleManager.Style = styleManager.Style;
            metroStyleManager.Theme = styleManager.Theme;
            metroStyleManager.UpdateOwnerForm();
        }

        private void BindEvents()
        {
            dateTimePicker2.ValueChanged += OnValueChanged;
            dateTimePicker3.ValueChanged += OnValueChanged;
            numericUpDown1.ValueChanged += OnValueChanged;
            btnCancel.Click += BtnCancelOnClick;
            btnOK.Click += BtnOkOnClick;
            btnManageBreaks.Click += BtnManageBreaksOnClick;
        }

        private void BtnManageBreaksOnClick(object sender, EventArgs eventArgs)
        {
            new ManageBreaks(_account, metroStyleManager).ShowDialog();
        }

        private void SetTimeFields()
        {
            Account s =
                Config.Singleton.AccountSettings.First(a => a.LoginName == _account.LoginName);
            if (s.ManuallyScheduled)
            {
                dateTimePicker2.Text = (s.StartTime - DateTime.Now).TotalSeconds > 0
                                           ? s.StartTime.ToShortTimeString()
                                           : DateTime.Now.ToShortTimeString();
                dateTimePicker3.Text = (s.EndTime - DateTime.Now).TotalSeconds > 0
                                           ? s.EndTime.ToShortTimeString()
                                           : (DateTime.Now + new TimeSpan(23, 57, 59)).ToShortTimeString();
            }
            else
            {
                dateTimePicker2.Text = DateTime.Now.ToShortTimeString();
                dateTimePicker3.Text = (DateTime.Now + new TimeSpan(23, 57, 59)).ToShortTimeString();
            }
        }

        private void SetControlText(Account account)
        {
            lblLogin.Text = account.LoginName;
            lblPassword.Text = account.Password;
        }

        private void BtnOkOnClick(object sender, EventArgs eventArgs)
        {
            SaveScheduleSettings();
            Close();
        }

        private void SaveScheduleSettings()
        {
            Logger.LoggingObject.Log(ELogType.Info, "Saving schedule settings for {0} (minutes: {1}).", _account.LoginName,
                                     lblTimeInMinutes.Text);
            Account s =
                Config.Singleton.AccountSettings.First(a => a.LoginName == _account.LoginName);
            DateTime currentTime = DateTime.Now;
            var startingTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day,
                                            dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute,
                                            dateTimePicker2.Value.Second);
            var endingTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day,
                                          dateTimePicker3.Value.Hour, dateTimePicker3.Value.Minute,
                                          dateTimePicker3.Value.Second);
            endingTime = endingTime.AddDays(1);
            s.SetStartTime(DateTime.Now);
            TimeSpan t = endingTime - startingTime;
            if (t.Days > 0)
                t = new TimeSpan(0, t.Hours, t.Minutes, t.Seconds);
            var t2 = new TimeSpan((int) numericUpDown1.Value, 0, 0, 0);
            TimeSpan final = t + t2;
            s.SetStartTime(startingTime);
            s.SetEndTime(startingTime.Add(final));
            s.SetShouldBeRunning(false);
            s.SetManuallyScheduled(true);
            if (final.TotalMilliseconds >= 0)
            {
                _form.LauncherCustomControls[s.Index].BtnKill.Invoke(
                    (MethodInvoker)
                    (() =>
                     _form.LauncherCustomControls[s.Index].BtnKill.Enabled = true));
                _form.LauncherCustomControls[s.Index].BtnStart.Invoke(
                    (MethodInvoker)
                    (() =>
                     _form.LauncherCustomControls[s.Index].BtnStart.Enabled = true));
            }
            else
            {
                _form.LauncherCustomControls[s.Index].BtnKill.Invoke(
                    (MethodInvoker)
                    (() =>
                     _form.LauncherCustomControls[s.Index].BtnKill.Enabled = false));
                _form.LauncherCustomControls[s.Index].BtnStart.Invoke(
                    (MethodInvoker)
                    (() =>
                     _form.LauncherCustomControls[s.Index].BtnStart.Enabled = false));
            }
        }

        private void BtnCancelOnClick(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private TimeSpan GetDuration()
        {
            TimeSpan t = new DateTime(1990, 1, 2, dateTimePicker3.Value.Hour, dateTimePicker3.Value.Minute,
                                      dateTimePicker3.Value.Second) -
                         new DateTime(1990, 1, 1, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute,
                                      dateTimePicker2.Value.Second);
            if (t.Days > 0)
                t = new TimeSpan(0, t.Hours, t.Minutes, t.Seconds);
            var t2 = new TimeSpan((int) numericUpDown1.Value, 0, 0, 0);
            TimeSpan final = t + t2;
            return final;
        }

        private void SetTotalValue()
        {
            lblTimeInMinutes.Text = GetDuration().TotalMinutes.ToString(CultureInfo.InvariantCulture);
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            SetTotalValue();
        }
    }
}