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

        public int Count => Humans.Count;

        public Population(int initialPopulationCount)
        {
            Humans = new List<Human>();
            for (int i = 0; i < initialPopulationCount; i++)
            {
                AddHuman(new Adult());
            }
        }

        public void AddHuman(Human human)
        {
            Humans.Add(human);
        }

        public void ReduceHunger()
        {
            foreach (var human in Humans)
            {
                human.Hunger--;
            }
        }

        public string GetAllJobs()
        {
            foreach (var human in Humans)
            {
                if (human.HasJob == false)
                {
                    human.GetJob();
                }
            }
            return "yee";
        }

        public void CheckHunger()
        {
            for (int i = 0; i < Humans.Count; i++)
            {
                if(Humans[i].Hunger == 0)
                {
                    KillHuman(i);
                }
            }
        }

        private void KillHuman(int index)
        {
            Humans.RemoveAt(index);
            Deaths++;
        }

        private void LoopThroughPopulation(Func<bool> condition)
        {
            for (int i = 0; i < Humans.Count; i++)
            {
                
            }
        }
    }
}
