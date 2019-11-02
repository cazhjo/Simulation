using SimulationLibrary.Occupations;
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

        public override int CountOfChildren()
        {
            return 0;
        }

        public override string GetOccupation(int chance)
        {
            int schoolChance = Globals.random.Next(0, chance);

            if(schoolChance == chance - 1)
            {
                Occupation = new Student();
                return $"{Name} has started studying";
            }
            return null;
        }
    }
}
