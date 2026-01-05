namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo donde va a hacer el gráfico
			Graphics lienzo = e.Graphics;

			//Lápiz con que dibuja. Color, grosor
			Pen lapiz = new(Color.Blue, 2);

			//==============
			//Letras
			//==============
			string Cadena = "Esta es una prueba";

			//Fuente y la brocha con que se pinta.
			Font Fuente = new("Tahoma", 16);
			SolidBrush Brocha = new(Color.Black);

			//Punto arriba a la izquierda para pintar la cadena
			PointF PuntoCadena = new(100.0F, 140.0F);

			//Formato para dibujar
			StringFormat Formato = new();
			Formato.FormatFlags = StringFormatFlags.DirectionVertical;

			//Dibuja la cadena
			lienzo.DrawString(Cadena, Fuente, Brocha, PuntoCadena, Formato);
		}
	}
}