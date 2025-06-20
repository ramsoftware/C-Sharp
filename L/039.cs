namespace Graficos {
    public partial class Form1 : Form {
        private Bitmap Lienzo;

        public Form1() {
            InitializeComponent();
            Lienzo = new Bitmap(400, 300);
        }

        //Pintar
        private void Form1_Paint(object sender, PaintEventArgs e) {
            DibujarLinea(50, 50, 300, 200, Color.Blue); // Línea de ejemplo
            e.Graphics.DrawImage(Lienzo, 0, 0);
        }

        //Algoritmo de Bresenham para líneas
        private void DibujarLinea(int Xini, int Yini, int Xfin, int Yfin, Color color) {
            int dx = Math.Abs(Xfin - Xini), sx = Xini < Xfin ? 1 : -1;
            int dy = -Math.Abs(Yfin - Yini), sy = Yini < Yfin ? 1 : -1;
            int error = dx + dy, e2;

            while (true) {
                if (Xini >= 0 && Xini < Lienzo.Width && Yini >= 0 && Yini < Lienzo.Height)
                    Lienzo.SetPixel(Xini, Yini, color); //Dibuja el pixel

                if (Xini == Xfin && Yini == Yfin) break;
                e2 = 2 * error;
                if (e2 >= dy) { error += dy; Xini += sx; }
                if (e2 <= dx) { error += dx; Yini += sy; }
            }
        }
    }
}