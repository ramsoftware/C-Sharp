namespace Ejemplo {

	//Inicia la aplicación aquí
	internal class Program {
		public static void Main() {
			Procedimiento();

			//Ejecuta el Garbage Collector
			GC.Collect(); //Limpia todo
			GC.WaitForPendingFinalizers(); //Espera que se limpie todo

			Console.WriteLine("Termina el programa");
		}

		public static void Procedimiento() {
			//Se instancia la clase con una variable local
			MiClase objClase = new MiClase(2010, 7.15, 'S', "Sally");
			objClase.Imprime();

			//Aquí debería ejecutarse el destructor de esa clase
		}
	}
}
