using SimulationLibrary.Occupations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Adult : Human
    {
        public bool HasPartner { get; internal set; }
        public Adult Partner { get; internal set; }
        

        public Adult()
        {
            Name = null ?? NameGenerator.GenerateName(6);
            Occupation = new Unemployed();
            IsAdult = true;
            Age = 3;
        }

        public Adult(Child child) : this()
        {
            if (!child.IsAdult)
            {
                Name = child.Name;
                if (child.IsEducated)
                {
                    IsEducated = true;
                    Balance = child.Balance;
                }
            }
        }

        public override void GetOccupation(int chance)
        {
            JobPicker.PickJob(this, chance);
        }
    }
}
    

