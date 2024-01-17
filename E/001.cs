using System.Collections;

namespace Ejemplo {
	class Program {
		static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList ListaAnimales = new ArrayList();

			//Adiciona elementos a la lista
			ListaAnimales.Add("Ballena");
			ListaAnimales.Add("Tortuga marina");
			ListaAnimales.Add("Tiburón");
			ListaAnimales.Add("Estrella de mar");
			ListaAnimales.Add("Hipocampo");
			ListaAnimales.Add("Serpiente marina");
			ListaAnimales.Add("Delfín");
			ListaAnimales.Add("Pulpo");
			ListaAnimales.Add("Caballito de mar");
			ListaAnimales.Add("Coral");
			ListaAnimales.Add("Pingüinos");
			ListaAnimales.Add("Calamar");
			ListaAnimales.Add("Gaviota");
			ListaAnimales.Add("Foca");
			ListaAnimales.Add("Manaties");
			ListaAnimales.Add("Ballena con barba");
			ListaAnimales.Add("Peces Guppy");
			ListaAnimales.Add("Orca");
			ListaAnimales.Add("Medusas");
			ListaAnimales.Add("Mejillones");
			ListaAnimales.Add("Caracoles");

			//Tamaño la lista
			int tamano = ListaAnimales.Count;
			Console.WriteLine("Tamaño de la lista: " + tamano);

			//Traer un determinado elemento de la lista
			int posicion = 7;
			string texto = ListaAnimales[posicion].ToString();
			Console.WriteLine("Elemento en la posición " + posicion + " es: " + texto);

			//Nos dice si existe un determinado elemento en la lista
			string buscar = "Foca";
			bool Existe = ListaAnimales.Contains(buscar);
			Console.WriteLine("Busca: " + buscar + " Resultado: " + Existe);

			//Nos dice la posición donde encontró el elemento en la lista
			int posBusca = ListaAnimales.IndexOf(buscar);
			Console.WriteLine("Busca: " + buscar + " Posición: " + posBusca.ToString());

			//Imprime la lista
			foreach (object elemento in ListaAnimales)
				Console.Write("{0}{1}", ";", elemento);
		}
	}
}
