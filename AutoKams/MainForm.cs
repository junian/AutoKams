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
using System.Diagnostics;
using System.Drawing.Imaging;
using AutoKams.Properties;

namespace AutoKams
{
    public partial class MainForm : Form
    {
        IList<CameraControl> controllers;
        string rootFolder;
        private object thisLock = new object();
        private DateTime startTime;
        private PerformanceCounter cpuUsage;
        private PerformanceCounter memoryUsage;

        public MainForm()
        {
            InitializeComponent();

            cpuUsage = new PerformanceCounter("Process", "% Processor Time",
                                    Process.GetCurrentProcess().ProcessName);
            memoryUsage = new PerformanceCounter("Process", "Working Set",
                                    Process.GetCurrentProcess().ProcessName);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            controllers = new List<CameraControl>();

            controllers.Add(cameraControl1);
            controllers.Add(cameraControl2);
            controllers.Add(cameraControl3);

            int interval = Settings.Default.CaptureInterval;
            txtInterval.Value = interval < txtInterval.Minimum ? txtInterval.Minimum :
                                interval > txtInterval.Maximum ? txtInterval.Maximum :
                                interval;
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
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        //Bitmap b = (Bitmap) c.CapturedImage.Clone();
                        lock (thisLock)
                        {
                            var savePath = rootFolder + "\\" + c.HeaderText + "_-_" + IDGenerator.GenerateDateTimeID() + ".jpg";
                            Debug.WriteLine(savePath);
                            c.CapturedImage.Save(savePath, ImageFormat.Jpeg);
                        }
                        //b.Dispose();
                    }));
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
                tmrClock.Start();
                startTime = DateTime.Now;
                Settings.Default.CaptureInterval = (int)txtInterval.Value;
                Settings.Default.Save();
            }
            else if (btnStart.Text.Equals("&Stop"))
            {
                btnStart.Text = "&Start";
                //btnBrowse.Visible = true;
                //tmrDetection.Enabled = false;
                tmrClock.Stop();
                tmrCapture.Stop();
                StopAllCams();
                //picGambar.Image.Save(DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
            }
        }

        private void tmrCapture_Tick(object sender, EventArgs e)
        {
            System.GC.Collect();
            CaptureAllCams();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                tmrClock.Stop();
                tmrCapture.Stop();
                StopAllCams();
            }
            catch (Exception ex)
            {
            }
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = "Run Time: " + (DateTime.Now - startTime).ToString();
            lblCpu.Text = "CPU: " + cpuUsage.NextValue().ToString("00.00");
            lblMemory.Text = "RAM: " + (memoryUsage.NextValue() / 1024.0f / 1024.0f).ToString("00.00") + "MB";
        }

    }
}
