using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF10
{
    internal class TargetShot
    {
        private string site;
        private List<Gift> gifts;

        public List<Gift> GetGifts()
        {
            return gifts;
        }

        public TargetShot(string s)
        {
            site = s;
            gifts = new List<Gift>();
        }

        public void Shows(Gift g)
        {
            if(g.targetShot != null)
            {
                throw new Exception("Object is not null");
            }
            if (gifts.Contains(g))
            {
                throw new Exception("It's already in the gifts list");
            }
            else
            {
                g.targetShot = this;
                gifts.Add(g);
            }
            
        }
    }
}
