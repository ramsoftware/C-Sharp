namespace Ejemplo {

	//Inicia la aplicación aquí
	internal class Program {

		//Una "clase especial" para almacenar constantes
		enum Meses {
			Enero = 1,
			Febrero = 2,
			Marzo = 3,
			Abril = 4,
			Mayo = 5,
			Junio = 6,
			Julio = 7,
			Agosto = 8,
			Septiembre = 9,
			Octubre = 10,
			Noviembre = 11,
			Diciembre = 12
		}
		
		static void Main() {
			Meses unMes = Meses.Junio;
			Console.WriteLine(unMes);
			Console.WriteLine((int) unMes);
		}
	}
}
