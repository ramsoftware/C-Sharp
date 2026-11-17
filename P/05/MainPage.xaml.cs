namespace Ejemplo {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        private void ClicSumar(object sender, EventArgs e) {
            int ValorA = Convert.ToInt32(numA.Text);
            int ValorB = Convert.ToInt32(numB.Text);
            int Suma = ValorA + ValorB;
            numR.Text = Suma.ToString();
        }
    }
}
