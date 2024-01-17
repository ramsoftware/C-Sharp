namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Operador ?
			int valA = 10;
			int valB = 13;
			string resultado = valA > valB ? "A es mayor": "B es mayor o igual";
			Console.WriteLine(resultado);

			//Segundo ejemplo
			int valC = 10;
			int valD = 13;
			int valE = 34;
			string imprimir = valE > valD && valC <= valD ? "Primero" : "de lo contrario, Segundo";
			Console.WriteLine(imprimir);
		}
	}
}