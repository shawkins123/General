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
    public partial class Form2 : Form
    {
        string accountName = "";




        public Form2()
        {
            InitializeComponent();

            //load here
            string[] strings = accountList();
            


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private string[] accountList()
        {
            string account;
            List<string> listAccountsDatabase = new List<string>();

            //load database
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("C:\\accounts.txt");
            //Read the first line of text
            try
            {
                account = sr.ReadLine();
                //Continue to read until you reach end of file
                while (account != null)
                {
                    //write the line to console window
                    listAccountsDatabase.Add(account);
                    //////////////////// hide below when necessary
                   // listBox1.Items.Add(account);
                    //Read the next line
                    account = sr.ReadLine();
                }
                //close the file
                string[] accountsDatabase = listAccountsDatabase.ToArray();

                sr.Close();
                // Console.ReadLine();
                //compare database to entry 
                return accountsDatabase;
            }
            catch
            {
                string errorMessage = "?no accounts?";
                Form4 form4 = new Form4(errorMessage);
                string[] strings = { "0" };
                return strings; //not exactly a great solution
            }
            
        }

        private int verifyAccount()
        {
            string[] accountsDatabase = accountList();
            string password = pswd_textBox2.Text;
            int result = 0;

            listBox1.Items.Add(accountsDatabase[0]);


            if (!string.IsNullOrEmpty(accountName)) // && !string.IsNullOrEmpty(password))
            {
                for (int i = 0; i < accountsDatabase.Length; i++)
                {
                    // need to verify account exists 2x -- possible to make this a method?
                    string accountNameFromDatabase;
                    string passwordFromDatabase;
                    string rawDatabasePull;
                    string[] rawDatabaseSplit;

                    rawDatabasePull = accountsDatabase[i].ToString();
                    rawDatabaseSplit = rawDatabasePull.Split("$$");
                    //below verifies
                    //below will have 2 items, account name and password
                    accountNameFromDatabase = rawDatabaseSplit[0].ToString();
                    passwordFromDatabase = rawDatabaseSplit[1].ToString();

                  //  listBox1.Items.Add(accountNameFromDatabase);
                  //  listBox1.Items.Add(passwordFromDatabase);

                    bool resultAccount = accountName.Equals(accountNameFromDatabase);
                    bool resultPassword = password.Equals(passwordFromDatabase);

                    if (resultAccount == true && resultPassword == true)
                    {
                        result += 2;
                    }
                    else if (resultAccount == true && resultPassword == false)
                    {
                        result += 1;
                    }
                    else
                    {
                        result += 0;
                    }
                }
            }
            return result;

        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            int result = verifyAccount();

            switch(result)
            {
                case 0:
                    {
                        string errorMessage = "No account found";
                        Form4 form4 = new Form4(errorMessage);

                        form4.Show();

                        break;
                    }
                case 1:
                    {
                        string errorMessage = "Passwords do not match.";
                        Form4 form4 = new Form4(errorMessage);

                        form4.Show();
                        break;
                    }
                case 2:
                    {
                        Form8 form8 = new Form8();

                        // this.Hide();

                        form8.ShowDialog();
                        break;
                    }

            }

                  
                
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void account_textBox1_TextChanged(object sender, EventArgs e)
        {
            accountName = account_textBox1.Text; //ensure this actually works
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if(!string.IsNullOrEmpty(accountName))
            { 
               int result = verifyAccount();
                listBox1.Items.Add(result);
                if(result == 1)
                {
            //pass account and email to form 7
            Form7 form7 = new Form7(accountName);
            form7.ShowDialog();
                    //  this.Hide();
                }
            }
            else
            {
                Form4 form4 = new Form4("Enter name of account");
                form4.ShowDialog();
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
