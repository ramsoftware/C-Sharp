namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo
			Graphics grafico = e.Graphics;
			Pen lapiz = new Pen(Color.Blue, 2);
			int contador = 10;
			int incremento = 2;

			//Primer gráfico
			do {
				grafico.DrawLine(lapiz, contador, 10, contador, 200);
				incremento++;
				//Incrementa el espacio entre línea y línea
				contador += incremento;
			}
			while (contador <= 602);
			contador -= incremento;

			//Segundo gráfico
			Pen lapiz2 = new Pen(Color.Red, 2);
			incremento = 2;
			do {
				grafico.DrawLine(lapiz2, contador, 200, contador, 380);
				incremento++;
				contador -= incremento;
			}
			while (contador >= 10);
		}
	}
}
