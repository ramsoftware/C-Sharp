namespace Ejemplo {
    public partial class MainPage : ContentPage {
        //Usa el objeto Reloj para actualizar la posición del rectángulo y redibujar la pantalla
        IDispatcherTimer Reloj;

        public MainPage() {
            InitializeComponent();

            Rectangulo.IniciarParametros();

            Reloj = Application.Current?.Dispatcher.CreateTimer();
            Reloj.Interval = TimeSpan.FromMilliseconds(100);
            if (Reloj is null) return;
            Reloj.Tick += CadaVezQueHaceTick;
            Reloj.Start();
        }


        async void CadaVezQueHaceTick(object? sender, EventArgs e) {
            Rectangulo.Logica();
            CanvasView.Invalidate();
        }
    }
}