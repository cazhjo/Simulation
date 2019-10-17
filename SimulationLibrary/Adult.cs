using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Adult : Human
    {
        public int Salary { get; set; }
        public int Balance { get; set; }
        public bool HasJob { get; set; }

        public override string GetJob(Random random)
        {
            if (HasJob)
            {
                return Name + "Already has a job";
            }
            if(random.Next(1, 6) == 5)
            {
                HasJob = true;
                SetSalary(random.Next(100, 300));
                return Name + "has gotten a job!";
            }
            return Name + "did not get a job";
        }
        
        private void SetSalary(int salary)
        {
            Salary = salary;
        }
    }
}
