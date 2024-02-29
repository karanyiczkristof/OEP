using System;

namespace HF1
{
    internal class Rac
    {
        private int n; 
        private int d; 

        public Rac(int i, int j)
        {
            if (j == 0)
                throw new ArgumentException("Denominator can't be zero");
            n = i;
            d = j;
        }

        public static Rac Add(Rac a, Rac b)
        {
            return new Rac(a.n * b.d + a.d * b.n, a.d * b.d);
        }

        public static Rac Sub(Rac a, Rac b)
        {
            return new Rac(a.n * b.d - a.d * b.n, a.d * b.d);
        }

        public static Rac Mul(Rac a, Rac b)
        {
            return new Rac(a.n * b.n, a.d * b.d);
        }

        public static Rac Div(Rac a, Rac b)
        {
            if (b.n == 0)
                throw new DivideByZeroException("Can't divide by zero");
            return new Rac(a.n * b.d, a.d * b.n);
        }

        public override string ToString()
        {
            return $"{n}/{d}";
        }
    }

    internal class Program
    {
        static void CreateRational()
        {
            int n, d = 1;
            string[] input;
            bool correct;
            do
            {
                input = Console.ReadLine().Split();
                correct = int.TryParse(input[0], out n);
                correct = correct && int.TryParse(input[1], out d);
            } while (!correct);
            try
            {
                Rac a = new Rac(n, d);
                Console.WriteLine(a);
            }
            catch (Exception e)
            {
                Console.WriteLine("Konstruktor - sikertelen");
            }
        }

        static void IsStatic()
        {
            try
            {
                int n, d = 1;
                string[] input;
                Rac a, b, c;
                bool correct;
                do
                {
                    input = Console.ReadLine().Split();
                    correct = int.TryParse(input[0], out n);
                    correct = correct && int.TryParse(input[1], out d);
                } while (!correct);
                a = new Rac(n, d);
                do
                {
                    input = Console.ReadLine().Split();
                    correct = int.TryParse(input[0], out n);
                    correct = correct && int.TryParse(input[1], out d);
                } while (!correct);
                b = new Rac(n, d);
                c = Rac.Add(a, b);
                Console.WriteLine(c);
                c = Rac.Sub(a, b);
                Console.WriteLine(c);
                c = Rac.Mul(a, b);
                Console.WriteLine(c);
                c = Rac.Div(a, b);
                Console.WriteLine(c);
            }
            catch (Exception e)
            {
                Console.WriteLine("Statikus metódusok - sikertelen");
            }
        }

        static void IsOverwritten()
        {
            try
            {
                int n, d = 1;
                string[] input;
                Rac a, b, c;
                bool correct;
                do
                {
                    input = Console.ReadLine().Split();
                    correct = int.TryParse(input[0], out n);
                    correct = correct && int.TryParse(input[1], out d);
                } while (!correct);
                a = new Rac(n, d);
                do
                {
                    input = Console.ReadLine().Split();
                    correct = int.TryParse(input[0], out n);
                    correct = correct && int.TryParse(input[1], out d);
                } while (!correct);
                b = new Rac(n, d);
                c = Rac.Add(a,b);
                Console.WriteLine(c);
                c = Rac.Sub(a,b);
                Console.WriteLine(c);
                c = Rac.Mul(a,b);
                Console.WriteLine(c);
                c = Rac.Div(a,b);
                Console.WriteLine(c);
            }
            catch (Exception e)
            {
                Console.WriteLine("Operátor felülírás - sikertelen");
            }
        }

        static void NoZeroDivision()
        {
            int n, d = 1;
            string[] input;
            Rac a, b, c;
            bool correct;
            do
            {
                input = Console.ReadLine().Split();
                correct = int.TryParse(input[0], out n);
                correct = correct && int.TryParse(input[1], out d);
            } while (!correct);
            a = new Rac(n, d);
            do
            {
                input = Console.ReadLine().Split();
                correct = int.TryParse(input[0], out n);
                correct = correct && int.TryParse(input[1], out d);
            } while (!correct);
            b = new Rac(n, d);
            try
            {
                c = Rac.Div(a,b);
                Console.WriteLine(c);
            }
            catch (Exception e)
            {
                Console.WriteLine("Az osztás sikertelen");
            }
        }

        static void Main(string[] args)
        {
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    CreateRational();
                    break;
                case 1:
                    IsStatic();
                    break;
                case 2:
                    IsOverwritten();
                    break;
                case 3:
                    NoZeroDivision();
                    break;
            }

        }
    }
}
