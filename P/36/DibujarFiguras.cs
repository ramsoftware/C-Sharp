namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        //Posiciones de los vértices del rectángulo
        public float PosXa = 60f;
        public float PosYa = 60f;

        public float PosXb = 120f;
        public float PosYb = 60f;

        public float PosXc = 120f;
        public float PosYc = 120f;

        public float PosXd = 60f;
        public float PosYd = 120f;

        public float AnguloGiro = 0;

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeColor = Colors.Black;
            Lienzo.StrokeSize = 2;

            //Para el giro
            float AnguloRadianes = (float)(AnguloGiro * Math.PI / 180);
            float CosA = (float)Math.Cos(AnguloRadianes);
            float SinA = (float)Math.Sin(AnguloRadianes);

            //Cálcula el giro
            float PosXag = PosXa * CosA - PosYa * SinA;
            float PosYag = PosXa * SinA + PosYa * CosA;

            float PosXbg = PosXb * CosA - PosYb * SinA;
            float PosYbg = PosXb * SinA + PosYb * CosA;

            float PosXcg = PosXc * CosA - PosYc * SinA;
            float PosYcg = PosXc * SinA + PosYc * CosA;

            float PosXdg = PosXd * CosA - PosYd * SinA;
            float PosYdg = PosXd * SinA + PosYd * CosA;

            // Dibuja un rectángulo en (PosX, PosY)
            Lienzo.DrawLine(PosXag, PosYag, PosXbg, PosYbg);
            Lienzo.DrawLine(PosXbg, PosYbg, PosXcg, PosYcg);
            Lienzo.DrawLine(PosXcg, PosYcg, PosXdg, PosYdg);
            Lienzo.DrawLine(PosXdg, PosYdg, PosXag, PosYag);
        }
    }
}