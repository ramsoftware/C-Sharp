namespace Animacion {
	public partial class Form1 : Form {
		int[,] Plano; //Dónde ocurre realmente la acción
		int PosX, PosY; //Coordenadas del cuadrado relleno
		int IncrX, IncrY; //Desplazamiento del cuadrado relleno

		public Form1() {
			InitializeComponent();

			//Inicializa el tablero
			Plano = new int[30, 30];

			//Inicializa la posición del cuadrado relleno
			Random azar = new();
			PosX = azar.Next(0, Plano.GetLength(0));
			PosY = azar.Next(0, Plano.GetLength(1));

			//Desplaza el cuadrado relleno
			IncrX = 1;
			IncrY = 1;
		}

		private void timer1_Tick(object sender, System.EventArgs e) {
			Logica(); //Lógica de la animación
			Refresh(); //Visual de la animación
		}

		void Logica() {
			//Borra la posición anterior
			Plano[PosX, PosY] = 0;

			//Si colisiona con alguna pared cambia el incremento
			if (PosX + IncrX >= Plano.GetLength(0) || PosX + IncrX < 0)
				IncrX *= -1;

			if (PosY + IncrY >= Plano.GetLength(1) || PosY + IncrY < 0)
				IncrY *= -1;

			//Cambia la posición de X y Y 
			PosX += IncrX;
			PosY += IncrY;

			//Nueva posición
			Plano[PosX, PosY] = 1;
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen Lapiz = new(Color.Blue, 1);
			Brush Llena = new SolidBrush(Color.Red);

			//Tamaño de cada celda
			int tX = ClientSize.Width / Plano.GetLength(0);
			int tY = ClientSize.Height / Plano.GetLength(1);

			//Fondo de la ventana
			Rectangle rect = new(0, 0, this.Width, this.Height);
			lienzo.FillRectangle(Brushes.Black, rect);

			//Dibuja la malla y la posición del rectángulo relleno
			for (int Fil = 0; Fil < Plano.GetLength(0); Fil++) {
				for (int Col = 0; Col < Plano.GetLength(1); Col++)
					if (Plano[Fil, Col] == 0)
						lienzo.DrawRectangle(Lapiz, Fil * tX, Col * tY, tX, tY);
					else
						lienzo.FillRectangle(Llena, Fil * tX, Col * tY, tX, tY);
			}
		}
	}
}