namespace Ejemplo {
    public partial class MainPage : ContentPage {
        //Usa el objeto Reloj para actualizar la posición del rectángulo y redibujar la pantalla
        IDispatcherTimer Reloj;
        int Tiempo = 18;

        int IncrementoX, IncrementoY; //Desplazamiento del cuadrado relleno

        public MainPage() {
            InitializeComponent();

            //Velocidad con que se desplaza el cuadrado relleno
            IncrementoX = 5;
            IncrementoY = 5;

            Reloj = Application.Current?.Dispatcher.CreateTimer();
            Reloj.Interval = TimeSpan.FromMilliseconds(Tiempo);
            if (Reloj is null) return;
            Reloj.Tick += CuandoHaceTick;
            Reloj.Start();
        }


        //Cada vez que hace tick el Reloj, se actualizan las
        //posiciones del rectángulo y se redibuja la pantalla
        void CuandoHaceTick(object? sender, EventArgs e) {
            Logica(); //Lógica de la animación
            CanvasView.Invalidate();
        }

        void Logica() {
            //Si colisiona con alguna pared cambia el incremento
            if (Rectangulo.PosXb > CanvasView.Width || Rectangulo.PosXa < 0)
                IncrementoX *= -1;

            if (Rectangulo.PosYc > CanvasView.Height || Rectangulo.PosYa < 0)
                IncrementoY *= -1;

            //Cambia la posición de X y Y 
            Rectangulo.PosXa += IncrementoX;
            Rectangulo.PosXb += IncrementoX;
            Rectangulo.PosXc += IncrementoX;
            Rectangulo.PosXd += IncrementoX;

            Rectangulo.PosYa += IncrementoY;
            Rectangulo.PosYb += IncrementoY;
            Rectangulo.PosYc += IncrementoY;
            Rectangulo.PosYd += IncrementoY;
        }

    }
}