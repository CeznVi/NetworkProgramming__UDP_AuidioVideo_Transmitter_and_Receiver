
namespace AudioVidou
{
    partial class TransmitterForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransmitterForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAudioStart = new System.Windows.Forms.Button();
            this.buttonVideoStart = new System.Windows.Forms.Button();
            this.comboBoxAudioDev = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVideoDev = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_TV = new System.Windows.Forms.PictureBox();
            this.groupBox_ServerConfig = new System.Windows.Forms.GroupBox();
            this.buttonAudioTransmittControl = new System.Windows.Forms.Button();
            this.buttonVideoTransmittControl = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_IpAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TV)).BeginInit();
            this.groupBox_ServerConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(878, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "Ready";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(878, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.buttonAudioStart);
            this.panel1.Controls.Add(this.buttonVideoStart);
            this.panel1.Controls.Add(this.comboBoxAudioDev);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxVideoDev);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 100);
            this.panel1.TabIndex = 2;
            // 
            // buttonAudioStart
            // 
            this.buttonAudioStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonAudioStart.Location = new System.Drawing.Point(722, 57);
            this.buttonAudioStart.Name = "buttonAudioStart";
            this.buttonAudioStart.Size = new System.Drawing.Size(127, 34);
            this.buttonAudioStart.TabIndex = 5;
            this.buttonAudioStart.Text = "Start";
            this.buttonAudioStart.UseVisualStyleBackColor = true;
            // 
            // buttonVideoStart
            // 
            this.buttonVideoStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonVideoStart.Location = new System.Drawing.Point(722, 8);
            this.buttonVideoStart.Name = "buttonVideoStart";
            this.buttonVideoStart.Size = new System.Drawing.Size(127, 32);
            this.buttonVideoStart.TabIndex = 4;
            this.buttonVideoStart.Text = "Start";
            this.buttonVideoStart.UseVisualStyleBackColor = true;
            this.buttonVideoStart.Click += new System.EventHandler(this.buttonVideoStart_Click);
            // 
            // comboBoxAudioDev
            // 
            this.comboBoxAudioDev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBoxAudioDev.FormattingEnabled = true;
            this.comboBoxAudioDev.ItemHeight = 24;
            this.comboBoxAudioDev.Location = new System.Drawing.Point(174, 59);
            this.comboBoxAudioDev.Name = "comboBoxAudioDev";
            this.comboBoxAudioDev.Size = new System.Drawing.Size(530, 32);
            this.comboBoxAudioDev.TabIndex = 3;
            this.comboBoxAudioDev.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioDev_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Audio Devices";
            // 
            // comboBoxVideoDev
            // 
            this.comboBoxVideoDev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideoDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBoxVideoDev.FormattingEnabled = true;
            this.comboBoxVideoDev.ItemHeight = 24;
            this.comboBoxVideoDev.Location = new System.Drawing.Point(174, 8);
            this.comboBoxVideoDev.Name = "comboBoxVideoDev";
            this.comboBoxVideoDev.Size = new System.Drawing.Size(530, 32);
            this.comboBoxVideoDev.TabIndex = 1;
            this.comboBoxVideoDev.SelectedIndexChanged += new System.EventHandler(this.comboBoxVideoDev_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Video Devices";
            // 
            // pictureBox_TV
            // 
            this.pictureBox_TV.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pictureBox_TV.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_TV.BackgroundImage")));
            this.pictureBox_TV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_TV.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox_TV.ErrorImage = null;
            this.pictureBox_TV.InitialImage = null;
            this.pictureBox_TV.Location = new System.Drawing.Point(0, 124);
            this.pictureBox_TV.Name = "pictureBox_TV";
            this.pictureBox_TV.Size = new System.Drawing.Size(596, 304);
            this.pictureBox_TV.TabIndex = 3;
            this.pictureBox_TV.TabStop = false;
            // 
            // groupBox_ServerConfig
            // 
            this.groupBox_ServerConfig.Controls.Add(this.buttonAudioTransmittControl);
            this.groupBox_ServerConfig.Controls.Add(this.buttonVideoTransmittControl);
            this.groupBox_ServerConfig.Controls.Add(this.textBox_Port);
            this.groupBox_ServerConfig.Controls.Add(this.label_Port);
            this.groupBox_ServerConfig.Controls.Add(this.textBox_IpAddress);
            this.groupBox_ServerConfig.Controls.Add(this.label3);
            this.groupBox_ServerConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox_ServerConfig.Location = new System.Drawing.Point(602, 124);
            this.groupBox_ServerConfig.Name = "groupBox_ServerConfig";
            this.groupBox_ServerConfig.Size = new System.Drawing.Size(276, 304);
            this.groupBox_ServerConfig.TabIndex = 4;
            this.groupBox_ServerConfig.TabStop = false;
            this.groupBox_ServerConfig.Text = "Server Config";
            // 
            // buttonAudioTransmittControl
            // 
            this.buttonAudioTransmittControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAudioTransmittControl.Location = new System.Drawing.Point(177, 150);
            this.buttonAudioTransmittControl.Name = "buttonAudioTransmittControl";
            this.buttonAudioTransmittControl.Size = new System.Drawing.Size(93, 65);
            this.buttonAudioTransmittControl.TabIndex = 5;
            this.buttonAudioTransmittControl.Text = "Transmitt Video";
            this.buttonAudioTransmittControl.UseVisualStyleBackColor = true;
            // 
            // buttonVideoTransmittControl
            // 
            this.buttonVideoTransmittControl.BackColor = System.Drawing.Color.Red;
            this.buttonVideoTransmittControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonVideoTransmittControl.Location = new System.Drawing.Point(7, 150);
            this.buttonVideoTransmittControl.Name = "buttonVideoTransmittControl";
            this.buttonVideoTransmittControl.Size = new System.Drawing.Size(91, 65);
            this.buttonVideoTransmittControl.TabIndex = 4;
            this.buttonVideoTransmittControl.Text = "Transmitt Video";
            this.buttonVideoTransmittControl.UseVisualStyleBackColor = false;
            this.buttonVideoTransmittControl.Click += new System.EventHandler(this.buttonVideoTransmittControl_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Port.Location = new System.Drawing.Point(6, 103);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(264, 29);
            this.textBox_Port.TabIndex = 3;
            this.textBox_Port.Text = "54000";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Port.Location = new System.Drawing.Point(6, 76);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(43, 24);
            this.label_Port.TabIndex = 2;
            this.label_Port.Text = "Port";
            // 
            // textBox_IpAddress
            // 
            this.textBox_IpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_IpAddress.Location = new System.Drawing.Point(7, 44);
            this.textBox_IpAddress.Name = "textBox_IpAddress";
            this.textBox_IpAddress.Size = new System.Drawing.Size(263, 29);
            this.textBox_IpAddress.TabIndex = 1;
            this.textBox_IpAddress.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ip Address";
            // 
            // TransmitterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 450);
            this.Controls.Add(this.groupBox_ServerConfig);
            this.Controls.Add(this.pictureBox_TV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TransmitterForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransmitterForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TV)).EndInit();
            this.groupBox_ServerConfig.ResumeLayout(false);
            this.groupBox_ServerConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAudioStart;
        private System.Windows.Forms.Button buttonVideoStart;
        private System.Windows.Forms.ComboBox comboBoxAudioDev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVideoDev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_TV;
        private System.Windows.Forms.GroupBox groupBox_ServerConfig;
        private System.Windows.Forms.Button buttonAudioTransmittControl;
        private System.Windows.Forms.Button buttonVideoTransmittControl;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox_IpAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

