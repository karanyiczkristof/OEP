namespace Hazi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bag<int> bag = new Bag<int>();
            bag.Insert(12);
            System.Console.WriteLine("12");
            bag.Insert(12);
            System.Console.WriteLine("12");
            bag.Insert(13);
            System.Console.WriteLine("13");
            bag.Insert(14);
            System.Console.WriteLine("14");

            
            System.Console.WriteLine(bag.Multipl(12));
            System.Console.WriteLine(bag.Max());
            bag.Remove(14);
            System.Console.WriteLine("14 removed");
        }
    }
}