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
        private static Population instance = new Population();

        /// <summary>
        /// Returns an instance of Population with 10 initial Adults
        /// </summary>
        public static Population Instance => instance;


        public int Count => Humans.Count;

        private Population()
        {
            Humans = new List<Human>();
            for (int i = 0; i < 10; i++)
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
