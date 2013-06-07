using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MinionLauncher.Forms;
using MinionReloggerLib.CustomEventArgs;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerGUI.CustomControls
{
    internal class LauncherCustomControl
    {
        private readonly Account _account;
        internal MetroButton BtnKill = new MetroButton();
        internal MetroButton BtnSchedule = new MetroButton();
        internal MetroButton BtnSetDirectory = new MetroButton();
        internal MetroButton BtnStart = new MetroButton();
        internal MetroLabel LblAccountName = new MetroLabel();
        internal MetroLabel LblStatus = new MetroLabel();

        internal LauncherCustomControl(MetroTabControl tabControl, int totalCount, int activeCount, int newSet,
                                       MetroThemeStyle theme, Account account)
        {
            _account = account;
            FixControls(newSet, theme, account);
            AddControlsToForm(tabControl, activeCount, newSet);
            ID = totalCount;
            BindEvents();
        }

        internal int ID { get; set; }


        internal string LoginName
        {
            get { return LblAccountName.Text; }
            set { LblAccountName.Text = value; }
        }

        internal string Status
        {
            get { return LblStatus.Text; }
            set { LblStatus.Text = value; }
        }

        internal MetroButton StartButton
        {
            get { return BtnStart; }
        }

        internal MetroButton KillButton
        {
            get { return BtnKill; }
        }

        private void BindEvents()
        {
            BtnStart.Click += OnStartClick;
            BtnKill.Click += OnKillClick;
            BtnSchedule.Click += OnScheduleClick;
        }

        private void AddControlsToForm(MetroTabControl tabControl, int activeCount, int newSet)
        {
            TabPage page = tabControl.TabPages[tabControl.TabPages.Count - 1];
            var newPage = new MetroTabPage
            {
                BackColor = Color.Transparent,
                Text = string.Format("{0}-{1}", activeCount + 2, activeCount + 11),
            };
            if (newSet == 10 && tabControl.TabPages.Count < 10)
                tabControl.TabPages.Add(newPage);
            newPage.Controls.Add(new MetroLabel
            {
                FontWeight = MetroLabelWeight.Bold,
                Text = "Login Name",
                Theme = MetroThemeStyle.Dark,
                Style = MetroColorStyle.Blue,
                Location = new Point(3, 10),
            });
            BtnStart.Enabled = false;
            BtnKill.Enabled = false;
            page.Controls.Add(LblAccountName);
            page.Controls.Add(BtnStart);
            page.Controls.Add(BtnKill);
            page.Controls.Add(BtnSchedule);
            page.Controls.Add(LblStatus);
        }

        private void FixControls(int newSet, MetroThemeStyle theme, Account account)
        {
            LblAccountName.Theme = theme;
            LblAccountName.Style = MetroColorStyle.Blue;
            LblAccountName.Text = account.LoginName;
            LblAccountName.Width = 280;
            BtnStart.Theme = theme;
            BtnStart.Style = MetroColorStyle.Blue;
            BtnStart.Text = "Start";
            BtnKill.Theme = theme;
            BtnKill.Style = MetroColorStyle.Blue;
            BtnKill.Text = "Stop";
            BtnSchedule.Theme = theme;
            BtnSchedule.Style = MetroColorStyle.Blue;
            BtnSchedule.Text = "Schedule";
            LblStatus.Theme = theme;
            LblStatus.Style = MetroColorStyle.Blue;
            LblStatus.Text = "Not Running";
            LblStatus.UseStyleColors = true;
            int heightPosition = (newSet) * 30;
            LblAccountName.Location = new Point(3, heightPosition + 3);
            BtnStart.Width = 53;
            BtnStart.Height = 23;
            BtnKill.Width = 46;
            BtnKill.Height = 23;
            BtnSchedule.Width = 75;
            BtnSchedule.Height = 23;
            BtnStart.Location = new Point(290, heightPosition);
            BtnKill.Location = new Point(349, heightPosition);
            BtnSchedule.Location = new Point(402, heightPosition);
            LblStatus.Location = new Point(484, heightPosition);
        }

        internal event ReloggerHandler StartClick;
        internal event ReloggerHandler KillClick;
        internal event ReloggerHandler ScheduleClick;

        private void OnScheduleClick(object sender, EventArgs eventArgs)
        {
            if (ScheduleClick != null)
                ScheduleClick(this, new ReloggerEventArgs(_account, ERelogEventArgsType.OnSchedule));
        }

        private void OnKillClick(object sender, EventArgs eventArgs)
        {
            if (KillClick != null)
                KillClick(this, new ReloggerEventArgs(_account, ERelogEventArgsType.OnKill));
        }

        private void OnStartClick(object sender, EventArgs eventArgs)
        {
            if (StartClick != null)
                StartClick(this, new ReloggerEventArgs(_account, ERelogEventArgsType.OnStart));
        }
    }
}