namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            //Color de la Línea
            Lienzo.StrokeColor = Colors.Blue;
            int contador = 10;
            int incremento = 2;

            //Primer gráfico
            do {
                Lienzo.DrawLine(contador, 0, contador, dirtyRect.Height / 2);
                incremento++;
                //Incrementa el espacio entre línea y línea
                contador += incremento;
            }
            while (contador <= dirtyRect.Width);
            contador -= incremento;

            //Segundo gráfico
            Lienzo.StrokeColor = Colors.Red;
            incremento = 2;
            do {
                Lienzo.DrawLine(contador, dirtyRect.Height / 2, contador, dirtyRect.Height);
                incremento++;
                contador -= incremento;
            }
            while (contador >= 10);
        }
    }
}
