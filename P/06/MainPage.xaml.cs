namespace Ejemplo {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        private void ClicSumar(object sender, EventArgs e) {
            if (double.TryParse(numA.Text, out double valorA) &&
                double.TryParse(numB.Text, out double valorB)) {
                double Suma = valorA + valorB;
                numR.Text = Suma.ToString();
            }
            else {
                numR.Text = "Entrada no válida";
            }
        }
    }
}
