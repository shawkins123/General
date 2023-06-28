using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//initial form -> 3 options buttons, 1 on-screen button
/*
 * Screen has one button only - click to continue
 * Options for user control are:
 * start application: application will announce it has loaded tools
 * click to continue: application will continue to form 2
 * exit: application will close 
 */

namespace NavigationApplication
{
    public partial class Form1 : Form
    {
        private bool areToolsLoaded;

        private bool canAccessExternals;

        private bool isErrorHandled;

        public bool toolsLoaded
        {
            get { return areToolsLoaded; }
            set { areToolsLoaded = value; }
        }

        public bool accessExternals
        {
            get { return canAccessExternals; }
            set { canAccessExternals = value; }
        }

        public bool errorHandled
        {
            get { return isErrorHandled; }
            set { isErrorHandled = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            areToolsLoaded = loadToolSet();
            canAccessExternals = accessExternalFeatures();        
        }

        private bool loadToolSet()
        {
            //enter code here for additional tool suites to be used
            return true;
        }

        private bool accessExternalFeatures()
        {
            //enter code here to ensure application has access to GPS, etc.
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //open application button
            openApplication();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //press to continue button (options)
            openNextForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //press to continue button (screen)
            openNextForm();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //exit button          
            this.Close();
        }

        private void openNextForm()
        {
            try
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void openApplication()
        {
            if (areToolsLoaded == true && canAccessExternals == true)
            {
                MessageBox.Show("Welcome to the Navigation App," +
                    "\n" + "Tap the screen to begin", "The Application says:");
            }
            else
            {
                int errorCode = 1;
                bool resultBool = errorHandler(errorCode);
                if (resultBool == false)
                {
                    MessageBox.Show("Error, please restart app");
                    this.Close();
                }
                errorRestart();
            }

        }

        private bool errorHandler(int errorNumber)
        {
            //enter code here to handle different kinds of errors
            isErrorHandled = false;
            return isErrorHandled;
        }

        private void errorRestart()
        {
            //enter code here to determine cause, send data for future bug patches, and force restart
            this.Close();
        }

        private void panel1_Paint()
        {
            //not used - but do not delete!!!!!!!!
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //not used - but do not delete!!!!!!!!
        }

    }
}
