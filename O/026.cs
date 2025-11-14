using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ejemplo {

    class Program {
        static void Main() {
            int Ancho = 500;
            int Alto = 500;
            int cantidadLineas = 20;
            Random Azar = new();

            // Crear una imagen de 500x500 píxeles con fondo blanco
            using (var NuevaImagen = new Image<Rgba32>(500, 500)) {
                NuevaImagen.Mutate(Lienzo => {
                    // Fondo blanco
                    Lienzo.Fill(Color.White);

                    // Crear un lapiz azul con grosor de 5 píxeles
                    var Lapiz = Pens.Solid(Color.Blue, 5);

                    for (int i = 0; i < cantidadLineas; i++) {
                        // Generar puntos aleatorios dentro del área de la imagen
                        var x1 = Azar.Next(Ancho);
                        var y1 = Azar.Next(Alto);
                        var x2 = Azar.Next(Ancho);
                        var y2 = Azar.Next(Alto);

                        var Linea = new SixLabors.ImageSharp.Drawing.PathBuilder()
                            .AddLine(new PointF(x1, y1), new PointF(x2, y2))
                            .Build();

                        Lienzo.Draw(Lapiz, Linea);
                    }
                });

                // Guardar la imagen
                NuevaImagen.Save("Lineas.png");
            }
        }
    }
}