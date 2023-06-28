using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombiesMidterm
{
    public class RegularZombieFactory : ZombieFactory
    {

        public override RegularZombieX CreateZombie(int health, bool isAlive)
        {
            return new RegularZombieX(50, true);
        }
    }

}
