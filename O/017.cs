using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			// Cargar la imagen original
			using (var Foto = Image.Load<Rgba32>("C:\\TEMP\\Grisú.jpg")) {
				// Recorrer cada píxel y convertirlo a escala de grises
				for (int y = 0; y < Foto.Height; y++) {
					for (int x = 0; x < Foto.Width; x++) {
						var pixel = Foto[x, y];
						// Calcular el valor de gris usando la fórmula de luminancia
						byte gris = (byte)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
						var Pixelgris = new Rgba32(gris, gris, gris, pixel.A);
						Foto[x, y] = Pixelgris;
					}
				}

				// Guardar la imagen en escala de grises
				Foto.Save("C:\\TEMP\\GrisúPixelGris.jpg");
			}
			Console.WriteLine("Proceso terminado");
		}
	}
}