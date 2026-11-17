namespace Ejemplo {
    public class DibujarFiguras : IDrawable {
        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Color de la Línea
            Lienzo.StrokeColor = Colors.Red;

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            //===================================
            //Rectángulo: Xpos, Ypos, Ancho, Alto
            //===================================
            Lienzo.DrawRectangle(100, 100, 200, 150);

        }
    }
}