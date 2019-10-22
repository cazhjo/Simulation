using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    class Unemployed : IJob
    {
        public int Salary => 0;
        public string Name => "Unemployed";

    }
}
