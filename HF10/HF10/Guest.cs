using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HF10
{
    internal class Guest
    {
        private string name;

        public string getName()
        {
            return name;
        }
        private List<Gift> prizes;
        public Guest(string n)
        {
            name = n;
            prizes = new List<Gift>();
        }

        public void Wins(Gift g)
        {
            if (!g.targetShot.GetGifts().Contains(g))
            {
                throw new InvalidOperationException("The gift is not in the gifts list.");
            }
            else
            {
                g.targetShot.GetGifts().Remove(g);
                prizes.Add(g);
            }
        }
        
        public int Result(TargetShot t)
        {
            int result = 0;
            foreach(Gift e in prizes)
            {
                if(e.targetShot == t)
                {
                    result += e.Value();
                }
            }
            return result;
        }
        

    }
}
