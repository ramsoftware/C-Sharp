namespace Ejemplo {
    public class DibujarFiguras : IDrawable {
        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Color de relleno
            Lienzo.StrokeColor = Colors.BlueViolet;

            //============================================
            //Dibujar líneas dado los puntos
            //============================================
            Point P0 = new(100, 180);
            Point P1 = new(200, 10);
            Point P2 = new(350, 50);
            Point P3 = new(250, 180);

            Lienzo.DrawLine(P0, P1);
            Lienzo.DrawLine(P2, P3);
        }
    }
}