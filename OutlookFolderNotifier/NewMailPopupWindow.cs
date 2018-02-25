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

        private static readonly List<NewMailPopupWindow> visiblePopups = new List<NewMailPopupWindow>();
        private bool isClosing;
        private Rectangle targetRect;

        private const double DeactiveOpacity = 0.9;

        public NewMailPopupWindow()
        {
            InitializeComponent();
        }

        public void ShowPopup()
        {
            const int popupsMargin = 5;
            var workingArea = Screen.PrimaryScreen.WorkingArea;
            var rect = new Rectangle(workingArea.Right - this.Width, workingArea.Bottom - this.Height, this.Width, this.Height);
            // avoid intersections
            lock (visiblePopups)
            {
                foreach (var f in visiblePopups)
                {
                    var frect = f.targetRect;
                    if (rect.IntersectsWith(frect))
                    {
                        // Move upwards.
                        var nextTop = f.Top - rect.Height - popupsMargin;
                        if (nextTop < workingArea.Top)
                        {
                            var nextLeft = frect.Left - rect.Width - popupsMargin;
                            nextTop = workingArea.Bottom - this.Height;
                            if (nextLeft < 0) break;
                            rect.X = nextLeft;
                        }

                        rect.Y = nextTop;
                    }
                }

                targetRect = rect;
                visiblePopups.Add(this);
            }

            this.Location = new Point(workingArea.Right, rect.Top);
            this.Opacity = 0;
            this.Visible = true;
            var transition = new Transition(new TransitionType_EaseInEaseOut(200));
            transition.add(this, nameof(this.Left), rect.Left);
            transition.add(this, nameof(this.Opacity), 1.0);
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
            transition.add(this, nameof(this.Opacity), 0.0);
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
            this.Opacity = 1;
        }

        private void NewMailPopupWindow_MouseLeave(object sender, EventArgs e)
        {
            if (!isClosing)
            {
                TimeoutTimer.Enabled = true;
                this.Opacity = DeactiveOpacity;
            }
        }

        private void NewMailPopupWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            lock (visiblePopups)
                visiblePopups.Remove(this);
        }
    }
}
