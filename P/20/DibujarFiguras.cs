namespace Ejemplo {
    public class DibujarFiguras : IDrawable {
        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Color de la Línea
            Lienzo.StrokeColor = Colors.Red;

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            //================================================================================================
            //Arco: Xpos, Ypos, Ancho, Alto, Ángulo Inicial, Ángulo Final, sentido del reloj, cierra la figura
            //================================================================================================
            Lienzo.DrawArc(10, 90, 160, 170, 0, 270, true, true);
        }
    }
}