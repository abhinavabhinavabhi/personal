namespace ChatClient
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
            this.send = new System.Windows.Forms.Button();
            this.grouptext = new System.Windows.Forms.RichTextBox();
            this.personaltext = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.usernamel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.login = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(333, 375);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(98, 35);
            this.send.TabIndex = 0;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Visible = false;
            this.send.Click += new System.EventHandler(this.button1_Click);
            // 
            // grouptext
            // 
            this.grouptext.AccessibleDescription = "";
            this.grouptext.BackColor = System.Drawing.SystemColors.ControlDark;
            this.grouptext.Cursor = System.Windows.Forms.Cursors.Default;
            this.grouptext.DetectUrls = false;
            this.grouptext.ForeColor = System.Drawing.SystemColors.InfoText;
            this.grouptext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grouptext.Location = new System.Drawing.Point(49, 52);
            this.grouptext.Name = "grouptext";
            this.grouptext.ReadOnly = true;
            this.grouptext.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.grouptext.ShowSelectionMargin = true;
            this.grouptext.Size = new System.Drawing.Size(681, 216);
            this.grouptext.TabIndex = 1;
            this.grouptext.Tag = "Group Chat";
            this.grouptext.Text = "\n\n";
            this.grouptext.Visible = false;
            this.grouptext.ZoomFactor = 1.5F;
            // 
            // personaltext
            // 
            this.personaltext.AcceptsTab = true;
            this.personaltext.Location = new System.Drawing.Point(49, 291);
            this.personaltext.Name = "personaltext";
            this.personaltext.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.personaltext.ShowSelectionMargin = true;
            this.personaltext.Size = new System.Drawing.Size(681, 57);
            this.personaltext.TabIndex = 2;
            this.personaltext.Tag = "type here";
            this.personaltext.Text = "";
            this.personaltext.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(180, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // usernamel
            // 
            this.usernamel.AutoSize = true;
            this.usernamel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamel.Location = new System.Drawing.Point(20, 34);
            this.usernamel.Name = "usernamel";
            this.usernamel.Size = new System.Drawing.Size(79, 16);
            this.usernamel.TabIndex = 4;
            this.usernamel.Text = "Username";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.usernamel);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(220, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 146);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(113, 85);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 5;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personaltext);
            this.Controls.Add(this.grouptext);
            this.Controls.Add(this.send);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.RichTextBox grouptext;
        private System.Windows.Forms.RichTextBox personaltext;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label usernamel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button login;
    }
}

