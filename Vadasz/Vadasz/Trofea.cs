using System;
using System.Collections.Generic;
using System.Text;

namespace Vadaszat
{
    class Trofea
    {
        private string helyszin;
        private string datum;

        private Vad zsakmany;

        public Vad GetZsakmany()
        {
            return zsakmany;
        }

        public Trofea(string h, string d, Vad zs)
        {
            helyszin = h;
            datum = d;
            zsakmany = zs;
        }



    }
}
