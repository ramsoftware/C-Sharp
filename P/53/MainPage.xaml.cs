namespace Ejemplo {
    public partial class MainPage : ContentPage {
        private readonly HttpClient cliente = new HttpClient();

        public MainPage() {
            InitializeComponent();
        }

        //El método debe ser async 
        private async void CuandoHaceClic(object sender, EventArgs e) {

            //¡OJO! Debe ponerse la URL o la IP de la red si prueba con Android 
            //localhost no funciona cuando emula Android porque sería el mismo teléfono
            string url = "http://localhost/enviatexto.php";

            //Espera asincrónicamente para que se complete una tarea
            //No bloquees la interfaz mientras responde el servidor
            string mensaje = await cliente.GetStringAsync(url);

            LaSalida.Text = mensaje;
        }

    }
}
