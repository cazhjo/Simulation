using System;

namespace SimulationLibrary
{
    public abstract class Human
    {
        public string Name { get; protected set; }
        public int Hunger { get; set; } = 10;
        public bool IsEducated { get; protected set; }
        public bool IsAdult { get; protected set; }

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

        public abstract void GetOccupation();
    }
}
