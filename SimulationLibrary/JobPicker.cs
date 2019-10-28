using SimulationLibrary.Occupations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public static class JobPicker
    {
        public static void PickJob(Human human, int chance)
        {
            bool canGetJob = Globals.random.Next(0, chance) == chance - 1;
            if (canGetJob)
            {
                int jobPicker = Globals.random.Next(0, 2);

                JobChoices(human, jobPicker);
            }
        }

        private static void JobChoices(Human human, int jobNumber)
        {
            if (!human.IsAdult)
            {
                human.Occupation = new Student();
                human.IsEducated = true;
            }

            if (human.IsEducated)
            {
                switch (jobNumber)
                {
                    case 0:
                        human.Occupation = new Programmer();
                        break;
                    case 1:
                        human.Occupation = new Doctor();
                        break;
                }
            }
            else
            {
                switch (jobNumber)
                {
                    case 0:
                        human.Occupation = new FastFoodWorker();
                        break;
                    case 1:
                        human.Occupation = new Cleaner();
                        break;
                }
            }
        }
    }
}
