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

        private async void Eliminar_Clicked(object sender, EventArgs e) {
            Button boton = (Button)sender;
            string codigo = boton.CommandParameter.ToString();
            bool borrar = await DisplayAlertAsync("Confirmación", "¿Desea borrar este registro?", "Sí", "No");
            if (borrar) {
                await EliminarColor(codigo);
            }
        }

        private async Task EliminarColor(string codigo) {
            try {
                var datos = new Dictionary<string, string>{{ "codigo", codigo }};
                var contenido = new FormUrlEncodedContent(datos);
                string url = "http://localhost/eliminarcolor.php";
                HttpResponseMessage respuesta = await cliente.PostAsync(url, contenido);
                string mensaje = await respuesta.Content.ReadAsStringAsync();
                await DisplayAlertAsync("Información", mensaje, "Aceptar");
                await CargarPagina(paginaActual);
            }
            catch (Exception ex) {
                await DisplayAlertAsync("Error", ex.Message, "Aceptar");
            }
        }
    }
}