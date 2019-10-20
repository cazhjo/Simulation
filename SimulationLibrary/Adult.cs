using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Adult : Human
    {
        public int Salary { get; set; }
        public int Balance { get; set; }

        public Adult()
        {
            Name = NameGenerator.GenerateName(6);
        }

        public override string GetJob(Random random)
        {
            if(random.Next(1, 1) == 1)
            {
                HasJob = true;
                SetSalary(random.Next(100, 300));
                return Name + " has gotten a job!";
            }
            return Name + " did not get a job";
        }
        
        private void SetSalary(int salary)
        {
            Salary = salary;
        }
    }
}
