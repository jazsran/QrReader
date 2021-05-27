namespace RepublicOfFitnessQrReader
{
    //Design by Pongsakorn Poosankam
    partial class QrReader
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
            this.imgVideo = new System.Windows.Forms.PictureBox();
            this.menuStripQrReader = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectVideoSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerQrReader = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.TimerTime = new System.Windows.Forms.Timer(this.components);
            this.lblLog = new System.Windows.Forms.Label();
            this.lblCam = new System.Windows.Forms.Label();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).BeginInit();
            this.menuStripQrReader.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgVideo
            // 
            this.imgVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgVideo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgVideo.ErrorImage = null;
            this.imgVideo.Location = new System.Drawing.Point(16, 114);
            this.imgVideo.Name = "imgVideo";
            this.imgVideo.Size = new System.Drawing.Size(323, 243);
            this.imgVideo.TabIndex = 0;
            this.imgVideo.TabStop = false;
            // 
            // menuStripQrReader
            // 
            this.menuStripQrReader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripQrReader.Location = new System.Drawing.Point(0, 0);
            this.menuStripQrReader.Name = "menuStripQrReader";
            this.menuStripQrReader.Size = new System.Drawing.Size(702, 24);
            this.menuStripQrReader.TabIndex = 9;
            this.menuStripQrReader.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.selectVideoSourceToolStripMenuItem,
            this.videoFormatToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // selectVideoSourceToolStripMenuItem
            // 
            this.selectVideoSourceToolStripMenuItem.Name = "selectVideoSourceToolStripMenuItem";
            this.selectVideoSourceToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.selectVideoSourceToolStripMenuItem.Text = "&Video Source";
            this.selectVideoSourceToolStripMenuItem.Click += new System.EventHandler(this.selectVideoSourceToolStripMenuItem_Click);
            // 
            // videoFormatToolStripMenuItem
            // 
            this.videoFormatToolStripMenuItem.Name = "videoFormatToolStripMenuItem";
            this.videoFormatToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.videoFormatToolStripMenuItem.Text = "&Video Format";
            this.videoFormatToolStripMenuItem.Click += new System.EventHandler(this.videoFormatToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // TimerQrReader
            // 
            this.TimerQrReader.Interval = 1500;
            this.TimerQrReader.Tick += new System.EventHandler(this.TimerQrReader_Tick);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(367, 114);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(323, 243);
            this.txtLog.TabIndex = 10;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Rockwell", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(9, 33);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(453, 38);
            this.lblTime.TabIndex = 11;
            this.lblTime.Text = "Please start the Qr Reader...";
            // 
            // TimerTime
            // 
            this.TimerTime.Interval = 1000;
            this.TimerTime.Tick += new System.EventHandler(this.TimerTime_Tick);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(364, 89);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(28, 13);
            this.lblLog.TabIndex = 12;
            this.lblLog.Text = "Log:";
            // 
            // lblCam
            // 
            this.lblCam.AutoSize = true;
            this.lblCam.Location = new System.Drawing.Point(13, 89);
            this.lblCam.Name = "lblCam";
            this.lblCam.Size = new System.Drawing.Size(53, 13);
            this.lblCam.TabIndex = 13;
            this.lblCam.Text = "Webcam:";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "&Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // QrReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 371);
            this.Controls.Add(this.lblCam);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.imgVideo);
            this.Controls.Add(this.menuStripQrReader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStripQrReader;
            this.MaximizeBox = false;
            this.Name = "QrReader";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qr Reader for Republic of Fitness";
            this.Load += new System.EventHandler(this.QrReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).EndInit();
            this.menuStripQrReader.ResumeLayout(false);
            this.menuStripQrReader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgVideo;
        private System.Windows.Forms.MenuStrip menuStripQrReader;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectVideoSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoFormatToolStripMenuItem;
        private System.Windows.Forms.Timer TimerQrReader;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer TimerTime;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblCam;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
    }
}

