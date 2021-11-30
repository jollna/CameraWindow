using AForge.Controls;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraWindow
{
    public partial class Form1 : Form
    {
        private MouseDirection direction = MouseDirection.None;//表示拖动的方向，起始为None，表示不拖动
        private MouseFunction mouseFunction = MouseFunction.None;//表示按下状态，起始为None，表示不执行任何操作
        private Point mousePoint { get; set; }
        private bool Proportion = false;
        public int windowWidth { get; set; }
        public int windowHeight { get; set; }
        private FilterInfoCollection videoDevices { get; set; }//所有摄像设备
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Proportion = false;
            AddMenu();
        }
        private void videoSourcePlayer1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //当鼠标按下坐标距离窗体右边缘10像素以上且纵坐标距离下边缘也在10像素以上时，设置按下状态为移动模式
                if (e.Location.X < this.videoSourcePlayer1.Width - 10 && e.Location.Y < this.videoSourcePlayer1.Height - 10)
                {
                    mouseFunction = MouseFunction.Move;
                    mousePoint = new Point(-e.X, -e.Y);
                }
                //当鼠标移动时横坐标距离窗体右边缘10像素以内、纵坐标距离窗体下边缘10像素以内时，要将光标变为倾斜的箭头形状，设置按下状态为调整窗体大小模式，同时拖拽方向direction置为MouseDirection.Declining
                else if (e.Location.X >= this.videoSourcePlayer1.Width - 10 && e.Location.Y > this.videoSourcePlayer1.Height - 10)
                {
                    direction = MouseDirection.Declining;
                    mouseFunction = MouseFunction.Size;
                }
                //当鼠标移动时横坐标距离窗体右边缘10像素以内时，要将光标变为倾斜的箭头形状，设置按下状态为调整窗体大小模式，同时拖拽方向direction置为MouseDirection.Herizontal
                else if (e.Location.X >= this.videoSourcePlayer1.Width - 10)
                {
                    direction = MouseDirection.Herizontal;
                    mouseFunction = MouseFunction.Size;
                }
                //同理当鼠标移动时纵坐标距离窗体下边缘10像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Vertical
                else if (e.Location.Y >= this.videoSourcePlayer1.Height - 10)
                {
                    direction = MouseDirection.Vertical;
                    mouseFunction = MouseFunction.Size;
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                AddMenu();
            }
        }

        private void videoSourcePlayer1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseFunction == MouseFunction.Move)
            {
                Point mouseSet = Control.MousePosition;//获得移动后鼠标的坐标
                mouseSet.Offset(mousePoint.X, mousePoint.Y);//设置移动后的位置
                this.Location = mouseSet;
            }
            //当鼠标移动时横坐标距离窗体右边缘10像素以内且纵坐标距离下边缘也在10像素以内时，要将光标变为倾斜的箭头形状
            if (e.Location.X >= this.videoSourcePlayer1.Width - 10 && e.Location.Y > this.videoSourcePlayer1.Height - 10)
            {
                this.Cursor = Cursors.SizeNWSE;
            }
            //当鼠标移动时横坐标距离窗体右边缘10像素以内时，要将光标变为倾斜的箭头形状
            else if (e.Location.X >= this.videoSourcePlayer1.Width - 10)
            {
                this.Cursor = Cursors.SizeWE;
            }
            //同理当鼠标移动时纵坐标距离窗体下边缘10像素以内时，要将光标变为倾斜的箭头形状
            else if (e.Location.Y >= this.videoSourcePlayer1.Height - 10)
            {
                this.Cursor = Cursors.SizeNS;
            }
            //设置光标为鼠标状态
            else
            {
                this.Cursor = Cursors.Arrow;
            }

            //获取鼠标
            if (direction != MouseDirection.None)
            {
                ResizeWindow();
            }
        }

        private void videoSourcePlayer1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseFunction = MouseFunction.None;
            direction = MouseDirection.None;
        }

        private void CameraMenu2_Click(object sender, EventArgs e)
        {
            double opacity = double.Parse(sender.ToString().Substring(0, sender.ToString().Length - 1)) / 100;
            this.Opacity = opacity;
        }
        private void CameraMenu_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.Stop();
            if (sender.ToString() == "无")
            {
            }
            else
            {
                for (int i = 0; i < videoDevices.Count; i++)
                {
                    if (videoDevices[i].Name == sender.ToString())
                    {
                        VideoCaptureDevice videoDevice = new VideoCaptureDevice(videoDevices[i].MonikerString);
                        videoSourcePlayer1.VideoSource = videoDevice;
                        videoSourcePlayer1.SignalToStop();
                        videoSourcePlayer1.WaitForStop();
                        videoSourcePlayer1.Start();
                    }
                }
            }
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "停止摄像头":
                    videoSourcePlayer1.Stop();
                    break;
                case "固定比例":
                    if (Proportion == false)
                    {
                        windowWidth = this.Width;
                        windowHeight = this.Height;
                        Proportion = true;
                    }
                    else
                    {
                        Proportion = false;
                    }
                    break;
                case "窗口置顶":
                    if (this.TopMost == false)
                    {
                        this.TopMost = true;
                    }
                    else
                    {
                        this.TopMost = false;
                    }
                    break;
                case "退出":
                    this.Dispose();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 调整窗体大小
        /// </summary>
        private void ResizeWindow()
        {
            //判断鼠标按下状态，只有为调整窗体大小状态才能调整窗口大小
            if (mouseFunction != MouseFunction.Size) return;
            //MousePosition的参考点是屏幕的左上角，表示鼠标当前相对于屏幕左上角的坐标this.left和this.top的参考点也是屏幕，属性MousePosition是该程序的重点
            if (Proportion)
            {
                if (direction == MouseDirection.Declining)
                {
                    //此行代码在mousemove事件中已经写过，在此再写一遍，并不多余，一定要写
                    this.Cursor = Cursors.SizeNWSE;
                    //下面是改变窗体宽和高的代码，不明白的可以仔细思考一下
                    if (MousePosition.X >= MousePosition.Y)
                    {
                        this.Width = MousePosition.X - this.Left;
                        this.Height = (this.Width * windowHeight) / windowWidth;
                    }
                    else
                    {
                        this.Height = MousePosition.Y - this.Top;
                        this.Width = (this.Height * windowWidth) / windowHeight;
                    }
                }
                if (direction == MouseDirection.Herizontal)
                {
                    this.Cursor = Cursors.SizeWE;
                    this.Width = MousePosition.X - this.Left;
                    this.Height = (this.Width * windowHeight) / windowWidth;
                }
                else if (direction == MouseDirection.Vertical)
                {
                    this.Cursor = Cursors.SizeNS;
                    this.Height = MousePosition.Y - this.Top;
                    this.Width = (this.Height * windowWidth) / windowHeight;
                }
                //即使鼠标按下，但是不在窗口右和下边缘，那么也不能改变窗口大小
                else
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
            else
            {

                if (direction == MouseDirection.Declining)
                {
                    //此行代码在mousemove事件中已经写过，在此再写一遍，并不多余，一定要写
                    this.Cursor = Cursors.SizeNWSE;
                    //下面是改变窗体宽和高的代码，不明白的可以仔细思考一下
                    this.Width = MousePosition.X - this.Left;
                    this.Height = MousePosition.Y - this.Top;
                }
                if (direction == MouseDirection.Herizontal)
                {
                    this.Cursor = Cursors.SizeWE;
                    this.Width = MousePosition.X - this.Left;
                }
                else if (direction == MouseDirection.Vertical)
                {
                    this.Cursor = Cursors.SizeNS;
                    this.Height = MousePosition.Y - this.Top;
                }
                //即使鼠标按下，但是不在窗口右和下边缘，那么也不能改变窗口大小
                else
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }
        /// <summary>
        /// 枚举鼠标位于窗体的不同状态
        /// </summary>
        public enum MouseDirection
        {
            Herizontal,//水平方向拖动，只改变窗体的宽度
            Vertical,//垂直方向拖动，只改变窗体的高度
            Declining,//倾斜方向，同时改变窗体的宽度和高度
            None//不做标志，即不拖动窗体改变大小
        }
        /// <summary>
        /// 枚举鼠标按下位置的状态
        /// </summary>
        public enum MouseFunction
        {
            Move,//移动窗体功能
            Size,//调整窗体大小功能
            None //不带任何功能
        }
        /// <summary>
        /// 生成右键菜单选项
        /// </summary>
        private void AddMenu()
        {
            contextMenuStrip1.Items.Clear();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);//得到所有接入的摄像设备
            ToolStripMenuItem CameraMenu = new ToolStripMenuItem("设置摄像头", Properties.Resources.camera);
            CameraMenu.DropDownItems.Add("无", Properties.Resources.NoCamera);
            foreach (FilterInfo device in videoDevices)
            {
                CameraMenu.DropDownItems.Add(device.Name, Properties.Resources.NweCamera);
            }
            contextMenuStrip1.Items.Add(CameraMenu);
            for (int i = 0; i < CameraMenu.DropDownItems.Count; i++)
            {
                CameraMenu.DropDownItems[i].Click += new EventHandler(CameraMenu_Click);
            }
            contextMenuStrip1.Items.Add("停止摄像头", Properties.Resources.stop);
            ToolStripMenuItem CameraMenu2 = new ToolStripMenuItem("窗体透明度", Properties.Resources.stop);
            for (int i = 1; i <= 10; i++)
            {
                CameraMenu2.DropDownItems.Add($"{i}0%");
                CameraMenu2.DropDownItems[i - 1].Click += new EventHandler(CameraMenu2_Click);
            }
            contextMenuStrip1.Items.Add(CameraMenu2);
            contextMenuStrip1.Items.Add("固定比例", GetImage(Proportion));
            contextMenuStrip1.Items.Add("窗口置顶", GetImage(this.TopMost));
            contextMenuStrip1.Items.Add("退出", Properties.Resources.export);
        }      
        /// <summary>
        /// 更新右键菜单图标
        /// </summary>
        /// <param name="IsCheckmark"></param>
        /// <returns></returns>
        private Image GetImage(bool IsCheckmark)
        {
            if (IsCheckmark)
            {
                return Properties.Resources.checkmark;
            }
            else
            {
                return Properties.Resources.cancel;
            }

        }
    }
}