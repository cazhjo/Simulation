using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public interface IJob
    {
        int Salary { get; }
        string Name { get; }

        public void PaySalary(Adult recipient)
        {
            recipient.Balance += Salary;
        }

        public void FireFromJob(Adult adult)
        {
            adult.Job = new Unemployed();
        }
    }
}
