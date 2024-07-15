using System.Collections;

namespace Ejemplo {
	class Program {
		static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList ListaAnimales = new();

			//Adiciona elementos a la lista
			ListaAnimales.Add("Ballena");
			ListaAnimales.Add("Tortuga marina");
			ListaAnimales.Add("Tiburón");
			ListaAnimales.Add("Estrella de mar");
			ListaAnimales.Add("Hipocampo");
			ListaAnimales.Add("Serpiente marina");
			ListaAnimales.Add("Delfín");
			ListaAnimales.Add("Pulpo");
			ListaAnimales.Add("Pingüinos");
			ListaAnimales.Add("Calamar");

			//Tamaño la lista
			int tamano = ListaAnimales.Count;
			Console.WriteLine("Tamaño de la lista: " + tamano);

			//Traer un determinado elemento de la lista
			int posicion = 7;
			string texto = ListaAnimales[posicion].ToString();
			Console.WriteLine("En posición: " + posicion + " es: " + texto);

			//Nos dice si existe un determinado elemento en la lista
			string buscar = "Pulpo";
			bool Existe = ListaAnimales.Contains(buscar);
			Console.WriteLine("Busca: " + buscar + " Resultado: " + Existe);

			//Nos dice la posición donde encontró el elemento en la lista
			int posBusca = ListaAnimales.IndexOf(buscar);
			Console.WriteLine("Busca: " + buscar + " Posición: " + posBusca);

			//Imprime la lista
			foreach (object elemento in ListaAnimales)
				Console.Write("{0}{1}", ";", elemento);
		}
	}
}