namespace Ejemplo;

//Inicia la aplicación aquí
internal class Program {

	//Una "clase especial" para almacenar constantes
	enum Meses {
		Enero, //0
		Febrero, //1
		Marzo, //2
		Abril, //3
		Mayo,  //4
		Junio,  //5
		Julio,  //6
		Agosto,  //7
		Septiembre, //8
		Octubre,  //9
		Noviembre,  //10
		Diciembre  //11
	}

	static void Main() {
		Meses unMes = Meses.Junio;
		Console.WriteLine(unMes);
		Console.WriteLine((int)unMes);
	}
}