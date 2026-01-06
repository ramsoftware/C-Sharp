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
        int cantidadRectangulos = 20;
        Random Azar = new();

        // Crear una imagen de 500x500 píxeles con fondo blanco
        using (var NuevaImagen = new Image<Rgba32>(500, 500)) {
            NuevaImagen.Mutate(Lienzo => {
                // Fondo blanco
                Lienzo.Fill(Color.White);

                // Crear un lapiz azul con grosor de 5 píxeles
                var Lapiz = Pens.Solid(Color.Blue, 5);

                for (int i = 0; i < cantidadRectangulos; i++) {
                    // Generar posición y tamaño aleatorios
                    int w = Azar.Next(40, 200);
                    int h = Azar.Next(40, 200);
                    int x = Azar.Next(0, Ancho - w);
                    int y = Azar.Next(0, Alto - h);

                    var rectangulo = new RectangularPolygon(x, y, w, h);

                    // Dibujar relleno azul
                    Lienzo.Fill(Color.Blue, rectangulo);

                    // Dibujar borde opcional
                    Lienzo.Draw(Color.DarkBlue, 3f, rectangulo);
                }
            });

            // Guardar la imagen
            NuevaImagen.Save("Rectangulos.png");
        }
    }
}
