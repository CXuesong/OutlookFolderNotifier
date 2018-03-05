using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace OutlookFolderNotifier
{
    public partial class MonitoredFoldersDialog : Form
    {
        public MonitoredFoldersDialog()
        {
            InitializeComponent();
        }

        public ICollection<string> ShowDialog(IEnumerable<string> monitoredPaths, IEnumerable<Folder> folders)
        {
            var paths = new HashSet<string>(monitoredPaths);
            void PopulateFolders(IEnumerable<Folder> fds, TreeNodeCollection parentCollection)
            {
                try
                {
                    foreach (var f in fds)
                    {
                        var node = new TreeNode(f.Name)
                        {
                            Checked = paths.Contains(f.FolderPath),
                            Tag = f.FolderPath,
                        };
                        parentCollection.Add(node);
                        if (f.Folders.Count > 0) PopulateFolders(f.Folders.OfType<Folder>(), node.Nodes);
                    }
                }
                catch (COMException ex) when (ex.HResult == unchecked((int)0xA304010F))
                {
                    // This situation can happen if you have SharePoint accounts
                    // AND currently there is no network available.
                }
            }

            FoldersTreeView.BeginUpdate();
            PopulateFolders(folders, FoldersTreeView.Nodes);
            FoldersTreeView.ExpandAll();
            FoldersTreeView.EndUpdate();

            if (base.ShowDialog() == DialogResult.OK)
            {
                var newPaths = new List<string>();

                void PopulatePaths(IEnumerable<TreeNode> treeNodes)
                {
                    foreach (var n in treeNodes)
                    {
                        if (n.Checked) newPaths.Add((string)n.Tag);
                        if (n.Nodes.Count > 0) PopulatePaths(n.Nodes.Cast<TreeNode>());
                    }
                }

                PopulatePaths(FoldersTreeView.Nodes.Cast<TreeNode>());
                return newPaths;
            }

            return null;

        }

    }
}
