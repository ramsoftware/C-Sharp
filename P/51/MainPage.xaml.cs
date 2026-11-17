using Microcharts;
using SkiaSharp;

namespace Ejemplo {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            CrearGrafico();
        }
        void CrearGrafico() {

            //Gráfico de pastel
            var Entradas = new[]
            {
                new ChartEntry(40) { Label = "Exitosos", ValueLabel = "30%", Color = SKColors.Green },
                new ChartEntry(30) { Label = "Aceptables", ValueLabel = "50%", Color = SKColors.Red },
                new ChartEntry(30) { Label = "Desastrosos", ValueLabel = "20%", Color = SKColors.Gray }
            };

            VistaGrafico.Chart = new PieChart {
                Entries = Entradas,
                HoleRadius = 0.4f
            };

        }
    }
}
