using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimulationLibrary
{
    public class Population
    {
        public List<Human> Humans { get; private set; }
        public int Deaths { get; private set; }
        public int Births { get; set; }
        public int Count => Humans.Count;
        public List<string> Announcements { get; private set; }

        private static Population instance = new Population();

        /// <summary>
        /// Returns an instance of Population with 10 initial Adults
        /// </summary>
        public static Population Instance => instance;



        private Population()
        {
            Humans = new List<Human>();
            Announcements = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                AddHuman(new Adult());
            }
        }

        public void AddHuman(Human human)
        {
            Humans.Add(human);
        }

        public void ReducePopulationHunger()
        {
            foreach (var human in Humans)
            {
                human.ReduceHunger(20);
            }
        }

        public void CreateCouples()
        {
            int partnerIndex;
            bool isCouple;

            foreach (Adult adult in Humans.Where(x => x.IsAdult))
            {
                do
                {
                    partnerIndex = Globals.random.Next(Humans.IndexOf(adult), Humans.Count);
                } while (!Humans[partnerIndex].IsAdult && Humans[partnerIndex].Name != adult.Name);

                isCouple = Couple.MakeCouple((Adult)adult, (Adult)Humans[partnerIndex], 3);

                if (isCouple)
                {
                    Announcements.Add($"{adult.Name} and {Humans[partnerIndex].Name} has become a couple");
                }
            }
        }

        public void AgeUpPopulation()
        {
            foreach (var human in Humans)
            {
                human.Age++;
            }
        }

        public void MakeChildrenAdults()
        {
            for (int i = 0; i < Humans.Count; i++)
            {
                if (!Humans[i].IsAdult && Humans[i].Age > 3)
                {
                    Humans[i] = new Adult((Child)Humans[i]);
                    Announcements.Add($"{Humans[i].Name} became an adult!");
                }
            }
        }

        public void MakeChildren()
        {
            List<Child> temp = new List<Child>();
            Child tempChild;

            foreach (Adult adult in Humans.Where(x => x.IsAdult))
            {
                if (adult.HasPartner)
                {
                    tempChild = Couple.MakeChild(adult, 5);

                    if (tempChild != null)
                    {
                        temp.Add(tempChild);
                    }
                }
            }

            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    Announcements.Add($"{temp[i].Name} has been born!");
                    Births++;
                    Humans.Add(temp[i]);
                }
            }
        }

        public void CheckHunger()
        {
            for (int i = 0; i < Humans.Count; i++)
            {
                if (Humans[i].Hunger == 0)
                {
                    KillHuman(i);
                }
            }
        }

        public void CheckAge()
        {
            for (int i = 0; i < Humans.Count; i++)
            {
                if (Humans[i].Age == 100)
                {
                    KillHuman(i);
                }
            }
        }

        public void GetJobs()
        {
            foreach (var human in Humans)
            {
                if(human.Occupation.Name == "Unemployed")
                {
                    if (human.IsAdult)
                    {
                        human.GetOccupation(4);
                        if (human.Occupation.Name != "Unemployed")
                        {
                            Announcements.Add($"{human.Name} has gotten a job as a {human.Occupation.Name}");
                        }
                    }
                    else
                    {
                        human.GetOccupation(4);
                        if(human.Occupation.Name != "Unemployed")
                        {
                            Announcements.Add($"{human.Name} has started School");
                        }
                    }
                }
            }
        }

        public void Payday()
        {
            foreach (var human in Humans)
            {
                human.Occupation.GetSalary(human);
                Announcements.Add($"{human.Name} has earned {human.Occupation.Salary} today");
            }
        }

        public void FoodShopping()
        {
            foreach (var human in Humans)
            {
                human.BuyFood();
            }
        }

        public void EatFood()
        {
            foreach (var human in Humans)
            {
                human.EatFood();
            }
        }

        public List<string> Announce()
        {
            return Announcements;
        }

        public void ClearAnnouncements()
        {
            Announcements.Clear();
        }

        public void KillHuman(int index)
        {
            if (Humans.Count > 0)
            {
                Announcements.Add($"{Humans[index].Name} has died");
                if (Humans[index].IsAdult)
                {
                    Couple.BreakUp((Adult)Humans[index]);
                }
                Humans.RemoveAt(index);
                Deaths++;
            }
        }
    }
}
