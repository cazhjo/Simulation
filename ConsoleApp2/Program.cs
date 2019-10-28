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
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 20, 3) { };
        private BorderedDisplay deathsDisplay = new BorderedDisplay(19, 11, 20, 3) { };
        private BorderedDisplay populationDisplay = new BorderedDisplay(38, 11, 20, 3) { };
        private BorderedDisplay birthsDisplay = new BorderedDisplay(57, 11, 20, 3) { };
        private static DateTime time = new DateTime();
        private bool announceJob = true;
        private bool announcePayday = true;
        private bool announceFamily = true;
        private bool announceDeath = true;
        public override List<BaseDisplay> Displays => new List<BaseDisplay>()
        {
            log,
            clockDisplay,
            Input.CreateDisplay(0, -3, -1, 3),
            deathsDisplay,
            populationDisplay,
            birthsDisplay
        };

        private List<string> Commands = new List<string>()
        {
            "AddAdult",
            "AddChild",
            "KillHuman",
            "AnnounceJobs",
            "AnnouncePayday",
            "AnnounceFamily",
            "AnnounceDeath"
        };


        Population population = Population.Instance;
        public override void PassTime(int deltaTime)
        {
            clockDisplay.Value = time.ToString("mm:ss");
            time = time.AddSeconds(1);
            deathsDisplay.Value = "Deaths: " + population.Deaths.ToString();
            populationDisplay.Value = "Population: " + population.Count.ToString();
            birthsDisplay.Value = "Births: " + population.Births.ToString();

            if (time.Minute == 0 && time.Second == 30)
            {
                population.GetJobs();
                LogAnnouncements(announceJob);
            }

            if (time.Minute == 1 && time.Second == 30)
            {
                population.Payday();
                population.ReducePopulationHunger();
                LogAnnouncements(announcePayday);
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
                LogAnnouncements(announceFamily);
            }

            if (time.Minute == 3)
            {
                population.CheckHunger();
                population.CheckAge();
                LogAnnouncements(announceDeath);

                time = new DateTime();

                population.AgeUpPopulation();
            }

            while (Input.HasInput)
            {
                Input.SetAutoCompleteWordList(Commands);

                switch (Input.Consume())
                {
                    case "AddAdult":
                        population.AddHuman(new Adult());
                        log.Log("Added new Adult");
                        break;
                    case "AddChild":
                        population.AddHuman(new Child());
                        log.Log("Added new child");
                        break;
                    case "KillHuman":
                        population.KillHuman(Globals.random.Next(0, population.Count));
                        break;
                    case "AnnounceJobs":
                        announceJob = !announceJob;
                        if (announceJob)
                        {
                            log.Log("Showing job announcements!");
                        }
                        else
                        {
                            log.Log("Hiding job announcements!");
                        }
                        break;
                    case "AnnouncePayday":
                        announcePayday = !announcePayday;
                        if (announcePayday)
                        {
                            log.Log("Showing payday announcements!");
                        }
                        else
                        {
                            log.Log("Hiding payday announcements!");
                        }
                        break;
                    case "AnnounceDeaths":
                        announceDeath = !announceDeath;
                        if (announceDeath)
                        {
                            log.Log("Showing death announcements!");
                        }
                        else
                        {
                            log.Log("Hiding death announcements!");
                        }
                        break;
                    case "AnnounceFamily":
                        announceFamily = !announceFamily;
                        if (announceFamily)
                        {
                            log.Log("Showing family announcements!");
                        }
                        else
                        {
                            log.Log("Hiding family announcements!");
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        private void LogAnnouncements(bool announce)
        {
            if (announce)
            {
                foreach (var announcement in population.Announce())
                {
                    log.Log(announcement);
                }
                
            }
            population.ClearAnnouncements();
        }

    }
}

