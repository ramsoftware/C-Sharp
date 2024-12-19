namespace Ejemplo {
	internal class Program {
		static void Main(string[] args) {
			/*	Hay N ciudades a recorrer (0 a N-1). 
				Sólo se puede visitar una ciudad por vez.
				En la tabla aparece cuanto cuesta ir de una
				ciudad (origen) a otra ciudad (destino).
				¿Qué ruta tomar para visitar todas las
				ciudades con el mínimo costo? */
			Random Azar = new();

			int ciudad = 20; //Número de ciudades

			//Valor mínimo que tendrá ir de una ciudad a otra
			int minValor = 15;

			//Valor máximo que tendrá ir de una ciudad a otra
			int maxValor = 85;

			//Ciudad origen a Ciudad destino
			int dest1, dest2;

			//Genera valores de viaje al azar
			int[,] valorviajes = Valores(ciudad, minValor, maxValor);

			//Imprime los valores
			Imprime(valorviajes);

			//Inicia con una ruta predeterminada 0, 1, 2, 3, .... N
			int[] ruta = IniciaRuta(ciudad);

			//Deduce el costo de esa ruta predeterminada
			int costo = DeduceCosto(ruta, valorviajes);

			Console.WriteLine("\r\nRutas:");
			ImprimeRuta(ruta, costo);

			//Usando el método Monte Carlo se buscarán
			//otras rutas con menor costo
			for (int pruebas = 1; pruebas <= 700000; pruebas++) {
				double r1 = Azar.NextDouble();
				dest1 = (int)Math.Floor( r1 * ruta.Length);

				do {
					double r2 = Azar.NextDouble();
					dest2 = (int)Math.Floor(r2 * ruta.Length);
				} while (dest2 == dest1);

				ModificaRuta(ruta, dest1, dest2);
				
				int costoNuevo = DeduceCosto(ruta, valorviajes);
				
				if (costoNuevo < costo) {
					costo = costoNuevo;
					ImprimeRuta(ruta, costo);
				}
				else {
					//Dejar la ruta como antes
					ModificaRuta(ruta, dest1, dest2);
				}
			}
		}

		//Modifica la ruta de viaje
		static void ModificaRuta(int[] ruta, int dest1, int dest2) {
			int tmp = ruta[dest1];
			ruta[dest1] = ruta[dest2];
			ruta[dest2] = tmp;
		}

		//Inicia el arreglo bidimensional de rutas
		static int[] IniciaRuta(int limite) {
			int[] ruta = new int[limite];
			for (int cont = 0; cont < limite; cont++) 
				ruta[cont] = cont;
			return ruta;
		}

		//Deduce el costo de la ruta de viaje
		static int DeduceCosto(int[] ruta, int[,] costos) {
			int acum = 0;
			for (int cont = 0; cont < ruta.Length - 1; cont++)
				acum += costos[ruta[cont], ruta[cont + 1]];
			return acum;
		}

		//Llena de valores al azar la tabla de costos de viajes
		//de una ciudad a otra
		static int[,] Valores(int ciudad, int minValor, int maxValor) {
			int[,] tablero = new int[ciudad, ciudad];
			Random Azar = new();
			for (int fila = 0; fila < ciudad; fila++) {
				for (int columna = 0; columna < ciudad; columna++) {
					tablero[fila, columna] = Azar.Next(minValor, maxValor);
				}
				tablero[fila, fila] = 0;
			}
			return tablero;
		}

		//Imprime el tablero
		static void Imprime(int[,] tablero) {
			Console.WriteLine("Tabla de costos");
			Console.Write("   ");
			for (int col = 0; col < tablero.GetLength(1); col++)
				Console.Write((char)(col + 65) + "  ");
			Console.WriteLine(" ");

			for (int fila = 0; fila < tablero.GetLength(0); fila++) {
				Console.Write((char)(fila + 65) + ": ");
				for (int col = 0; col < tablero.GetLength(1); col++)
					Console.Write(tablero[fila, col] + " ");
				Console.WriteLine(" ");
			}
		}

		//Imprime la ruta y su costo
		static void ImprimeRuta(int[] ruta, int costo) {
			for (int col = 0; col < ruta.Length; col++) {
				Console.Write((char)(ruta[col] + 65) + "->");
			}
			Console.WriteLine(" $" + costo);
		}
	}
}
