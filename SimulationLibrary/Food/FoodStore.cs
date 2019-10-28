using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary.Food
{
    public class FoodStore
    {
        public static List<IFood> FoodStorage = new List<IFood>
        {
            new Dairy(),
            new Fruit(),
            new Grain(),
            new Protein(),
            new Vegetable()
        };
    }
}
