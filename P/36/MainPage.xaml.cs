namespace Ejemplo {
    public partial class MainPage : ContentPage {
        const float Paso = 5f;

        public MainPage() {
            InitializeComponent();
        }

        void PresionaAumenta(object sender, EventArgs e) {
            Rectangulo.AnguloGiro += Paso;
            CanvasView.Invalidate(); // Fuerza redibujado
        }

        void PresionaDisminuye(object sender, EventArgs e) {
            Rectangulo.AnguloGiro -= Paso;
            CanvasView.Invalidate();
        }
    }
}