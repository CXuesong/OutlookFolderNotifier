namespace OutlookFolderNotifier
{
    partial class PrimaryRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PrimaryRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.MonitoredFoldersButton = this.Factory.CreateRibbonButton();
            this.TestNotificationButton = this.Factory.CreateRibbonButton();
            this.ShowAboutButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabFolder";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabFolder";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.MonitoredFoldersButton);
            this.group1.Items.Add(this.TestNotificationButton);
            this.group1.Items.Add(this.ShowAboutButton);
            this.group1.Label = "Folder Notifier";
            this.group1.Name = "group1";
            // 
            // MonitoredFoldersButton
            // 
            this.MonitoredFoldersButton.Label = "Monitored Folders";
            this.MonitoredFoldersButton.Name = "MonitoredFoldersButton";
            this.MonitoredFoldersButton.SuperTip = "Configure the monitored folders for which a popup message will be shown when the " +
    "new mail has been added.";
            this.MonitoredFoldersButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.MonitoredFoldersButton_Click);
            // 
            // TestNotificationButton
            // 
            this.TestNotificationButton.Label = "Test Notification";
            this.TestNotificationButton.Name = "TestNotificationButton";
            this.TestNotificationButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TestNotificationButton_Click);
            // 
            // ShowAboutButton
            // 
            this.ShowAboutButton.Label = "About This Add-in";
            this.ShowAboutButton.Name = "ShowAboutButton";
            this.ShowAboutButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShowAboutButton_Click);
            // 
            // PrimaryRibbon
            // 
            this.Name = "PrimaryRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.PrimaryRibbonTab_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton MonitoredFoldersButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TestNotificationButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShowAboutButton;
    }

    partial class ThisRibbonCollection
    {
        internal PrimaryRibbon PrimaryRibbonTab
        {
            get { return this.GetRibbon<PrimaryRibbon>(); }
        }
    }
}
