namespace Ejemplo {
	class Program {
		static void Main() {
			//Se define una lista enlazada
			LinkedList<string> Lenguajes = new LinkedList<string>();
			
			//Agrega al final
			Lenguajes.AddLast("Visual Basic .NET");
			Lenguajes.AddLast("F#");
			Lenguajes.AddLast("C#");
			Lenguajes.AddLast("TypeScript");

			//Imprime esa lista
			Console.WriteLine("Agregando con AddLast");
			foreach (string elemento in Lenguajes) Console.Write(elemento + "; ");

			//Agrega al inicio
			Lenguajes.AddFirst("C++");
			Lenguajes.AddFirst("C");

			//Imprime esa lista
			Console.WriteLine("\r\n\r\nAgregando con AddFirst");
			foreach (string elemento in Lenguajes) Console.Write(elemento + "; ");

			//Agrega al final
			Lenguajes.AddLast("Python");
			Console.WriteLine("\r\n\r\nAgregando con AddLast");
			foreach (string elemento in Lenguajes) Console.Write(elemento + "; ");

			//Cantidad
			Console.WriteLine("\r\n\r\nCantidad es: " + Lenguajes.Count);

			//Elimina primer elemento
			Lenguajes.RemoveFirst();
			Console.WriteLine("\r\nEliminado el primer elemento");
			foreach (string elemento in Lenguajes) Console.Write(elemento + "; ");

			//Elimina último elemento
			Lenguajes.RemoveLast();
			Console.WriteLine("\r\n\r\nEliminado el último elemento");
			foreach (string elemento in Lenguajes) Console.Write(elemento + "; ");

			//Elimina determinado elemento
			Lenguajes.Remove("F#");
			Console.WriteLine("\r\n\r\nEliminado F#");
			foreach (string elemento in Lenguajes) Console.Write(elemento + "; ");

			//Adiciona antes de C#
			LinkedListNode<string> nodoPosiciona = Lenguajes.Find("C#"); //Busca el nodo que tiene C#
			Lenguajes.AddBefore(nodoPosiciona, "Assembler");
			Console.WriteLine("\r\n\r\nAdiciona antes de C#");
			foreach (string elemento in Lenguajes) Console.Write(elemento + "; ");

			//Adiciona después de C#
			Lenguajes.AddAfter(nodoPosiciona, "Ada");
			Console.WriteLine("\r\n\r\nAdiciona después de C#");
			foreach (string elemento in Lenguajes) Console.Write(elemento + "; ");
		}
	}
}
