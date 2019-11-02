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
        public List<Human> Children { get; private set; } = new List<Human>();
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

        public override string GetOccupation(int chance)
        {
            if (Occupation.Name == "Unemployed")
            {
                JobPicker.PickJob(this, chance);
                if (Occupation.Name != "Unemployed")
                {
                    return $"{Name} has gotten a job as a {Occupation.Name}";
                }
            }
            return null;
        }

        public override int CountOfChildren()
        {
            int temp = 0;
            foreach (var child in Children)
            {
                temp += 1 + child.CountOfChildren();
            }

            return temp;
        }
    }
}
    

