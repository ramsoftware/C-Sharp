namespace Ejemplo {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }


        private void CambiaValorSlider(object sender, ValueChangedEventArgs e) {
            // e.NewValue trae el valor actual (double)
            lblValorSlider.Text = $"Control Slider. Valor: {e.NewValue:0.##}";
        }

        private void CambiaValorStepper(object sender, ValueChangedEventArgs e) {
             lblValorStepper.Text = $"Control Stepper. Valor: {e.NewValue:0.##}";
        }

        private void CambiaValorProgreso(object sender, ValueChangedEventArgs e) {
            pgbProgreso.Progress = e.NewValue;
        }
    }
}
