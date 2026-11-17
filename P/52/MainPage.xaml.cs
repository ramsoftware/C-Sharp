using Microcharts;
using SkiaSharp;

namespace Ejemplo {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            CrearGrafico();
        }
        void CrearGrafico() {

            //Gráfico de radar para mostrar el rendimiento en diferentes áreas
            var Entradas = new[]
            {
                new ChartEntry(30) { Label = "Análisis", ValueLabel = "30", Color = SKColors.Blue },
                new ChartEntry(65) { Label = "Diseño", ValueLabel = "65", Color = SKColors.Green },
                new ChartEntry(90) { Label = "Implementación", ValueLabel = "90", Color = SKColors.Red },
                new ChartEntry(70) { Label = "Evaluación", ValueLabel = "70", Color = SKColors.Purple }
            };

            VistaGrafico.Chart = new RadarChart {
                Entries = Entradas,
                LineSize = 6
            };

        }
    }
}
