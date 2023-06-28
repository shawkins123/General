using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombiesMidterm
{
    public class Bullet
    {
        private int damage;
        private int type;

        public Bullet(int damage, int type)
        {
            this.damage = damage;
            this.type = type;
        }

        public void setDamage(int damage)
            { this.damage = damage; }
        public int getDamage()
        {
            return damage;
        }

        public int getType()
        {
            return type;
        }
    }
}
