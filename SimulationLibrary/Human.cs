using System;

namespace SimulationLibrary
{
    public abstract class Human
    {
        public string Name { get; protected set; }
        public int Hunger { get; set; } = 10;
        public bool IsEducated { get; protected set; }
        public bool IsAdult { get; protected set; }
        public bool HasPartner { get; internal set; }
        public Couple @Couple { get; set; }

        public void BuyFood()
        {
            throw new NotImplementedException();
        }
        public void EatFood() 
        {
            throw new NotImplementedException();
        }

        public void ReduceHunger(int amount)
        {
            Hunger -= amount;
        }

        public virtual Couple CoupleWith(Human human2)
        {
            @Couple = new @Couple(this, human2);
            return @Couple;
        }

        public abstract void GetOccupation();
    }
}
