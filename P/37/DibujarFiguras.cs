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

            //Calcula el centro del rectángulo
            float CentroX = (PosXa + PosXb + PosXc + PosXd) / 4;
            float CentroY = (PosYa + PosYb + PosYc + PosYd) / 4;

            //Calcula el giro
            float PosXag = PosXa * CosA - PosYa * SinA;
            float PosYag = PosXa * SinA + PosYa * CosA;

            float PosXbg = PosXb * CosA - PosYb * SinA;
            float PosYbg = PosXb * SinA + PosYb * CosA;

            float PosXcg = PosXc * CosA - PosYc * SinA;
            float PosYcg = PosXc * SinA + PosYc * CosA;

            float PosXdg = PosXd * CosA - PosYd * SinA;
            float PosYdg = PosXd * SinA + PosYd * CosA;

            //Giro del centro
            float CentroXg = CentroX * CosA - CentroY * SinA;
            float CentroYg = CentroX * SinA + CentroY * CosA;

            //Desplazamiento del centro
            float dX = CentroXg - CentroX;
            float dY = CentroYg - CentroY;


            // Dibuja un rectángulo en (PosX, PosY)
            Lienzo.DrawLine(PosXag - dX, PosYag - dY, PosXbg - dX, PosYbg - dY);
            Lienzo.DrawLine(PosXbg - dX, PosYbg - dY, PosXcg - dX, PosYcg - dY);
            Lienzo.DrawLine(PosXcg - dX, PosYcg - dY, PosXdg - dX, PosYdg - dY);
            Lienzo.DrawLine(PosXdg - dX, PosYdg - dY, PosXag - dX, PosYag - dY);
        }
    }
}