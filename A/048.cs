namespace Ejemplo {
	internal class Program {
		static void Main() {

			//Ciclos anidados simulando 
			//un minutero y un segundero
			for (int minuto = 0; minuto <= 10; minuto++) {
				for (int segundo = 0; segundo < 60; segundo++) {
					Console.WriteLine(minuto + ":" + segundo);
				}
			}
		}
	}
}