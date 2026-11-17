namespace Ejemplo {

    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        private void OnMostrarSeleccionadasClicked(object sender, EventArgs e) {
            var seleccionadas = new List<string>();

            if (ChkOpA.IsChecked) seleccionadas.Add("Opción A");
            if (ChkOpB.IsChecked) seleccionadas.Add("Opción B");
            if (ChkOpC.IsChecked) seleccionadas.Add("Opción C");

            if (seleccionadas.Count == 0) {
                ResultadoEditor.Text = "no activó ninguna opción";
            }
            else {
                // Unir cada opción en una línea distinta
                ResultadoEditor.Text = string.Join(Environment.NewLine, seleccionadas);
            }
        }

    }
}
