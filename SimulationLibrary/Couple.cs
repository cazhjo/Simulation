using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class Couple
    {
        public Human[] couple;

        public Couple(Human human1, Human human2)
        {
            couple = new Human[2] { human1, human2 };
            human1.HasPartner = true;
            human2.HasPartner = true;
        }

        public void BreakUp()
        {
            couple[0].HasPartner = false;
            couple[1].HasPartner = false;
            Array.Clear(couple, 0, 2);
        }

        public Child MakeChild()
        {
            return new Child();
        }
    }
}
