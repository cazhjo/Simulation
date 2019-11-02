using SimulationLibrary.Occupations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public static class JobPicker
    {
        public static void PickJob(Adult adult, int chance)
        {
            bool canGetJob = Globals.random.Next(0, chance) == chance - 1;
            if (canGetJob)
            {
                int jobPicker = Globals.random.Next(0, 2);

                JobChoices(adult, jobPicker);
            }
        }

        private static void JobChoices(Adult adult, int jobNumber)
        {
            if (adult.IsEducated)
            {
                switch (jobNumber)
                {
                    case 0:
                        adult.Occupation = new Programmer();
                        break;
                    case 1:
                        adult.Occupation = new Doctor();
                        break;
                }
            }
            else
            {
                switch (jobNumber)
                {
                    case 0:
                        adult.Occupation = new FastFoodWorker();
                        break;
                    case 1:
                        adult.Occupation = new Cleaner();
                        break;
                }
            }
        }
    }
}
