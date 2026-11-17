namespace Ejemplo {

    // Modelo simple con Id y Nombre
    public class Opcion {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        //Constructor para inicializar la lista de opciones
        public Opcion(int Id, string Nombre) {
            this.Id = Id;
            this.Nombre = Nombre;
        }

    }

    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();

            List<Opcion> opciones = [
                new Opcion(1, "Opción 1"),
                new Opcion(2, "Opción 2"),
                new Opcion(3, "Opción 3"),
                new Opcion(4, "Opción 4"),
                new Opcion(5, "Opción 5")
            ];

            // Asignar las opciones al Picker
            OpcionesPicker.ItemsSource = opciones;
        }


        // Evento del botón: muestra Id + Nombre 
        private void OnMostrarSeleccionClicked(object sender, EventArgs e) {
            var selecciona = OpcionesPicker.SelectedItem as Opcion;
            if (selecciona is null) {
                Salida.Text = "No has seleccionado ninguna opción";
                return;
            }

            Salida.Text = $"Id: {selecciona.Id}  |  Nombre: {selecciona.Nombre}";
        }
    }
}
