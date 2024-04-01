namespace Animacion {
	public partial class Form1 : Form {
		int[,] Tablero; //Dónde ocurre realmente la acción
		int PosX, PosY; //Coordenadas del cuadrado relleno
		int IncrementoX, IncrementoY; //Desplazamiento del cuadrado relleno

		public Form1() {
			InitializeComponent();

			//Inicializa el tablero
			Tablero = new int[30, 30];

			//Inicializa la posición del cuadrado relleno
			Random azar = new();
			PosX = azar.Next(0, Tablero.GetLength(0));
			PosY = azar.Next(0, Tablero.GetLength(1));

			//Desplaza el cuadrado relleno
			IncrementoX = 1;
			IncrementoY = 1;
		}

		private void timer1_Tick(object sender, System.EventArgs e) {
			Logica(); //Lógica de la animación
			Refresh(); //Visual de la animación
		}

		void Logica() {
			//Borra la posición anterior
			Tablero[PosX, PosY] = 0;

			//Si colisiona con alguna pared cambia el incremento
			if (PosX + IncrementoX >= Tablero.GetLength(0) || PosX + IncrementoX < 0) IncrementoX *= -1;
			if (PosY + IncrementoY >= Tablero.GetLength(1) || PosY + IncrementoY < 0) IncrementoY *= -1;

			//Cambia la posición de X y Y 
			PosX += IncrementoX;
			PosY += IncrementoY;

			//Nueva posición
			Tablero[PosX, PosY] = 1;
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Tamaño de cada celda
			int tamanoX = ClientSize.Width / Tablero.GetLength(0);
			int tamanoY = ClientSize.Height / Tablero.GetLength(1);

			//Fondo de la ventana
			e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, this.Height));

			//Dibuja la malla y la posición del rectángulo relleno
			for (int Fila = 0; Fila < Tablero.GetLength(0); Fila++) {
				for (int Columna = 0; Columna < Tablero.GetLength(1); Columna++)
					if (Tablero[Fila, Columna] == 0)
						e.Graphics.DrawRectangle(Pens.Blue, Fila * tamanoX, Columna * tamanoY, tamanoX, tamanoY);
					else
						e.Graphics.FillRectangle(Brushes.Chocolate, Fila * tamanoX, Columna * tamanoY, tamanoX, tamanoY);
			}
		}
	}
}