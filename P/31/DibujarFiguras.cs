namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            Lienzo.StrokeColor = Colors.Blue;
            float xval = 0;
            float yval = dirtyRect.Height / 2;
            do {
                Lienzo.DrawLine(xval, dirtyRect.Height / 2 - yval, xval, dirtyRect.Height / 2 + yval);
                xval += 5;
                yval -= 5;
            }
            while (yval >= 0);

            Lienzo.StrokeColor = Colors.Red;
            xval = dirtyRect.Width / 2;
            yval = dirtyRect.Height;
            do {
                Lienzo.DrawLine(dirtyRect.Width / 2 - xval, yval, dirtyRect.Width / 2 + xval, yval);
                xval -= 5;
                yval -= 5;
            }
            while (yval >= dirtyRect.Height / 2);

        }
    }
}
