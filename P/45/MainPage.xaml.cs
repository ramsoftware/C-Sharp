namespace Ejemplo {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        async private void CuandoHaceClic(object? sender, EventArgs e) {
            string StringGuarda = CadenaGuarda.Text;
            string Archivo = NombreArchivo.Text;

            string rutaCompleta = Path.Combine(FileSystem.AppDataDirectory, Archivo);
            RutaCompleta.Text = rutaCompleta;

            //Guardar el texto en el archivo
            try {
                await File.WriteAllTextAsync(rutaCompleta, StringGuarda);
            }
            catch (Exception ex) {
                // Manejar errores (permisos, falta de espacio, etc.)
                Console.WriteLine($"Error al guardar: {ex.Message}");
            }

            //Recuperar el texto del archivo
            if (File.Exists(rutaCompleta)) {
                string textoRecuperado = await File.ReadAllTextAsync(rutaCompleta);
                LaSalida.Text = textoRecuperado;
            }
            else {
                LaSalida.Text = "Problemas para recuperar el archivo.";
            }
        }
    }
}
