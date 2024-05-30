using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF10
{
    abstract class Size
    {
        public virtual int Multi()
        {
            return 0;
        }
        
    }

    class S : Size
    {

        private static S instance;
        public override int Multi()
        {
            return 1;
        }
        public static S Instance()
        {
            if (instance == null)
            {
                instance = new S();
            }
            return instance;
        }
    }

    class M : Size
    {
        private static M instance;
        public override int Multi()
        {
            return 2;
        }

        public static M Instance()
        {
            if (instance == null)
            {
                instance = new M();
            }
            return instance;
        }
    }

    class L : Size
    {
        private static L instance;
        public override int Multi()
        {
            return 3;
        }

        public static L Instance()
        {
            if (instance == null)
            {
                instance = new L();
            }
            return instance;
        }
    }

    class XL : Size
    {
        private static XL instance;
        public override int Multi()
        {
            return 4;
        }

        public static XL Instance()
        {
            if (instance == null)
            {
                instance = new XL();
            }
            return instance;
        }
    }


}
