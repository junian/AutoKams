using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Diagnostics;
using AutoKams.Utils;

namespace AutoKams.Controls
{
    public partial class CameraControl : UserControl
    {
        private FilterInfoCollection vidSources;
        private VideoCaptureDevice camera;
        private Bitmap resizedImage;
        private Bitmap capturedImage;

        public CameraControl()
        {
            InitializeComponent();
        }

        private void CameraControl_Load(object sender, EventArgs e)
        {
            vidSources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo f in vidSources)
                cmbCam.Items.Add(f.Name);
            if (cmbCam.Items.Count > 0)
                cmbCam.SelectedIndex = 0;
            else
                MessageBox.Show("no camera(s) detected");
        }

        public Bitmap CapturedImage
        {
            get
            {
                return capturedImage;
            }
        }

        public PictureBox CamPicture
        {
            get
            {
                return picCam;
            }
        }

        public String HeaderText
        {
            get
            {
                return groupBox.Text;
            }
            set
            {
                groupBox.Text = value;
            }
        }

        public void StopCamera()
        {
            try
            {
                camera.SignalToStop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public bool StartCamera()
        {
            try
            {
                camera = new VideoCaptureDevice(vidSources[cmbCam.SelectedIndex].MonikerString);
                foreach (VideoCapabilities c in camera.VideoCapabilities)
                {
                    Debug.WriteLine(c.FrameSize);
                }

                camera.DesiredFrameSize = new Size(320, 240);
                camera.DesiredFrameRate = 15;
                camera.NewFrame += new AForge.Video.NewFrameEventHandler(camera_NewFrame);
                camera.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        void camera_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            capturedImage = (Bitmap)eventArgs.Frame.Clone();
            resizedImage = BitmapUtil.ResizeImage((Bitmap)eventArgs.Frame.Clone(), picCam.Width, picCam.Height);
            picCam.Image = resizedImage;
        }


    }
}
