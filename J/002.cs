namespace Ejemplo {

	// El individuo es una posible solución al problema
	internal class Individuo {
		public int Puntos;
		public string Cadena;

		public Individuo() {
			Puntos = -1;
			Cadena = string.Empty;
		}

		//Operador mutación
		//Cambia una letra al azar de la Cadena
		public void Muta(Random Azar, string Letras) {
			char[] Arreglo = Cadena.ToCharArray();
			int PosA = Azar.Next(Cadena.Length);
			int PosB = Azar.Next(Letras.Length);
			Arreglo[PosA] = Letras[PosB];
			Cadena = new string(Arreglo);
		}

		//Puntaje del individuo
		public void Evalua(string CadenaBusca) {
			Puntos = 0;
			for (int Cont = 0; Cont < CadenaBusca.Length; Cont++)
				if (CadenaBusca[Cont] == Cadena[Cont])
					Puntos++;
		}
	}

	internal class Program {

		//Con que letras se va a formar los individuos
		private const string Letras = "abcdefghijklmnopqrstuvwxyz ";
		
		//Población: conjunto de individuos
		static List<Individuo> Pobl = [];

		static void Main() {
			Random Azar = new();

			string CadenaBusca = "prueba de algoritmos evolutivos";
			OperadorMutacion(Azar, CadenaBusca);
		}

		// Operador mutación
		static void OperadorMutacion(Random Azar, string Busca) {
			int TamanoPoblacion = 350;
			int TotalCiclos = 50000;

			//Crea la población de individuos
			CreaPobl(Azar, TamanoPoblacion, Busca);

			for (int itera = 1; itera <= TotalCiclos; itera++) {

				//Selecciona dos individuos distintos al azar
				int IndivA = Azar.Next(Pobl.Count);
				int IndivB;
				do {
					IndivB = Azar.Next(Pobl.Count);
				} while (IndivA == IndivB);

				// El individuo ganador reemplaza al perdedor
				// muta esa copia y la evalúa
				if (Pobl[IndivA].Puntos > Pobl[IndivB].Puntos) {
					Pobl[IndivB].Cadena = Pobl[IndivA].Cadena;
					Pobl[IndivB].Muta(Azar, Letras);
					Pobl[IndivB].Evalua(Busca);
				}
				else if (Pobl[IndivB].Puntos > Pobl[IndivA].Puntos) {
					Pobl[IndivA].Cadena = Pobl[IndivB].Cadena;
					Pobl[IndivA].Muta(Azar, Letras);
					Pobl[IndivA].Evalua(Busca);
				}

				// Muestra resultados parciales
				if (itera % 4000 == 0) {
					List<Individuo> Temp;
					Temp = Pobl.OrderByDescending(obj => obj.Puntos).ToList();
					Console.Write("Individuo: " + Temp[0].Cadena);
					Console.WriteLine(" Puntos: " + Temp[0].Puntos);
				}
			}

			//Muestra el mejor individuo con el mejor puntaje
			Console.WriteLine("\r\n\r\nFinaliza");
			Pobl = Pobl.OrderByDescending(obj => obj.Puntos).ToList();
			Console.WriteLine("Individuo: " + Pobl[0].Cadena);
			Console.WriteLine("Puntos: " + Pobl[0].Puntos);
		}

		// Crea la población 
		static void CreaPobl(Random Azar, int TotalIndiv, string Busca) {
			//Genera la población
			Pobl.Clear();
			for (int Cont = 1; Cont <= TotalIndiv; Cont++) {
				Individuo obj = new() {
					Cadena = CadAzar(Azar, Busca.Length)
				};
				obj.Evalua(Busca);
				Pobl.Add(obj);
			}
		}

		// Devuelve una cadena al azar
		static string CadAzar(Random Azar, int Tamano) {
			string Cadena = string.Empty;
			for (int Cont = 1; Cont <= Tamano; Cont++)
				Cadena += Letras[Azar.Next(Letras.Length)].ToString();
			return Cadena;
		}
	}
}