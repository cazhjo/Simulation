using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary.Occupations
{
    public class Doctor : IOccupation
    {
        public int Salary => 75;

        public string Name => "Doctor";
    }
}
