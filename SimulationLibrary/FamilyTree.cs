using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLibrary
{
    public class FamilyTree
    {
        private List<Human> children  = new List<Human>();

        public void Add(Human human)
        {
            children.Add(human);
        }

        public void Remove(Human human)
        {
            children.Remove(human);
        }

        public int Count()
        {
            return children.Count;
        }

        public string GetChildName(int index)
        {
            return children[index].Name;
        }
    }
}
