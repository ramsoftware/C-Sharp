namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Conversión vs Cast
			double valA = 15.7;

			int valB = Convert.ToInt32(valA); //Redondea
			int valC = (int)valA; //Trunca

			//Ejemplos
			Console.WriteLine("Valor B es: " + valB.ToString());
			Console.WriteLine("Valor C es: " + valC.ToString());
		}
	}
}