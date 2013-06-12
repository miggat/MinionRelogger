using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Helpers.Input;

namespace RestartDelayComponent
{
    public partial class SettingsForm : MetroForm
    {
        private int _currentValue;

        public SettingsForm()
        {
            InitializeComponent();
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            _currentValue = Config.Singleton.GeneralSettings.RestartDelay;
            UpdateLabelText();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetRestartDelay(_currentValue);
            Close();
        }

        private void BtnNewValueClick(object sender, EventArgs e)
        {
            SetRestartDelay(false, Config.Singleton.GeneralSettings.RestartDelay);
        }

        private void UpdateLabelText()
        {
            metroLabel2.Text = _currentValue + " seconds";
        }

        private void SetRestartDelay(bool mustBeEntered = true, int currentValue = 0)
        {
            int final;
            string result = currentValue == 0 ? @"0" : currentValue.ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 0 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult = InputBox.ShowInputBox("Restart Delay",
                                                     "Please enter the desired restart delay (to avoid max key limits) (!in seconds!).",
                                                     ref result);
                done = true;
            }
            if (dialogResult == DialogResult.OK)
                _currentValue = final;
            UpdateLabelText();
        }
    }
}