namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo donde va a hacer el gráfico
			Graphics lienzo = e.Graphics;

			//Lápiz con que dibuja. Color, grosor
			Pen lapiz = new Pen(Color.Blue, 2);

			//==============
			//Letras
			//==============
			string Cadena = "Esta es una prueba";

			//Fuente y la brocha con que se pinta.
			Font FuenteLetra = new Font("Tahoma", 16);
			SolidBrush BrochaPinta = new SolidBrush(Color.Black);

			//Punto arriba a la izquierda para pintar la cadena
			PointF PuntoCadena = new PointF(100.0F, 140.0F);

			//Formato para dibujar
			StringFormat FormatoDibuja = new StringFormat();
			FormatoDibuja.FormatFlags = StringFormatFlags.DirectionVertical;

			//Dibuja la cadena
			lienzo.DrawString(Cadena, FuenteLetra, BrochaPinta, PuntoCadena, FormatoDibuja);
		}
	}
}
