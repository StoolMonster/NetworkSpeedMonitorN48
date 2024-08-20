using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkSpeedMonitorN48
{
    public partial class Form1 : Form
    {
        private PerformanceCounterCategory category;
        private String[] instanceNames;
        private PerformanceCounter[] uploadCounters;
        private PerformanceCounter[] downloadCounters;
        private System.Windows.Forms.Timer timer;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private int line1NI = 0;
        private int line2NI = 0;

        private ContextMenuStrip mainWindowContextMenuStrip;
        private ContextMenuStrip networkInterfaceChooseContextMenuStrip;
        private ContextMenuStrip trayMenu;
        private ToolStripMenuItem resetWindowPositionToolStripMenuItem;
        private ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toggleMouseInteractionItem;

        private NotifyIcon trayIcon;
        private bool mouseInteractionEnabled = true;

        private ToolTip labelWiFiToolTip;
        private ToolTip labelEthToolTip;

        [DllImport("dwmapi.dll", EntryPoint = "DwmGetColorizationColor")]
        private static extern void DwmGetColorizationColor(out uint color, out bool opaqueBlend);

        public Form1()
        {
            InitializeComponent();

            this.TopMost = true;


            ResetWindowPosition();

            //
            labelWiFi.MouseDown += Form1_MouseDown;
            labelWiFiSe.MouseDown += Form1_MouseDown;
            labelWiFiRe.MouseDown += Form1_MouseDown;
            labelEth.MouseDown += Form1_MouseDown;
            labelEthSe.MouseDown += Form1_MouseDown;
            labelEthRe.MouseDown += Form1_MouseDown;

            // Initialize network interfaces
            category = new PerformanceCounterCategory("Network Interface");
            instanceNames = category.GetInstanceNames();
            uploadCounters = new PerformanceCounter[instanceNames.Length];
            downloadCounters = new PerformanceCounter[instanceNames.Length];

            // Set up PerformaceCounters for each network interface
            for (int i = 0; i < instanceNames.Length; i++)
            {
                string instanceName = instanceNames[i];
                uploadCounters[i] = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instanceName);
                downloadCounters[i] = new PerformanceCounter("Network Interface", "Bytes Received/sec", instanceName);

                // Choose init network interface based on names, users can choose manully later.
                if (instanceName.Contains("Eth"))
                {
                    line2NI = i;
                }
                if (instanceName.Contains("Wi-Fi"))
                {
                    line1NI = i;
                }
            }

            labelWiFiToolTip = new ToolTip();
            labelWiFiToolTip.AutoPopDelay = 5000;
            labelWiFiToolTip.InitialDelay = 500;
            labelWiFiToolTip.ReshowDelay = 500;
            labelWiFiToolTip.ShowAlways = true;
            labelWiFiToolTip.SetToolTip(labelWiFi, instanceNames[line1NI]);

            labelEthToolTip = new ToolTip();
            labelEthToolTip.AutoPopDelay = 5000;
            labelEthToolTip.InitialDelay = 500;
            labelEthToolTip.ReshowDelay = 500;
            labelEthToolTip.ShowAlways = true;
            labelWiFiToolTip.SetToolTip(labelEth, instanceNames[line2NI]);  

            SetUpCommonToolStripMenuItems();
            SetUpMainWindowContextMenuStrip();
            SetUpNetworkInterfaceChooseContextMenuStrip();
            SetUpTray();

            // Set up update timer of network speed
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += NetworkSpeedUpdate_Tick;
            timer.Start();
        }

        private void SetUpMainColor()
        {
            // TODO, there is a problem with this function.
            // Set up window's background color as system accent color
            uint colorizationColor;
            bool opaqueBlend;

            // Retrieve the system accent color using DwmGetColorizationColor
            DwmGetColorizationColor(out colorizationColor, out opaqueBlend);
            // Convert the retrieved color to a Color object
            Color accentColor = Color.FromArgb(
                (int)(colorizationColor >> 24),    // Alpha
                (int)(colorizationColor & 0xFF),   // Red
                (int)((colorizationColor >> 8) & 0xFF),  // Green
                (int)((colorizationColor >> 16) & 0xFF)  // Blue
            );

            // Set the form's BackColor to the system accent color
            this.BackColor = accentColor;
        }

        private void SetUpCommonToolStripMenuItems()
        {
            resetWindowPositionToolStripMenuItem = new ToolStripMenuItem("Reset window position", null, resetWindowPositionToolStripMenuItem_Click);
            alwaysOnTopToolStripMenuItem = new ToolStripMenuItem("Always on top", null, alwaysOnTopToolStripMenuItem_Click);
            alwaysOnTopToolStripMenuItem.Checked = this.TopMost;
            exitToolStripMenuItem = new ToolStripMenuItem("Exit", null, exitToolStripMenuItem_Click);
            toggleMouseInteractionItem = new ToolStripMenuItem("Toggle Mouse Interaction", null, ToggleMouseInteraction_Click);
            toggleMouseInteractionItem.Checked = mouseInteractionEnabled;
        }

        private void SetUpMainWindowContextMenuStrip()
        {
            mainWindowContextMenuStrip = new ContextMenuStrip();
            this.ContextMenuStrip = mainWindowContextMenuStrip;
            mainWindowContextMenuStrip.Opening += MainWindowContextMenuStrip_Opening;
        }

        private void SetUpNetworkInterfaceChooseContextMenuStrip()
        {
            // Set up ContextMenuStrip to choose which network interface to show.
            networkInterfaceChooseContextMenuStrip = new ContextMenuStrip();
            networkInterfaceChooseContextMenuStrip.Opening += networkInterfaceChooseContextMenuStrip_Opening;
            labelWiFi.ContextMenuStrip = networkInterfaceChooseContextMenuStrip;
            labelEth.ContextMenuStrip = networkInterfaceChooseContextMenuStrip;
        }

        private void SetUpTray()
        {
            // Set up tray icon
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Text = "NetworkSpeedMonitor",
                Visible = true
            };

            // Set up tray menu
            trayMenu = new ContextMenuStrip();
            trayIcon.ContextMenuStrip = trayMenu;
            trayMenu.Opening += trayMenu_Opening;
        }

        private void MainWindowContextMenuStrip_Opening(object sender, EventArgs e)
        {
            mainWindowContextMenuStrip.Items.Clear();
            mainWindowContextMenuStrip.Items.Add(resetWindowPositionToolStripMenuItem);
            mainWindowContextMenuStrip.Items.Add(alwaysOnTopToolStripMenuItem);
            mainWindowContextMenuStrip.Items.Add(exitToolStripMenuItem);
        }

        private void ToggleMouseInteraction_Click(object sender, EventArgs e)
        {
            mouseInteractionEnabled = !mouseInteractionEnabled;
            toggleMouseInteractionItem.Checked = mouseInteractionEnabled;
            this.Enabled = mouseInteractionEnabled;
        }

        private void networkInterfaceChooseContextMenuStrip_Opening(object sender, EventArgs e)
        {
            networkInterfaceChooseContextMenuStrip.Items.Clear();

            for (int i = 0; i < instanceNames.Length; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(instanceNames[i]);
                item.Tag = instanceNames[i];
                item.Click += Item_Click;
                networkInterfaceChooseContextMenuStrip.Items.Add(item);
            }
        }

        private void trayMenu_Opening(object sender, EventArgs e)
        {
            trayMenu.Items.Clear();
            trayMenu.Items.Add(toggleMouseInteractionItem);
            trayMenu.Items.Add(resetWindowPositionToolStripMenuItem);
            trayMenu.Items.Add(alwaysOnTopToolStripMenuItem);
            trayMenu.Items.Add(exitToolStripMenuItem);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var selectedItem = (ToolStripMenuItem)sender;
            int selectedInterfaceIndex = networkInterfaceChooseContextMenuStrip.Items.IndexOf(selectedItem);

            if (networkInterfaceChooseContextMenuStrip.SourceControl == labelWiFi)
            {
                line1NI = selectedInterfaceIndex;
                labelWiFiToolTip.SetToolTip(labelWiFi, instanceNames[line1NI]);
            }
            else if (networkInterfaceChooseContextMenuStrip.SourceControl == labelEth)
            {
                line2NI = selectedInterfaceIndex;
                labelEthToolTip.SetToolTip(labelEth, instanceNames[line2NI]);
            }
        }

        private void ResetWindowPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            int x = 0;
            int y = Screen.PrimaryScreen.Bounds.Height - this.Height;
            this.Location = new Point(x, y);
        }

        private void NetworkSpeedUpdate_Tick(object sender, EventArgs e)
        {
            string uploadSpeed = FormatBytes(uploadCounters[line1NI].NextValue());
            string downloadSpeed = FormatBytes(downloadCounters[line1NI].NextValue());
            labelWiFiSe.Text = uploadSpeed + "/s";
            labelWiFiRe.Text = downloadSpeed + "/s";

            uploadSpeed = FormatBytes(uploadCounters[line2NI].NextValue());
            downloadSpeed = FormatBytes(downloadCounters[line2NI].NextValue());
            labelEthSe.Text = uploadSpeed + "/s";
            labelEthRe.Text = downloadSpeed + "/s";
        }

        private string FormatBytes(float bytes)
        {
            bytes /= 1024;
            string[] sizes = { "KB", "MB", "GB", "TB" };
            int order = 0;
            while (bytes >= 999.0 && order < sizes.Length - 1)
            {
                order++;
                bytes /= 1024;
            }
            return String.Format("{0:0.#} {1}", bytes, sizes[order]);
        }


        // Use mouse left button to move the form
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
            alwaysOnTopToolStripMenuItem.Checked = this.TopMost;
        }

        private void resetWindowPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetWindowPosition();
        }


        // 重写 WndProc 方法来拦截和处理 Windows 消息。
        protected override void WndProc(ref Message m)
        {
            const int WM_ACTIVATE = 0x0006; // 当窗口被激活或失去激活状态时发送的消息。
            const int WM_NCACTIVATE = 0x0086; // 当非客户区（如标题栏）激活或失去激活状态时发送的消息。
            const int WM_MOUSEACTIVATE = 0x0021; // 当鼠标激活窗口时发送的消息。
            const int WM_WINDOWPOSCHANGING = 0x0046; // 在窗口位置或大小正在改变时发送的消息。

            base.WndProc(ref m);

            // 处理表单激活和窗口位置变化等消息
            if (m.Msg == WM_ACTIVATE || m.Msg == WM_NCACTIVATE || m.Msg == WM_MOUSEACTIVATE || m.Msg == WM_WINDOWPOSCHANGING)
            {
                // 确保表单始终置顶
                this.TopMost = true;
            }
        }
    }
}