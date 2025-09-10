namespace Graficos {

	public partial class Form1 : Form {
		private Bitmap Lienzo;

		public Form1() {
			InitializeComponent();

			//Uso de bitmap para hacer gráficos
			Lienzo = new Bitmap(200, 200);
			Graphics Grafico = Graphics.FromImage(Lienzo);
			Grafico.Clear(Color.White);
			Pen Lapiz = new(Color.Green, 4);
			Grafico.DrawEllipse(Lapiz, 25, 25, 150, 150); // Círculo
		}

		//Pintar
		private void Form1_Paint(object sender, PaintEventArgs e) {
			e.Graphics.DrawImage(Lienzo, 50, 50);
		}
	}
}