namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            //Color de la Línea
            Lienzo.StrokeColor = Colors.Red;
            int contador = 10;
            int incremento = 2;

            do {
                Lienzo.DrawLine(0, contador, dirtyRect.Width / 2, contador);
                incremento++;
                //Incrementa el espacio entre línea y línea
                contador += incremento;
            } while (contador <= 602);
            contador -= incremento;

            //Segundo gráfico
            Lienzo.StrokeColor = Colors.Blue;
            incremento = 2;
            do {
                Lienzo.DrawLine(dirtyRect.Width / 2, contador, dirtyRect.Width, contador);
                incremento++;
                contador -= incremento;
            } while (contador >= 10);

        }
    }
}
