using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF10
{
    internal class AmPark
    {


        private List<Guest> guests;
        private List<TargetShot> targetShots = new List<TargetShot>();
        
        public AmPark(List<TargetShot> t)
        {
            if(t.Count < 2)
            {
                throw new Exception("The length is less than 2");
            }
            else
            {
                targetShots = t;
                guests = new List<Guest>();
            }
        }

        public string Best(TargetShot t)
        {
            if(guests.Count == 0)
            {
                throw new InvalidOperationException("There are no guests");
            }

            int maxResult = 0;
            string guestName = null;

            foreach(Guest guest in guests)
            {
                int result = guest.Result(t);

                if(result > maxResult)
                {
                    maxResult = result;
                    guestName = guest.getName();
                }
            }
            return guestName;
        }

        public void Receives(Guest g)
        {
            if (guests.Contains(g))
            {
                throw new InvalidOperationException("The guest is already in the Park");
            }
            else
            {
                guests.Add(g);
            }
        }
    }
}
