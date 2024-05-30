using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF10
{
    internal class Gift
    {
        private Size size;
        public TargetShot targetShot;


        public int Value()
        {
            return Point() * size.Multi();
        }

        public virtual int Point()
        {
            return 0;
        }

        protected Gift(Size size)
        {
            this.size = size;
        }
    }
    class Ball : Gift
    {
        public override int Point()
        {
            return 1;
        }

        public Ball(Size size) : base(size) { }
    }


    class Figure : Gift
    {
        public override int Point()
        {
            return 2;
        }

        public Figure(Size size) : base(size) { }
    }

    class Plush : Gift
    {
        public override int Point()
        {
            return 3;
        }

        public Plush(Size size) : base(size) { }
    }
}
