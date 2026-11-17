using System.Text.Json;

namespace Ejemplo {
    public partial class MainPage : ContentPage {
        private readonly HttpClient cliente = new HttpClient();

        public MainPage() {
            InitializeComponent();
            CargarPagina();
        }

        private async Task CargarPagina() {
            string url = $"http://localhost/MAUI/colores.php";

            string recibeJSON = await cliente.GetStringAsync(url);

            List<Colores> lista =
                JsonSerializer.Deserialize<List<Colores>>
                (
                    recibeJSON,
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                );

            ListaColores.ItemsSource = lista;
        }
    }
}