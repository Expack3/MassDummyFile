using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MassDummyFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectDirButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                {
                    GlobalVars.directory = folderBrowserDialog1.SelectedPath;
                    GlobalVars.fileArray = Directory.GetFiles(GlobalVars.directory).ToList<string>();
                    DirectorySelection.Visible = true;
                    ExtTextbox.Enabled = true;
                }
                else
                {
                    GlobalVars.directory = null;
                    GlobalVars.fileArray = null;
                    DirectorySelection.Visible = false;
                    ExtTextbox.Enabled = false;
                }
            }
            canDummy();
        }

        private void CreateDummyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (CreateDummyRadio.Checked)
            {
                RestoreRadio.Checked = false;
                CreateBakCheck.Enabled = true;
                ExtTextbox.Enabled = true;
                GlobalVars.restoreBak = false;
                StartThread(1);
            }
        }

        private void RestoreRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (RestoreRadio.Checked)
            {
                CreateDummyRadio.Checked = false;
                CreateBakCheck.Enabled = false;
                ExtTextbox.Enabled = false;
                GlobalVars.restoreBak = true;
                StartThread(3);
            }
        }

        private void ExtTextbox_TextChanged(object sender, EventArgs e)
        {
            if (ExtValidator.validate(ExtTextbox.Text))
            {
                GlobalVars.fileExt[0] = ExtTextbox.Text;
                GlobalVars.extValid = true;
                StartThread(1);
            }
            else
            {
                GlobalVars.fileExt[0] = null;
                GlobalVars.extValid = false;
            }
            canDummy();
        }

        private void canDummy()
        {
            if (CreateDummyRadio.Checked)
            {
                if (GlobalVars.directory != null && GlobalVars.fileArray.Count > 0 && GlobalVars.extValid == true && backgroundWorker2.IsBusy != true && backgroundWorker1.IsBusy != true)
                {
                    StartButton.Enabled = true;
                }
                else
                    StartButton.Enabled = false;
            }
            else if (GlobalVars.directory != null && GlobalVars.restoreBak && backgroundWorker2.IsBusy != true && backgroundWorker1.IsBusy != true)
            {
                StartButton.Enabled = true;
            }
            else
            {
                StartButton.Enabled = false;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartThread(2);
        }

        private void CreateBakCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CreateBakCheck.Checked)
            {
                GlobalVars.makeBak = true;
            }
            else
            {
                GlobalVars.makeBak = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;
            DummyOps dmo = (DummyOps)e.Argument;
            dmo.DoWork(worker, e);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;
            ArrayReduction arrRed = (ArrayReduction)e.Argument;
            arrRed.reduce(worker, e);
        }

        /// <summary>
        /// Starts an asyncronous worker thread. Int 1 reduces the Directory array using the globally-stored file extension; Int 2 runs a mass dummy file operation; Int 3 is the same as using Int 1, except it uses .bak instead.
        /// </summary>
        /// <param name="sender"></param>
        private void StartThread(object sender)
        {
            if (sender.Equals(1))
            {
                backgroundWorker2.RunWorkerAsync(new ArrayReduction(false));
            }
            else if(sender.Equals(2))
            {
                ProgressText.ResetText();
                backgroundWorker1.RunWorkerAsync(new DummyOps());
                ProgressText.Visible = true;
            }
            if (sender.Equals(3))
            {
                backgroundWorker2.RunWorkerAsync(new ArrayReduction(true));
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else
            {
                canDummy();
            }
            ProgressText.Visible = false;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressText.Text = ((int)e.UserState).ToString() + "% complete.";
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else
            {
                GlobalVars.reloadDir = false;
                canDummy();
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            GlobalVars.fileArray = (List<string>)e.UserState; //updates the file array with the new, optimized file array
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            while(backgroundWorker1.IsBusy && backgroundWorker2.IsBusy)
            {
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
                if (backgroundWorker2.IsBusy)
                {
                    backgroundWorker2.CancelAsync();
                }
                
            }
        }
    }
}
