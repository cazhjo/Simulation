﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary.Occupations
{
    public class Cleaner : IOccupation
    {
        public int Salary => 30;

        public string Name => "Cleaner";
    }
}
