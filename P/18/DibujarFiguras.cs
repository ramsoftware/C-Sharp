namespace Ejemplo {
    public class DibujarFiguras : IDrawable {
        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Color de la Línea
            Lienzo.StrokeColor = Colors.Red;

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            //=============================			
            //Línea: Xini, Yini, Xfin, Yfin
            //=============================
            Lienzo.DrawLine(10, 20, 210, 90);
        }
    }
}
