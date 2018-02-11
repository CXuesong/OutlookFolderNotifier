using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace OutlookFolderNotifier
{
    public class FolderMonitor : IDisposable
    {
        private readonly string folderName;
        private Outlook.Items items;

        public FolderMonitor(string folderName, Outlook.Items items)
        {
            this.folderName = folderName;
            this.items = items;
            items.ItemAdd += Items_ItemAdd;
        }

        private void Items_ItemAdd(object item)
        {
            if (item is Outlook.MailItem mail)
            {
                if (!mail.UnRead) return;
                ShowNewMailNotification(folderName, string.Format("{0} <{1}>", mail.SenderName, mail.SenderEmailAddress),
                    mail.Subject, mail.Body);
            }
        }

        public static void ShowNewMailNotification(string folderName, string sender, string subject, string bodyPreview)
        {
            //var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            //var toastTextElements = toastXml.GetElementsByTagName("text");
            //toastTextElements[0].AppendChild(toastXml.CreateTextNode(subject));
            //toastTextElements[1].AppendChild(toastXml.CreateTextNode(bodyPreview));
            //var notification = new ToastNotification(toastXml);
            //ToastNotificationManager.CreateToastNotifier().Show(notification);
            const int bodyPreviewLength = 300;
            if (bodyPreview.Length < bodyPreviewLength)
                bodyPreview += "<END>";
            else
                bodyPreview = bodyPreview.Substring(0, bodyPreviewLength);
            var popup = new NewMailPopupWindow
            {
                FolderLabel = {Text = "In " + folderName},
                SenderLabel = {Text = sender},
                SubjectLabel = {Text = subject},
                BodyPreviewLabel = {Text = bodyPreview}
            };

            void ApplyClickHandler(Control ctrl)
            {
                ctrl.Click += (_, e) =>
                {
                    Globals.ThisAddIn.Application.ActiveExplorer().Activate();
                    popup.Close();
                };
                foreach (Control c in ctrl.Controls)
                {
                    ApplyClickHandler(c);
                }
            }

            ApplyClickHandler(popup);
            SystemSounds.Question.Play();
            popup.ShowPopup();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            items.ItemAdd -= Items_ItemAdd;
        }
    }
}
