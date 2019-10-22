using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Adult : Human
    {
        public int Balance { get; set; }
        public IJob Job { get; set; }
        public string JobStatus => Job.Name;

        public Adult()
        {
            Name = NameGenerator.GenerateName(6);
            Job = new Unemployed();
        }

        public override void GetJob()
        {
            bool canGetJob = Globals.random.Next(0, 5) == 4;
            if (canGetJob)
            {
                int jobPicker = Globals.random.Next(0, 3);

                switch (jobPicker)
                {
                    case 0:
                        Job = new FastFoodWorker();
                        break;
                    case 1:
                        Job = new Programmer();
                        break;
                }
            }
        }
    }
}
