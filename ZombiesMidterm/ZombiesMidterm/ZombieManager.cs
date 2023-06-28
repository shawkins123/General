using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombiesMidterm
{
    //acting GameObjectManager
    public class ZombieManager
    {
        private RegularZombieFactory rz_factory;
        private Bullet _bullet;
        private GameEventManager gameEventManager;

        private List<RegularZombieX> zombieList;
        public List<RegularZombieX> ZombieList { get { return zombieList; } set {zombieList = value;} }

        private int deathCount;
        private bool allDead;

        //sets up factory, list, and set gameEventManager
        public void initialize(GameEventManager gem)
        {
            
            rz_factory = new RegularZombieFactory();
            gameEventManager = gem;
            allDead = false;
            zombieList = new List<RegularZombieX>();           
        }

        //adds zombies via factory and assigns decorator per choice
        public void addZombie(int choice)
        {   
                if(choice == 1)
                {
                    zombieList.Add(rz_factory.CreateZombie(50 , true));
                }   
                else if(choice == 2)
                {
                    RegularZombieX zombie = rz_factory.CreateZombie(50, true);
                    ConeDecorator decorator1 = new ConeDecorator(zombie, 25, 1);
                    decorator1.SetComponent(zombie);
                    int type = decorator1.getDecoratorType();
                    int health = decorator1.getHealth();
                    zombie.setHasAccessory(true,health, type);
                    zombieList.Add(zombie);
                }
                else if(choice == 3)
                {
                    RegularZombieX zombie = rz_factory.CreateZombie(50, true);
                    BucketDecorator decorator1 = new BucketDecorator(zombie, 100, 2);
                    decorator1.SetComponent(zombie);
                    int type = decorator1.getDecoratorType();
                    int health = decorator1.getHealth();
                    zombie.setHasAccessory(true, health, type);
                    zombieList.Add(zombie);
                }
                else if (choice == 4)
                {
                    RegularZombieX zombie = rz_factory.CreateZombie(50, true);
                    DoorDecorator decorator1 = new DoorDecorator(zombie, 25, 3);
                    decorator1.SetComponent(zombie);
                    int type = decorator1.getDecoratorType();
                    int health = decorator1.getHealth();
                    zombie.setHasAccessory(true, health, type);
                    zombieList.Add(zombie);
                }
                else
                {
                    MessageBox.Show("Error - Zombie Manager");
                }             
        }

        //can code to specifically target zombies via getZombie then using remove function
        //- this is simpler for purposes of this program
        public void removeZombies()
        {
            int size = zombieList.Count;
            if(size <= 0)
            {
                MessageBox.Show("List is already empty");
            }
            else
            {
                zombieList.Clear();
            }
        }

        //the Zombie Manager does not need to handle the bullets, as this complicates the program
        //however, if the bullets/plants were implemented as true objects then they would be handled
        //via the Zombie Manager (to then be titled GameObjectManager)
        public void setBullet(Bullet bullet)
        {
            _bullet = bullet;
            passBullet();
        }

        public void passBullet()
        {
           gameEventManager.setBullet(_bullet);
        }

        //death count is used to keep track of zombies via observer method, game stops when
        //last zombie is killed
        public void increaseDeathCount()
        {
            deathCount += 1;
            if (deathCount == zombieList.Count)
                allDead = true;              
        }

        public bool getAllDead()
        {
            return allDead;
        }

    }
}
