using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using OutlookFolderNotifier.Properties;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace OutlookFolderNotifier
{
    public partial class PrimaryRibbon
    {
        private void PrimaryRibbonTab_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void MonitoredFoldersButton_Click(object sender, RibbonControlEventArgs e)
        {
            using (var dialog = new MonitoredFoldersDialog())
            {
                var result = dialog.ShowDialog(Settings.Default.MonitoredFolders ?? new string[] { },
                    Globals.ThisAddIn.Application.Session.Folders.OfType<Outlook.Folder>());
                if (result != null)
                {
                    Settings.Default.MonitoredFolders = result.ToArray();
                    Settings.Default.Save();
                    Globals.ThisAddIn.RefreshFolderMonitors();
                }
            }
        }

        private void TestNotificationButton_Click(object sender, RibbonControlEventArgs e)
        {
            FolderMonitor.ShowNewMailNotification("FolderName", "Sender <sender@company.org>", "Mail Subject", "Mail body.");
        }

        private void ShowAboutButton_Click(object sender, RibbonControlEventArgs e)
        {
            using (var dialog = new AboutAddInDialog())
                dialog.ShowDialog();
        }
    }
}
