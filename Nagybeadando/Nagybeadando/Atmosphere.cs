using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando
{

    class Atmosphere
    {
        public List<Layer> Layers { get; private set; }

        public Atmosphere(List<Layer> layers)
        {
            Layers = layers;    
        }

        public void ApplyWeather(char weather)
        {
            List<(char material, double thickness)> transformedLayers = new List<(char material, double thickness)>();

            foreach (var layer in Layers)
            {
                char transformedMaterial;
                double transformedThickness = layer.Transform(weather, out transformedMaterial);
                if (transformedThickness > 0)
                {
                    transformedLayers.Add((transformedMaterial, transformedThickness));
                }
                layer.ReactToWeather(weather);
            }

            AdjustLayers();

            foreach (var (material, thickness) in transformedLayers)
            {
                ApplyTransformation(material, thickness);
            }
        }

        private void ApplyTransformation(char material, double thickness)
        {
            for (int i = Layers.Count - 1; i >= 0; i--)
            {
                if (Layers[i].Material == material)
                {
                    Layers[i].Thickness += thickness;
                    return;
                }
            }

            if (thickness >= 0.5)
            {
                Layers.Insert(0, new Layer(material, thickness));
            }
        }

        public void AdjustLayers()
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                if (Layers[i].Thickness <= 0.5)
                {
                    double excessThickness = Layers[i].Thickness;
                    Layers[i].Thickness = 0;
                    CombineWithUpperLayer(Layers[i].Material, excessThickness, i);
                }
            }
            RemoveEmptyLayers();
        }

        private void CombineWithUpperLayer(char material, double thickness, int startIndex)
        {
            for (int i = startIndex + 1; i < Layers.Count; i++)
            {
                if (Layers[i].Material == material)
                {
                    Layers[i].Thickness += thickness;
                    return;
                }
            }
            if (thickness >= 0.5)
            {
                Layers.Insert(0, new Layer(material, thickness));
            }
        }

        public void RemoveEmptyLayers()
        {
            Layers = Layers.Where(layer => layer.Thickness > 0).ToList();
        }

        public void Simulate(char weather)
        {
            ApplyWeather(weather);
            AdjustLayers();
            RemoveEmptyLayers();
        }

        public override string ToString()
        {
            return string.Join("\n", Layers.Select(layer => $"{layer.Material} {layer.Thickness}"));
        }
    }

}
