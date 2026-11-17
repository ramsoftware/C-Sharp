namespace Ejemplo {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        async private void CuandoHaceClic(object? sender, EventArgs e) {
            //Declara la lista
            List<string> ListaAnimales = [];

            //Adiciona elementos a la lista
            ListaAnimales.Add("Ballena");
            ListaAnimales.Add("Tortuga marina");
            ListaAnimales.Add("Tiburón");
            ListaAnimales.Add("Hipocampo");
            ListaAnimales.Add("Delfín");
            ListaAnimales.Add("Pulpo");
            ListaAnimales.Add("Caballito de mar");
            ListaAnimales.Add("Coral");
            ListaAnimales.Add("Pingüinos");

            string Archivo = NombreArchivo.Text;
            string rutaCompleta = Path.Combine(FileSystem.AppDataDirectory, Archivo);

            // Guardar cada string en una línea
            File.WriteAllLines(rutaCompleta, ListaAnimales);

            //Leer el archivo y convertirlo a una lista
            List<string> nuevaLista = File.ReadAllLines(rutaCompleta).ToList();

            //Ponerlo en el control
            ListadoAnimal.Text = string.Join(Environment.NewLine, nuevaLista);
        }
    }
}
