namespace ChatServer
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
            this.openConnectionBtn = new System.Windows.Forms.Button();
            this.closeConnectionBtn = new System.Windows.Forms.Button();
            this.usersOnline = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openConnectionBtn
            // 
            this.openConnectionBtn.Location = new System.Drawing.Point(34, 45);
            this.openConnectionBtn.Name = "openConnectionBtn";
            this.openConnectionBtn.Size = new System.Drawing.Size(130, 57);
            this.openConnectionBtn.TabIndex = 0;
            this.openConnectionBtn.Text = "Mở kết nối";
            this.openConnectionBtn.UseVisualStyleBackColor = true;
            this.openConnectionBtn.Click += new System.EventHandler(this.openConnection_Click);
            // 
            // closeConnectionBtn
            // 
            this.closeConnectionBtn.Location = new System.Drawing.Point(34, 120);
            this.closeConnectionBtn.Name = "closeConnectionBtn";
            this.closeConnectionBtn.Size = new System.Drawing.Size(130, 57);
            this.closeConnectionBtn.TabIndex = 1;
            this.closeConnectionBtn.Text = "Đóng kết nối";
            this.closeConnectionBtn.UseVisualStyleBackColor = true;
            this.closeConnectionBtn.Click += new System.EventHandler(this.closeConnection_Click);
            // 
            // usersOnline
            // 
            this.usersOnline.Location = new System.Drawing.Point(183, 45);
            this.usersOnline.Name = "usersOnline";
            this.usersOnline.Size = new System.Drawing.Size(154, 132);
            this.usersOnline.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Đang Online";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 189);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersOnline);
            this.Controls.Add(this.closeConnectionBtn);
            this.Controls.Add(this.openConnectionBtn);
            this.Name = "MainForm";
            this.Text = "Chat Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openConnectionBtn;
        private System.Windows.Forms.Button closeConnectionBtn;
        private System.Windows.Forms.ListBox usersOnline;
        private System.Windows.Forms.Label label1;
    }
}

