namespace Ejemplo {
	internal class Program {
		static void Main(string[] args) {
			//============================================
			//Acceso a variable externa a la expresión lambda
			//============================================
			double valorExterno = 12.345;
			
			//Expresión lambda haciendo uso de un valor externo
			var UnCalculo = (double Parametro) => Parametro * valorExterno;

			//Se usa la expresión
			double Resulta = UnCalculo(5);
			Console.WriteLine("Resultado es: " + Resulta);
		}
	}
}
