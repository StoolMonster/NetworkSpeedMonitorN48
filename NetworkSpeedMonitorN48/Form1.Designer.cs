namespace NetworkSpeedMonitorN48
{
    partial class Form1
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
            this.labelWiFi = new System.Windows.Forms.Label();
            this.labelEth = new System.Windows.Forms.Label();
            this.labelWiFiSe = new System.Windows.Forms.Label();
            this.labelEthSe = new System.Windows.Forms.Label();
            this.labelWiFiRe = new System.Windows.Forms.Label();
            this.labelEthRe = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.keepOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetWindowPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWiFi
            // 
            this.labelWiFi.Location = new System.Drawing.Point(0, 0);
            this.labelWiFi.Name = "labelWiFi";
            this.labelWiFi.Size = new System.Drawing.Size(40, 20);
            this.labelWiFi.TabIndex = 0;
            this.labelWiFi.Text = "WiFi";
            // 
            // labelEth
            // 
            this.labelEth.Location = new System.Drawing.Point(0, 20);
            this.labelEth.Name = "labelEth";
            this.labelEth.Size = new System.Drawing.Size(40, 20);
            this.labelEth.TabIndex = 1;
            this.labelEth.Text = "Eth";
            // 
            // labelWiFiSe
            // 
            this.labelWiFiSe.Location = new System.Drawing.Point(46, 0);
            this.labelWiFiSe.Name = "labelWiFiSe";
            this.labelWiFiSe.Size = new System.Drawing.Size(80, 20);
            this.labelWiFiSe.TabIndex = 2;
            this.labelWiFiSe.Text = "0 KB/s";
            this.labelWiFiSe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEthSe
            // 
            this.labelEthSe.Location = new System.Drawing.Point(46, 20);
            this.labelEthSe.Name = "labelEthSe";
            this.labelEthSe.Size = new System.Drawing.Size(80, 20);
            this.labelEthSe.TabIndex = 3;
            this.labelEthSe.Text = "0 KB/s";
            this.labelEthSe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWiFiRe
            // 
            this.labelWiFiRe.Location = new System.Drawing.Point(132, 0);
            this.labelWiFiRe.Name = "labelWiFiRe";
            this.labelWiFiRe.Size = new System.Drawing.Size(80, 20);
            this.labelWiFiRe.TabIndex = 4;
            this.labelWiFiRe.Text = "0 KB/s";
            this.labelWiFiRe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEthRe
            // 
            this.labelEthRe.Location = new System.Drawing.Point(132, 20);
            this.labelEthRe.Name = "labelEthRe";
            this.labelEthRe.Size = new System.Drawing.Size(80, 20);
            this.labelEthRe.TabIndex = 5;
            this.labelEthRe.Text = "0 KB/s";
            this.labelEthRe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepOnTopToolStripMenuItem,
            this.resetWindowPositionToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 76);
            // 
            // keepOnTopToolStripMenuItem
            // 
            this.keepOnTopToolStripMenuItem.Name = "keepOnTopToolStripMenuItem";
            this.keepOnTopToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.keepOnTopToolStripMenuItem.Text = "Disable Keep On Top";
            this.keepOnTopToolStripMenuItem.Click += new System.EventHandler(this.keepOnTopToolStripMenuItem_Click);
            // 
            // resetWindowPositionToolStripMenuItem
            // 
            this.resetWindowPositionToolStripMenuItem.Name = "resetWindowPositionToolStripMenuItem";
            this.resetWindowPositionToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.resetWindowPositionToolStripMenuItem.Text = "Reset Window Position";
            this.resetWindowPositionToolStripMenuItem.Click += new System.EventHandler(this.resetPositionToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(241, 81);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.labelEthRe);
            this.Controls.Add(this.labelWiFiRe);
            this.Controls.Add(this.labelEthSe);
            this.Controls.Add(this.labelWiFiSe);
            this.Controls.Add(this.labelEth);
            this.Controls.Add(this.labelWiFi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWiFi;
        private System.Windows.Forms.Label labelEth;
        private System.Windows.Forms.Label labelWiFiSe;
        private System.Windows.Forms.Label labelEthSe;
        private System.Windows.Forms.Label labelWiFiRe;
        private System.Windows.Forms.Label labelEthRe;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem keepOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetWindowPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}

