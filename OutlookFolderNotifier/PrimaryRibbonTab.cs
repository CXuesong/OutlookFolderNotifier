using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using OutlookFolderNotifier.Properties;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace OutlookFolderNotifier
{
    public partial class PrimaryRibbonTab
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
                if (result != null) Settings.Default.MonitoredFolders = result.ToArray();
            }
        }
    }
}
