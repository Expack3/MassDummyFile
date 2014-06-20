namespace MassDummyFile
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.selectDirButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateDummyRadio = new System.Windows.Forms.RadioButton();
            this.RestoreRadio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateBakCheck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.DirectorySelection = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.ExtTextbox = new System.Windows.Forms.TextBox();
            this.ProgressText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Select the target directory.";
            // 
            // selectDirButton
            // 
            this.selectDirButton.Location = new System.Drawing.Point(13, 30);
            this.selectDirButton.Name = "selectDirButton";
            this.selectDirButton.Size = new System.Drawing.Size(94, 23);
            this.selectDirButton.TabIndex = 1;
            this.selectDirButton.Text = "Select Directory";
            this.selectDirButton.UseVisualStyleBackColor = true;
            this.selectDirButton.Click += new System.EventHandler(this.selectDirButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "2. Is this a restore or a dummy creation operation?";
            // 
            // CreateDummyRadio
            // 
            this.CreateDummyRadio.AutoSize = true;
            this.CreateDummyRadio.Checked = true;
            this.CreateDummyRadio.Location = new System.Drawing.Point(11, 88);
            this.CreateDummyRadio.Name = "CreateDummyRadio";
            this.CreateDummyRadio.Size = new System.Drawing.Size(118, 17);
            this.CreateDummyRadio.TabIndex = 2;
            this.CreateDummyRadio.TabStop = true;
            this.CreateDummyRadio.Text = "Create Dummy Files";
            this.CreateDummyRadio.UseVisualStyleBackColor = true;
            this.CreateDummyRadio.CheckedChanged += new System.EventHandler(this.CreateDummyRadio_CheckedChanged);
            // 
            // RestoreRadio
            // 
            this.RestoreRadio.AutoSize = true;
            this.RestoreRadio.Location = new System.Drawing.Point(151, 88);
            this.RestoreRadio.Name = "RestoreRadio";
            this.RestoreRadio.Size = new System.Drawing.Size(107, 17);
            this.RestoreRadio.TabIndex = 2;
            this.RestoreRadio.Text = "Restore Backups";
            this.RestoreRadio.UseVisualStyleBackColor = true;
            this.RestoreRadio.CheckedChanged += new System.EventHandler(this.RestoreRadio_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "3. Do you want to create backups of the dummied files?";
            // 
            // CreateBakCheck
            // 
            this.CreateBakCheck.AutoSize = true;
            this.CreateBakCheck.Location = new System.Drawing.Point(13, 163);
            this.CreateBakCheck.Name = "CreateBakCheck";
            this.CreateBakCheck.Size = new System.Drawing.Size(121, 17);
            this.CreateBakCheck.TabIndex = 3;
            this.CreateBakCheck.Text = "Create Backup Files";
            this.CreateBakCheck.UseVisualStyleBackColor = true;
            this.CreateBakCheck.CheckedChanged += new System.EventHandler(this.CreateBakCheck_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "4. Enter the extension of the files you wish to dummy out.";
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(126, 317);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Go!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DirectorySelection
            // 
            this.DirectorySelection.AutoSize = true;
            this.DirectorySelection.Location = new System.Drawing.Point(113, 35);
            this.DirectorySelection.Name = "DirectorySelection";
            this.DirectorySelection.Size = new System.Drawing.Size(97, 13);
            this.DirectorySelection.TabIndex = 6;
            this.DirectorySelection.Text = "Directory Selected!";
            this.DirectorySelection.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // ExtTextbox
            // 
            this.ExtTextbox.Enabled = false;
            this.ExtTextbox.Location = new System.Drawing.Point(13, 230);
            this.ExtTextbox.Name = "ExtTextbox";
            this.ExtTextbox.Size = new System.Drawing.Size(265, 20);
            this.ExtTextbox.TabIndex = 4;
            this.ExtTextbox.TextChanged += new System.EventHandler(this.ExtTextbox_TextChanged);
            // 
            // ProgressText
            // 
            this.ProgressText.AutoSize = true;
            this.ProgressText.Location = new System.Drawing.Point(13, 281);
            this.ProgressText.Name = "ProgressText";
            this.ProgressText.Size = new System.Drawing.Size(35, 13);
            this.ProgressText.TabIndex = 7;
            this.ProgressText.Text = "label5";
            this.ProgressText.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 352);
            this.Controls.Add(this.ProgressText);
            this.Controls.Add(this.DirectorySelection);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ExtTextbox);
            this.Controls.Add(this.CreateBakCheck);
            this.Controls.Add(this.RestoreRadio);
            this.Controls.Add(this.CreateDummyRadio);
            this.Controls.Add(this.selectDirButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mass Dummy File Creator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectDirButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton CreateDummyRadio;
        private System.Windows.Forms.RadioButton RestoreRadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CreateBakCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label DirectorySelection;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox ExtTextbox;
        private System.Windows.Forms.Label ProgressText;
    }
}

