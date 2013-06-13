/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Alpha -- https://github.com/Vipeax/MinionRelogger   *
*  Copyright (C) 2013, Robert van den Boorn                                  *
*                                                                            *
*  This program is free software: you can redistribute it and/or modify      *
*   it under the terms of the GNU General Public License as published by     *
*   the Free Software Foundation, either version 3 of the License, or        *
*   (at your option) any later version.                                      *
*                                                                            *
*   This program is distributed in the hope that it will be useful,          *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*                                                                            *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Helpers.Input;

namespace LaunchDelayComponent
{
    public partial class SettingsForm : MetroForm
    {
        private int _currentValue;

        public SettingsForm()
        {
            InitializeComponent();
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            _currentValue = Config.Singleton.GeneralSettings.LaunchDelay;
            UpdateLabelText();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetLaunchDelay(_currentValue);
            Close();
        }

        private void BtnNewValueClick(object sender, EventArgs e)
        {
            SetLaunchDelay(false, Config.Singleton.GeneralSettings.LaunchDelay);
        }

        private void UpdateLabelText()
        {
            metroLabel2.Text = _currentValue + " seconds";
        }

        private void SetLaunchDelay(bool mustBeEntered = true, int currentValue = 0)
        {
            int final;
            string result = currentValue == 0 ? @"20" : currentValue.ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 20 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult = InputBox.ShowInputBox("Launch Delay",
                                                     "Please enter the desired delay between GW2 launches (!minimum: 20, in seconds!).",
                                                     ref result);
                done = true;
            }
            if (dialogResult == DialogResult.OK)
                _currentValue = final;
            UpdateLabelText();
        }
    }
}