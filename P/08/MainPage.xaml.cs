namespace Ejemplo {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }


        private void CalcularEdad(object sender, EventArgs e) {
            var nacimiento = FechaNace.Date.Value; // solo la parte de fecha
            var hoy = DateTime.Today;              // fecha actual (zona horaria del dispositivo)

            // Cálculo de la edad en años
            int edad = hoy.Year - nacimiento.Year;

            // Muestra al usuario
            Salida.Text = "Tienes " + edad.ToString() + " años";
        }
    }
}
