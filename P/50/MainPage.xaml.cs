using Microcharts;
using SkiaSharp;

namespace Ejemplo {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            CrearGrafico();
        }
        void CrearGrafico() {

            //Gráfico de puntos
            var entries = new[]
            {
                new ChartEntry(5)  { Label = "A", ValueLabel = "5", Color = SKColors.Red },
                new ChartEntry(15) { Label = "B", ValueLabel = "15", Color = SKColors.Green },
                new ChartEntry(35) { Label = "C", ValueLabel = "35", Color = SKColors.Blue },
                new ChartEntry(20) { Label = "D", ValueLabel = "20", Color = SKColors.Orange }
            };

            VistaGrafico.Chart = new PointChart {
                Entries = entries,
                PointSize = 18
            };

        }
    }
}
