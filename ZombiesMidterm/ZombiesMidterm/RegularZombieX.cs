using System.Collections.Generic;

namespace ZombiesMidterm
{
   //zombie object -> can be renamed plain zombie 
    public class RegularZombieX : Entity, ISubject
    {

        private int health;
        private bool isAlive;
        private bool hasAccessory;
        private int healthAcs;
        private int typeAcs;
        private List<IObserver> _observers = new List<IObserver>();

        public RegularZombieX(int health, bool isAlive)             
            {
            this.health = health;
            this.isAlive = isAlive;
            }
        
        public bool getIsAlive()
        {
            return isAlive;
        }

        public void setHealth(int health)
        {
            this.health = health;
        }

        public override int getHealth()
        {
            return health;
        }

        public override void takeDamage(int amount)
        {
            health -= amount;
        }

        public void Die()
        {
            isAlive = false;
            this.Notify();
        }

        public void setHasAccessory(bool has, int health,int type)
        {
            hasAccessory = has;
            healthAcs = health;
            typeAcs = type;
        }

        public bool getHasAccessory()
        {
            return hasAccessory;
        }

        public int getTypeAcs()
        {
            return typeAcs;
        }

        public int getHealthAcs()
        {
            return healthAcs;
        }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }

 }

       
    

