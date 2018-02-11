# Outlook Folder Notifier

Shows notifications for some of the sub-folders in Outlook.

[Download Releases](https://github.com/CXuesong/OutlookFolderNotifier/releases) | [Issues](https://github.com/CXuesong/OutlookFolderNotifier/issues) | [Chat on Gitter](https://gitter.im/CXuesong/OutlookFolderNotifier)

## Motivation

As it is commonly observed till Office 2016, though Outlook provides notification for new e-mails recieved in the "inbox" folder, it won't show such notifications for the received e-mails in any other folders (e.g. IMAP folders). Though there are already some tips on the internet to enable notifications for all incoming e-mails, sometimes we just want those which come into spam folder come silently. Thus I decided to spend a day writing this rudimentary Outlook add-in to solve the problem.

## Prerequisite

*   Microsoft Office Outlook 2013/2016 running on Windows
*   .NET Framework 4.6.1
*   VSTO 2010

## Usage

*   [Download](https://github.com/CXuesong/OutlookFolderNotifier/releases) & Install the plugin, the installer should automatically download and install the requirements if missing
*   Open Outlook
*   Open "Folder" ribbon tab, you may see "Folder Notifier" ribbon group to the right side
*   Click "Monitored Folders"
*   Check the folders that you want to receive notifications about, and click "OK"
*   Voila. You can get yourself a new mail to test it out now.

## Troubleshooting

If you bump into similar error as follows when installing

```
The value of the property 'type' cannot be parsed. The error is: Could not load file or assembly 'Microsoft.Office.Business.Applications.Fba, Version = 14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c' or one of its dependencies. The system cannot find the file specified. (C:\Program Files (x86)\Common Files\Microsoft\Share\VSTO\10.0\VSTOInstaller.exe.Config line10)
```

You may consider comment out (suggested) or remove the content between `<webRequestModules>` in `VSTOInstaller.exe.Config` located in the path as mentioned above.