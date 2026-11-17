namespace Ejemplo {

    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        private void OnMostrarSeleccionClicked(object sender, EventArgs e) {

            // Revisa los RadioButton del grupo y busca el que esté IsChecked = true
            string? seleccion = null;

            if (RbA.IsChecked) seleccion = RbA.Content?.ToString();
            else if (RbB.IsChecked) seleccion = RbB.Content?.ToString();
            else if (RbC.IsChecked) seleccion = RbC.Content?.ToString();

            ResultadoEditor.Text = string.IsNullOrWhiteSpace(seleccion)
                ? "no activo ninguna opción"
                : $"Seleccionaste: {seleccion}";
        }
    }
}