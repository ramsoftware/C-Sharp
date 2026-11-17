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

            //Llega al extremo inferior derecho del canvas
            Lienzo.DrawLine(0, 0, dirtyRect.Width, dirtyRect.Height);

        }
    }
}