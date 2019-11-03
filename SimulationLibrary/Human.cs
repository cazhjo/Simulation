using SimulationLibrary.FoodClasses;
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
        public IOccupation Occupation { get; internal set; }
        internal Adult Parent1 { get; set; }
        internal Adult Parent2 { get; set; }
        internal List<Food> FoodInventory { get; set; } = new List<Food>();

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

        public abstract string GetOccupation(int chance);
        public abstract int CountOfChildren();
    }
}
