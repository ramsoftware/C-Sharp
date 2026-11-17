namespace Ejemplo {
    public partial class MainPage : ContentPage {

        const float Paso = 10f;

        public MainPage() {
            InitializeComponent();
        }

        void PresionaArriba(object sender, EventArgs e) {
            // Mover hacia arriba: disminuir Y
            Rectangulo.PosY -= Paso;
            CanvasView.Invalidate(); // Fuerza redibujado
        }

        void PresionaAbajo(object sender, EventArgs e) {
            // Mover hacia abajo: aumentar Y
            Rectangulo.PosY += Paso;
            CanvasView.Invalidate();
        }

        void PresionaIzquierda(object sender, EventArgs e) {
            // Mover a la izquierda: disminuir X
            Rectangulo.PosX -= Paso;
            CanvasView.Invalidate();
        }

        void PresionaDerecha(object sender, EventArgs e) {
            // Mover a la derecha: aumentar X
            Rectangulo.PosX += Paso;
            CanvasView.Invalidate();
        }
    }
}