namespace ZombiesMidterm
{
    //decorates zombies with specified objects - type and health of decoration
    abstract class Decorator : Entity
    {
            protected Entity _ZombieComponent;

            public Decorator(Entity ZombieComponent)
            {
                this._ZombieComponent = ZombieComponent;
            }

            public void SetComponent(Entity ZombieComponent)
            {
                this._ZombieComponent = ZombieComponent;
            }

            public override void takeDamage(int amount)
            {
                if (this._ZombieComponent != null)
                {
                    this._ZombieComponent.takeDamage(amount);
                }
            }

        public override int getHealth()
        {
            return this._ZombieComponent.getHealth();
        }

    }

    class ConeDecorator : Decorator
    {
        private int health;
        private int type = 1;

        public ConeDecorator(Entity comp, int health, int type) : base(comp)
        {
            this.health = health;
            this.type = type;
        }
      
        public override int getHealth()
        {
            return health;
        }

        public override void takeDamage(int amount)
        {
            this.health -= amount;
        }

        public int getDecoratorType()
        {
            return type;
        }


    }
  
    class BucketDecorator : Decorator
    {
        private int health;
        private int type = 2;

        public BucketDecorator(Entity comp, int health, int type) : base(comp)
        {
            this.health = health;
            this.type = type;
        }

        public override int getHealth()
        {
            return health;
        }

        public override void takeDamage(int amount)
        {
            this.health -= amount;
        }

        public int getDecoratorType()
        {
            return type;
        }

    }

    class DoorDecorator : Decorator
    {
        private int health;
        private int type = 3;

        public DoorDecorator(Entity comp, int health, int type) : base(comp)
        {
            this.health = health;
            this.type = type;
        }
        public override int getHealth()
        {
            return health;
        }

        public override void takeDamage(int amount)
        {
            this.health -= amount;
        }

        public int getDecoratorType()
        {
            return type;
        }

    }

}

       
    

