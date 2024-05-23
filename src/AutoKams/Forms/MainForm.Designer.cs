namespace Juniansoft.AutoKams.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrCapture = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCpu = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMemory = new System.Windows.Forms.ToolStripStatusLabel();
            this.cameraControl3 = new Juniansoft.AutoKams.Controls.CameraControl();
            this.cameraControl2 = new Juniansoft.AutoKams.Controls.CameraControl();
            this.cameraControl1 = new Juniansoft.AutoKams.Controls.CameraControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(158, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 44);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrCapture
            // 
            this.tmrCapture.Tick += new System.EventHandler(this.tmrCapture_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInterval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(377, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 97);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Capture Control";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(15, 46);
            this.txtInterval.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(120, 20);
            this.txtInterval.TabIndex = 5;
            this.txtInterval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Capture Interval (ms):";
            // 
            // tmrClock
            // 
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTimer,
            this.lblCpu,
            this.lblMemory});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1103, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTimer
            // 
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // lblCpu
            // 
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(0, 17);
            // 
            // lblMemory
            // 
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(0, 17);
            // 
            // cameraControl3
            // 
            this.cameraControl3.HeaderText = "Camera 3";
            this.cameraControl3.Location = new System.Drawing.Point(695, 3);
            this.cameraControl3.Name = "cameraControl3";
            this.cameraControl3.Size = new System.Drawing.Size(339, 302);
            this.cameraControl3.TabIndex = 2;
            // 
            // cameraControl2
            // 
            this.cameraControl2.HeaderText = "Camera 2";
            this.cameraControl2.Location = new System.Drawing.Point(350, 3);
            this.cameraControl2.Name = "cameraControl2";
            this.cameraControl2.Size = new System.Drawing.Size(339, 302);
            this.cameraControl2.TabIndex = 1;
            // 
            // cameraControl1
            // 
            this.cameraControl1.HeaderText = "Camera 1";
            this.cameraControl1.Location = new System.Drawing.Point(5, 3);
            this.cameraControl1.Name = "cameraControl1";
            this.cameraControl1.Size = new System.Drawing.Size(339, 302);
            this.cameraControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.cameraControl1);
            this.panel1.Controls.Add(this.cameraControl2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cameraControl3);
            this.panel1.Location = new System.Drawing.Point(32, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 437);
            this.panel1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 528);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoKams";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CameraControl cameraControl1;
        private Controls.CameraControl cameraControl2;
        private Controls.CameraControl cameraControl3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrCapture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown txtInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTimer;
        private System.Windows.Forms.ToolStripStatusLabel lblCpu;
        private System.Windows.Forms.ToolStripStatusLabel lblMemory;
        private System.Windows.Forms.Panel panel1;
    }
}

