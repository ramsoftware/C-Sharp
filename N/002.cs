namespace Animacion {
	public partial class Form1 : Form {
		int PosX, PosY; //Coordenadas del cuadrado relleno
		int Tamano; //Tamaño del lado del cuadrado
		int IncrementoX, IncrementoY; //Desplazamiento del cuadrado relleno

		public Form1() {
			InitializeComponent();

			//Inicializa la posición y tamaño del cuadrado relleno
			PosX = 10;
			PosY = 20;
			Tamano = 40;

			//Velocidad con que se desplaza el cuadrado relleno
			IncrementoX = 5;
			IncrementoY = 5;
		}

		private void timer1_Tick(object sender, System.EventArgs e) {
			Logica(); //Lógica de la animación
			Refresh(); //Visual de la animación
		}

		void Logica() {
			//Si colisiona con alguna pared cambia el incremento
			if (PosX + Tamano > this.ClientSize.Width || PosX < 0)
				IncrementoX *= -1;
			
			if (PosY + Tamano > this.ClientSize.Height || PosY < 0)
				IncrementoY *= -1;

			//Cambia la posición de X y Y 
			PosX += IncrementoX;
			PosY += IncrementoY;
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			
			//Fondo de la ventana
			Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
			Lienzo.FillRectangle(Brushes.Black, rect);

			//Gráfico a animar
			Lienzo.FillRectangle(Brushes.Red, PosX, PosY, Tamano, Tamano);
		}
	}
}