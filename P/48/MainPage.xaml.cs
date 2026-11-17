using Microcharts;
using SkiaSharp;

namespace Ejemplo {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            CrearGrafico();
        }
        void CrearGrafico() {
            var Entradas = new[]
            {
                new ChartEntry(45)
                {
                    Label = "Enero",
                    ValueLabel = "45",
                    Color = SKColor.Parse("#266489")
                },
                new ChartEntry(60)
                {
                    Label = "Febrero",
                    ValueLabel = "60",
                    Color = SKColor.Parse("#68B9C0")
                },
                new ChartEntry(37)
                {
                    Label = "Marzo",
                    ValueLabel = "37",
                    Color = SKColor.Parse("#A8B9C0")
                },
                new ChartEntry(78)
                {
                    Label = "Abril",
                    ValueLabel = "78",
                    Color = SKColor.Parse("#C8A0D4")
                },
                new ChartEntry(59)
                {
                    Label = "Mayo",
                    ValueLabel = "59",
                    Color = SKColor.Parse("#BCDEAB")
                }
            };

            VistaGrafico.Chart = new BarChart {
                Entries = Entradas
            };
        }
    }
}
