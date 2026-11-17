namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            float lim = dirtyRect.Width / 2;
            float cont = lim;
            int incremento = 2;

            do {
                float comun = lim - (cont - lim);

                //Parte superior
                Lienzo.StrokeColor = Colors.Blue;
                Lienzo.DrawLine(cont, 0, cont, dirtyRect.Height / 2);
                Lienzo.DrawLine(comun, 0, comun, dirtyRect.Height / 2);

                //Parte inferior
                Lienzo.StrokeColor = Colors.Red;
                Lienzo.DrawLine(cont, dirtyRect.Height / 2, cont, dirtyRect.Height);
                Lienzo.DrawLine(comun, dirtyRect.Height / 2, comun, dirtyRect.Height);

                incremento++;
                cont += incremento;
            }
            while (cont <= 2 * lim);

        }
    }
}
