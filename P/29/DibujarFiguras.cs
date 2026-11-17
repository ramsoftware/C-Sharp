namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            int xval = 0;
            int yval = 0;

            //Parte izquierda
            Lienzo.StrokeColor = Colors.Blue;
            do {
                Lienzo.DrawLine(xval, dirtyRect.Height / 2 - yval, xval, dirtyRect.Height / 2 + yval);
                xval += 5;
                yval += 5;
            } while (yval < dirtyRect.Height / 2);

            //Parte derecha
            Lienzo.StrokeColor = Colors.Red;
            do {
                Lienzo.DrawLine(xval, dirtyRect.Height / 2 - yval, xval, dirtyRect.Height / 2 + yval);
                xval += 5;
                yval -= 5;
            } while (yval > 0);

        }
    }
}
