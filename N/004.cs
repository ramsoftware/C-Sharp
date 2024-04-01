namespace Animacion {
	public partial class Form1 : Form {
		//Constantes para calificar cada celda del tablero
		private const int ESCAMINO = 0;
		private const int ESOBSTACULO = 1;
		private const int ESDEPREDADOR = 2;
		private const int ESPRESA = 3;

		int[,] Tablero; //Dónde ocurre realmente la acción
		int PosDepredaX, PosDepredaY; //Coordenadas del depredador
		int DepredaX, DepredaY; //Desplazamiento del depredador
		int PresaX, PresaY; //Coordenadas de la presa
		int FantasmaX, FantasmaY; //Coordenadas de la presa fantasma para desatorar
		bool BuscaFantasma; //Alterna entre buscar la presa real o la presa fantasma
		Random Azar; //Único generador de números aleatorios.

		public Form1() {
			InitializeComponent();
			Azar = new Random();
			IniciarParametros();
		}

		public void IniciarParametros() {
			//Inicializa el tablero.
			Tablero = new int[30, 30];

			//Habrán obstáculos en el 20%
			int Obstaculos = Tablero.GetLength(0) * Tablero.GetLength(1) * 20 / 100;
			for (int cont = 1; cont <= Obstaculos; cont++) {
				int obstaculoX, obstaculoY;
				do {
					obstaculoX = Azar.Next(0, Tablero.GetLength(0));
					obstaculoY = Azar.Next(0, Tablero.GetLength(1));
				} while (Tablero[obstaculoX, obstaculoY] != 0);
				Tablero[obstaculoX, obstaculoY] = ESOBSTACULO;
			}

			//Inicializa la posición del depredador
			do {
				PosDepredaX = Azar.Next(0, Tablero.GetLength(0));
				PosDepredaY = Azar.Next(0, Tablero.GetLength(1));
			} while (Tablero[PosDepredaX, PosDepredaY] != 0);
			Tablero[PosDepredaX, PosDepredaY] = ESDEPREDADOR;

			//Inicializa la posición de la presa
			do {
				PresaX = Azar.Next(0, Tablero.GetLength(0));
				PresaY = Azar.Next(0, Tablero.GetLength(1));
			} while (Tablero[PresaX, PresaY] != 0);
			Tablero[PresaX, PresaY] = ESPRESA;

			//Desplazamiento del depredador
			DepredaX = 1;
			DepredaY = 1;

			timer1.Start();
		}


		private void timer1_Tick(object sender, System.EventArgs e) {
			Logica(); //Lógica de la animación
			Refresh(); //Visual de la animación
		}

		public void Logica() {
			Tablero[PosDepredaX, PosDepredaY] = ESCAMINO;

			if (BuscaFantasma == false) {
				//Esta buscando la presa
				if (PosDepredaX > PresaX) DepredaX = -1;
				else if (PosDepredaX < PresaX) DepredaX = 1;
				else DepredaX = 0;

				if (PosDepredaY > PresaY) DepredaY = -1;
				else if (PosDepredaY < PresaY) DepredaY = 1;
				else DepredaY = 0;

				if (PosDepredaX == PresaX && PosDepredaY == PresaY) {  //Verifica si ya llegó a la presa
					timer1.Stop();
					MessageBox.Show("El depredador alcanzó a la presa", "Depredador - Presa", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				//Si no, verifica si puede desplazarse a la nueva ubicación
				else if (Tablero[PosDepredaX + DepredaX, PosDepredaY + DepredaY] == ESCAMINO || Tablero[PosDepredaX + DepredaX, PosDepredaY + DepredaY] == ESPRESA) {
					PosDepredaX += DepredaX;
					PosDepredaY += DepredaY;
				}
				else { //Si no, entonces está atorado con los obstáculos. Luego genera coordenadas de presa fantasma
					do {
						FantasmaX = Azar.Next(0, Tablero.GetLength(0));
						FantasmaY = Azar.Next(0, Tablero.GetLength(1));
					} while (Tablero[FantasmaX, FantasmaY] != ESCAMINO);
					BuscaFantasma = true;
				}
			}
			else { //Está buscando la presa fantasma
				if (PosDepredaX > FantasmaX) DepredaX = -1;
				else if (PosDepredaX < FantasmaX) DepredaX = 1;
				else DepredaX = 0;

				if (PosDepredaY > FantasmaY) DepredaY = -1;
				else if (PosDepredaY < FantasmaY) DepredaY = 1;
				else DepredaY = 0;

				//Si ha dado con la presa fantasma o se queda atorado, deja de perseguir la presa fantasma
				if (PosDepredaX == FantasmaX && PosDepredaY == FantasmaY || Tablero[PosDepredaX + DepredaX, PosDepredaY + DepredaY] == ESOBSTACULO)
					BuscaFantasma = false;
				else {
					PosDepredaX += DepredaX;
					PosDepredaY += DepredaY;
				}
			}

			Tablero[PosDepredaX, PosDepredaY] = ESDEPREDADOR;
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Tamaño de cada celda
			int tamanoX = 500 / Tablero.GetLength(0);
			int tamanoY = 500 / Tablero.GetLength(1);
			int desplaza = 50;

			//Dibuja el arreglo bidimensional
			for (int Fila = 0; Fila < Tablero.GetLength(0); Fila++) {
				for (int Columna = 0; Columna < Tablero.GetLength(1); Columna++) {
					int UbicaX = Fila * tamanoX + desplaza;
					int UbicaY = Columna * tamanoY + desplaza;
					switch (Tablero[Fila, Columna]) {
						case ESCAMINO: e.Graphics.DrawRectangle(Pens.Blue, UbicaX, UbicaY, tamanoX, tamanoY); break;
						case ESOBSTACULO: e.Graphics.FillRectangle(Brushes.Black, UbicaX, UbicaY, tamanoX, tamanoY); break;
						case ESDEPREDADOR: e.Graphics.FillRectangle(Brushes.Red, UbicaX, UbicaY, tamanoX, tamanoY); break;
						case ESPRESA: e.Graphics.FillRectangle(Brushes.Blue, UbicaX, UbicaY, tamanoX, tamanoY); break;
					}
				}
			}
		}
	}
}