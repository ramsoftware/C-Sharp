namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {

            //Grosor de la Línea
            Lienzo.StrokeSize = 2;

            float pX1, pY1, pX2, pY2, pX3, pY3, constanteX, constanteY;

            //Coordenadas del triángulo
            pX1 = 0;
            pY1 = 0;

            pX2 = dirtyRect.Width;
            pY2 = dirtyRect.Height / 2;

            pX3 = 0;
            pY3 = dirtyRect.Height;

            constanteX = 20;
            constanteY = 30;

            for (int Cont = 1; Cont <= 5; Cont++) {
                Lienzo.DrawLine(pX1, pY1, pX2, pY2);
                Lienzo.DrawLine(pX2, pY2, pX3, pY3);
                Lienzo.DrawLine(pX1, pY1, pX3, pY3);

                pX1 += constanteX;
                pY1 += constanteY;

                pX2 -= constanteX;

                pX3 += constanteX;
                pY3 -= constanteY;
            }
        }
    }
}
