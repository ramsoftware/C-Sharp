namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeSize = 2;

            float Ancho = dirtyRect.Width;
            float Alto = dirtyRect.Height;

            float PosX = 0;
            float PosY = 0;
            for (int Cont = 1; Cont <= 20; Cont++) {
                Lienzo.DrawRectangle(PosX, PosY, Ancho, Alto);
                PosX += 5;
                PosY += 5;
                Ancho -= 10;
                Alto -= 10;
            }

        }
    }
}