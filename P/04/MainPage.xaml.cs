namespace Ejemplo {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        private void CuandoHaceClic(object sender, EventArgs e) {
            string Nombre = UnNombre.Text;
            LaSalida.Text = "Hola " + Nombre;
        }
    }
}
