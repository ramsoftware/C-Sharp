using System.Collections.ObjectModel;

namespace Ejemplo {

    public partial class MainPage : ContentPage {

        private record Estudiante(int Id, string Nombre, string Programa);

        private readonly ObservableCollection<Estudiante> lstEstudiantes = new();

        public MainPage() {
            InitializeComponent();
            VistaEstudiantes.ItemsSource = lstEstudiantes;
        }

        private void OnCargarClicked(object sender, EventArgs e) {
            lstEstudiantes.Clear();
            lstEstudiantes.Add(new Estudiante(1, "Ana María", "Ingeniería de Sistemas"));
            lstEstudiantes.Add(new Estudiante(2, "Carlos López", "Matemáticas"));
            lstEstudiantes.Add(new Estudiante(3, "Diana Rojas", "Física"));
            lstEstudiantes.Add(new Estudiante(4, "Rafael Moreno", "Biología"));
        }

        private void CambiaSeleccion(object sender, SelectionChangedEventArgs e) {
            // Single selection: e.CurrentSelection tiene 0 o 1 elemento
            var Seleccion = e.CurrentSelection?.FirstOrDefault() as Estudiante;

            ResultadoEditor.Text = Seleccion is null
                ? "no activo ninguna opción"
                : $"Id: {Seleccion.Id}\nNombre: {Seleccion.Nombre}\nPrograma: {Seleccion.Programa}";
        }
    }
}
