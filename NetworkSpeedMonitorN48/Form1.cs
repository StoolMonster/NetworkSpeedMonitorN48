using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private bool mouseInteractionEnabled = true;

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
            }

            // Set up ContextMenuStrip to choose which network interface to show.
            contextMenuStrip2.Opening += ContextMenuStrip2_Opening;
            labelWiFi.ContextMenuStrip = contextMenuStrip2;
            labelEth.ContextMenuStrip = contextMenuStrip2;

            // Set up tray icon
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Text = "NetworkSpeedMonitor",
                Visible = true
            };

            // Set up tray menu
            trayMenu = new ContextMenuStrip();
            ToolStripMenuItem toggleMouseInteractionItem = new ToolStripMenuItem("Toggle Mouse Interaction", null, ToggleMouseInteraction_Click);
            trayMenu.Items.Add(toggleMouseInteractionItem);
            trayIcon.ContextMenuStrip = trayMenu;

            // Set up update timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void ToggleMouseInteraction_Click(object sender, EventArgs e)
        {
            mouseInteractionEnabled = !mouseInteractionEnabled;
            this.Enabled = mouseInteractionEnabled;
            this.Text = mouseInteractionEnabled ? "Mouse Interaction Enabled" : "Mouse Interaction Disabled";
        }

        private void ContextMenuStrip2_Opening(object sender, EventArgs e)
        {
            contextMenuStrip2.Items.Clear();

            for (int i = 0; i < instanceNames.Length; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(instanceNames[i]);
                item.Tag = instanceNames[i];
                item.Click += Item_Click;
                contextMenuStrip2.Items.Add(item);
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var selectedItem = (ToolStripMenuItem)sender;
            int selectedInterfaceIndex = contextMenuStrip2.Items.IndexOf(selectedItem);

            if (contextMenuStrip2.SourceControl == labelWiFi)
            {
                line1NI = selectedInterfaceIndex;
            }
            else if (contextMenuStrip2.SourceControl == labelEth)
            {
                line2NI = selectedInterfaceIndex;
            }
        }

        private void ResetWindowPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            int x = 0;
            int y = Screen.PrimaryScreen.Bounds.Height - this.Height;
            this.Location = new Point(x, y);
        }

        private void Timer_Tick(object sender, EventArgs e)
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
            while (bytes >= 1024 && order < sizes.Length - 1)
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

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void keepOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
            if (this.TopMost)
            {
                keepOnTopToolStripMenuItem.Text = "Disbale Keep on Top";
            }
            else
            {
                keepOnTopToolStripMenuItem.Text = "Keep on Top";

            }
        }

        private void resetPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetWindowPosition();
        }
    }
}
