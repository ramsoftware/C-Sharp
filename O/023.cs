using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;

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

                // Dibujar una línea desde (50, 50) hasta (450, 450)
                var Linea = new SixLabors.ImageSharp.Drawing.PathBuilder()
                    .AddLine(new PointF(50, 50), new PointF(450, 450))
                    .Build();

                Lienzo.Draw(Lapiz, Linea);
            });

            // Guardar la imagen
            NuevaImagen.Save("linea_azul.png");
        }
    }
}
