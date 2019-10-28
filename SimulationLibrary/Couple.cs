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
            if ((!adult1.HasPartner && !adult2.HasPartner)&& adult1 != adult2 && tempChance == chance - 1)
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
                return new Child();
            }
            return null;
        }
    }
}
