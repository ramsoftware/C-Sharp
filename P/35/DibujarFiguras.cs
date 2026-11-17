namespace Ejemplo {
    public class DibujarFiguras : IDrawable {
        public float PosX = 30f;
        public float PosY = 30f;
        private float Ancho = 40;
        private float Alto = 40;

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeColor = Colors.Black;
            Lienzo.StrokeSize = 2;

            // Dibuja un rectángulo en (PosX, PosY)
            Lienzo.DrawRectangle(PosX, PosY, Ancho, Alto);
        }
    }
}