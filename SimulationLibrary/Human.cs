using SimulationLibrary.Food;
using System;
using System.Collections.Generic;

namespace SimulationLibrary
{
    public abstract class Human
    {
        public string Name { get; protected set; }
        public int Age { get; internal set; }
        public int Balance { get; internal set; }
        public int Hunger { get; set; } = 100;
        public bool IsEducated { get; internal set; }
        public bool IsAdult { get; protected set; }
        internal IOccupation Occupation { get; set; }
        internal List<IFood> FoodInventory { get; set; } = new List<IFood>();

        public void BuyFood()
        {

            if (Balance > 0)
            {
                foreach (var item in FoodStore.FoodStorage)
                {
                    if (Balance >= item.Price)
                    {
                        FoodInventory.Add(item);
                        Balance -= item.Price;
                    }
                }
            }
        }
        public void EatFood()
        {
            if (Hunger < 100 && FoodInventory.Count != 0)
            {
                int foodPicker = Globals.random.Next(0, FoodInventory.Count);

                if (FoodInventory[foodPicker].Energy + Hunger > 100)
                {
                    Hunger = 100;
                }
                else
                {
                    Hunger += FoodInventory[foodPicker].Energy;
                    FoodInventory.RemoveAt(foodPicker);
                }
            }
        }

        public void ReduceHunger(int amount)
        {
            Hunger -= amount;
        }

        public abstract void GetOccupation();
    }
}
