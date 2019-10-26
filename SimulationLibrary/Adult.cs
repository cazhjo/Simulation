using SimulationLibrary.Occupations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Adult : Human
    {
        public int Balance { get; set; }
        public IOccupation Occupation { get; internal set; }
        public string OccupationStatus => Occupation.Name;
        

        public Adult()
        {
            Name = null ?? NameGenerator.GenerateName(6);
            Occupation = new Unemployed();
            IsAdult = true;
        }

        public Adult(Child child) : this()
        {
            if (!child.IsAdult)
            {
                Name = child.Name;
                if (child.IsEducated)
                {
                    IsEducated = true;
                }
            }
        }

        public override void GetOccupation()
        {
            JobPicker.PickJob(this);
        }
    }
}
    

