using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public static class Couple
    {
        
        public static bool MakeCouple(Adult adult1, Adult adult2, int chance)
        {
            int tempChance = Globals.random.Next(0, chance);
            if ((adult1.Parent1 == adult2.Parent1) && (adult1.Parent2 == adult2.Parent2))
            {
                if (adult1.Parent1 != null || adult1.Parent2 != null)
                {
                    return false;
                }
            }
            if ((!adult1.HasPartner && !adult2.HasPartner)&& (adult1 != adult2) && (tempChance == chance - 1))
            {
                adult1.Partner = adult2;
                adult2.Partner = adult1;

                adult1.HasPartner = true;
                adult2.HasPartner = true;

                return true;
            }
            return false;
        }

        public static void BreakUp(Adult adult)
        {
            if (adult.HasPartner)
            {
                adult.Partner.HasPartner = false;
                adult.Partner.Partner = null;

                adult.Partner = null;
                adult.HasPartner = false;
            }
        }

        public static Child MakeChild(Adult adult, int chance)
        {
            int tempChance = Globals.random.Next(0, chance);
            if (adult.HasPartner && tempChance == chance - 1)
            {
                Child child = new Child
                {
                    Parent1 = adult,
                    Parent2 = adult.Partner
                };

                //if (adult.Parent1 != null)
                //{
                //    adult.Parent1.Children[adult.Parent1.Children.IndexOf(adult)].Children.Add(child);
                //}

                //if (adult.Parent2 != null)
                //{
                //    adult.Parent2.Children[adult.Parent2.Children.IndexOf(adult)].Children.Add(child);
                //}

                adult.Children.Add(child);
                adult.Partner.Children.Add(child);



                return child;
            }
            return null;
        }
    }
}
