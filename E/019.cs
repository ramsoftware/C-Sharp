using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			List<string> ListaAnimales = new List<string>();

			//Adiciona elementos a la lista
			ListaAnimales.Add("Ballena");
			ListaAnimales.Add("Tortuga");
			ListaAnimales.Add("Tiburón");
			ListaAnimales.Add("Hipocampo");
			ListaAnimales.Add("Delfín");
			ListaAnimales.Add("Pulpo");
			ListaAnimales.Add("Coral");
			ListaAnimales.Add("Pingüinos");
			ListaAnimales.Add("Calamar");
			ListaAnimales.Add("Gaviota");
			ListaAnimales.Add("Foca");
			ListaAnimales.Add("Manaties");
			ListaAnimales.Add("Orca");
			ListaAnimales.Add("Medusas");
			ListaAnimales.Add("Mejillones");
			ListaAnimales.Add("Caracoles");

			//Tamaño de la lista
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
			Console.WriteLine("Busca: " + buscar + " Posición: " + posBusca.ToString() + "\r\n");

			//Imprime la lista
			Console.WriteLine("Lista Original");
			ImprimeLista(ListaAnimales);

			//Retira elemento de la lista
			Console.WriteLine("Retira HipoCampo");
			ListaAnimales.Remove("Hipocampo");
			ImprimeLista(ListaAnimales);

			//Elimina el objeto de determinada posición.
			Console.WriteLine("Retira Elemento posición 5");
			ListaAnimales.RemoveAt(5);
			ImprimeLista(ListaAnimales);

			//Cambia una cadena en la lista
			Console.WriteLine("Modifica elemento posición 3");
			ListaAnimales[3] = "ORNITORRINCO";
			ImprimeLista(ListaAnimales);

			//Inserta una cadena en la posición 4 de la lista
			Console.WriteLine("Inserta elemento posición 4");
			ListaAnimales.Insert(4, "CACATÚA");
			ImprimeLista(ListaAnimales);

			//Genera nueva lista
			int posicionInicial = 5;
			int cantidad = 3;
			List<string> nuevaLista = ListaAnimales.GetRange(posicionInicial, cantidad);
			Console.WriteLine("Nueva lista");
			ImprimeLista(nuevaLista);

			//Recorrido con foreach
			Console.WriteLine("Recorrido con foreach");
			foreach (Object objeto in ListaAnimales) Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			//Recorrido con for
			Console.WriteLine("Recorrido con for");
			for (int cont = 0; cont < ListaAnimales.Count; cont++) 
				Console.Write("{0}{1}", ";", ListaAnimales[cont]);
			Console.WriteLine("\r\n");

			//Recorrido con un IEnumerator
			Console.WriteLine("Recorrido con un IEnumerator");
			IEnumerator Iobjeto = ListaAnimales.GetEnumerator();
			while (Iobjeto.MoveNext()) Console.Write("{0}{1}", ";", Iobjeto.Current);
			Console.WriteLine("\r\n");

			//Guarda el List en un arreglo estático de tipo string
			Console.WriteLine("Pasa el List a un arreglo estático de tipo cadena");
			string[] cadenas = ListaAnimales.ToArray();
			for (int cont = 0; cont < cadenas.Length; cont++) Console.Write(cadenas[cont] + ";");
			Console.WriteLine("\r\n");

			//Adiciona un arreglo estático al List
			Console.WriteLine("Adiciona un arreglo estático al List");
			string[] Cadenas = { "Gato", "Perro", "Conejo", "Liebre", "Oveja" };
			ListaAnimales.AddRange(Cadenas);
			ImprimeLista(ListaAnimales);

			//Inserta un arreglo estático al List
			Console.WriteLine("Inserta un arreglo estático al List");
			string[] Aves = { "Azulejo", "Bichofue", "Paloma", "Gavilán", "Halcón" };
			int posicionInserta = 4;
			ListaAnimales.InsertRange(posicionInserta, Aves);
			ImprimeLista(ListaAnimales);

			//Invierte la lista
			Console.WriteLine("Invierte la lista");
			ListaAnimales.Reverse();
			ImprimeLista(ListaAnimales);

			//Ordena el List
			Console.WriteLine("Ordena la lista");
			ListaAnimales.Sort();
			ImprimeLista(ListaAnimales);

			//Busca en forma binaria en el List
			Console.WriteLine("Búsqueda binaria en la lista");
			string Buscar = "Gato";
			int buscado = ListaAnimales.BinarySearch(Buscar);
			Console.WriteLine("Buscando a: " + Buscar + " encontrado en: " + buscado.ToString() + "\r\n");

			//Elimina un rango de elementos del List
			Console.WriteLine("Elimina un rango de elementos");
			int PosBorra = 1;
			int CantidadBorra = 4;
			ListaAnimales.RemoveRange(PosBorra, CantidadBorra);
			ImprimeLista(ListaAnimales);

			//Limpia el List
			Console.WriteLine("Borra el List");
			Console.WriteLine("(Antes) Total de elementos: " + ListaAnimales.Count);
			ListaAnimales.Clear();
			Console.WriteLine("(Después) Total de elementos: " + ListaAnimales.Count);
		}

		static void ImprimeLista(List<string> listado) {
			for (int cont = 0; cont < listado.Count; cont++) 
				Console.Write("{0}{1}", ";", listado[cont]);
			Console.WriteLine("\r\n");
		}
	}
}
