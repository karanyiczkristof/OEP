using System;

namespace HF3
{

    public class Diag
    {

        public class OutOfRangeException : Exception;
        public class NonDiagonalAssignment : Exception;
        public class NonMatchingDimensions : Exception;

        List<double> x = new List<double>();

        public Diag(int n)
        {
            for (int i = 0; i < n; i++)
            {
                x.Add(0);
            }
        }

        public double Get(int i, int j)
        {
            if (!(i >= 0 && i < x.Count) || !(j >= 0 && j < x.Count))
            {
                throw new OutOfRangeException();
            }
            if (i == j)
            {
                return x[i];
            }
            else
            {
                return 0.0;
            }
        }

        public void Set(int i, int j, double e)
        {
            if (!(i >= 0 && i < x.Count) || !(j >= 0 && j < x.Count))
            {
                throw new OutOfRangeException();
            }
            if (i == j)
            {
                x[i] = e;
            }
            else
            {
                throw new NonDiagonalAssignment();
            }
        }

        public static Diag Add(Diag a, Diag b)
        {
            if (a.x.Count != b.x.Count)
            {
                throw new NonMatchingDimensions();
            }
            Diag c = new Diag(a.x.Count);
            for (int i = 0; i < c.x.Count; i++)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }

        public static Diag Multiply(Diag a, Diag b)
        {
            if (a.x.Count != b.x.Count)
            {
                throw new NonMatchingDimensions();
            }
            Diag c = new Diag(a.x.Count);
            for (int i = 0; i < c.x.Count; i++)
            {
                c.x[i] = a.x[i] * b.x[i];
            }
            return c;
        }

        public static Diag operator +(Diag a, Diag b)
        {
            return Diag.Add(a, b);
        }

        public static Diag operator *(Diag a, Diag b)
        {
            return Diag.Multiply(a, b);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < x.Count; i++)
            {
                for (int j = 0; j < x.Count; j++)
                {
                    str += "\t" + Get(i, j);
                }
                str += "\n";
            }
            return str;
        }
    }
    public class Program
    {
        static void CreateDiag()
        {
            int size = int.Parse(Console.ReadLine());
            try
            {
                Diag a = new Diag(size);
                Console.WriteLine("Konstruktor - korrekt");
            }
            catch (Exception e)
            {
                Console.WriteLine("Konstruktor - hiba");
            }
        }
        static void TestGet()
        {
            int size = int.Parse(Console.ReadLine());
            try
            {
                Diag a = new Diag(size);
                int changes = int.Parse(Console.ReadLine());
                string[] input;
                for (int i = 0; i < changes; i++)
                {
                    input = Console.ReadLine().Split();
                    a.Set(int.Parse(input[0]), int.Parse(input[1]), double.Parse(input[2]));
                }
                int gets = int.Parse(Console.ReadLine());
                for (int i = 0; i < gets; i++)
                {
                    input = Console.ReadLine().Split();
                    Console.WriteLine($"{a.Get(int.Parse(input[0]), int.Parse(input[1]))}");
                }
                Console.WriteLine("GetTest vége");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get hiba");
            }
        }
        static void TestSet()
        {
            int size = int.Parse(Console.ReadLine());
            try
            {
                Diag a = new Diag(size);
                int changes = int.Parse(Console.ReadLine());
                string[] input;
                for (int i = 0; i < changes; i++)
                {
                    input = Console.ReadLine().Split();
                    a.Set(int.Parse(input[0]), int.Parse(input[1]), double.Parse(input[2]));
                    Console.WriteLine($"{a.Get(int.Parse(input[0]), int.Parse(input[1]))}");
                }
                Console.WriteLine("SetTest vége");
            }
            catch (Exception e)
            {
                Console.WriteLine("Set hiba");
            }
        }
        static void TestAdd()
        {
            int size;
            int changes;
            string[] input;
            size = int.Parse(Console.ReadLine());
            Diag a = new Diag(size);
            changes = int.Parse(Console.ReadLine());
            for (int i = 0; i < changes; i++)
            {
                input = Console.ReadLine().Split();
                a.Set(int.Parse(input[0]), int.Parse(input[1]), double.Parse(input[2]));
            }
            size = int.Parse(Console.ReadLine());
            Diag b = new Diag(size);
            changes = int.Parse(Console.ReadLine());
            for (int i = 0; i < changes; i++)
            {
                input = Console.ReadLine().Split();
                b.Set(int.Parse(input[0]), int.Parse(input[1]), double.Parse(input[2]));
            }
            try
            {
                Diag c = Diag.Add(a, b);
                Diag d = a + b;
                int gets = int.Parse(Console.ReadLine());
                for (int i = 0; i < gets; i++)
                {
                    input = Console.ReadLine().Split();
                    Console.WriteLine($"{c.Get(int.Parse(input[0]), int.Parse(input[1]))}");
                    Console.WriteLine($"{d.Get(int.Parse(input[0]), int.Parse(input[1]))}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Összeadás hiba");
            }
        }
        static void TestMultiply()
        {
            int size;
            int changes;
            string[] input;
            size = int.Parse(Console.ReadLine());
            Diag a = new Diag(size);
            changes = int.Parse(Console.ReadLine());
            for (int i = 0; i < changes; i++)
            {
                input = Console.ReadLine().Split();
                a.Set(int.Parse(input[0]), int.Parse(input[1]), double.Parse(input[2]));
            }
            size = int.Parse(Console.ReadLine());
            Diag b = new Diag(size);
            changes = int.Parse(Console.ReadLine());
            for (int i = 0; i < changes; i++)
            {
                input = Console.ReadLine().Split();
                b.Set(int.Parse(input[0]), int.Parse(input[1]), double.Parse(input[2]));
            }
            try
            {
                Diag c = Diag.Multiply(a, b);
                Diag d = a * b;
                int gets = int.Parse(Console.ReadLine());
                for (int i = 0; i < gets; i++)
                {
                    input = Console.ReadLine().Split();
                    Console.WriteLine($"{c.Get(int.Parse(input[0]), int.Parse(input[1]))}");
                    Console.WriteLine($"{d.Get(int.Parse(input[0]), int.Parse(input[1]))}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Szorzás hiba");
            }
        }
        static void Main(string[] args)
        {
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    CreateDiag();
                    break;
                case 1:
                    TestGet();
                    break;
                case 2:
                    TestSet();
                    break;
                case 3:
                    TestAdd();
                    break;
                case 4:
                    TestMultiply();
                    break;
            }
        }
    }
}