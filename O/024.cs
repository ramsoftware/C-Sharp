using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ejemplo {

    class Program {
        static void Main() {
            // Crear una imagen de 500x500 píxeles con fondo blanco
            using (var NuevaImagen = new Image<Rgba32>(500, 500)) {
                NuevaImagen.Mutate(Lienzo => {
                    // Fondo blanco
                    Lienzo.Fill(Color.White);

                    // Crear un lapiz azul con grosor de 5 píxeles
                    var Lapiz = Pens.Solid(Color.Blue, 5);

                    // Dibujar un círculo centrado en (250, 250) con radio 100
                    var Circulo = new EllipsePolygon(new PointF(250, 250), 100);

                    Lienzo.Draw(Lapiz, Circulo);
                });

                // Guardar la imagen
                NuevaImagen.Save("circulo_azul.png");
            }
        }
    }
}