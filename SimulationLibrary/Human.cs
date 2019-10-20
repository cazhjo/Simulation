using System;

namespace SimulationLibrary
{
    public abstract class Human
    {
        public string Name { get; set; }
        public int Hunger { get; set; } = 10;
        public bool HasJob { get; set; }

        public void BuyFood()
        {

        }
        public void EatFood() 
        {
            
        }

        public abstract string GetJob(Random random);
    }
}
