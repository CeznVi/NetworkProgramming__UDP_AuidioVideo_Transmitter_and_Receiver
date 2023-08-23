namespace UDPVIdeoReciver
{
    partial class ReciverForm
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.button_audioControl = new System.Windows.Forms.Button();
            this.button_videoControl = new System.Windows.Forms.Button();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ipAdress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_TV = new System.Windows.Forms.PictureBox();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TV)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Info});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Info
            // 
            this.toolStripStatusLabel_Info.Name = "toolStripStatusLabel_Info";
            this.toolStripStatusLabel_Info.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel_Info.Text = "Ready";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel.Controls.Add(this.button_audioControl);
            this.panel.Controls.Add(this.button_videoControl);
            this.panel.Controls.Add(this.textBox_port);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.textBox_ipAdress);
            this.panel.Controls.Add(this.label1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 41);
            this.panel.TabIndex = 2;
            // 
            // button_audioControl
            // 
            this.button_audioControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_audioControl.Location = new System.Drawing.Point(659, 3);
            this.button_audioControl.Name = "button_audioControl";
            this.button_audioControl.Size = new System.Drawing.Size(138, 35);
            this.button_audioControl.TabIndex = 4;
            this.button_audioControl.Text = "Audio";
            this.button_audioControl.UseVisualStyleBackColor = true;
            // 
            // button_videoControl
            // 
            this.button_videoControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_videoControl.Location = new System.Drawing.Point(490, 3);
            this.button_videoControl.Name = "button_videoControl";
            this.button_videoControl.Size = new System.Drawing.Size(122, 35);
            this.button_videoControl.TabIndex = 3;
            this.button_videoControl.Text = "Video";
            this.button_videoControl.UseVisualStyleBackColor = true;
            this.button_videoControl.Click += new System.EventHandler(this.button_videoControl_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBox_port.Location = new System.Drawing.Point(383, 6);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(91, 29);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.Text = "54000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(315, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "PORT";
            // 
            // textBox_ipAdress
            // 
            this.textBox_ipAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBox_ipAdress.Location = new System.Drawing.Point(108, 6);
            this.textBox_ipAdress.Name = "textBox_ipAdress";
            this.textBox_ipAdress.Size = new System.Drawing.Size(201, 29);
            this.textBox_ipAdress.TabIndex = 1;
            this.textBox_ipAdress.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Adress";
            // 
            // pictureBox_TV
            // 
            this.pictureBox_TV.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pictureBox_TV.BackgroundImage = global::UDPVIdeoReciver.Resource1._375;
            this.pictureBox_TV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_TV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_TV.ErrorImage = null;
            this.pictureBox_TV.InitialImage = null;
            this.pictureBox_TV.Location = new System.Drawing.Point(0, 65);
            this.pictureBox_TV.Name = "pictureBox_TV";
            this.pictureBox_TV.Size = new System.Drawing.Size(800, 363);
            this.pictureBox_TV.TabIndex = 3;
            this.pictureBox_TV.TabStop = false;
            // 
            // ReciverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox_TV);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ReciverForm";
            this.Text = "TV Reciver";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Info;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ipAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_videoControl;
        private System.Windows.Forms.Button button_audioControl;
        private System.Windows.Forms.PictureBox pictureBox_TV;
    }
}

