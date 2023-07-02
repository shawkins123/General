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
    public partial class Form3 : Form
    {




        //    string[] dataBase1 = { "x1", "x2", "x3" };
        //    string[] dataBase2 = { "y1", "y2", "y3" };
        //    string[] dataBase3 = {"z1", "z2", "z3" };


        string accountName = "";
        string programName = "";
        string passwordVar = "";

        public Form3()
        {
            InitializeComponent();

            /*
            for (int i = 0; i < dataBase1.Length; i++)
            {
                listBox1.Items.Add(dataBase1[i]);
            }

            for (int i = 0; i < dataBase2.Length; i++)
            {
                listBox2.Items.Add(dataBase2[i]);
            }

            for (int i = 0; i < dataBase3.Length; i++)
            {
                listBox3.Items.Add(dataBase3[i]);
            }

            programName = textBox1.Text;
            accountName = textBox2.Text;
            passwordVar = textBox3.Text;
            */
        }

        private string[] DatabasePull()
        {
        String dataLine;
        List<string> listDatabase = new List<string>();


                StreamReader sr = new StreamReader("C:\\database.txt");
                dataLine = sr.ReadLine();
                //Read the first line of text

                //Continue to read until you reach end of file
                while (dataLine != null)
                {
                    //write the line to console window
                    listDatabase.Add(dataLine);
                    //Read the next line
                    dataLine = sr.ReadLine();
                }
                //close the file
                String[] dataLinesDatabase = listDatabase.ToArray();
                sr.Close();
                return dataLinesDatabase;

                
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //adds entries


            if(programName != "" & accountName != "" & passwordVar != "")
            { 
            listBox1.Items.Add(programName);
            listBox2.Items.Add(accountName);
            listBox3.Items.Add(passwordVar);
                //create streamwriter, write over list on text file

                string delimiter = "$$";
                string listBox1wDel = string.Join(delimiter, listBox1.Items.ToString());
                string listBox2wDel = string.Join(delimiter, listBox2.Items.ToString());
                string listBox3wDel = string.Join(delimiter, listBox3.Items.ToString());
                string[] allListBoxes = { listBox1wDel, listBox2wDel, listBox3wDel };
                

                using (StreamWriter sw = new StreamWriter("C:\\database.txt"))
                {
                    foreach (string line in allListBoxes)
                        sw.WriteLine(line);
                }

                /* another way of adding delimiter
                 string ns = "";
foreach(string s in sa)
{
if (ns.Length != 0)
{
    ns += " * ";
}

ns += s;
}


                */


                


            }
            else
            {
            //  Form4 form4 = new Form4();
           //     form4.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            programName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            accountName = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            passwordVar = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //deletes entries
            string programDelete, accountDelete, passwordDelete;
            int totalCount = 5;
            string programList = "", accountList = "", passwordList = "";

            if (programName == "" || accountName == "" || passwordVar == "")
            {
             // Form4 form4 = new Form4();
             //   form4.ShowDialog();
            }
            else
            {
                listBox1.Items.Remove(programName);
                listBox2.Items.Remove(accountName);
                listBox3.Items.Remove(passwordVar);

            }
        }

            private void button4_Click(object sender, EventArgs e)
        {
            //finds entries
            string programNameSearch = "";
            programNameSearch = textBox1.Text;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == programNameSearch)
                {
                    textBox2.Text = listBox2.Items[i].ToString();
                    textBox3.Text = listBox3.Items[i].ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //modifies entries
            string accountNameChange, passwordVarChange;
            string programNameCompare;

            programNameCompare = textBox1.Text;

            accountNameChange = textBox2.Text;
            passwordVarChange = textBox3.Text;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == programNameCompare)
                {
                    accountName = listBox2.Items[i].ToString();
                    passwordVar = listBox3.Items[i].ToString();

                    if(accountName != accountNameChange)
                    {
                        listBox2.Items[i] = accountNameChange;
                    }

                    if(passwordVar != passwordVarChange)
                    {
                        listBox3.Items[i] = passwordVarChange;
                    }
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //clears entries
            string clearBox = "";
            textBox1.Text = clearBox;
            textBox2.Text = clearBox;
            textBox3.Text = clearBox;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }

    }
