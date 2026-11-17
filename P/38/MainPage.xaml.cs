namespace Ejemplo {
    public partial class MainPage : ContentPage {
        //Usa el objeto timer para actualizar la posición del rectángulo y redibujar la pantalla
        IDispatcherTimer timer;
        int Mueve = 1;

        public MainPage() {
            InitializeComponent();

            timer = Application.Current?.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16); // 60 FPS aproximadamente
            if (timer is null) return;
            timer.Tick += OnTick;
            timer.Start();
        }


        //Cada vez que hace tick el timer, se actualizan las
        //posiciones del rectángulo y se redibuja la pantalla
        void OnTick(object? sender, EventArgs e) {
            //Se mueve siempre que el rectángulo no se salga de los límites del canvas
            if ((Mueve == 1 && Rectangulo.PosXb <= CanvasView.Width) ||
                (Mueve == -1 && Rectangulo.PosXa >= 0)) {
                Rectangulo.PosXa += Mueve;
                Rectangulo.PosXb += Mueve;
                Rectangulo.PosXc += Mueve;
                Rectangulo.PosXd += Mueve;
                CanvasView.Invalidate();
            }
        }

        void PresionaIzquierda(object sender, EventArgs e) {
            Mueve = -1;
        }

        void PresionaDerecha(object sender, EventArgs e) {
            Mueve = 1;
        }
    }
}