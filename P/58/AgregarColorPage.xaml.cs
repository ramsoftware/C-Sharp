namespace Ejemplo;

public partial class AgregarColorPage : ContentPage {
    private readonly HttpClient cliente = new();

    public AgregarColorPage() {
        InitializeComponent();
    }

    private async void Guardar_Clicked(object sender, EventArgs e) {
        try {
            string nombre = txtNombre.Text;
            if (string.IsNullOrWhiteSpace(nombre)) {
                await DisplayAlertAsync("Validación", "Debe ingresar un nombre", "Aceptar");
                return;
            }

            var datos = new Dictionary<string, string> {{ "nombre", nombre }};
            var contenido = new FormUrlEncodedContent(datos);
            string url = "http://localhost/guardarcolor.php";
            HttpResponseMessage respuesta = await cliente.PostAsync(url, contenido);
            string mensaje = await respuesta.Content.ReadAsStringAsync();
            await DisplayAlertAsync("Información", mensaje, "Aceptar");
            await Navigation.PopAsync();
        }
        catch (Exception ex) {
            await DisplayAlertAsync("Error", ex.Message, "Aceptar");
        }
    }
}