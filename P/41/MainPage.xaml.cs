namespace Ejemplo {
    public partial class MainPage : ContentPage {
        //Usa el objeto Reloj para actualizar la posición del rectángulo y redibujar la pantalla
        IDispatcherTimer Reloj;

        public MainPage() {
            InitializeComponent();

            //Inicia el reloj
            Reloj = Application.Current?.Dispatcher.CreateTimer();
            Reloj.Interval = TimeSpan.FromMilliseconds(40);
            if (Reloj is null) return;
            Reloj.Tick += PorCadaTick;
            Reloj.Start();
        }


        //Cada vez que hace tick el Reloj, se actualizan las
        //posiciones del rectángulo y se redibuja la pantalla
        void PorCadaTick(object? sender, EventArgs e) {
            Rectangulo.Logica(); //Lógica de la animación
            CanvasView.Invalidate();
        }
    }
}