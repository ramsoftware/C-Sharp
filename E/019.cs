using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			List<string> Lista = new List<string>();

			//Adiciona elementos a la lista
			Lista.Add("Ballena");
			Lista.Add("Tortuga");
			Lista.Add("Tiburón");
			Lista.Add("Hipocampo");
			Lista.Add("Delfín");
			Lista.Add("Pulpo");
			Lista.Add("Coral");
			Lista.Add("Pingüinos");
			Lista.Add("Calamar");
			Lista.Add("Gaviota");
			Lista.Add("Foca");
			Lista.Add("Manaties");
			Lista.Add("Orca");
			Lista.Add("Medusas");
			Lista.Add("Mejillones");
			Lista.Add("Caracoles");

			//Tamaño de la lista
			int tamano = Lista.Count;
			Console.WriteLine("Tamaño: " + tamano);

			//Traer un determinado elemento de la lista
			int posicion = 7;
			string texto = Lista[posicion].ToString();
			Console.Write("Posición: " + posicion);
			Console.WriteLine("  : " + texto);

			//Nos dice si existe un determinado
			//elemento en la lista
			string buscar = "Foca";
			bool Existe = Lista.Contains(buscar);
			Console.Write("Busca: " + buscar);
			Console.WriteLine("  Resultado: " + Existe);

			//Nos dice la posición donde encontró
			//el elemento en la lista
			int posBusca = Lista.IndexOf(buscar);
			Console.Write("Busca: " + buscar);
			Console.WriteLine(" Posición: " + posBusca + "\r\n");

			//Imprime la lista
			Console.WriteLine("Lista Original");
			ImprimeLista(Lista);

			//Retira elemento de la lista
			Console.WriteLine("Retira HipoCampo");
			Lista.Remove("Hipocampo");
			ImprimeLista(Lista);

			//Elimina el objeto de determinada posición.
			Console.WriteLine("Retira Elemento posición 5");
			Lista.RemoveAt(5);
			ImprimeLista(Lista);

			//Cambia una cadena en la lista
			Console.WriteLine("Modifica elemento posición 3");
			Lista[3] = "ORNITORRINCO";
			ImprimeLista(Lista);

			//Inserta una cadena en la posición 4 de la lista
			Console.WriteLine("Inserta elemento posición 4");
			Lista.Insert(4, "CACATÚA");
			ImprimeLista(Lista);

			//Genera nueva lista
			int pos = 5;
			int cantidad = 3;
			List<string> nueva = Lista.GetRange(pos, cantidad);
			Console.WriteLine("Nueva lista");
			ImprimeLista(nueva);

			//Recorrido con foreach
			Console.WriteLine("Recorrido con foreach");
			foreach (Object objeto in Lista) 
				Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			//Recorrido con for
			Console.WriteLine("Recorrido con for");
			for (int cont = 0; cont < Lista.Count; cont++) 
				Console.Write("{0}{1}", ";", Lista[cont]);
			Console.WriteLine("\r\n");

			//Recorrido con un IEnumerator
			Console.WriteLine("Recorrido con un IEnumerator");
			IEnumerator Iobjeto = Lista.GetEnumerator();
			while (Iobjeto.MoveNext()) 
				Console.Write("{0}{1}", ";", Iobjeto.Current);
			Console.WriteLine("\r\n");

			//Guarda el List en un arreglo
			//estático de tipo string
			Console.WriteLine("List a arreglo estático");
			string[] cadenas = Lista.ToArray();
			for (int cont = 0; cont < cadenas.Length; cont++) 
				Console.Write(cadenas[cont] + ";");
			Console.WriteLine("\r\n");

			//Adiciona un arreglo estático al List
			Console.WriteLine("Adiciona arreglo estático al List");
			string[] Cadenas = { "Gato", "Perro", "Conejo" };
			Lista.AddRange(Cadenas);
			ImprimeLista(Lista);

			//Inserta un arreglo estático al List
			Console.WriteLine("Inserta arreglo estático al List");
			string[] Aves = { "Azulejo", "Bichofue", "Gavilán" };
			int posicionInserta = 4;
			Lista.InsertRange(posicionInserta, Aves);
			ImprimeLista(Lista);

			//Invierte la lista
			Console.WriteLine("Invierte la lista");
			Lista.Reverse();
			ImprimeLista(Lista);

			//Ordena el List
			Console.WriteLine("Ordena la lista");
			Lista.Sort();
			ImprimeLista(Lista);

			//Busca en forma binaria en el List
			Console.WriteLine("Búsqueda binaria en la lista");
			string Buscar = "Gato";
			int buscado = Lista.BinarySearch(Buscar);
			Console.Write("Buscando a: " + Buscar);
			Console.WriteLine(" encontrado en: " + buscado + "\r\n");

			//Elimina un rango de elementos del List
			Console.WriteLine("Elimina un rango de elementos");
			int PosBorra = 1;
			int CantidadBorra = 4;
			Lista.RemoveRange(PosBorra, CantidadBorra);
			ImprimeLista(Lista);

			//Limpia el List
			Console.WriteLine("Borra el List");
			Console.WriteLine("(Antes) Elementos: " + Lista.Count);
			Lista.Clear();
			Console.WriteLine("(Después) Elementos: " + Lista.Count);
		}

		static void ImprimeLista(List<string> listado) {
			for (int cont = 0; cont < listado.Count; cont++) 
				Console.Write("{0}{1}", ";", listado[cont]);
			Console.WriteLine("\r\n");
		}
	}
}
