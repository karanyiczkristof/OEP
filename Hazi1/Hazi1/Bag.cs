using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Hazi1
{
    class Pair<Element>
    {   
        public int count;
        public Element data;



        public Pair(int c, Element e)
        {
            count = c;
            data = e;
        }

       
    }

    public class Bag<Element> where Element : IComparable<Element> 
    {
        private List<Pair<Element>> seq;
        private int maxind = 0;

        public Bag()
        {
            seq = new List<Pair<Element>>();
        }

        public void SetEmpty()
            {
                seq = new List<Pair<Element>>();
            }

        public bool Empty()
        {
            return seq.Count == 0;
        }

        public int Multipl(Element e)
        {
           (bool l,int ind) = LogSearch(e);
            if (l)
            {
                return seq[ind-1].count;
            }
            else
            {
                return 0;
            }
        }

        public Element Max()
        {
            if(seq.Count > 0)
            {
                return seq[maxind-1].data;
            }
            return default(Element);
        }

        public void Insert(Element e)
        {
            (bool l,int ind) = LogSearch(e);
           
            if (l)
            {
                ++seq[ind-1].count;
                if (seq[ind-1].count > seq[maxind-1].count)
                {
                    maxind = ind;
                }
            }
            else
            {
                List<Pair<Element>> seq2 = new List<Pair<Element>>();
                for (int i = 1; i < seq.Count; i++)
                {
                    seq2.Add(seq[i]);

                }

                for (int i = 0; i < ind-2; i++)
                {
                    seq.Add(seq2[i]);

                }
                seq.Add(new Pair<Element>(1,e)); 
                for (int i = ind+1; i < seq2.Count; i++)
                {
                    seq.Add(seq2[i]);
                }
                if (seq.Count == 1)
                {
                    maxind = 1;
                }
                else if(maxind > ind)
                {
                    ++maxind;
                }
            }
        }

        public void Remove(Element e)
        {
            (bool l, int ind) = LogSearch(e);
            if (l)
            {
                ++seq[ind-1].count;
                if (seq[ind-1].count > 1)
                {
                    --seq[ind-1].count;
                }
                else if (seq[ind-1].count == 1)
                {
                    List<Pair<Element>> seq2 = new List<Pair<Element>>();
                    for (int i = 1; i <= ind-1; i++)
                    {
                        seq[i] = seq2[i];

                    }
                    for (int i = ind + 1; i <= seq.Count; i++)
                    {
                        seq[i] = seq2[i];
                    }

                }
                if (seq.Count > 0)
                {
                    int max = 0;
                    for(int i = 1; i < seq.Count; i++)
                    {
                        if (seq[i].count > max)
                        {
                            max = seq[i].count;
                        }
                    }
                    maxind = max;
                }

            }

        }

        private (bool,int) LogSearch(Element e)
        {
            int ind = 0;
            bool l = false;
            int ah = 1;
            int fh = seq.Count;
            while (!l && ah <= fh)
            {
                ind = ((ah + fh) / 2);
                if (seq[ind-1].data.CompareTo(e) > 0)
                {
                    fh = ind - 1;
                }
                else if (seq[ind-1].data.CompareTo(e) == 0)
                {
                    l = true;
                }
                else if (seq[ind-1].data.CompareTo(e) < 0)
                {
                    ah = ind + 1;
                }
                
            }
            if (!l)
            {
                ind = ah;
            }
            return (l, ind);
        }
    }
}