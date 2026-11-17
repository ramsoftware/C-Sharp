namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Color de la Línea
            Lienzo.StrokeColor = Colors.Red;

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            //=============================
            //Elipse: Xpos, Ypos, Ancho, Alto
            //=============================

            Lienzo.DrawEllipse(10, 90, 100, 170);
        }
    }
}
