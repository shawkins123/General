using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombiesMidterm
{
    public class GameEventManager
    {
        private RegularZombieX target;
        private Bullet bullet;

        //deals damage to target based on bullet type and damage
        //damage is already defined via word document instructions
        public void simulateCollisionDetection()
        {
            int value = bullet.getType();

            if (value == 1)
                doDamage(25, target);
            if (value == 2)
                doDamageFromAbove(30, target);
            if (value == 3)
                applyMagnetForce(target);

        }

        public void doDamage(int damage, RegularZombieX target)
        {
            int damageOverrun = 0;

            if (target.getHasAccessory())
            {
                int healthAcs = target.getHealthAcs();
                int typeAcs = target.getTypeAcs();
                int health;

                health = healthAcs - damage;

                if (health <= 0)
                {
                    damageOverrun = health;
                    target.takeDamage(Math.Abs(damageOverrun));
                    target.setHasAccessory(false, 0, 0);
                }
                else
                    target.setHasAccessory(true, health, typeAcs);

            }
            else
            {
                dealDirectDamage(damage, target);
            }


        }

        private static void dealDirectDamage(int damage, RegularZombieX target)
        {
            target.takeDamage(damage);
            int health = target.getHealth();
            if (health <= 0)
            {
                target.setHealth(0);
                target.Die();
            }
        }

        public void doDamageFromAbove(int damage, RegularZombieX target)
        {
            int damageOverrun = 0;
            if (target.getHasAccessory())
            {
                int healthAcs = target.getHealthAcs();
                int typeAcs = target.getTypeAcs();
                int health;
                if (typeAcs == 3)
                {
                    target.takeDamage(damage);
                    int healthTarget = target.getHealth();
                    if (healthTarget <= 0)
                    {
                        target.setHasAccessory(false, 0, 0);
                        target.setHealth(0);
                        target.Die();
                    }
                }
                else
                {
                    health = healthAcs - damage;

                    if (health <= 0)
                    {
                        damageOverrun = health;
                        target.takeDamage(Math.Abs(damageOverrun));
                        target.setHasAccessory(false, 0, 0);
                    }
                    else
                        target.setHasAccessory(true, health, typeAcs);
                }
            }
            else
            {
                dealDirectDamage(damage, target);
            }
        }

            public void applyMagnetForce(RegularZombieX target)
            {
            if (target.getHasAccessory())
            {
                int typeAcs = target.getTypeAcs();
          
                if (typeAcs == 2 || typeAcs == 3)
                {
                    target.setHasAccessory(false, 0, 0);
                }

            }
            }

        public void setTarget(RegularZombieX target)
        {
            this.target = target;
        }

        public void setBullet(Bullet bullet)
        {
            this.bullet = bullet;
        }
    }

   

}
