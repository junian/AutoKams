using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AutoKams.Controls;
using AutoKams.Utils;
using System.IO;

namespace AutoKams
{
    public partial class MainForm : Form
    {
        IList<CameraControl> controllers;
        string rootFolder;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            controllers = new List<CameraControl>();

            controllers.Add(cameraControl1);
            controllers.Add(cameraControl2);
            controllers.Add(cameraControl3);
        }

        private void StartAllCams()
        {
            foreach (var c in controllers)
            {
                c.StartCamera();
            }
        }

        private void StopAllCams()
        {
            foreach (var c in controllers)
            {
                c.StopCamera();
            }
        }

        private void CaptureAllCams()
        {
            foreach (var c in controllers)
            {
                if (c.CapturedImage != null)
                {
                    Bitmap b = (Bitmap)c.CapturedImage;
                    b.Save(rootFolder + "\\" + c.HeaderText + "_-_" + IDGenerator.GenerateDateTimeID() + ".jpg");
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("&Start"))
            {
                //if (StartCamera())
                //{
                StartAllCams();
                btnStart.Text = "&Stop";
                rootFolder = IDGenerator.GenerateDateID();
                if (!Directory.Exists(rootFolder))
                {
                    Directory.CreateDirectory(rootFolder);
                }
                tmrCapture.Interval = (int)txtInterval.Value;
                tmrCapture.Start();
                //btnBrowse.Visible = false;
                //tmrDetection.Enabled = true;
                //}
            }
            else if (btnStart.Text.Equals("&Stop"))
            {
                //btnStart.Text = "&Start";
                //btnBrowse.Visible = true;
                //tmrDetection.Enabled = false;
                tmrCapture.Stop();
                StopAllCams();
                //picGambar.Image.Save(DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
            }
        }

        private void tmrCapture_Tick(object sender, EventArgs e)
        {
            CaptureAllCams();
        }

    }
}
