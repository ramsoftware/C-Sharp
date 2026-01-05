using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Graficos {

	public partial class Form1 : Form {
		private Bitmap Lienzo;

		public Form1() {
			Lienzo = new Bitmap(400, 300, PixelFormat.Format24bppRgb);
			InitializeComponent();
		}

		//Pintar
		private void Form1_Paint(object sender, PaintEventArgs e) {
			DibujaLineaUsandoLockBits(100, 100, 301, 201, Color.Red);
			e.Graphics.DrawImage(Lienzo, 0, 0);
		}

		/*
		 * LockBits bloquea una parte del Bitmap en memoria para que pueda acceder directamente a los datos de píxeles
		 * mediante punteros o arrays. Esto es mucho más rápido que usar GetPixel y SetPixel, que son lentos porque
		 * implican muchas llamadas a funciones nativas.
		 * 
		 * Usa LockBits cuando:
		 * Es necesario modificar muchos píxeles rápidamente (por ejemplo, filtros de imagen, efectos, procesamiento de imágenes).
		 * Se está haciendo animaciones por píxel o manipulación de texturas.
		 * Se desea leer o escribir datos de píxeles en bloque.
		 * */
		private void DibujaLineaUsandoLockBits(int Xini, int Yini, int Xfin, int Yfin, Color color) {
			Rectangle Rectangulo = new(0, 0, Lienzo.Width, Lienzo.Height);
			BitmapData Datos = Lienzo.LockBits(Rectangulo, ImageLockMode.ReadWrite, Lienzo.PixelFormat);

			int bytesPorPixel = Image.GetPixelFormatSize(Lienzo.PixelFormat) / 8;
			int Paso = Datos.Stride;
			IntPtr ptr = Datos.Scan0;
			int Alto = Lienzo.Height;
			int Ancho = Lienzo.Width;

			byte[] Pixeles = new byte[Paso * Alto];
			Marshal.Copy(ptr, Pixeles, 0, Pixeles.Length);

			// Algoritmo de Bresenham
			int dx = Math.Abs(Xfin - Xini), sx = Xini < Xfin ? 1 : -1;
			int dy = -Math.Abs(Yfin - Yini), sy = Yini < Yfin ? 1 : -1;
			int Error = dx + dy, Error2;

			while (true) {
				if (Xini >= 0 && Xini < Ancho && Yini >= 0 && Yini < Alto) {
					int Indice = Yini * Paso + Xini * bytesPorPixel;
					Pixeles[Indice + 0] = color.B;
					Pixeles[Indice + 1] = color.G;
					Pixeles[Indice + 2] = color.R;
				}

				if (Xini == Xfin && Yini == Yfin) break;
				Error2 = 2 * Error;
				if (Error2 >= dy) { Error += dy; Xini += sx; }
				if (Error2 <= dx) { Error += dx; Yini += sy; }
			}

			Marshal.Copy(Pixeles, 0, ptr, Pixeles.Length);
			Lienzo.UnlockBits(Datos);
		}
	}
}