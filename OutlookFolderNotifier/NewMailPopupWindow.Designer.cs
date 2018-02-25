namespace OutlookFolderNotifier
{
    partial class NewMailPopupWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SenderLabel = new System.Windows.Forms.Label();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.BodyPreviewLabel = new System.Windows.Forms.Label();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.TimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SenderLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FolderLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BodyPreviewLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SubjectLabel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.MouseEnter += new System.EventHandler(this.NewMailPopupWindow_MouseEnter);
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.NewMailPopupWindow_MouseLeave);
            // 
            // SenderLabel
            // 
            this.SenderLabel.AutoSize = true;
            this.SenderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SenderLabel.Location = new System.Drawing.Point(3, 12);
            this.SenderLabel.Name = "SenderLabel";
            this.SenderLabel.Size = new System.Drawing.Size(41, 12);
            this.SenderLabel.TabIndex = 6;
            this.SenderLabel.Text = "label2";
            this.SenderLabel.MouseEnter += new System.EventHandler(this.NewMailPopupWindow_MouseEnter);
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FolderLabel.Location = new System.Drawing.Point(3, 0);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(41, 12);
            this.FolderLabel.TabIndex = 5;
            this.FolderLabel.Text = "label4";
            this.FolderLabel.MouseEnter += new System.EventHandler(this.NewMailPopupWindow_MouseEnter);
            // 
            // BodyPreviewLabel
            // 
            this.BodyPreviewLabel.AutoEllipsis = true;
            this.BodyPreviewLabel.AutoSize = true;
            this.BodyPreviewLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.BodyPreviewLabel.Location = new System.Drawing.Point(3, 53);
            this.BodyPreviewLabel.Name = "BodyPreviewLabel";
            this.BodyPreviewLabel.Size = new System.Drawing.Size(56, 16);
            this.BodyPreviewLabel.TabIndex = 3;
            this.BodyPreviewLabel.Text = "label3";
            this.BodyPreviewLabel.MouseEnter += new System.EventHandler(this.NewMailPopupWindow_MouseEnter);
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Font = new System.Drawing.Font("宋体", 14F);
            this.SubjectLabel.Location = new System.Drawing.Point(5, 29);
            this.SubjectLabel.Margin = new System.Windows.Forms.Padding(5);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(69, 19);
            this.SubjectLabel.TabIndex = 1;
            this.SubjectLabel.Text = "label1";
            this.SubjectLabel.MouseEnter += new System.EventHandler(this.NewMailPopupWindow_MouseEnter);
            // 
            // TimeoutTimer
            // 
            this.TimeoutTimer.Interval = 5000;
            this.TimeoutTimer.Tick += new System.EventHandler(this.TimeoutTimer_Tick);
            // 
            // NewMailPopupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(350, 150);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewMailPopupWindow";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewMailPopupWindow_FormClosed);
            this.MouseEnter += new System.EventHandler(this.NewMailPopupWindow_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.NewMailPopupWindow_MouseLeave);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Label SubjectLabel;
        internal System.Windows.Forms.Label BodyPreviewLabel;
        internal System.Windows.Forms.Label SenderLabel;
        internal System.Windows.Forms.Label FolderLabel;
        private System.Windows.Forms.Timer TimeoutTimer;
    }
}