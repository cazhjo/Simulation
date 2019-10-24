using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Population
    {
        public List<Human> Humans { get; set; }
        private List<Couple> Couples { get; set; }
        public int Deaths { get; private set; }
        public int Births { get; set; }
        public int Count => Humans.Count;

        private static Population instance = new Population();

        /// <summary>
        /// Returns an instance of Population with 10 initial Adults
        /// </summary>
        public static Population Instance => instance;



        private Population()
        {
            Humans = new List<Human>();
            for (int i = 0; i < 10; i++)
            {
                AddHuman(new Adult());
            }
            Couples = new List<Couple>();
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
            for (int i = 0; i < Humans.Count; i++)
            {

                if (Humans[i].IsAdult && Globals.random.Next(0, 3) == 2)
                {
                    if (!Humans[i].HasPartner)
                    {
                        do
                        {
                            partnerIndex = Globals.random.Next(i, Humans.Count);
                        } while (Humans[partnerIndex].HasPartner);

                        Couples.Add(Humans[i].CoupleWith(Humans[partnerIndex]));
                    }
                }
            }
        }

        public string MakeChildrenAdults()
        {
            for (int i = 0; i < Humans.Count; i++)
            {
                if (!Humans[i].IsAdult)
                {
                    Humans[i] = new Adult((Child)Humans[i]);
                    return Humans[i].Name + "Became an adult";
                }
            }
            return null;
        }

        public void MakeChildren()
        {
            int childChance;
            foreach (var couple in Couples)
            {
                childChance = Globals.random.Next(0, 5);
                if (childChance == 4)
                {
                    Humans.Add(couple.MakeChild());
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

        private void KillHuman(int index)
        {
            Humans.RemoveAt(index);
            Deaths++;
        }
    }
}
