using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;

namespace Nagybeadando
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Adja meg a fájl nevét:");
            string fileName = Console.ReadLine();
            string[] lines = File.ReadAllLines(fileName);

            string weatherPattern = lines[0];
            List<Layer> layers = new List<Layer>();

            for (int i = 1; i < lines.Length; i++)
            {
                layers.Add(Layer.Parse(lines[i]));
            }

            Atmosphere atmosphere = new Atmosphere(layers);
            Simulation simulation = new Simulation(atmosphere, weatherPattern);
            simulation.Run();
        }
    }
}
