namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        // Define los puntos en orden (horario/antihorario)
        private readonly PointF[] puntos =
        {
            new(50, 10),
            new(90, 40),
            new(75, 90),
            new(25, 90),
            new(10, 40)
        };

        public Color ColorRelleno { get; set; } = Color.FromArgb("#33A1FD");
        public Color ColorPerimetro { get; set; } = Colors.MidnightBlue;
        public float GrosorPerimetro { get; set; } = 3f;

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            // Activa el suavizado de bordes (“anti‑aliasing”) cuando se dibuja
            // líneas, curvas, polígonos o texto en un GraphicsView de .NET MAUI.
            Lienzo.Antialias = true;

            // Construir el PathF del polígono
            var rutaPuntos = new PathF();
            if (puntos.Length > 0) {
                rutaPuntos.MoveTo(puntos[0]);
                for (int i = 1; i < puntos.Length; i++)
                    rutaPuntos.LineTo(puntos[i]);
                rutaPuntos.Close(); // importante cerrarlo
            }

            // Relleno
            Lienzo.FillColor = ColorRelleno;
            Lienzo.FillPath(rutaPuntos);

            // Trazo
            Lienzo.StrokeColor = ColorPerimetro;
            Lienzo.StrokeSize = GrosorPerimetro;
            Lienzo.DrawPath(rutaPuntos);
        }
    }
}