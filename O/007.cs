using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ejemplo;

internal class Program {
    static void Main() {
        //Carga imagen original
        string Entrada = "C:\\TEMP\\Grisú.jpg";
        using (Image<Rgba32> Foto = Image.Load<Rgba32>(Entrada)) {
            //Aplica el filtro de invertir colores
            Foto.Mutate(x => x.Invert());

            //Guarda la nueva imagen
            string Salida = "C:\\TEMP\\GrisúInvierte.jpg";
            Foto.Save(Salida);
        }

        Console.WriteLine("Conversión terminada.");
    }
}