using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace OutlookFolderNotifier
{
    public partial class NewMailPopupWindow : Form
    {

        private bool isClosing;

        public NewMailPopupWindow()
        {
            InitializeComponent();
        }

        public void ShowPopup()
        {
            var workingArea = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(workingArea.Right, workingArea.Bottom - this.Height);
            this.Show();
            var transition = new Transition(new TransitionType_EaseInEaseOut(500));
            transition.add(this, nameof(this.Left), workingArea.Right - this.Width);
            transition.run();
            transition.TransitionCompletedEvent += (_, e) => { TimeoutTimer.Enabled = true; };
        }

        private void ClosePopup()
        {
            var workingArea = Screen.PrimaryScreen.WorkingArea;
            if (isClosing) return;
            isClosing = true;
            var transition = new Transition(new TransitionType_EaseInEaseOut(500));
            transition.add(this, nameof(this.Left), workingArea.Right);
            transition.run();
            transition.TransitionCompletedEvent += (_, e) => { this.Close(); };
        }

        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            TimeoutTimer.Enabled = false;
            ClosePopup();
        }

        private void NewMailPopupWindow_MouseEnter(object sender, EventArgs e)
        {
            TimeoutTimer.Enabled = false;
        }

        private void NewMailPopupWindow_MouseLeave(object sender, EventArgs e)
        {
            if (!isClosing) TimeoutTimer.Enabled = true;
        }
    }
}
