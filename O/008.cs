using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Carga imagen original
			string Entrada = "C:\\TEMP\\Grisú.jpg";
			using (Image<Rgba32> Foto = Image.Load<Rgba32>(Entrada)) {
				//Aplica un efecto similar a las cámaras antiguas Kodachrome
				Foto.Mutate(x => x.Kodachrome());

				//Guarda la nueva imagen
				string Salida = "C:\\TEMP\\GrisúKodachrome.jpg";
				Foto.Save(Salida);
			}

			Console.WriteLine("Conversión terminada.");
		}
	}
}