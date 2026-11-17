using Microcharts;
using SkiaSharp;

namespace Ejemplo {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            CrearGrafico();
        }
        void CrearGrafico() {

            //Gráfico de líneas con datos de ejemplo
            var Entradas = new[]
            {
                new ChartEntry(10) { Label = "Enero", ValueLabel = "10", Color = SKColors.Blue },
                new ChartEntry(25) { Label = "Febrero", ValueLabel = "25", Color = SKColors.Blue },
                new ChartEntry(40) { Label = "Marzo", ValueLabel = "40", Color = SKColors.Blue },
                new ChartEntry(30) { Label = "Abril", ValueLabel = "30", Color = SKColors.Blue }
            };

            VistaGrafico.Chart = new LineChart {
                Entries = Entradas,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Circle,
                PointSize = 15
            };

        }
    }
}
