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
        private BorderedDisplay birthsDisplay = new BorderedDisplay(57, 11, 20, 3) { };
        private static DateTime time = new DateTime(); 
        public override List<BaseDisplay> Displays => new List<BaseDisplay>()
        {
            log, 
            clockDisplay, 
            Input.CreateDisplay(0, -3, -1, 3), 
            deathsDisplay, 
            populationDisplay,
            birthsDisplay
        };

        Population population = Population.Instance;
        public override void PassTime(int deltaTime)
        {
            clockDisplay.Value = time.ToString("mm:ss");
            time = time.AddSeconds(1);
            deathsDisplay.Value = "Deaths: " + population.Deaths.ToString();
            populationDisplay.Value = "Population: " + population.Count.ToString();
            birthsDisplay.Value = "Births: " + population.Births.ToString();
            
            if(time.Minute == 0 && time.Second == 30)
            {
                population.GetJobs();
                LogAnnouncements();
            }

            if (time.Minute == 1 && time.Second == 30)
            {
                population.Payday();
                population.ReducePopulationHunger();
                LogAnnouncements();
            }
            if (time.Minute == 2 && time.Second < 1)
            {
                population.FoodShopping();
                population.EatFood();
            }

            if (time.Minute == 2 && time.Second == 30)
            {
                population.MakeChildrenAdults();
                population.CreateCouples();
                population.MakeChildren();
                LogAnnouncements();
            }

            if (time.Minute == 3)
            {
                population.CheckHunger();
                population.CheckAge();

                time = new DateTime();
                population.AgeUpPopulation();
            }

            while (Input.HasInput)
            {
                log.Log(Input.Consume());
            }
        }

        private void LogAnnouncements()
        {
            foreach (var announcement in population.Announce())
            {
                log.Log(announcement);
            }
            population.ClearAnnouncements();
        }
    }
}
