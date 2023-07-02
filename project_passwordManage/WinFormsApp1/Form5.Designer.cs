namespace WinFormsApp1
{
    partial class Form5
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
            this.accountName_box = new System.Windows.Forms.TextBox();
            this.password_Box = new System.Windows.Forms.TextBox();
            this.confirmPass_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.accountName = new System.Windows.Forms.TextBox();
            this.passwordConfirm = new System.Windows.Forms.TextBox();
            this.passwordEnter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // accountName_box
            // 
            this.accountName_box.Location = new System.Drawing.Point(103, 84);
            this.accountName_box.Name = "accountName_box";
            this.accountName_box.Size = new System.Drawing.Size(347, 23);
            this.accountName_box.TabIndex = 0;
            // 
            // password_Box
            // 
            this.password_Box.Location = new System.Drawing.Point(104, 144);
            this.password_Box.Name = "password_Box";
            this.password_Box.Size = new System.Drawing.Size(336, 23);
            this.password_Box.TabIndex = 1;
            // 
            // confirmPass_box
            // 
            this.confirmPass_box.Location = new System.Drawing.Point(102, 196);
            this.confirmPass_box.Name = "confirmPass_box";
            this.confirmPass_box.Size = new System.Drawing.Size(332, 23);
            this.confirmPass_box.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "account name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "password";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(64, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 37);
            this.button3.TabIndex = 0;
            this.button3.Text = "new account";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(271, 253);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // accountName
            // 
            this.accountName.Location = new System.Drawing.Point(63, 63);
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(290, 23);
            this.accountName.TabIndex = 2;
            this.accountName.TextChanged += new System.EventHandler(this.accountName_TextChanged);
            // 
            // passwordConfirm
            // 
            this.passwordConfirm.Location = new System.Drawing.Point(64, 150);
            this.passwordConfirm.Name = "passwordConfirm";
            this.passwordConfirm.Size = new System.Drawing.Size(290, 23);
            this.passwordConfirm.TabIndex = 3;
            // 
            // passwordEnter
            // 
            this.passwordEnter.Location = new System.Drawing.Point(64, 108);
            this.passwordEnter.Name = "passwordEnter";
            this.passwordEnter.Size = new System.Drawing.Size(290, 23);
            this.passwordEnter.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "account name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "confirm password";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 197);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 23);
            this.textBox1.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "email";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(510, 319);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 10;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Form5
            // 
            this.ClientSize = new System.Drawing.Size(753, 434);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passwordEnter);
            this.Controls.Add(this.passwordConfirm);
            this.Controls.Add(this.accountName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Name = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox accountName_box;
        private TextBox password_Box;
        private TextBox confirmPass_box;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox accountName;
        private TextBox passwordConfirm;
        private TextBox passwordEnter;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private Label label7;
        private TextBox textBox2;
    }
}