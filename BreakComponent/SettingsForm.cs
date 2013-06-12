using System;
using MetroFramework.Forms;

namespace BreakComponent
{
    public partial class SettingsForm : MetroForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}