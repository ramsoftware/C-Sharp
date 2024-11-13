using Microsoft.Win32;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SharpImagen {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		SixLabors.ImageSharp.Image Foto, Copia;

		public MainWindow() {
			InitializeComponent();
		}

		//Carga la imagen y la muestra en el control
		private void MuestraFoto() {
			var FlujoMemoria = new MemoryStream();
			Copia.SaveAsBmp(FlujoMemoria);

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

		private void btnSepia_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.Sepia());
			MuestraFoto();
		}

		private void btnBlancoNegro_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.BlackWhite());
			MuestraFoto();
		}

		private void btnGrises_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.Grayscale());
			MuestraFoto();
		}

		private void btnOriginal_Click(object sender, RoutedEventArgs e) {
			Copia = Foto.CloneAs<Rgba32>();
			MuestraFoto();
		}

		private void btnReflejoH_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.Flip(FlipMode.Horizontal));
			MuestraFoto();
		}

		private void btnReflejoV_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.Flip(FlipMode.Vertical));
			MuestraFoto();
		}

		private void btnInvierte_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.Invert());
			MuestraFoto();
		}

		private void btnKodachrome_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.Kodachrome());
			MuestraFoto();
		}

		private void btnLomograph_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.Lomograph());
			MuestraFoto();
		}

		private void btnPolaroid_Click(object sender, RoutedEventArgs e) {
			Copia.Mutate(x => x.Polaroid());
			MuestraFoto();
		}

		private void btnCarga_Click(object sender, RoutedEventArgs e) {
			OpenFileDialog dlgAbrir = new OpenFileDialog();
			dlgAbrir.Filter = "Archivos de imagen|*.bmp;*.jpg;*.jpeg;*.gif;*.webp;*.tga";
			dlgAbrir.Title = "Seleccione un archivo de imagen";

			if (dlgAbrir.ShowDialog() == true) {
				try {
					Foto = SixLabors.ImageSharp.Image.Load<Rgba32>(dlgAbrir.FileName);
					Copia = Foto.CloneAs<Rgba32>();
					MuestraFoto();
					btnBlancoNegro.IsEnabled = true;
					btnGrises.IsEnabled = true;
					btnSepia.IsEnabled = true;
					btnOriginal.IsEnabled = true;
					btnReflejoH.IsEnabled = true;
					btnReflejoV.IsEnabled = true;
					btnInvierte.IsEnabled = true;
					btnKodachrome.IsEnabled = true;
					btnLomograph.IsEnabled = true;
					btnPolaroid.IsEnabled = true;
				}
				catch (Exception ex) {
					MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
				}
			}
		}
	}
}