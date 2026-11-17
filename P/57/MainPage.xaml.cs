using System.Text.Json;

namespace Ejemplo {
    public partial class MainPage : ContentPage {
        private readonly HttpClient cliente = new HttpClient();

        private int paginaActual = 1;

        public MainPage() {
            InitializeComponent();
            CargarPagina(paginaActual);
        }

        private async Task CargarPagina(int pagina) {
            string url = $"http://localhost/colores.php?pagina={pagina}";

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

        private async void BtnSiguiente_Clicked(object sender, EventArgs e) {
            paginaActual++;
            await CargarPagina(paginaActual);
        }

        private async void BtnAnterior_Clicked(object sender, EventArgs e) {
            if (paginaActual > 1) {
                paginaActual--;
                await CargarPagina(paginaActual);
            }
        }

        private async void NuevoColor_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new AgregarColorPage());
        }

        protected override async void OnAppearing() {
            base.OnAppearing();
            await CargarPagina(1);
        }
    }
}