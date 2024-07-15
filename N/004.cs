namespace Animacion {
	public partial class Form1 : Form {
		//Constantes para calificar cada celda del Plano
		private const int CAMINO = 0;
		private const int OBSTACULO = 1;
		private const int CAZADOR = 2;
		private const int PRESA = 3;

		//Dónde ocurre realmente la acción
		int[,] Plano;

		//Coordenadas del cazador
		int CazaX, CazaY;

		//Desplazamiento del cazador
		int CazaMX, CazaMY;

		//Coordenadas de la presa
		int PresaX, PresaY;

		//Coordenadas temporales para desatorar
		int tmpX, tmpY;

		//Alterna entre buscar la presa real o
		//ir a la coordenada temporal
		bool BuscaTmp;

		//Único generador de números aleatorios.
		Random Azar;

		public Form1() {
			InitializeComponent();
			Azar = new Random();
			IniciarParametros();
		}

		public void IniciarParametros() {
			//Inicializa el Plano.
			Plano = new int[30, 30];

			//Total de paredes dentro del plano
			int Obstaculos = 150;
			for (int cont = 1; cont <= Obstaculos; cont++) {
				int obstaculoX, obstaculoY;
				do {
					obstaculoX = Azar.Next(0, Plano.GetLength(0));
					obstaculoY = Azar.Next(0, Plano.GetLength(1));
				} while (Plano[obstaculoX, obstaculoY] != 0);
				Plano[obstaculoX, obstaculoY] = OBSTACULO;
			}

			//Inicializa la posición del cazador
			do {
				CazaX = Azar.Next(0, Plano.GetLength(0));
				CazaY = Azar.Next(0, Plano.GetLength(1));
			} while (Plano[CazaX, CazaY] != 0);
			Plano[CazaX, CazaY] = CAZADOR;

			//Inicializa la posición de la presa
			do {
				PresaX = Azar.Next(0, Plano.GetLength(0));
				PresaY = Azar.Next(0, Plano.GetLength(1));
			} while (Plano[PresaX, PresaY] != 0);
			Plano[PresaX, PresaY] = PRESA;

			//Desplazamiento del cazador
			CazaMX = 1;
			CazaMY = 1;

			timer1.Start();
		}


		private void timer1_Tick(object sender, System.EventArgs e) {
			Logica(); //Lógica de la animación
			Refresh(); //Visual de la animación
		}

		public void Logica() {
			Plano[CazaX, CazaY] = CAMINO;

			if (BuscaTmp == false) {
				//Esta buscando la presa
				if (CazaX > PresaX) CazaMX = -1;
				else if (CazaX < PresaX) CazaMX = 1;
				else CazaMX = 0;

				if (CazaY > PresaY) CazaMY = -1;
				else if (CazaY < PresaY) CazaMY = 1;
				else CazaMY = 0;

				//Verifica si ya llegó a la presa
				if (CazaX == PresaX && CazaY == PresaY) {
					timer1.Stop();
					MessageBox.Show("El cazador alcanzó a la presa");
					return;
				}
				//Si no, verifica si puede desplazarse a la nueva ubicación
				else if (Plano[CazaX + CazaMX, CazaY + CazaMY] == CAMINO ||
						Plano[CazaX + CazaMX, CazaY + CazaMY] == PRESA) {
					CazaX += CazaMX;
					CazaY += CazaMY;
				}
				//Si no, entonces está atorado con los obstáculos.
				//Luego genera ubicación temporal para ir allí
				else {
					do {
						tmpX = Azar.Next(0, Plano.GetLength(0));
						tmpY = Azar.Next(0, Plano.GetLength(1));
					} while (Plano[tmpX, tmpY] != CAMINO);
					BuscaTmp = true;
				}
			}
			else { //Está yendo a la ubicación temporal
				if (CazaX > tmpX) CazaMX = -1;
				else if (CazaX < tmpX) CazaMX = 1;
				else CazaMX = 0;

				if (CazaY > tmpY) CazaMY = -1;
				else if (CazaY < tmpY) CazaMY = 1;
				else CazaMY = 0;

				//Si ha llegado a la ubicación temporal o se queda atorado
				//deja de ir a esa ubicación temporal
				if (CazaX == tmpX && CazaY == tmpY ||
					Plano[CazaX + CazaMX, CazaY + CazaMY] == OBSTACULO)
					BuscaTmp = false;
				else {
					CazaX += CazaMX;
					CazaY += CazaMY;
				}
			}

			Plano[CazaX, CazaY] = CAZADOR;
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen Lapiz = new(Color.Blue, 1);
			Brush Llena1 = new SolidBrush(Color.Black);
			Brush Llena2 = new SolidBrush(Color.Red);
			Brush Llena3 = new SolidBrush(Color.Blue);

			//Tamaño de cada celda
			int tX = 500 / Plano.GetLength(0);
			int tY = 500 / Plano.GetLength(1);
			int desplaza = 50;

			//Dibuja el arreglo bidimensional
			for (int Fil = 0; Fil < Plano.GetLength(0); Fil++) {
				for (int Col = 0; Col < Plano.GetLength(1); Col++) {
					int uX = Fil * tX + desplaza;
					int uY = Col * tY + desplaza;
					switch (Plano[Fil, Col]) {
						case CAMINO:
							lienzo.DrawRectangle(Lapiz, uX, uY, tX, tY); 
							break;
						case OBSTACULO:
							lienzo.FillRectangle(Llena1, uX, uY, tX, tY); 
							break;
						case CAZADOR:
							lienzo.FillRectangle(Llena2, uX, uY, tX, tY); 
							break;
						case PRESA:
							lienzo.FillRectangle(Llena3, uX, uY, tX, tY); 
							break;
					}
				}
			}
		}
	}
}