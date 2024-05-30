using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando
{
    class Layer
    {
        public char Material { get; private set; }
        public double Thickness { get; set; }

        public Layer(char material, double thickness)
        {
            Material = material;
            Thickness = thickness;
        }

        public static Layer Parse(string line)
        {
            var parts = line.Split(' ');
            var material = parts[0][0];
            var thickness = double.Parse(parts[1], CultureInfo.InvariantCulture);
            return new Layer(material, thickness);
        }

        public double Transform(char weather, out char transformedMaterial)
        {
            double transformedThickness = 0;
            transformedMaterial = Material;

            switch (Material)
            {
                case 'z':
                    if (weather == 'm')
                    {
                        transformedThickness = Thickness * 0.05;
                        transformedMaterial = 'x';
                        Thickness *= 0.95;
                    }
                    break;

                case 'x':
                    if (weather == 'z')
                    {
                        transformedThickness = Thickness * 0.5;
                        transformedMaterial = 'z';
                        Thickness *= 0.5;
                    }
                    else if (weather == 'n')
                    {
                        transformedThickness = Thickness * 0.05;
                        transformedMaterial = 'z';
                        Thickness *= 0.95;
                    }
                    else
                    {
                        transformedThickness = Thickness * 0.15;
                        transformedMaterial = 's';
                        Thickness *= 0.85;
                    }
                    break;

                case 's':
                    if (weather == 'n')
                    {
                        transformedThickness = Thickness * 0.05;
                        transformedMaterial = 'x';
                        Thickness *= 0.95;
                    }
                    break;
            }

            return transformedThickness;
        }

        public void ReactToWeather(char weather)
        {
            switch (Material)
            {
                case 'z':
                    if (weather == 'm')
                    {
                        Thickness *= 0.95;
                    }
                    break;

                case 'x':
                    if(weather == 'z')
                    {
                        Thickness *= 0.5;
                    } else if (weather == 'n')
                    {
                        Thickness *= 0.95;
                    } else
                    {
                        Thickness *= 0.85;
                    }
                    break;

                case 's':
                    if (weather == 'n')
                    {
                        Thickness *= 0.95;
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Material} {Thickness}";
        }
    }

}
