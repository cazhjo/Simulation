using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Population
    {
        public List<Human> Humans {get; set; }
        public int Deaths { get; private set; }
        public int Births { get; set; }

        public Population()
        {
            Humans = new List<Human>();
        }

        public void AddHuman(Human human)
        {
            Humans.Add(human);
        }

        public void CheckHunger()
        {
            for (int i = 0; i < Humans.Count; i++)
            {
                if(Humans[i].Hunger == 0)
                {
                    Humans.RemoveAt(i);
                    Deaths++;
                }
            }
        }
    }
}
