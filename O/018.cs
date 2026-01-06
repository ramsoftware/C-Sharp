using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ejemplo;

internal class Program {
    static void Main() {
        // Cargar la imagen original
        using (var Foto = Image.Load<Rgba32>("C:\\TEMP\\Grisú.jpg")) {

            // Recorrer cada píxel y convertirlo
            for (int y = 0; y < Foto.Height; y++) {
                for (int x = 0; x < Foto.Width; x++) {
                    var pixel = Foto[x, y];

                    //Invierte el color
                    byte NuevoR = (byte)(255 - pixel.R);
                    byte NuevoG = (byte)(255 - pixel.G);
                    byte NuevoB = (byte)(255 - pixel.B);

                    //El pixel con el nuevo color
                    var PixelNuevo = new Rgba32(NuevoR, NuevoG, NuevoB, pixel.A);

                    //Cambia la imagen
                    Foto[x, y] = PixelNuevo;
                }
            }

            // Guardar la imagen en escala de grises
            Foto.Save("C:\\TEMP\\GrisúInvierte.jpg");
        }
        Console.WriteLine("Proceso terminado");
    }
}