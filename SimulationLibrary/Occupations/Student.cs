using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary.Occupations
{
    class Student : IOccupation
    {
        public int Salary => 25;

        public string Name => "Student";
    }
}
