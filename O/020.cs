using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SharpImagen {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			LoadImage("C:\\TEMP\\Grisú.jpg");
		}

		//Carga la imagen y la muestra en el control
		private void LoadImage(string RutaImagen) {
			try {
				using (var image = SixLabors.ImageSharp.Image.Load<Rgba32>(RutaImagen)) {
					using (var FlujoMemoria = new MemoryStream()) {
						image.SaveAsBmp(FlujoMemoria);

						/* Mover la posición actual dentro del flujo de memoria
						  (FlujoMemoria) a un punto específico.
						  FlujoMemoria es usado para almacenar temporalmente la imagen
						  en memoria.
						  Seek(0, SeekOrigin.Begin): Es el método que mueve la 
						  posición actual dentro del flujo.
						  Este método toma dos parámetros:
							0: Este es el desplazamiento en bytes desde la posición
							   especificada por el segundo parámetro.
							   En este caso, 0 significa que no se está moviendo
							   desde la posición especificada, simplemente se está
							   estableciendo la posición en el inicio del flujo.
							SeekOrigin.Begin: Este es un enumerador que especifica
											  el punto de referencia desde el cual
											  se calcula la nueva posición.
											  SeekOrigin.Begin indica que el punto
											  de referencia es el comienzo del flujo. */
						FlujoMemoria.Seek(0, SeekOrigin.Begin);

						var bitmap = new BitmapImage();

						/* BeginInit() marca el inicio de un bloque de inicialización
						 * para el objeto BitmapImage. Durante este bloque, se puede
						 * establecer varias propiedades del BitmapImage sin que el
						 * objeto intente cargarse o procesarse inmediatamente */
						bitmap.BeginInit();
						bitmap.StreamSource = FlujoMemoria;

						/* Se utiliza para configurar cómo se almacena en caché la
						   imagen cuando se carga en un objeto BitmapImage.
						   bitmap: Es el objeto BitmapImage que se está utilizando
								   para mostrar la imagen en la aplicación WPF.
						   CacheOption: Es una propiedad del BitmapImage que determina
										cómo se almacena en caché la imagen.
										Esto afecta el rendimiento y el uso de memoria
										de la aplicación.
						   BitmapCacheOption.OnLoad: Es uno de los valores del enumerador
													 BitmapCacheOption. Especifica que la
													 imagen debe cargarse completamente en
													 memoria cuando se llama al método
													 EndInit(). Esto significa que toda
													 la imagen se carga y se almacena en
													 memoria de una vez.
						*/
						bitmap.CacheOption = BitmapCacheOption.OnLoad;

						/* En este punto, el BitmapImage se carga y se procesa utilizando
						 * las propiedades que se establecieron durante el bloque
						 * de inicialización. */
						bitmap.EndInit();
						ImagenFoto.Source = bitmap;
					}
				}
			}
			catch (Exception ex) {
				MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
			}
		}
	}
}