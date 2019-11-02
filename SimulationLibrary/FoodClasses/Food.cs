using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary.FoodClasses
{
    public class Food
    {
        public int Price { get; }
        public int Energy { get; }
        public string Name { get; }

        public Food(int price, int energy, string name)
        {
            Price = price;
            Energy = energy;
            Name = name;
        }

    }
}
