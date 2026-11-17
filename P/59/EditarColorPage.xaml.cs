namespace Ejemplo;

public partial class EditarColorPage : ContentPage {
    private readonly HttpClient cliente = new();

    private int codigo;

    public EditarColorPage(
        int codigoColor,
        string nombreColor) {
        InitializeComponent();

        codigo = codigoColor;

        txtCodigo.Text = codigoColor.ToString();
        txtNombre.Text = nombreColor;
    }

    private async void Guardar_Clicked(object sender, EventArgs e) {
        var datos = new Dictionary<string, string>
            {
                {"codigo", codigo.ToString() },
                {"nombre", txtNombre.Text}
            };

        var contenido = new FormUrlEncodedContent(datos);

        string url = "http://localhost/actualizarcolor.php";

        await cliente.PostAsync(url, contenido);
        await Navigation.PopAsync();
    }
}