using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary.FoodClasses
{
    public class FoodStore
    {
        public static List<Food> FoodStorage = new List<Food>
        {
            new Food(25, 15, "Dairy"),
            new Food(15, 10, "Fruit"),
            new Food(60, 30, "Grain"),
            new Food(100, 50, "Protein"),
            new Food(45, 25, "Vegetable")
        };
    }
}
