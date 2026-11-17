using System.Text.Json;

namespace Ejemplo {
    public partial class MainPage : ContentPage {
        private readonly HttpClient cliente = new HttpClient();

        public MainPage() {
            InitializeComponent();
        }

        private async void ObtenerDatos(object sender, EventArgs e) {
            string url = "http://localhost/datos.php";

            string RecibeJSON = await cliente.GetStringAsync(url);

            //JSON recibido del servidor es interpretado
            Persona persona = JsonSerializer.Deserialize<Persona>(
                RecibeJSON,
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                }
            );

            lblNombre.Text = "Nombre: " + persona.Nombre;
            lblEdad.Text = "Edad: " + persona.Edad;
            lblCiudad.Text = "Ciudad: " + persona.Ciudad;
        }
    }
}