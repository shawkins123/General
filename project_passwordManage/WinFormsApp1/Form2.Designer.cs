namespace WinFormsApp1
{
    partial class Form2
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.account_textBox1 = new System.Windows.Forms.TextBox();
            this.pswd_textBox2 = new System.Windows.Forms.TextBox();
            this.lbl_accountName = new System.Windows.Forms.Label();
            this.lbl_psswrd = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(242, 56);
            this.button2.TabIndex = 1;
            this.button2.Text = "Create New Account";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(560, 320);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 54);
            this.button3.TabIndex = 2;
            this.button3.Text = "Forget Login?";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // account_textBox1
            // 
            this.account_textBox1.Location = new System.Drawing.Point(54, 136);
            this.account_textBox1.Name = "account_textBox1";
            this.account_textBox1.Size = new System.Drawing.Size(337, 23);
            this.account_textBox1.TabIndex = 3;
            this.account_textBox1.TextChanged += new System.EventHandler(this.account_textBox1_TextChanged);
            // 
            // pswd_textBox2
            // 
            this.pswd_textBox2.Location = new System.Drawing.Point(54, 179);
            this.pswd_textBox2.Name = "pswd_textBox2";
            this.pswd_textBox2.Size = new System.Drawing.Size(337, 23);
            this.pswd_textBox2.TabIndex = 4;
            // 
            // lbl_accountName
            // 
            this.lbl_accountName.AutoSize = true;
            this.lbl_accountName.Location = new System.Drawing.Point(412, 136);
            this.lbl_accountName.Name = "lbl_accountName";
            this.lbl_accountName.Size = new System.Drawing.Size(87, 15);
            this.lbl_accountName.TabIndex = 5;
            this.lbl_accountName.Text = "Account Name";
            this.lbl_accountName.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_psswrd
            // 
            this.lbl_psswrd.AutoSize = true;
            this.lbl_psswrd.Location = new System.Drawing.Point(412, 179);
            this.lbl_psswrd.Name = "lbl_psswrd";
            this.lbl_psswrd.Size = new System.Drawing.Size(57, 15);
            this.lbl_psswrd.TabIndex = 6;
            this.lbl_psswrd.Text = "Password";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(646, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(587, 134);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(128, 94);
            this.listBox1.TabIndex = 8;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lbl_psswrd);
            this.Controls.Add(this.lbl_accountName);
            this.Controls.Add(this.pswd_textBox2);
            this.Controls.Add(this.account_textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox account_textBox1;
        private TextBox pswd_textBox2;
        private Label lbl_accountName;
        private Label lbl_psswrd;
        private Button button4;
        private ListBox listBox1;
    }
}