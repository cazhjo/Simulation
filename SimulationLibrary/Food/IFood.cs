using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary.Food
{
    public interface IFood
    {
        int Price { get; }
        int Energy { get; }
    }
}
