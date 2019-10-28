using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public interface IOccupation
    {
        int Salary { get; }
        string Name { get; }

        public void GetSalary(Human recipient)
        {
            recipient.Balance += Salary;
        }
    }
}
