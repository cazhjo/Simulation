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
                TargetUpdateTime = 1000
            };
            var sim = new MySimulation();
            await gui.Start(sim);
        }
    }

    public class MySimulation : Simulation
    {
        public Random random = new Random();
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 20, 3) { };
        private BorderedDisplay deathsDisplay = new BorderedDisplay(19, 11, 20, 3) { };
        private BorderedDisplay populationDisplay = new BorderedDisplay(38, 11, 20, 3) { };
        public override List<BaseDisplay> Displays => new List<BaseDisplay>()
        {
            log, 
            clockDisplay, 
            Input.CreateDisplay(0, -3, -1, 3), 
            deathsDisplay, 
            populationDisplay
        };

        Population population = new Population();

        public override void PassTime(int deltaTime)
        {
            
            log.Log($"Hunger {population.Humans[0].Hunger}");
            clockDisplay.Value = DateTime.Now.ToString("mm:ss");
            population.Humans[0].Hunger--;
            population.CheckHunger();
            deathsDisplay.Value = "Deaths: " + population.Deaths.ToString();
            populationDisplay.Value = "Population: " + population.Humans.Count.ToString();

            log.Log(population.Humans[0].GetJob(random));

            while (Input.HasInput)
            {
                    log.Log(population.Humans[0].GetJob(random));
            }
        }
    }
}
