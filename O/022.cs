using SixLabors.ImageSharp;

namespace Ejemplo {

    class Program {
        static void Main() {
            ImageInfo InformacionImagen = Image.Identify(@"Grisú.jpg");
            Console.WriteLine($"Ancho: {InformacionImagen.Width}");
            Console.WriteLine($"Alto: {InformacionImagen.Height}");
        }
    }
}