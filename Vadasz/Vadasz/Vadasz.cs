using System;
using System.Collections.Generic;
using System.Text;

namespace Vadaszat
{
    class Vadasz
    {
        private string nev;
        private string szulev;
        private List<Trofea> trofeak;

        public Vadasz(string str, string ev)
        {
            nev = str;
            szulev = ev;
        }

        public void Elejt(string hol, string mikor, Vad mit)
        {
            trofeak.Add(new Trofea(hol, mikor, mit));
        }


        public int Hanyhimoroszlan()
        {

            int sum = 0;
            foreach(Trofea e in trofeak)
            {
                if(e.GetZsakmany().IsOroszlan() && e.GetZsakmany().GetHim())
                {
                    sum++;
                }
            }
            return sum;
        }

        public double MaxSzarvtomeg()
        {
            double max = 0;
            foreach(Trofea e in trofeak)
            {
                if (e.GetZsakmany().IsOrrszarvu())
                {
                    Orrszarvu o = (Orrszarvu)e.GetZsakmany();
                    double mt = o.szarv / o.tomeg;

                    if (mt > max)
                    {
                        max = mt;
                    }
                }
            }
            return max;
        }


        public bool EgyezoAgyarhossz()
        {
            bool l = false;
            foreach (Trofea e in trofeak)
            {
                if (e.GetZsakmany().IsOrrszarvu())
                {
                    Elefant eli = (Elefant)e.GetZsakmany();
                    if (eli.bal == eli.jobb)
                    {
                        l = true;
                    }

                }
            }
            return l;
        }
    }
}