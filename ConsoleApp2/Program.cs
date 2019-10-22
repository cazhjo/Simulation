using ConsoleSimulationEngine2000;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimulationLibrary;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var gui = new ConsoleGUI()
            {
                TargetUpdateTime = 100
            };
            var sim = new MySimulation();
            await gui.Start(sim);
        }
    }

    public class MySimulation : Simulation
    {
        private Random random = new Random();
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 20, 3) { };
        private BorderedDisplay deathsDisplay = new BorderedDisplay(19, 11, 20, 3) { };
        private BorderedDisplay populationDisplay = new BorderedDisplay(38, 11, 20, 3) { };
        private static DateTime time = new DateTime(); 
        public override List<BaseDisplay> Displays => new List<BaseDisplay>()
        {
            log, 
            clockDisplay, 
            Input.CreateDisplay(0, -3, -1, 3), 
            deathsDisplay, 
            populationDisplay
        };

        Population population = new Population(10);
        public override void PassTime(int deltaTime)
        {
            clockDisplay.Value = time.ToString("mm:ss");
            time = time.AddSeconds(1);

            if(time.Minute == 1)
            {
                log.Log(population.GetAllJobs(random));
            }
            else if(time.Minute == 2)
            {
                population.ReduceHunger();
                population.CheckHunger();
                log.Log($"Hunger {population.Humans[0].Hunger}");
            }

                deathsDisplay.Value = "Deaths: " + population.Deaths.ToString();
                populationDisplay.Value = "Population: " + population.Humans.Count.ToString();

            

            if(time.Minute == 02)
            {
                time = time.Subtract(time.TimeOfDay);
            }

            while (Input.HasInput)
            {
            }
        }
    }
}
