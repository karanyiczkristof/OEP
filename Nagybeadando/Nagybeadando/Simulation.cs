using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando
{
    class Simulation
{
    private Atmosphere atmosphere;
    private string weatherPattern;

    public Simulation(Atmosphere atmosphere, string weatherPattern)
    {
        this.atmosphere = atmosphere;
        this.weatherPattern = weatherPattern;
    }

    public void Run()
    {
        int i = 0;
        while (atmosphere.Layers.Count >= 3 && atmosphere.Layers.Exists(layer => layer.Thickness >= 0.5))
        {
            char currentWeather = weatherPattern[i % weatherPattern.Length];
            atmosphere.Simulate(currentWeather);
            Console.WriteLine($"Kör: {i + 1}");
            Console.WriteLine(atmosphere);
            i++;
        }
    }
}
}
