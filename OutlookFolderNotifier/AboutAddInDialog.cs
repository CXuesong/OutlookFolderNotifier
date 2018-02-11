using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookFolderNotifier
{
    public partial class AboutAddInDialog : Form
    {
        public AboutAddInDialog()
        {
            InitializeComponent();
        }

        private void DonateButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: Open donation link here (or maybe not).");
        }

        private void AboutAddInDialog_Load(object sender, EventArgs e)
        {
            VersionLabel.Text = string.Format("Assembly version: {0}", typeof(AboutAddInDialog).Assembly.GetName().Version);
        }

        private void GoToSourceCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var proc = Process.Start("https://github.com/cxuesong/OutlookFolderNotifier"))
            { }
        }

        private void GoToIssuesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var proc = Process.Start("https://github.com/cxuesong/OutlookFolderNotifier/issues"))
            { }
        }
    }
}
