namespace Animacion {
    public class DibujarFiguras : IDrawable {

        //Posiciones iniciales de los vértices del rectángulo
        public float PosXa = 60f;
        public float PosYa = 60f;

        public float PosXb = 120f;
        public float PosYb = 60f;

        public float PosXc = 120f;
        public float PosYc = 120f;

        public float PosXd = 60f;
        public float PosYd = 120f;

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeColor = Colors.Black;
            Lienzo.StrokeSize = 2;

            // Dibuja un rectángulo en (PosX, PosY)
            Lienzo.DrawLine(PosXa, PosYa, PosXb, PosYb);
            Lienzo.DrawLine(PosXb, PosYb, PosXc, PosYc);
            Lienzo.DrawLine(PosXc, PosYc, PosXd, PosYd);
            Lienzo.DrawLine(PosXd, PosYd, PosXa, PosYa);
        }
    }
}