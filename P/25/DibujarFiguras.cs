namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Color de la Línea
            Lienzo.FillColor = Colors.Red;

            //=============================
            //Arco: Xpos, Ypos, Ancho, Alto
            //=============================

            Lienzo.FillEllipse(10, 90, 100, 170);
        }
    }
}