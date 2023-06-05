using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmadikBead
{
    abstract class Registration
    {

        public abstract int GetSize(); 
       
        
    }


    class File : Registration
    {
        private int size;

        public File(int s) 
        {
            size = s;
        }
        public override int GetSize()
        {
            return size;
        }
    }

    class Folder : Registration
    {

        private List<Registration> items = new List<Registration>();
        public override int GetSize()
        {
            int sum = 0;

            foreach (Registration b in items)
            {
                sum += b.GetSize();
            }
            return sum;
        }

        public void Add(Registration r)
        {
            items.Add(r);
        }
    }

    class FileSystem : Folder
    {
        
    }

}
