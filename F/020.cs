namespace Ejemplo {
	internal class Program {
		static void Main() {
			List<string> Textos = new List<string>(){ "abc", "Opq", "Afv", "Tkl", "qaz", "Akh", "oSd", "uyt", "oxv" };
			
			//Extrae las palabras que empiezan con "a"
			var PalabraMinusculaA = from palabra in Textos
				where palabra.ToLower().StartsWith("a")
				select palabra.ToLower();
			
			foreach(string Cadena in PalabraMinusculaA) Console.WriteLine(Cadena);
			
			//Extrae las palabras que empiezan con "o" usando la instrucción Let
			var PalabraMinusculaB = from palabra in Textos
				let minuscula = palabra.ToLower()
				where minuscula.StartsWith("o")
				select minuscula;
			
			foreach(string Cadena in PalabraMinusculaB) Console.WriteLine(Cadena);
		}
	}
}
