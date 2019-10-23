using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Child : Human
    {
        public Child()
        {
            Name = NameGenerator.GenerateName(6);
            IsAdult = false;
        }

        public override void GetOccupation()
        {
            bool canGetEducated = Globals.random.Next(0, 3) == 2;

            if (canGetEducated)
            {
                IsEducated = true;
            }
        }
    }
}
