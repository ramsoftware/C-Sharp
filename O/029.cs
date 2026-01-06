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
        Font font;
        if (SystemFonts.TryGet("Tahoma", out FontFamily tahomaFamily)) {
            font = tahomaFamily.CreateFont(16, FontStyle.Regular);
        }
        else {
            throw new InvalidOperationException("La fuente 'Tahoma' no está disponible en el sistema.");
        }

        string texto = "Texto con Tahoma 16 pt";
        var color = Color.Blue; // Cambia el color según necesites
        var position = new PointF(50, 80); // Posición superior izquierda del texto

        img.Mutate(ctx => {
            // Dibujar texto
            ctx.DrawText(texto, font, color, position);
        });

        img.Save("texto_tahoma.png");
        Console.WriteLine("Imagen generada: texto_tahoma.png");
    }
}
