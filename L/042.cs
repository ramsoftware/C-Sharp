/*
Si se está dibujando formas geométricas, usar Graphics.
Es más simple, legible y suficientemente rápido para
la mayoría de los casos.

Si se necesita modificar píxeles directamente
(como en procesamiento de imágenes), entonces
usar LockBits.
*/
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Graficos {
    public partial class Form1 : Form {
        private Bitmap Lienzo;

        public Form1() {
            InitializeComponent();

            // Crear el bitmap
            Lienzo = new Bitmap(200, 200, PixelFormat.Format24bppRgb);

            // Usar LockBits para dibujar un círculo
            Rectangle rectangulo = new Rectangle(0, 0, Lienzo.Width, Lienzo.Height);
            BitmapData bmpDato = Lienzo.LockBits(rectangulo, ImageLockMode.ReadWrite, Lienzo.PixelFormat);

            int paso = bmpDato.Stride;
            IntPtr ptr = bmpDato.Scan0;
            int bytes = Math.Abs(paso) * Lienzo.Height;
            byte[] rgbValues = new byte[bytes];

            Marshal.Copy(ptr, rgbValues, 0, bytes);

            int centroX = 100;
            int centroY = 100;
            int radio = 75;

            for (int y = 0; y < Lienzo.Height; y++) {
                for (int x = 0; x < Lienzo.Width; x++) {
                    int dx = x - centroX;
                    int dy = y - centroY;
                    int distancia = dx * dx + dy * dy;

                    // Dibujar solo el borde del círculo (ancho de 4 píxeles)
                    if (distancia >= radio * radio - 4 * radio && distancia <= radio * radio + 4 * radio) {
                        int indice = y * paso + x * 3;
                        rgbValues[indice] = 0;      // Blue
                        rgbValues[indice + 1] = 255; // Green
                        rgbValues[indice + 2] = 0;   // Red
                    }
                    else {
                        int indice = y * paso + x * 3;
                        rgbValues[indice] = 255;
                        rgbValues[indice + 1] = 255;
                        rgbValues[indice + 2] = 255;
                    }
                }
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            Lienzo.UnlockBits(bmpDato);
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(Lienzo, 50, 50);
        }
    }
}
