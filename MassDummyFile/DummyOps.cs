using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace MassDummyFile
{
    public class DummyOps
    {
        int FilesAltered;
        int elapsedTime;
        DateTime lastReportDateTime;

        public DummyOps()
        {
            elapsedTime = 20;
        }

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e) //tests to see what kind of operation is needed
        {
            FilesAltered = 0;
            if (GlobalVars.restoreBak)
            {
                RestoreBaks(worker, e);
            }
            else if (GlobalVars.makeBak)
            {
                DummyCreation(true, worker, e);
            }
            else
            {
                DummyCreation(false, worker, e);
            }
        }

        private void RestoreBaks(BackgroundWorker worker, DoWorkEventArgs e) //restores backed-up files created by this utility
        {
            lastReportDateTime = DateTime.Now;
            string[] tempString;
            for (int i = 0; i < GlobalVars.fileArray.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                if ((tempString = GlobalVars.fileArray[i].Split(new string[] {".bak"}, 2, StringSplitOptions.None)).Length == 2)
                {
                    if (File.Exists(tempString[0])) //File.Move doesn't work if tempString[0] already exists, so test for this
                    {
                        File.Delete(tempString[0]);
                    }
                    File.Move(GlobalVars.fileArray[i], tempString[0]);
                    GlobalVars.fileArray[i] = tempString[0];
                    FilesAltered++;
                }
                tempString = null;
                int compare = DateTime.Compare(
                        DateTime.Now, lastReportDateTime.AddMilliseconds(elapsedTime));
                if (compare > 0)
                {
                    worker.ReportProgress(FilesAltered / GlobalVars.fileArray.Count, (FilesAltered / GlobalVars.fileArray.Count) * 100);
                }
            }
            worker.ReportProgress(FilesAltered / GlobalVars.fileArray.Count, 1);
        }

        private void DummyCreation(bool BakFirst, BackgroundWorker worker, DoWorkEventArgs e) //overrides pre-existing files with dummy files
        {
            lastReportDateTime = DateTime.Now;
            string[] tempString;
            if (BakFirst)
            {
                int tempCount = GlobalVars.fileArray.Count; //store the pre-dummied fileArray count to prevent overriding .bak files.
                for (int i = 0; i < tempCount; i++)
                {
                    if (GlobalVars.fileArray[i].Split(GlobalVars.fileExt, 2, StringSplitOptions.None).Length == 2)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                        string tempString2 = GlobalVars.fileArray[i];
                        File.Move(GlobalVars.fileArray[i], GlobalVars.fileArray[i] + ".bak");
                        GlobalVars.fileArray[i] = GlobalVars.fileArray[i] + ".bak";
                        File.Create(tempString2).Close();
                        GlobalVars.fileArray.Add(tempString2);
                        FilesAltered++;
                        int compare = DateTime.Compare(
                        DateTime.Now, lastReportDateTime.AddMilliseconds(elapsedTime));
                        if (compare > 0)
                        {
                            worker.ReportProgress(FilesAltered / GlobalVars.fileArray.Count, (FilesAltered / GlobalVars.fileArray.Count) * 100);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < GlobalVars.fileArray.Count; i++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    if ((tempString = GlobalVars.fileArray[i].Split(GlobalVars.fileExt, 2, StringSplitOptions.None)).Length == 2)
                    {
                        File.Create(GlobalVars.fileArray[i]).Close();
                    }
                    tempString = null;
                    int compare = DateTime.Compare(
                        DateTime.Now, lastReportDateTime.AddMilliseconds(elapsedTime));
                    if (compare > 0)
                    {
                        worker.ReportProgress(FilesAltered / GlobalVars.fileArray.Count, (FilesAltered / GlobalVars.fileArray.Count) * 100);
                    }
                }
            }
            worker.ReportProgress(FilesAltered / GlobalVars.fileArray.Count, 1);
        }
    }
}
