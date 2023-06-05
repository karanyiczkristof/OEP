using System;
using System.Collections.Generic;
using System.Text;

namespace Vadaszat
{
    class Vad
    {
        public int tomeg;
        protected bool him;

        public bool GetHim()
        {
            return him;
        }

        public virtual bool IsElefant()
        {
            return false;
        }

        public virtual bool IsOrrszarvu()
        {
            return false;
        }

        public virtual bool IsOroszlan()
        {
            return false;
        }

        protected Vad(int t, bool h)
        {
            tomeg = t;
            him = h;
        }
    }

        class Elefant : Vad
        {
            public int jobb;
            public int bal;

            public override bool IsElefant()
            {
                return true;
            }

            public Elefant(int tomeg, int jobb, int bal, bool him) : base(tomeg, him)
            {
                this.jobb = jobb;
                this.bal = bal;
            }
        }

        class Orrszarvu : Vad
        {
            public int szarv;

            public override bool IsOrrszarvu()
            {
                return true;
            }

            public Orrszarvu(int tomeg, int szarv, bool him) : base(tomeg, him)
            {
                this.szarv = szarv;
            }
        }


        class Oroszlan : Vad
        {
            public override bool IsOroszlan()
            {
                return true;
            }

            public Oroszlan(int tomeg, bool him) : base(tomeg, him) { }
        }






    

    

}
