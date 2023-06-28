using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombiesMidterm
{
    public partial class Form1 : Form
    {
        private ZombieManager m_manager;
        private GameEventManager m_gameEventManager;
        private Bullet _bullet;
        private String @fileString;
        private bool isGameStarted;
        private List<TextBox> txt;
        private List<PictureBox> pic;
        private bool isFilePathSet;
        public String FileString { get { return fileString; } set { fileString = value; } }

        private String samplePath = "C:\\Users\\shawk\\source\\repos\\ZombiesMidterm\\ZombiesMidterm\\Graphics";
        public bool IsGameStarted { get { return isGameStarted; } set { isGameStarted = value; } }
        public List<TextBox> TextList { get { return txt; } set { txt = value; } }
        public List<PictureBox> Pic { get { return pic; } set { pic = value; } }

        public bool IsFilePathSet { get { return isFilePathSet; } set { isFilePathSet = value; } }
     
        public Form1()
        {
            InitializeComponent();
            
            //initializes the rest of the component...
            textBox17.Text = samplePath;
            radioButton1.Checked = true;
            checkBox1.Checked = true;
            isFilePathSet = false;

            setupManagers();
            setLists();
        }

        //sets up initial bullet to be used
        //initializes GameEventManager 
        //initializes ZombieManager (GameObjectManager)
        private void setupManagers()
        {
            Bullet initialBullet = new Bullet(25, 1);
            _bullet = initialBullet;


            m_gameEventManager = new GameEventManager();
            m_manager = new ZombieManager();
            m_manager.initialize(m_gameEventManager);
           
        }
        //ensures file path is set up by producing image

        //add zombie button
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFilePathSet == true)
            {
                if (isGameStarted == false)
                {                   
                    if (m_manager.ZombieList.Count < 8)
                    { 
                        if (radioButton1.Checked)
                        {
                            setChoice(1);
                        }
                        else if (radioButton2.Checked)
                        {
                            setChoice(2);
                        }
                        else if (radioButton3.Checked)
                        {
                            setChoice(3);
                        }
                        else if (radioButton4.Checked)
                        {
                            setChoice(4);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Zombies limited to 8");
                    }
                }
                else
                {
                    MessageBox.Show("Game is already started, cannot add more zombies");
                }
            }
            else
            {
                MessageBox.Show("Set the file path first");
            }
        }
        public void setChoice(int choice)
        {
            m_manager.addZombie(choice);
            populate();
        }

        //start game button
        //considers damage input
        private void button4_Click(object sender, EventArgs e)
        {
            isGameStarted = true;
        }

        //shoot zombies button
        //creates observer
        //selects target and attaches observer
        //deals damage to either accessory or target
        //kills target if health is <= 0
        //rechecks status of target - replaces zombie if accessory is broken
        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                var observer = new TargetObserver();
                observer.setManager(m_manager);

                if (IsGameStarted == true)
                {
                    bool allDead = m_manager.getAllDead();
                    if (allDead)
                    {
                        MessageBox.Show("All Zombies are dead");
                    }
                    else
                    { 
                        setDamage();

                        RegularZombieX target = getTarget();
                        target.Attach(observer);

                        m_manager.passBullet();
                        m_gameEventManager.simulateCollisionDetection();

                        target.Detach(observer);
                        getTarget();
                        populate();
                    }
                }
                else
                {
                    MessageBox.Show("First start the game");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //finds target by searching for first 'isAlive' zombie
        //zombie is both selected as target and attached with an observer
        private RegularZombieX getTarget()
        {
            int size = m_manager.ZombieList.Count();

            for (int i = 0; i < size; i++)
            {
                bool isAlive = m_manager.ZombieList[i].getIsAlive();
                if (isAlive)
                {
                   m_gameEventManager.setTarget(m_manager.ZombieList[i]);
                   return m_manager.ZombieList[i];
                }
            }

            return null;

        }

        //exit button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        //end game button, clears zombie list
        private void button2_Click(object sender, EventArgs e)
        {

            m_manager.removeZombies();

            foreach (TextBox t in txt)
            {
                t.Text = "";
            }

            foreach (PictureBox p in pic)
            {
                p.Image = null;
            }

            isGameStarted = false;
        }

        //set filepath button
        private void button6_Click(object sender, EventArgs e)
        {
            fileString = textBox17.Text;
            if (!String.IsNullOrEmpty(fileString))
            {
                addPeashooter();
                addMagnetShroom();
                addWatermelon();             
            }
            isFilePathSet = true;
        }

        //determines bullet object to be used to attack target (zombie)
        public void setDamage()
        {
            if (checkBox1.Checked)
            {
                Bullet bullet = new Bullet(25, 1);
                _bullet = bullet;
            }
            if (checkBox2.Checked)
            {
                Bullet bullet = new Bullet(30, 2);
                _bullet = bullet;
            }
            if (checkBox3.Checked)
            {
                Bullet bullet = new Bullet(0, 3);
                _bullet = bullet;
            }

            m_manager.setBullet(_bullet);
        }



        //gets list of zombies and assigns them to picture/text boxes
        private void populate()
        {
            int size = m_manager.ZombieList.Count;
            string graphics;

            for (int i = 0; i < size; i++)
            {
                RegularZombieX assignZ = m_manager.ZombieList[i];
                int health = assignZ.getHealth();
                //   int healthAcs = assignZ.AccessoryHealth;
                //    int totalHealth = health + healthAcs;

                int type = assignZ.getTypeAcs();
                int healthAcs = assignZ.getHealthAcs();
                string typeStr = "";
                if (type == 1)
                    typeStr = "ConeZombie";
                else if (type == 2)
                    typeStr = "BucketZombie";
                else if (type == 3)
                    typeStr = "DoorZombie";
                else
                    typeStr = "RegularZombie";

                int totalHealth = health + healthAcs;

                graphics = getGraphicsString(typeStr);
                
                assignPositions(i, totalHealth, typeStr, graphics);
            }

        }

        public string getGraphicsString(string type)
        {
            string paren = "\\";
            string png = ".png";
            string graphics = paren + type + png;

            return graphics;
        }

        //not the most elegant solution but works for purposes of this program
        private void assignPositions(int i, int health, string type, string graphics)
        {

            switch (i)
            {
                case 0:
                    pictureBox2.Image = Image.FromFile(fileString + graphics);
                    textBox1.Text = health.ToString();
                    textBox2.Text = type;
                    break;
                case 1:
                    pictureBox3.Image = Image.FromFile(fileString + graphics);
                    textBox3.Text = health.ToString();
                    textBox4.Text = type;
                    break;
                case 2:
                    pictureBox4.Image = Image.FromFile(fileString + graphics);
                    textBox5.Text = health.ToString();
                    textBox6.Text = type;
                    break;
                case 3:
                    pictureBox5.Image = Image.FromFile(fileString + graphics);
                    textBox7.Text = health.ToString();
                    textBox8.Text = type;
                    break;
                case 4:
                    pictureBox6.Image = Image.FromFile(fileString + graphics);
                    textBox9.Text = health.ToString();
                    textBox10.Text = type;
                    break;
                case 5:
                    pictureBox7.Image = Image.FromFile(fileString + graphics);
                    textBox11.Text = health.ToString();
                    textBox12.Text = type;
                    break;
                case 6:
                    pictureBox8.Image = Image.FromFile(fileString + graphics);
                    textBox13.Text = health.ToString();
                    textBox14.Text = type;
                    break;
                case 7:
                    pictureBox9.Image = Image.FromFile(fileString + graphics);
                    textBox15.Text = health.ToString();
                    textBox16.Text = type;
                    break;
            }
        }
        public void setLists()
        {
            List<TextBox> list = new List<TextBox>();

            list.Add(textBox1);
            list.Add(textBox2);
            list.Add(textBox3);
            list.Add(textBox4);
            list.Add(textBox5);
            list.Add(textBox6);
            list.Add(textBox7);
            list.Add(textBox8);
            list.Add(textBox9);
            list.Add(textBox10);
            list.Add(textBox11);
            list.Add(textBox12);
            list.Add(textBox13);
            list.Add(textBox14);
            list.Add(textBox15);
            list.Add(textBox16);

            txt = list;

            List<PictureBox> list2 = new List<PictureBox>();

            list2.Add(pictureBox2);
            list2.Add(pictureBox3);
            list2.Add(pictureBox4);
            list2.Add(pictureBox5);
            list2.Add(pictureBox6);
            list2.Add(pictureBox7);
            list2.Add(pictureBox8);
            list2.Add(pictureBox9);

            pic = list2;
        }

        //radio buttons select choices for zombies
        //regular zombie selection
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }
        //cone zombie selection
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }
        //bucket zombie selection
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
            }
        }
        //door zombie selection
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }
        //add peashooter image to form1
        private void addPeashooter()
        {
            fileString = textBox17.Text;
            String @pString = "\\peashooter.png";
            pictureBox1.Image = Image.FromFile(fileString + pString);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Visible = true;
        }
        //add watermelon image to form1
        private void addWatermelon()
        {
            fileString = textBox17.Text;
            String @pString = "\\watermelon.png";
            pictureBox10.Image = Image.FromFile(fileString + pString);
            pictureBox10.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox10.Visible = true;
        }
        //add magnetshroom image to form1
        private void addMagnetShroom()
        {
            fileString = textBox17.Text;
            String @pString = "\\magnetshroom.png";
            pictureBox11.Image = Image.FromFile(fileString + pString);
            pictureBox11.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox11.Visible = true;
        }
        //check for peashooter plant
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }
        //check for watermelon plant
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }
        //check for magnetshroom plant
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        //test purposes only
        public void testBox(int i, string str)
        {
            MessageBox.Show(i.ToString() + "\n" + str);
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
