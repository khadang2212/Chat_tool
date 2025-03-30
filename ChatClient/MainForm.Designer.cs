namespace ChatClient
{
    partial class MainForm
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
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.UserNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.messageTxtBox = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.messageChatBox = new System.Windows.Forms.RichTextBox();
            this.userOnline = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(177, 12);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 0;
            this.ConnectBtn.Text = "Kết nối";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // UserNameTxtBox
            // 
            this.UserNameTxtBox.Location = new System.Drawing.Point(65, 13);
            this.UserNameTxtBox.Name = "UserNameTxtBox";
            this.UserNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.UserNameTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ngắt Kết nối";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // messageTxtBox
            // 
            this.messageTxtBox.Location = new System.Drawing.Point(7, 190);
            this.messageTxtBox.Name = "messageTxtBox";
            this.messageTxtBox.Size = new System.Drawing.Size(294, 20);
            this.messageTxtBox.TabIndex = 4;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(307, 188);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(56, 23);
            this.SendBtn.TabIndex = 5;
            this.SendBtn.Text = "Gửi";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // messageChatBox
            // 
            this.messageChatBox.Location = new System.Drawing.Point(7, 41);
            this.messageChatBox.Name = "messageChatBox";
            this.messageChatBox.Size = new System.Drawing.Size(356, 143);
            this.messageChatBox.TabIndex = 6;
            this.messageChatBox.Text = "";
            // 
            // userOnline
            // 
            this.userOnline.FormattingEnabled = true;
            this.userOnline.Location = new System.Drawing.Point(369, 43);
            this.userOnline.Name = "userOnline";
            this.userOnline.Size = new System.Drawing.Size(165, 108);
            this.userOnline.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 248);
            this.Controls.Add(this.userOnline);
            this.Controls.Add(this.messageChatBox);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.messageTxtBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameTxtBox);
            this.Controls.Add(this.ConnectBtn);
            this.Name = "MainForm";
            this.Text = "ChatClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox UserNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox messageTxtBox;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.RichTextBox messageChatBox;
        private System.Windows.Forms.ListBox userOnline;
    }
}

