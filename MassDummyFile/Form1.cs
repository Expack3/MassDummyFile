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
                    GlobalVars.fileArray = Directory.GetFiles(GlobalVars.directory);
                    DirectorySelection.Visible = true;
                }
                else
                {
                    GlobalVars.directory = null;
                    GlobalVars.fileArray = null;
                    DirectorySelection.Visible = false;
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
            }
        }

        private void ExtTextbox_TextChanged(object sender, EventArgs e)
        {
            if (ExtValidator.validate(ExtTextbox.Text))
            {
                GlobalVars.fileExt[0] = ExtTextbox.Text;
                GlobalVars.extValid = true;
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
                if (GlobalVars.directory != null && GlobalVars.fileArray.Length > 0 && GlobalVars.extValid == true)
                {
                    StartButton.Enabled = true;
                }
            }
            else if (GlobalVars.directory != null && GlobalVars.restoreBak)
            {
                StartButton.Enabled = true;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            DummyOps.MassDummyFile();
        }

        private void CreateBakCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CreateBakCheck.Checked)
            {
                GlobalVars.makeBak = true;
            }
        }
    }
}
