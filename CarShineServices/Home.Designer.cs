namespace CarShineServices
{
    partial class Home
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnEmailService = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mailStatusBox = new System.Windows.Forms.RichTextBox();
            this.btnEmailServiceStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "SMS Service";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnEmailService
            // 
            this.btnEmailService.Location = new System.Drawing.Point(30, 103);
            this.btnEmailService.Name = "btnEmailService";
            this.btnEmailService.Size = new System.Drawing.Size(132, 46);
            this.btnEmailService.TabIndex = 2;
            this.btnEmailService.Text = "Email Service Start";
            this.btnEmailService.UseVisualStyleBackColor = true;
            this.btnEmailService.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(509, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 46);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mailStatusBox
            // 
            this.mailStatusBox.Location = new System.Drawing.Point(168, 103);
            this.mailStatusBox.Name = "mailStatusBox";
            this.mailStatusBox.Size = new System.Drawing.Size(267, 61);
            this.mailStatusBox.TabIndex = 4;
            this.mailStatusBox.Text = "";
            // 
            // btnEmailServiceStop
            // 
            this.btnEmailServiceStop.Location = new System.Drawing.Point(441, 103);
            this.btnEmailServiceStop.Name = "btnEmailServiceStop";
            this.btnEmailServiceStop.Size = new System.Drawing.Size(132, 46);
            this.btnEmailServiceStop.TabIndex = 5;
            this.btnEmailServiceStop.Text = "Email Service ReStart";
            this.btnEmailServiceStop.UseVisualStyleBackColor = true;
            this.btnEmailServiceStop.Click += new System.EventHandler(this.btnEmailServiceStop_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 268);
            this.Controls.Add(this.btnEmailServiceStop);
            this.Controls.Add(this.mailStatusBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEmailService);
            this.Controls.Add(this.button1);
            this.Name = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEmailService;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox mailStatusBox;
        private System.Windows.Forms.Button btnEmailServiceStop;
    }
}

