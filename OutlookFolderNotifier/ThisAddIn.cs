using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using OutlookFolderNotifier.Properties;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace OutlookFolderNotifier
{
    public partial class ThisAddIn
    {

        private readonly List<FolderMonitor> monitors = new List<FolderMonitor>();

        public void RefreshFolderMonitors()
        {
            foreach (var m in monitors) m.Dispose();
            monitors.Clear();
            if (Settings.Default.MonitoredFolders != null)
            {
                var monitoredFolders = new HashSet<string>(Settings.Default.MonitoredFolders);

                void VisitFolder(IEnumerable<Outlook.Folder> fs)
                {
                    foreach (var f in fs)
                    {
                        if (monitoredFolders.Contains(f.FolderPath))
                        {
                            monitors.Add(new FolderMonitor(f.FolderPath, f.Items));
                        }
                        if (f.Folders.Count > 0) VisitFolder(f.Folders.OfType<Outlook.Folder>());
                    }
                }

                VisitFolder(Application.Session.Folders.OfType<Outlook.Folder>());
            }
        }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.FirstChanceException += (o, e1) =>
            {
                MessageBox.Show(e1.Exception.ToString());
            };
            RefreshFolderMonitors();
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
            // 备注: Outlook不会再触发这个事件。如果具有
            //    在 Outlook 关闭时必须运行，详请参阅 https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO 生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
