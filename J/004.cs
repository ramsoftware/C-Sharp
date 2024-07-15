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

		//Operador cruce: Cruza dos cadenas en sitios al azar
		public void Cruce(Random Azar, string CadenaA, string CadenaB) {
			int Pos = Azar.Next(CadenaA.Length);

			//Cadena = IzquierdaA + DerechaB o
			//Cadena = DerechaB + IzquierdaA
			if (Azar.NextDouble() < 0.5)
				Cadena = CadenaA[..Pos] + CadenaB[Pos..];
			else
				Cadena = CadenaB[Pos..] + CadenaA[..Pos];
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
			CruceMuta(Azar, CadenaBusca);
		}

		// Operador mutación
		static void CruceMuta(Random Azar, string Busca) {
			int TamanoPoblacion = 500;
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

				//Crea el hijo cruzando porciones de cadena de ambos padres
				//y luego muta ese hijo
				Individuo Hijo = new();
				Hijo.Cruce(Azar, Pobl[IndivA].Cadena, Pobl[IndivB].Cadena);
				Hijo.Muta(Azar, Letras);
				Hijo.Evalua(Busca);

				//Si el hijo es mejor que el primer padre, lo reemplaza
				if (Hijo.Puntos > Pobl[IndivA].Puntos) {
					Pobl[IndivA].Cadena = Hijo.Cadena;
					Pobl[IndivA].Puntos = Hijo.Puntos;
				}

				//Si el hijo es mejor que el segundo padre, lo reemplaza
				if (Hijo.Puntos > Pobl[IndivB].Puntos) {
					Pobl[IndivB].Cadena = Hijo.Cadena;
					Pobl[IndivB].Puntos = Hijo.Puntos;
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