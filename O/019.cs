using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ejemplo {
	class Program {
		static void Main() {
			int[,] Nucleo = {
			{ 1, 0, -1 },
			{ 1, 0, -1 },
			{ 1, 0, -1 }
		};

			int nAlto = Nucleo.GetLength(0);
			int nAncho = Nucleo.GetLength(1);

			using (var Foto = Image.Load<Rgba32>("C:\\TEMP\\Grisú.jpg")) {
				var pixel = Foto[0, 0];
				for (int y = 0; y < Foto.Height - nAlto + 1; y++) {
					for (int x = 0; x < Foto.Width - nAncho + 1; x++) {
						int Acumula = 0;
						for (int nY = 0; nY < nAlto; nY++) {
							for (int nX = 0; nX < nAncho; nX++) {
								pixel = Foto[x + nX, y + nY];
								int gris = (int) (0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
								Acumula += gris * Nucleo[nX, nY];
							}
						}
						byte suma = (byte) Acumula;
						Foto[x, y] = new Rgba32(suma, suma, suma, pixel.A);
					}
				}
				// Guardar la imagen que se le aplicó el núcleo
				Foto.Save("C:\\TEMP\\GrisúAplicaNucleo.jpg");
			}
			Console.WriteLine("Proceso terminado");
		}
	}
}