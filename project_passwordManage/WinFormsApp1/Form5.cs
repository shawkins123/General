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
    public partial class Form5 : Form
    {
        string accountNameX = ""; 

        public Form5()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        private bool accountCompare()
        {
            string dataLine;
            string accountCompare;
            int counterCompareResult = 0;
            bool accountCompareResult = false;
            string[] accountComponents;
            string accountVar = accountName.Text;

            // textBox2.Text = accountName.Text;
            
            StreamReader sr = new StreamReader("C:\\accounts.txt");

            dataLine = sr.ReadLine();

            if (string.IsNullOrEmpty(dataLine))
            {
                accountCompareResult = false;
            }
            else
            {
                //Continue to read until you reach end of file
                while (dataLine != null)
                {
                    accountComponents = dataLine.Split("$$");
                    accountCompare = accountComponents[0];

                    
                    if( (accountCompare.ToLower()).Equals(accountVar.ToLower()))
                    {
                        counterCompareResult += 1;
                    }
                    dataLine = sr.ReadLine();
                }
                sr.Close();
                
                if( counterCompareResult >= 1)
                {
                    accountCompareResult = true;
                }
                else
                {
                    accountCompareResult = false;
                }              
            }
         
               textBox2.Text = accountCompareResult.ToString();
            
            return accountCompareResult;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string account = accountName.Text;
            string password = passwordEnter.Text;
            string passwordCon = passwordConfirm.Text;
            string emailVar = textBox1.Text;
            // make sure there are no other matching accounts

            bool accountCompareResult = accountCompare();

            if (accountCompareResult == true)
            {
                Form4 form4 = new Form4("Account already exists!");
                form4.Show();
            }
            else
            {
              
                bool passwordMatch = string.Equals(password, passwordCon);
                if (passwordMatch == true)
                {
                    string[] accountInfoPass = { account, password }; // add email later

                    accountAdd(accountInfoPass);

                    Form4 form4 = new Form4("Account successfully created!");
                    form4.ShowDialog();

                    Form8 form8 = new Form8();

                    this.Hide();

                    form8.ShowDialog();
                }
                else
                {
                    Form4 form4 = new Form4("Passwords did not match.");
                    form4.Show();

                }
            }
        }

        private void accountAdd(string[] accountInfo)
        {
            
            string account, password;
         //   string email;
            string delimiter = "$$";
            string accountInfoCombined;

            StreamWriter sw = new StreamWriter("C://accounts.txt", append: true);

            account = accountInfo[0];
            password = accountInfo[1];
          //  email = accountInfo[2]; //not used in current build
            accountInfoCombined = account + delimiter + password + delimiter;

            sw.WriteLine(accountInfoCombined);

            sw.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void accountName_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
