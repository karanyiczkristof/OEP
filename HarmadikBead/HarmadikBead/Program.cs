namespace HarmadikBead
{
    internal class Program
    {
        static void Main(string[] args)
        {   

            
            File Kepek = new File(33);
            File OEP = new File(16);


            Console.WriteLine("Ennyi memóriát foglal a Képek mappa: {0}", Kepek.GetSize());
            
        }
    }
}