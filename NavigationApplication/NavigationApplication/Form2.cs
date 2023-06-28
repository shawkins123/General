using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//application form -> 9 options buttons, 2 textboxes, 1 on-screen button, 1 radio button
/*
 * Screen has one button only - emergency call
 * Screen has a radio button - meant to simulate if/when the application has connection to internet
 * 
 * Options for user control are:
 * set file path: users must link the file path that contains the images
 * confirm destination: sets destination
 * enter destination: destination is hard-coded
 * get directions: gives directions to user
 * progress: advances the user in the app
 * repeat directions: repeats
 * cancel directions: cancels 
 * emergency call: places an emergency call
 * exit: exits application
 * 
 * there are two textboxes
 * textbox 1: handles user input for setting a file path
 * textbox 2: shows progress meter, read-only
 */

namespace NavigationApplication
{
    public partial class Form2 : Form
    {

        //below are publically accessible variables
        //meant to be replaced eventually
        public string pa_directions = "";

        public int pa_progressMeter;

        //field values

        private string locationID;

        private string filePath;

        private bool isLocationConfirmed;

        private bool isDestinationSet;

        private string destination;

        //setters/getters
        public string location
        {
            get { return locationID; }
            set { locationID = value; }
        }

        public string file
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public bool locationConfirmed
        {
            get { return isLocationConfirmed; }
            set { isLocationConfirmed = value; }
        }


        public bool destinationSet
        {
            get { return isDestinationSet; }
            set { isDestinationSet = value; }
        }

        public string destinationID
        {
            get { return destination; }
            set { destination = value; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          isLocationConfirmed = false;   
          isDestinationSet = false;
          
            //use for testing
            //textBox1.Text = "filepath here";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //set file path button
            string input = "Write the filepath here to access GPS stand-in, use double '\\'";
            string confirmationOutput = "filepath accepted!";

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = input;
            }
            else
            {
                checkConnection();
                filePath = textBox1.Text;
                textBox1.Text = confirmationOutput;
                pa_progressMeter = 0;
                displayProgressMeter(pa_progressMeter);
                pictureBox1.Image = Image.FromFile(filePath + "\\model1.png");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //confirm destination button
            if (!String.IsNullOrEmpty(filePath))
            {
                isLocationConfirmed = true;
                confirmDestinationPopup();
                locationID = grabGPSCoordinates();
                pictureBox1.Image = Image.FromFile(filePath + "\\model5.png");
            }
            else
            {
                MessageBox.Show("Please enter file path before continuing");
            }
        }

        private void confirmDestinationPopup()
        {
            string coordinates = grabGPSCoordinates();
            DialogResult result = MessageBox.Show("Are you currently located at:"
                + "\n" + coordinates + "?", "The Application says: ", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                locationID = coordinates;
            }
            if(result == DialogResult.No)
            {
                processGPSError();
            }
        }

        private string grabGPSCoordinates()
        {
            //coordinates hardcoded
            //not possible to fail this step as written
            bool didProcessFail = false;
            string failsafeCoordinates = "123 ABC Lane, State//Country//Zip";

            string national, state, local, delimiter;
            int zipcode;

            delimiter = ", ";
            national = "USA";
            state = "SomeState";
            local = "123 ABC Lane";
            zipcode = 12345;

            try
            {
                StringBuilder sb = new StringBuilder(local);
                sb.Append(delimiter + state);
                sb.Append(delimiter + national);
                sb.Append(delimiter + zipcode.ToString());

                return sb.ToString();
            }
            catch (Exception ex)
            {
                didProcessFail = true;
                MessageBox.Show(ex.ToString());
            }

            if (didProcessFail)
            {
                processGPSError();
            }

            return failsafeCoordinates;
        }

        private void processGPSError()
        {
            //location hardcoded
            //enter code here for error handling
            locationID = "123 ABC Lane, State//Country//Zip";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //enter destination button
            bool allGood = checkLocationConfirmed();
            if (allGood)
            {
                string input = "Classroom nine";
                textBox1.Text = input;
                destination = input;

                isDestinationSet = true;

                MessageBox.Show("Destination set", "The Application says:");

                pa_progressMeter = 1;
                displayProgressMeter(pa_progressMeter);
                advanceProgress();

            }
        }

        private void displayProgressMeter(int progress)
        {
            //progress meter to right of progress button
            textBox2.Text = pa_progressMeter.ToString();
        }

        private bool checkLocationConfirmed()
        {
            if (isLocationConfirmed)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Confirm location before proceeding", "The Application says:");
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //get directions button
            bool allGood = checkLocationConfirmed();
            if (allGood)
            {
                allGood = isDestinationSet;
                if (allGood)
                {
                    MessageBox.Show(pa_directions);
                }
                else
                {
                    MessageBox.Show("Set destination first", "The Application says:");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //progress button
            pa_progressMeter += 1;
            advanceProgress();
        }

        private void advanceProgress()
        {
            //directions hardcoded
            bool allGood = checkLocationConfirmed();
            if (allGood)
            {
                allGood = isDestinationSet;
                if (allGood)
                {

                    if (pa_progressMeter > 3)
                    {
                        pa_progressMeter = 0;
                    }

                    displayProgressMeter(pa_progressMeter);

                    switch (pa_progressMeter)
                    {
                        case 0:
                            pa_directions = "Destination not set.";
                            pictureBox1.Image = Image.FromFile(filePath + "\\model5.png");
                            break;
                        case 1:
                            pa_directions = "Walk forward ten meters, turn left, walk forward ten meters," +
                            " turn right, walk forward ten meters." + "\n" +
                            "Your destination will be on the right";
                            pictureBox1.Image = Image.FromFile(filePath + "\\model2.jpg");
                            break;
                        case 2:
                            pa_directions = "Turn left, walk forward ten meters," +
                            " turn right, walk forward ten meters." + "\n" +
                            "Your destination will be on the right";
                            pictureBox1.Image = Image.FromFile(filePath + "\\model4.png");
                            break;
                        case 3:
                            pa_directions = "You've arrived at your destination";
                            pictureBox1.Image = Image.FromFile(filePath + "\\model3.png");
                            break;
                    }

                    MessageBox.Show(pa_directions, "The Application says:");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //repeat directions button
            if (!String.IsNullOrEmpty(pa_directions))
            {
                MessageBox.Show(pa_directions, "The Application says:");
            }
            else
            {
                MessageBox.Show("Error: destination not set", "The Application says:");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //cancel directions button

            bool allGood = checkLocationConfirmed();
            if (allGood)
            {
                allGood = isDestinationSet;
                if (allGood)
                {
                    try
                    {
                        resetAll();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        }

        private void resetAll()
        {
            isDestinationSet = false;
            destination = "";
            pa_directions = "";
            pa_progressMeter = 0;
            displayProgressMeter(pa_progressMeter);
            advanceProgress();
            MessageBox.Show("Destination canceled", "The Application says:");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //emergency call button
            emergencyProtocol();
        }

        private void emergencyProtocol()
        {
            string sendCoordinates = grabGPSCoordinates();
            bool isCallSuccessful = placeEmergencyCall(sendCoordinates);
            if (isCallSuccessful == false)
            {
                pingLocationEmergency(sendCoordinates);
                MessageBox.Show("Could not place call, contacting Emergency services through App", "The Application says:");
            }
            else
            {
                MessageBox.Show("Call Connecting...", "The Application says:");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //emergency call button
            emergencyProtocol();
        }

        private bool placeEmergencyCall(string coordinates)
        {
            string coordinatesGPS = coordinates;
            bool callGoesThrough = accessPhone();
            if (callGoesThrough == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool accessPhone()
        {
            //code here for some error handling
            return true;
        }

        private void pingLocationEmergency(string coordinates)
        {
            //code here for sending location to emergency personnel
            string coordinatesGPS = coordinates;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //exit button
            this.Close();
        }

        private void checkConnection()
        {
            radioButton1.Checked = true; //shows 'internet' is connected 
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //not in use - do not delete!!!!!!
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //not in use - do not delete!!!!!!
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //not in use - do not delete!!!!!!
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //not in use - do not delete!!!!!!
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //not in use - do not delete!!!!!!
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //not in use - do not delete!!!!!!
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
