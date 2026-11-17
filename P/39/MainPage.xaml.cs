namespace Animacion {
    public partial class MainPage : ContentPage {
        //Usa el objeto timer para actualizar la posición del rectángulo y redibujar la pantalla
        IDispatcherTimer timer;
        int MueveX = 1;
        int MueveY = 0;
        int Tiempo = 18;

        public MainPage() {
            InitializeComponent();

            timer = Application.Current?.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(Tiempo);
            if (timer is null) return;
            timer.Tick += OnTick;
            timer.Start();
        }


        //Cada vez que hace tick el timer, se actualizan las
        //posiciones del rectángulo y se redibuja la pantalla
        void OnTick(object? sender, EventArgs e) {
            //Se mueve siempre que el rectángulo no se salga de los límites del canvas
            if ((MueveX == 1 && Rectangulo.PosXb <= CanvasView.Width) ||
                (MueveX == -1 && Rectangulo.PosXa >= 0)) {
                Rectangulo.PosXa += MueveX;
                Rectangulo.PosXb += MueveX;
                Rectangulo.PosXc += MueveX;
                Rectangulo.PosXd += MueveX;
            }

            //Se mueve siempre que el rectángulo no se salga de los límites del canvas
            if ((MueveY == 1 && Rectangulo.PosYb <= CanvasView.Height) ||
                (MueveY == -1 && Rectangulo.PosYa >= 0)) {
                Rectangulo.PosYa += MueveY;
                Rectangulo.PosYb += MueveY;
                Rectangulo.PosYc += MueveY;
                Rectangulo.PosYd += MueveY;
            }

            CanvasView.Invalidate();
        }

        void PresionaIzquierda(object sender, EventArgs e) {
            MueveX = -1;
            MueveY = 0;
        }

        void PresionaDerecha(object sender, EventArgs e) {
            MueveX = 1;
            MueveY = 0;
        }

        void PresionaArriba(object sender, EventArgs e) {
            MueveY = -1;
            MueveX = 0;
        }

        void PresionaAbajo(object sender, EventArgs e) {
            MueveY = 1;
            MueveX = 0;
        }

        void MasVelocidad(object sender, EventArgs e) {
            if (Tiempo > 3) {
                Tiempo -= 3;
                timer.Interval = TimeSpan.FromMilliseconds(Tiempo);
            }
        }

        void MenosVelocidad(object sender, EventArgs e) {
            if (Tiempo < 60) {
                Tiempo += 3;
                timer.Interval = TimeSpan.FromMilliseconds(Tiempo);
            }
        }
    }
}