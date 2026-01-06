using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ejemplo; 

class Program {
    static void Main() {
        int width = 800, height = 600;

        using var img = new Image<Rgba32>(width, height, Color.White);

        // Intentar obtener Tahoma desde fuentes del sistema
        Font fuenteLetra;
        if (SystemFonts.TryGet("Tahoma", out FontFamily tahomaFamily)) {
            fuenteLetra = tahomaFamily.CreateFont(31, FontStyle.Regular);
        }
        else {
            throw new InvalidOperationException("La fuente 'Tahoma' no está disponible en el sistema.");
        }

        string Texto = "Texto con Tahoma 31 pt";

        img.Mutate(x => x
                  .DrawText(
                      new DrawingOptions {
                          Transform = Matrix3x2Extensions.CreateRotationDegrees(45, new PointF(50, 50))
                      },
                     Texto,
                     fuenteLetra,
                     Color.Black,
                     new PointF(50, 50)));


        img.Save("texto_tahoma.png");
        Console.WriteLine("Imagen generada: texto_tahoma.png");
    }
}
