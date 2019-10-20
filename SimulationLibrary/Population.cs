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

        /// <summary>
        /// Creates new population with 10 humans
        /// </summary>
        public Population()
        {
            Humans = new List<Human>();
            for (int i = 0; i < 10; i++)
            {
                AddHuman(new Adult());
            }
        }

        public int Count()
        {
            return Humans.Count;
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

        public string GetAllJobs(Random random)
        {
            foreach (var human in Humans)
            {
                if (human.HasJob == false)
                {
                    human.GetJob(random);
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
                    Humans.RemoveAt(i);
                    Deaths++;
                }
            }
        }
    }
}
