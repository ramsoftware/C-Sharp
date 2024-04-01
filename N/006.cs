namespace Animacion {
	public partial class Form1 : Form {
		//Constantes para calificar cada celda del tablero
		private const int VACIO = 0;
		private const int SANO = 1;
		private const int INFECTADO = 2;

		int[,] Tablero; //Dónde ocurre realmente la acción

		Random azar;

		//Tamaño de cada celda
		int tamanoFila, tamanoColumna, desplaza;

		//Población
		List<Individuo> Individuos;

		public Form1() {
			InitializeComponent();
			IniciarParametros();
		}

		public void IniciarParametros() {
			Tablero = new int[30, 30]; //Inicializa el tablero.
			azar = new Random();

			//Tamaño de cada celda
			tamanoFila = 500 / Tablero.GetLength(0);
			tamanoColumna = 500 / Tablero.GetLength(1);
			desplaza = 50;

			//Inicializa la población
			Individuos = new List<Individuo>();
			int NumIndividuos = 100;
			for (int cont = 1; cont <= NumIndividuos; cont++) {
				int Fila, Columna;
				do {
					Fila = azar.Next(Tablero.GetLength(0));
					Columna = azar.Next(Tablero.GetLength(1));
				} while (Tablero[Fila, Columna] != VACIO);
				Tablero[Fila, Columna] = SANO;
				Individuos.Add(new Individuo(Fila, Columna, SANO));
			}

			//Inicia con un individuo infectado
			Individuos[azar.Next(NumIndividuos)].Estado = INFECTADO;

			timer1.Start();
		}


		private void timer1_Tick(object sender, System.EventArgs e) {
			Logica();
			Refresh(); //Visual de la animación
		}

		//Lógica de la población
		private void Logica() {

			//Mueve los individuos
			for (int cont = 0; cont < Individuos.Count; cont++)
				Individuos[cont].Mover(azar.Next(8), Tablero.GetLength(0), Tablero.GetLength(1));

			//Limpia el tablero
			for (int Fila = 0; Fila < Tablero.GetLength(0); Fila++)
				for (int Columna = 0; Columna < Tablero.GetLength(1); Columna++)
					Tablero[Fila, Columna] = VACIO;

			//Refleja ese movimiento en el tablero
			for (int cont = 0; cont < Individuos.Count; cont++) {
				int Fila = Individuos[cont].Fila;
				int Columna = Individuos[cont].Columna;
				Tablero[Fila, Columna] = Individuos[cont].Estado;
			}

			//Chequea si un individuo infectado coincide con un individuo sano en la misma casilla para infectarlo
			for (int cont = 0; cont < Individuos.Count; cont++) {
				if (Individuos[cont].Estado == INFECTADO) {
					for (int busca = 0; busca < Individuos.Count; busca++) {
						if (Individuos[cont].Fila == Individuos[busca].Fila &&
							Individuos[cont].Columna == Individuos[busca].Columna)
							Individuos[busca].Estado = INFECTADO;
					}
				}
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Dibuja el arreglo bidimensional
			for (int Fila = 0; Fila < Tablero.GetLength(0); Fila++) {
				for (int Columna = 0; Columna < Tablero.GetLength(1); Columna++) {
					int UbicaFila = Fila * tamanoFila + desplaza;
					int UbicaColumna = Columna * tamanoColumna + desplaza;
					switch (Tablero[Fila, Columna]) {
						case VACIO: e.Graphics.DrawRectangle(Pens.Blue, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
						case SANO: e.Graphics.FillRectangle(Brushes.Black, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
						case INFECTADO: e.Graphics.FillRectangle(Brushes.Red, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
					}
				}
			}
		}
	}

	internal class Individuo {
		public int Fila, Columna, Estado;

		public Individuo(int Fila, int Columna, int Estado) {
			this.Fila = Fila;
			this.Columna = Columna;
			this.Estado = Estado;
		}

		public void Mover(int direccion, int NumFilas, int NumColumnas) {
			switch (direccion) {
				case 0: Fila--; Columna--; break;
				case 1: Fila--; break;
				case 2: Fila--; Columna++; break;
				case 3: Columna--; break;
				case 4: Columna++; break;
				case 5: Fila++; Columna--; break;
				case 6: Fila++; break;
				case 7: Fila++; Columna++; break;
			}

			if (Fila < 0) Fila = 0;
			if (Columna < 0) Columna = 0;
			if (Fila >= NumFilas) Fila = NumFilas - 1;
			if (Columna >= NumColumnas) Columna = NumColumnas - 1;
		}
	}
}
