namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeSize = 2;

            float PosYa = 0, PosXb = 0;
            while (PosYa < dirtyRect.Height && PosXb < dirtyRect.Width) {
                Lienzo.DrawLine(0, PosYa, PosXb, dirtyRect.Height);
                PosYa += 40;
                PosXb += 20;
            }
        }
    }
}