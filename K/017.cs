namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo
			Graphics grafico = e.Graphics;

			//Primer gráfico
			Pen lapiz = new Pen(Color.Blue, 2);
			int contador = 10;
			int incremento = 2;

			do {
				grafico.DrawLine(lapiz, 10, contador, 300, contador);
				incremento++;
				contador += incremento; //Incrementa el espacio entre línea y línea
			} while (contador <= 602);
			contador -= incremento;

			//Segundo gráfico
			Pen lapiz2 = new Pen(Color.Red, 2);
			incremento = 2;
			do {
				grafico.DrawLine(lapiz2, 300, contador, 590, contador);
				incremento++;
				contador -= incremento;
			} while (contador >= 10);
		}
	}
}
