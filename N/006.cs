namespace Animacion {
	public partial class Form1 : Form {
		//Constantes para calificar cada celda del tablero
		private const int VACIO = 0;
		private const int SANO = 1;
		private const int INFECTADO = 2;

		int[,] Plano; //Dónde ocurre realmente la acción

		Random azar;

		//Tamaño de cada celda
		int tamF, tamC, desplaza;

		//Población
		List<Individuo> Pobl;

		public Form1() {
			InitializeComponent();
			IniciarParametros();
		}

		public void IniciarParametros() {
			Plano = new int[30, 30]; //Inicializa el tablero.
			azar = new Random();

			//Inicializa la población
			Pobl = new List<Individuo>();
			int NumIndividuos = 100;
			for (int cont = 1; cont <= NumIndividuos; cont++) {
				int Fila, Columna;
				do {
					Fila = azar.Next(Plano.GetLength(0));
					Columna = azar.Next(Plano.GetLength(1));
				} while (Plano[Fila, Columna] != VACIO);
				Plano[Fila, Columna] = SANO;
				Pobl.Add(new Individuo(Fila, Columna, SANO));
			}

			//Inicia con un individuo infectado
			Pobl[azar.Next(NumIndividuos)].Estado = INFECTADO;

			timer1.Start();
		}


		private void timer1_Tick(object sender, System.EventArgs e) {
			Logica();
			Refresh(); //Visual de la animación
		}

		//Lógica de la población
		private void Logica() {
			int NumFil = Plano.GetLength(0);
			int NumCol = Plano.GetLength(1);

			//Mueve los individuos
			for (int cont = 0; cont < Pobl.Count; cont++)
				Pobl[cont].Mover(azar.Next(8), NumFil, NumCol);

			//Limpia el tablero
			for (int Fil = 0; Fil < NumFil; Fil++)
				for (int Col = 0; Col < NumCol; Col++)
					Plano[Fil, Col] = VACIO;

			//Refleja ese movimiento en el tablero
			for (int cont = 0; cont < Pobl.Count; cont++) {
				int Fila = Pobl[cont].Fila;
				int Columna = Pobl[cont].Columna;
				Plano[Fila, Columna] = Pobl[cont].Estado;
			}

			//Chequea si un individuo infectado coincide con un
			//individuo sano en la misma casilla para infectarlo
			for (int cont = 0; cont < Pobl.Count; cont++) {
				if (Pobl[cont].Estado == INFECTADO) {
					for (int busca = 0; busca < Pobl.Count; busca++) {
						if (Pobl[cont].Fila == Pobl[busca].Fila &&
							Pobl[cont].Columna == Pobl[busca].Columna)
							Pobl[busca].Estado = INFECTADO;
					}
				}
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen Lapiz = new(Color.Blue, 1);
			Brush Llena1 = new SolidBrush(Color.Black);
			Brush Llena2 = new SolidBrush(Color.Red);

			//Tamaño de cada celda
			tamF = 500 / Plano.GetLength(0);
			tamC = 500 / Plano.GetLength(1);
			desplaza = 50;

			//Dibuja el arreglo bidimensional
			for (int Fil = 0; Fil < Plano.GetLength(0); Fil++) {
				for (int Col = 0; Col < Plano.GetLength(1); Col++) {
					int uF = Fil * tamF + desplaza;
					int uC = Col * tamC + desplaza;
					switch (Plano[Fil, Col]) {
						case VACIO: 
							lienzo.DrawRectangle(Lapiz, uF, uC, tamF, tamC); 
							break;
						case SANO: 
							lienzo.FillRectangle(Llena1, uF, uC, tamF, tamC); 
							break;
						case INFECTADO: 
							lienzo.FillRectangle(Llena2, uF, uC, tamF, tamC); 
							break;
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
