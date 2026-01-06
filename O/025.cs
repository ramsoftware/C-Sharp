using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ejemplo;

class Program {
    static void Main() {
        // Crear una imagen de 500x500 píxeles con fondo blanco
        using (var NuevaImagen = new Image<Rgba32>(500, 500)) {
            NuevaImagen.Mutate(Lienzo => {
                // Fondo blanco
                Lienzo.Fill(Color.White);

                // Crear un lapiz azul con grosor de 5 píxeles
                var Lapiz = Pens.Solid(Color.Blue, 5);

                // Definir los puntos del polígono (triángulo en este caso)
                var Poligono = new Polygon(new LinearLineSegment(
                    new PointF(250, 100),
                    new PointF(100, 400),
                    new PointF(400, 400),
                    new PointF(250, 100) // cerrar el triángulo
                ));

                Lienzo.Draw(Lapiz, Poligono);
            });

            // Guardar la imagen
            NuevaImagen.Save("poligono_azul.png");
        }
    }
}
