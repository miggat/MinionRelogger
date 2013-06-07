using System;
using System.Linq;
using MetroFramework.Components;
using MetroFramework.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerGUI
{
    internal partial class ManageBreaks : MetroForm
    {
        private readonly Account _account;

        internal ManageBreaks(Account account, MetroStyleManager styleManager)
        {
            InitializeComponent();
            _account = account;
            StyleManager = styleManager;
            UpdateFormAppearance(styleManager);
            Account wanted =
                Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == _account.LoginName);
            if (wanted != null)
            {
                numericUpDown1.Value = (decimal) wanted.BreakObject.TimeSpanInterval.TotalMinutes;
                numericUpDown2.Value = (decimal) wanted.BreakObject.TimeSpanToAddToLastBreak.TotalMinutes;
                numericUpDown3.Value = (decimal) wanted.BreakObject.TimeSpanToPause.TotalMinutes;
                numericUpDown4.Value = (decimal) wanted.BreakObject.TimeSpanToWaitLonger.TotalMinutes;
                chkBoxEnableBreak.Checked = wanted.BreakObject.BreakEnabled;
            }
        }

        private void UpdateFormAppearance(MetroStyleManager styleManager)
        {
            metroStyleManager.Style = styleManager.Style;
            metroStyleManager.Theme = styleManager.Theme;
            metroStyleManager.UpdateOwnerForm();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            MakeBreak();
            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void MakeBreak()
        {
            var r = new Random();

            var breakObject = new BreakObject
                {
                    TimeSinceLastBreak = DateTime.Now,
                    TimeSpanInterval = new TimeSpan(0, (int) numericUpDown1.Value, 0),
                    TimeSpanToAddToLastBreak = new TimeSpan(0, r.Next(0, (int) numericUpDown2.Value), 0),
                    TimeSpanToPause = new TimeSpan(0, (int) numericUpDown3.Value, 0),
                    TimeSpanToWaitLonger = new TimeSpan(0, r.Next(0, (int) numericUpDown4.Value), 0),
                    BreakEnabled = chkBoxEnableBreak.Checked,
                };
            breakObject.TimeActualStartBreak = breakObject.TimeSinceLastBreak + breakObject.TimeSpanInterval +
                                               breakObject.TimeSpanToAddToLastBreak;
            breakObject.TimeActualStopBreak = breakObject.TimeActualStartBreak + breakObject.TimeSpanToPause +
                                              breakObject.TimeSpanToWaitLonger;
            Account wanted =
                Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == _account.LoginName);
            if (wanted != null)
            {
                wanted.SetBreak(breakObject);
            }
        }
    }
}