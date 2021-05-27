using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using OnBarcode.Barcode.BarcodeScanner;

namespace RepublicOfFitnessQrReader
{
    public partial class QrReader : Form
    {
        public QrReader()
        {
            InitializeComponent();
        }

        Qr webcam;

        private void QrReader_Load(object sender, EventArgs e)
        {
            webcam = new Qr();
            webcam.InitializeWebCam(ref imgVideo);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcam.Start();
            TimerTime.Start();
            TimerQrReader.Start();
        }          

        private void selectVideoSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcam.AdvanceSetting();
        }

        private void videoFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcam.ResolutionSetting();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("F");
        }

        private void TimerQrReader_Tick(object sender, EventArgs e)
        {
            System.Drawing.Bitmap BmpFrame = new Bitmap(imgVideo.Image);
            string[] qrcode = BarcodeScanner.Scan(BmpFrame, BarcodeType.QRCode);          
            //string[] qrcode = { "ROF-0001" };

            if (qrcode != null)
            {
                string status = webcam.TimeInOrTimeOutMember(qrcode[0]);
                if (status != "")
                    txtLog.Text = status + Environment.NewLine + txtLog.Text;
            }
        }
    }
}
