using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using MetroFramework.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Helpers.Input;

namespace IPCheckComponent
{
    public partial class SettingsForm : MetroForm
    {
        private readonly List<string> _currentIPList;

        public SettingsForm()
        {
            InitializeComponent();
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            _currentIPList = Config.Singleton.GeneralSettings.AllowedIPAddressesAsString;
            PopulateIPList();
            metroToggle1.Checked = Config.Singleton.GeneralSettings.CheckForIP;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetCheckForIP(metroToggle1.Checked);
            Config.Singleton.GeneralSettings.EmptyIPList();
            foreach (string ip in _currentIPList)
            {
                IPAddress final;
                if (IPAddress.TryParse(ip, out final) && !Config.Singleton.GeneralSettings.AlreadyContainsIP(final))
                    Config.Singleton.GeneralSettings.AddIP(final);
            }
            Close();
        }

        private void BtnAddIPClick(object sender, EventArgs e)
        {
            IPAddress final;
            string result = "";
            var dialogResult = DialogResult.OK;
            while (!IPAddress.TryParse(result, out final) && (dialogResult == DialogResult.OK))
                dialogResult = InputBox.ShowInputBox("IP To Add",
                                                     "Please enter the desired IP to add (in the format: 127.0.0.1).",
                                                     ref result);
            if (dialogResult == DialogResult.OK)
                _currentIPList.Add(final.ToString());
            PopulateIPList();
        }

        private void BtnAddRangeClick(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Adding new IP range, the last pair of digits will be skipped, 192.168.1.1 becomes 192.168.1.0-255. Enter a valid IP address though!");
            IPAddress final;
            string result = "";
            var dialogResult = DialogResult.OK;
            while (!IPAddress.TryParse(result, out final) && (dialogResult == DialogResult.OK))
                dialogResult = InputBox.ShowInputBox("IP range to Add",
                                                     "Please enter the desired IP range to add (in the format: 192.168.1.0).",
                                                     ref result);
            if (dialogResult == DialogResult.OK)
            {
                var first3 = new[]
                    {final.GetAddressBytes()[0], final.GetAddressBytes()[1], final.GetAddressBytes()[2]};
                for (int i = 0; i < 256; i++)
                {
                    _currentIPList.Add(string.Format("{0}.{1}.{2}.{3}", first3[0], first3[1], first3[2], i));
                }
            }
            PopulateIPList();
        }

        private void BtnDeleteIPClick(object sender, EventArgs e)
        {
            if (cmbBoxIPs.SelectedIndex != -1)
                _currentIPList.RemoveAt(cmbBoxIPs.SelectedIndex);
            PopulateIPList();
        }

        private void PopulateIPList()
        {
            cmbBoxIPs.Items.Clear();
            foreach (string ip in _currentIPList)
            {
                cmbBoxIPs.Items.Add(ip);
            }
        }
    }
}