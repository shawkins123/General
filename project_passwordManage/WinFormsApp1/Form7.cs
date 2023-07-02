using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form7 : Form
    {
        string codeVerify; //code verify is what user enters
        string account;

        public Form7(string accountName)
        {
            InitializeComponent();
            account = accountName; //works??
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emailVar = "";
            emailVar = textBox1.Text;

            if (!string.IsNullOrEmpty(emailVar))
            {
                //account is verified
                //grab email associated with account
                //send email with code
            }
        }

        private int getKey()
            {
            int key = 123; //this is what system generates
            return key;
            }


        private void button3_Click(object sender, EventArgs e)
        {
            int key = getKey();
            int code = verifyEntryCode(codeVerify);

            if(code == key)
            {
                //send account details via email
            }
            else
            {
                Form4 form4 = new Form4("Code entered cannot be verified");
                form4.ShowDialog();
            }
        }

        private int verifyEntryCode(string codeVerify)
        {
            int code = 0;
            if (!string.IsNullOrEmpty(codeVerify))
            { 
                bool result = int.TryParse(codeVerify, out code);
                if (result == false)
                {
                    Form4 form4 = new Form4("Code is non-numeric; returning 0");
                    form4.ShowDialog();               
                }
            }
            return code;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            codeVerify = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
