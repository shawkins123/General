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
    public partial class Form8 : Form
    {
        string accountName = "";
        string programName = "";
        string passwordVar = "";
        int cipherKey = 1;

        public Form8()
        {
            InitializeComponent();

             DatabasePull(); 
        }
        private void DatabasePull()
        {
            string dataLine;
            // List<string> listDatabase = new List<string>();
            // String[] dataLinesDatabase;
            string rawDatabasePull;
            string[] rawDatabaseSplit;

            StreamReader sr = new StreamReader("C:\\database.txt");
            dataLine = sr.ReadLine();
            //Read the first line of text
           
            //Continue to read until you reach end of file
            while (dataLine != null)
            {
                //read dataline
                rawDatabasePull = dataLine;
                rawDatabasePull = decryptCipher(dataLine.Trim());
                //split dataline
                rawDatabaseSplit = rawDatabasePull.Split("$$");
                //add datalines to listboxes

            //   string encryptedString = encryptCipher(rawDatabaseSplit[0]);
            //   string decryptedString = decryptCipher(rawDatabaseSplit[0]);
                //    listBox1.Items.Add(encryptedString);
           
                //   listBox1.Items.Add(decryptedString);

                 listBox1.Items.Add(rawDatabaseSplit[0]);
                 listBox2.Items.Add(rawDatabaseSplit[1]); 
                       listBox3.Items.Add(rawDatabaseSplit[2]);

                //Read the next line
                dataLine = sr.ReadLine();
            }
            //close the file
            
            sr.Close();

            
            if (listBox1.Items[0] == null)
            {
                Form4 form4 = new Form4("Data failed to load properly");
                form4.ShowDialog();
            }
            

        }

        private string encryptCipher(string dataLine)
        {
            //get dataLine
            //break down dataline into character array
            //determine datatype compare characters in array and add cipher
            //reassemble dataline
            //return it
            string encryptedDataLine;
            var builder = new StringBuilder();
            char[] alphabetLower = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] alphabetUpper = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] cipher = dataLine.ToCharArray();
            for(int i = 0; i < cipher.Length; i++)
            {
                
                
                if (char.IsLetter(cipher[i]))
                {
                    if(char.IsLower(cipher[i]))
                    {
                        var letter = cipher[i];
                        int index = Array.IndexOf(alphabetLower, letter);
                        int newIndex = (cipherKey + index) % 26;
                        char newLetter = alphabetLower[newIndex];
                        cipher[i] = newLetter;
                    //    listBox1.Items.Add(cipher[i]);
                    }
                    if (char.IsUpper(cipher[i]))
                    {
                        var letter = cipher[i];
                        int index = Array.IndexOf(alphabetUpper, letter);
                        int newIndex = (cipherKey + index) % 26;
                        char newLetter = alphabetUpper[newIndex];
                        cipher[i] = newLetter;
                    //    listBox1.Items.Add(cipher[i]);
                    }
                }
                if (char.IsNumber(cipher[i]))
                {
                    int intVal = (int)Char.GetNumericValue(cipher[i]);
                    //look into problem with converting int value to char??
                    
                    switch (intVal)
                    {
                        case 0:
                            cipher[i] = '1';
                            break;
                        case 1:
                            cipher[i] = '2';
                            break;
                        case 2:
                            cipher[i] = '3';
                            break;
                        case 3:
                            cipher[i] = '4';
                            break;
                        case 4:
                            cipher[i] = '5';
                            break;
                        case 5:
                            cipher[i] = '6';
                            break;
                        case 6:
                            cipher[i] = '7';
                            break;
                        case 7:
                            cipher[i] = '8';
                            break;
                        case 8:
                            cipher[i] = '9';
                            break;
                       
                        case 9:
                            cipher[i] = '@'; //make sure to forbid use of '@' in creating of programs                            
                            break;
                    }
 
                }

                builder.Append(cipher[i]);
            }
             encryptedDataLine = builder.ToString();
          //  listBox1.Items.Add(encryptedDataLine);
            return encryptedDataLine;
        }

        private string decryptCipher(String dataLine)
        {
            //get dataLine
            //break down dataline into character array
            //determine datatype compare characters in array and delete cipher
            //reassemble dataline
            //return it
            string decryptedDataLine;
            var builder = new StringBuilder();
            char[] alphabetLower = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] alphabetUpper = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] cipher = dataLine.ToCharArray();
            for (int i = 0; i < cipher.Length; i++)
            {
                if (char.IsLetter(cipher[i]))
                {
                    if (char.IsLower(cipher[i]))
                    {
                        var letter = cipher[i];
                        int index = Array.IndexOf(alphabetLower, letter);
                        int newIndex = (index - cipherKey) % 26;
                        char newLetter = alphabetLower[newIndex];
                        cipher[i] = newLetter;
                    }                 
                    if (char.IsUpper(cipher[i]))
                    {
                        var letter = cipher[i];
                        int index = Array.IndexOf(alphabetUpper, letter);
                        int newIndex = (index - cipherKey) % 26;
                        char newLetter = alphabetUpper[newIndex];
                        cipher[i] = newLetter;
                    }
                    
                }
                if (char.IsNumber(cipher[i]))
                {
                    int intVal = (int)Char.GetNumericValue(cipher[i]);
                    //look into problem with converting int value to char??

                    switch (intVal)
                    {
                        case 1:
                            cipher[i] = '0';
                            break;
                        case 2:
                            cipher[i] = '1';
                            break;
                        case 3:
                            cipher[i] = '2';
                            break;
                        case 4:
                            cipher[i] = '3';
                            break;
                        case 5:
                            cipher[i] = '4';
                            break;
                        case 6:
                            cipher[i] = '5';
                            break;
                        case 7:
                            cipher[i] = '6';
                            break;
                        case 8:
                            cipher[i] = '7';
                            break;
                        case 9:
                            cipher[i] = '8';
                            break;

                    }
                }
                if (cipher[i].Equals('@'))
                {
                     cipher[i] = '9';
                }
               builder.Append(cipher[i]);
            }
            decryptedDataLine = builder.ToString();
        //    listBox2.Items.Add(decryptedDataLine);


            return decryptedDataLine;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //adds entries
            if (programName != "" & accountName != "" & passwordVar != "")
            {
                listBox1.Items.Add(programName);
                listBox2.Items.Add(accountName);
                listBox3.Items.Add(passwordVar);
            }
        }

        private void DataBaseWrite()
        {
            string delimiter = "$$";
            string wipe = "";
            string listBox1wDel = string.Join(delimiter, listBox1.Items.ToString());
            string listBox2wDel = string.Join(delimiter, listBox2.Items.ToString());
            string listBox3wDel = string.Join(delimiter, listBox3.Items.ToString());
            string[] allListBoxes = { listBox1wDel, listBox2wDel, listBox3wDel };

            StreamWriter sw = new StreamWriter("C:\\database.txt");

            sw.Write(wipe);
     
            foreach (string line in allListBoxes)
            {               
                    sw.WriteLine(encryptCipher(line));
            }
            sw.Close();             
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

            if (programName == "" || accountName == "" || passwordVar == "")
            {
                Form4 form4 = new Form4("Fill out form completely");
                form4.ShowDialog();
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
            string programNameSearch = textBox1.Text;

            if (!string.IsNullOrEmpty(programNameSearch))
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (listBox1.Items[i].ToString() == programNameSearch)
                    {
                        textBox2.Text = listBox2.Items[i].ToString();
                        textBox3.Text = listBox3.Items[i].ToString();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //modifies entries
            string accountNameChange, passwordVarChange, programNameCompare;

            programNameCompare = textBox1.Text;
            accountNameChange = textBox2.Text;
            passwordVarChange = textBox3.Text;

            if(!string.IsNullOrEmpty(accountNameChange) && !string.IsNullOrEmpty(passwordVarChange) && !string.IsNullOrEmpty(programNameCompare))
            { 
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (listBox1.Items[i].ToString() == programNameCompare)
                    {
                        accountName = listBox2.Items[i].ToString();
                        passwordVar = listBox3.Items[i].ToString();

                        if (accountName != accountNameChange)
                        {
                            listBox2.Items[i] = accountNameChange;
                        }

                        if (passwordVar != passwordVarChange)
                        {
                            listBox3.Items[i] = passwordVarChange;
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //clears entries
            string clearBox = "";
            textBox1.Text = clearBox;
            textBox2.Text = clearBox;
            textBox3.Text = clearBox;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //saves changes to file 
            try 
            { 
            DataBaseWrite();
            }
            catch
            {
                Form4 form4 = new Form4("Failed to save to database.");
                form4.ShowDialog();
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
         * 
         public Program(string programName, accountName, passwordVar)
        {

        }
         use via Program oneProgram = new Program(programX, accountX, passwordX);
         */
    }
}
