namespace CameraWindow
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置摄像头ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止摄像头ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口置顶ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.ContextMenuStrip = this.contextMenuStrip1;
            this.videoSourcePlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(0, 0);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(302, 266);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer1_MouseDown);
            this.videoSourcePlayer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer1_MouseMove);
            this.videoSourcePlayer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置摄像头ToolStripMenuItem,
            this.停止摄像头ToolStripMenuItem,
            this.窗口置顶ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 92);
            // 
            // 设置摄像头ToolStripMenuItem
            // 
            this.设置摄像头ToolStripMenuItem.Image = global::CameraWindow.Properties.Resources.camera;
            this.设置摄像头ToolStripMenuItem.Name = "设置摄像头ToolStripMenuItem";
            this.设置摄像头ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.设置摄像头ToolStripMenuItem.Text = "设置摄像头";
            // 
            // 停止摄像头ToolStripMenuItem
            // 
            this.停止摄像头ToolStripMenuItem.Image = global::CameraWindow.Properties.Resources.stop;
            this.停止摄像头ToolStripMenuItem.Name = "停止摄像头ToolStripMenuItem";
            this.停止摄像头ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.停止摄像头ToolStripMenuItem.Text = "停止摄像头";
            this.停止摄像头ToolStripMenuItem.Click += new System.EventHandler(this.停止摄像头ToolStripMenuItem_Click);
            // 
            // 窗口置顶ToolStripMenuItem
            // 
            this.窗口置顶ToolStripMenuItem.Image = global::CameraWindow.Properties.Resources.cancel;
            this.窗口置顶ToolStripMenuItem.Name = "窗口置顶ToolStripMenuItem";
            this.窗口置顶ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.窗口置顶ToolStripMenuItem.Text = "窗口置顶";
            this.窗口置顶ToolStripMenuItem.Click += new System.EventHandler(this.窗口置顶ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = global::CameraWindow.Properties.Resources.export;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 266);
            this.Controls.Add(this.videoSourcePlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置摄像头ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止摄像头ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口置顶ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

