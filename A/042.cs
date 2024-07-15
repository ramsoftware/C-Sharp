namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Uso del TryParse. Trata de convertir un string a entero 
			string Numero = "150";
			int valorEntero;
			if (Int32.TryParse(Numero, out valorEntero)) {
				Console.WriteLine("Conversión. valorEntero: " + valorEntero);
			}
			else {
				Console.WriteLine("1. No se puede convertir a entero");
			}

			//Segundo ejemplo
			Numero = "4.178"; //Un punto en la cadena
			if (Int32.TryParse(Numero, out valorEntero)) {
				Console.WriteLine("Conversión. valorEntero: " + valorEntero);
			}
			else {
				Console.WriteLine("2. No se puede convertir a entero");
			}

			//Tercer ejemplo
			Numero = "	  90	"; //espacios en la cadena
			if (Int32.TryParse(Numero, out valorEntero)) {
				Console.WriteLine("Conversión. valorEntero: " + valorEntero);
			}
			else {
				Console.WriteLine("3. No se puede convertir a entero");
			}

			//Cuarto ejemplo
			Numero = "-90";
			if (Int32.TryParse(Numero, out valorEntero)) {
				Console.WriteLine("Conversión. valorEntero: " + valorEntero);
			}
			else {
				Console.WriteLine("4. No se puede convertir a entero");
			}

			//Quinto ejemplo
			Numero = "- 90"; //Espacio intermedio
			if (Int32.TryParse(Numero, out valorEntero)) {
				Console.WriteLine("Conversión. valorEntero: " + valorEntero);
			}
			else {
				Console.WriteLine("5. No se puede convertir a entero");
			}
		}
	}
}
