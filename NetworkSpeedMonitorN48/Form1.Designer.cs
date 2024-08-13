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
            this.labelWiFi = new System.Windows.Forms.Label();
            this.labelEth = new System.Windows.Forms.Label();
            this.labelWiFiSe = new System.Windows.Forms.Label();
            this.labelEthSe = new System.Windows.Forms.Label();
            this.labelWiFiRe = new System.Windows.Forms.Label();
            this.labelEthRe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelWiFi
            // 
            this.labelWiFi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWiFi.Location = new System.Drawing.Point(0, 0);
            this.labelWiFi.Name = "labelWiFi";
            this.labelWiFi.Size = new System.Drawing.Size(50, 20);
            this.labelWiFi.TabIndex = 0;
            this.labelWiFi.Text = "WiFi";
            this.labelWiFi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEth
            // 
            this.labelEth.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEth.Location = new System.Drawing.Point(0, 20);
            this.labelEth.Name = "labelEth";
            this.labelEth.Size = new System.Drawing.Size(50, 20);
            this.labelEth.TabIndex = 1;
            this.labelEth.Text = "Eth";
            this.labelEth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelWiFiSe
            // 
            this.labelWiFiSe.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWiFiSe.Location = new System.Drawing.Point(50, 0);
            this.labelWiFiSe.Name = "labelWiFiSe";
            this.labelWiFiSe.Size = new System.Drawing.Size(100, 20);
            this.labelWiFiSe.TabIndex = 2;
            this.labelWiFiSe.Text = "999.9 KB/s";
            this.labelWiFiSe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEthSe
            // 
            this.labelEthSe.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEthSe.Location = new System.Drawing.Point(50, 20);
            this.labelEthSe.Name = "labelEthSe";
            this.labelEthSe.Size = new System.Drawing.Size(100, 20);
            this.labelEthSe.TabIndex = 3;
            this.labelEthSe.Text = "999.9 KB/s";
            this.labelEthSe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWiFiRe
            // 
            this.labelWiFiRe.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWiFiRe.Location = new System.Drawing.Point(150, 0);
            this.labelWiFiRe.Name = "labelWiFiRe";
            this.labelWiFiRe.Size = new System.Drawing.Size(100, 20);
            this.labelWiFiRe.TabIndex = 4;
            this.labelWiFiRe.Text = "999.9 KB/s";
            this.labelWiFiRe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEthRe
            // 
            this.labelEthRe.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEthRe.Location = new System.Drawing.Point(150, 20);
            this.labelEthRe.Name = "labelEthRe";
            this.labelEthRe.Size = new System.Drawing.Size(100, 20);
            this.labelEthRe.TabIndex = 5;
            this.labelEthRe.Text = "999.9 KB/s";
            this.labelEthRe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(333, 83);
            this.Controls.Add(this.labelEthRe);
            this.Controls.Add(this.labelWiFiRe);
            this.Controls.Add(this.labelEthSe);
            this.Controls.Add(this.labelWiFiSe);
            this.Controls.Add(this.labelEth);
            this.Controls.Add(this.labelWiFi);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWiFi;
        private System.Windows.Forms.Label labelEth;
        private System.Windows.Forms.Label labelWiFiSe;
        private System.Windows.Forms.Label labelEthSe;
        private System.Windows.Forms.Label labelWiFiRe;
        private System.Windows.Forms.Label labelEthRe;
    }
}

