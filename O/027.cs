using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ejemplo;

class Program {
    static void Main() {
        int Ancho = 500;
        int Alto = 500;
        int cantidadCirculos = 20;
        Random Azar = new();

        // Crear una imagen de 500x500 píxeles con fondo blanco
        using (var NuevaImagen = new Image<Rgba32>(500, 500)) {
            NuevaImagen.Mutate(Lienzo => {
                // Fondo blanco
                Lienzo.Fill(Color.White);

                // Crear un lapiz azul con grosor de 5 píxeles
                var Lapiz = Pens.Solid(Color.Blue, 5);

                for (int i = 0; i < cantidadCirculos; i++) {
                    // Radio aleatorio entre 10 y 50
                    float radio = Azar.Next(10, 51);

                    // Posición aleatoria dentro de los límites de la imagen
                    float x = Azar.Next((int)radio, Ancho - (int)radio);
                    float y = Azar.Next((int)radio, Alto - (int)radio);

                    var circle = new EllipsePolygon(new PointF(x, y), radio);
                    Lienzo.Draw(Lapiz, circle);
                }
            });

            // Guardar la imagen
            NuevaImagen.Save("Circulos.png");
        }
    }
}