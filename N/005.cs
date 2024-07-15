namespace Animacion {
	public partial class Form1 : Form {
		//Constantes para calificar cada celda del tablero
		private const int INACTIVA = 0;
		private const int ACTIVA = 1;

		int[,] Plano; //Dónde ocurre realmente la acción
		Random Azar; //Único generador de números aleatorios.

		public Form1() {
			InitializeComponent();
			Azar = new Random();
			IniciarParametros();
		}

		private void mnuReiniciar_Click(object sender, EventArgs e) {
			IniciarParametros();
		}

		public void IniciarParametros() {
			//Inicializa el tablero.
			Plano = new int[40, 40];

			//Habrán celdas activas en el 20%
			int Activos = 200;
			for (int cont = 1; cont <= Activos; cont++) {
				int posX, posY;
				do {
					posX = Azar.Next(0, Plano.GetLength(0));
					posY = Azar.Next(0, Plano.GetLength(1));
				} while (Plano[posX, posY] != 0);
				Plano[posX, posY] = ACTIVA;
			}

			timer1.Start();
		}


		private void timer1_Tick(object sender, System.EventArgs e) {
			Logica(); //Lógica de la animación
			Refresh(); //Visual de la animación
		}

		public void Logica() {
			//Copia el tablero a uno temporal   
			int[,] PlanoTmp = Plano.Clone() as int[,];

			//Va de celda en celda
			for (int posX = 0; posX < Plano.GetLength(0); posX++) {
				for (int posY = 0; posY < Plano.GetLength(1); posY++) {

					//Determina el número de vecinos activos
					int BordeXizq;
					if (posX - 1 < 0)
						BordeXizq = Plano.GetLength(0) - 1;
					else
						BordeXizq = posX - 1;

					int BordeYarr;
					if (posY - 1 < 0)
						BordeYarr = Plano.GetLength(1) - 1;
					else
						BordeYarr = posY - 1;

					int BordeXder;
					if (posX + 1 >= Plano.GetLength(0))
						BordeXder = 0;
					else
						BordeXder = posX + 1;


					int BordeYaba;
					if (posY + 1 >= Plano.GetLength(1))
						BordeYaba = 0;
					else
						BordeYaba = posY + 1;

					int Activos = Plano[BordeXizq, BordeYarr];
					Activos += Plano[posX, BordeYarr];
					Activos += Plano[BordeXder, BordeYarr];

					Activos += Plano[BordeXizq, posY];
					Activos += Plano[BordeXder, posY];

					Activos += Plano[BordeXizq, BordeYaba];
					Activos += Plano[posX, BordeYaba];
					Activos += Plano[BordeXder, BordeYaba];

					//Los cambios se registran en el tablero temporal

					//Si la celda está inactiva y tiene 3 celdas activas
					//alrededor, entonces la celda se activa
					if (Plano[posX, posY] == INACTIVA && Activos == 3)
						PlanoTmp[posX, posY] = ACTIVA;

					//Si la celda está activa y tiene menos de 2 celdas o
					//más de 3 celdas, entonces la celda se inactiva
					if (Plano[posX, posY] == ACTIVA &&
						(Activos < 2 || Activos > 3))
						PlanoTmp[posX, posY] = INACTIVA;
				}
			}

			//El cambio en el tablero temporal se copia sobre el tablero
			Plano = PlanoTmp.Clone() as int[,];
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen Lapiz = new(Color.Blue, 1);
			Brush Llena = new SolidBrush(Color.Black);

			//Tamaño de cada celda
			int tX = 600 / Plano.GetLength(0);
			int tY = 600 / Plano.GetLength(1);
			int desplaza = 50;

			//Dibuja el arreglo bidimensional
			for (int Fil = 0; Fil < Plano.GetLength(0); Fil++) {
				for (int Col = 0; Col < Plano.GetLength(1); Col++) {
					int uX = Fil * tX + desplaza;
					int uY = Col * tY + desplaza;
					switch (Plano[Fil, Col]) {
						case INACTIVA:
							lienzo.DrawRectangle(Lapiz, uX, uY, tX, tY);
							break;
						case ACTIVA:
							lienzo.FillRectangle(Llena, uX, uY, tX, tY);
							break;
					}
				}
			}
		}
	}
}
