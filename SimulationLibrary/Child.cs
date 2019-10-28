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
            Occupation = new Unemployed();
        }

        public override void GetOccupation(int chance)
        {
            JobPicker.PickJob(this, chance);
        }
    }
}
