namespace ZombiesMidterm
{
    public interface IObserver
    {
        void Update(RegularZombieX subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    //notifies zombiemanager of zombie death to increase death counter
    class TargetObserver : IObserver
    {
        private ZombieManager _manager;

        public void setManager(ZombieManager manager)
        {
            _manager = manager;
        }
        public void Update(RegularZombieX subject)
        {
            if (!(subject as RegularZombieX).getIsAlive())
            {
                _manager.increaseDeathCount();
            }
        }
    }

}
