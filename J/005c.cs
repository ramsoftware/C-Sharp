using System.Diagnostics;
using System.Text;

/* Las variables son: 
 * A. Tamaño de la cadena
 * B. Tamaño de la población
 * C. Tiempo dedicado a cada estrategia
 * D. Complejidad de la cadena a buscar (simple con sólo vocales
 * a complejo con todo el abecedario)
 * 
 * Como son múltiples variables, para poner a prueba 
 * las diferentes estrategias,se varia sólo una variable
 * y el resto se congela */
namespace MetricaEvolutivo {
	internal class Estrategia {
		//Letras que conforman las cadenas
		private const string Letras = "aeiou";

		//Población
		private List<Individuo> Pobl = [];
		private int TotalIndividuos;

		//Único generador de números aleatorios
		private Random Azar;

		//Cadena a buscar
		private string Busca;

		//Tiempo dado a cada estrategia
		private int Tiempo;

		/* Configura la simulación */
		public void Simular() {
			Azar = new();
			TotalIndividuos = 1000;
			int TotalPruebas = 2; //Total para generar promedios
			int TMinimo = 10; //Tiempo mínimo dado a cada estrategia
			int TMaximo = 1000; //Tiempo máximo dado a cada estrategia
			int TAvance = 10; //Avance de mínimo a máximo
			int TCadenaBusca = 500; //Tamaño de la cadena a buscar

			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine("Total de Pruebas: " + TotalPruebas);
			Console.WriteLine("Tiempo mínimo: " + TMinimo);
			Console.WriteLine("Tiempo máximo: " + TMaximo);
			Console.WriteLine("Tamaño cadena busca: " + TCadenaBusca);
			Console.WriteLine("Población: " + TotalIndividuos);

			Console.WriteLine("Tiempo;E1;E2;E3;E4;E5;E6;E7");
			for (Tiempo = TMinimo; Tiempo <= TMaximo; Tiempo += TAvance) {
				int AcumEstr1 = 0;
				int AcumEstr2 = 0;
				int AcumEstr3 = 0;
				int AcumEstr4 = 0;
				int AcumEstr5 = 0;
				int AcumEstr6 = 0;
				int AcumEstr7 = 0;
				for (int prueba = 1; prueba <= TotalPruebas; prueba++) {
					Busca = CadAzar(TCadenaBusca);
					AcumEstr1 += Estrategia1();
					AcumEstr2 += Estrategia2();
					AcumEstr3 += Estrategia3();
					AcumEstr4 += Estrategia4();
					AcumEstr5 += Estrategia5();
					AcumEstr6 += Estrategia6();
					AcumEstr7 += Estrategia7();
				}
				double Promedio1 = (double)AcumEstr1 / TotalPruebas;
				double Promedio2 = (double)AcumEstr2 / TotalPruebas;
				double Promedio3 = (double)AcumEstr3 / TotalPruebas;
				double Promedio4 = (double)AcumEstr4 / TotalPruebas;
				double Promedio5 = (double)AcumEstr5 / TotalPruebas;
				double Promedio6 = (double)AcumEstr6 / TotalPruebas;
				double Promedio7 = (double)AcumEstr7 / TotalPruebas;
				Console.Write(Tiempo + ";" + Promedio1);
				Console.Write(";" + Promedio2);
				Console.Write(";" + Promedio3);
				Console.Write(";" + Promedio4);
				Console.Write(";" + Promedio5);
				Console.Write(";" + Promedio6);
				Console.WriteLine(";" + Promedio7);
			}
		}

		/* Crea la población para cada estrategia */
		void CreaPoblacion() {
			//Genera la población
			Pobl.Clear();
			for (int Cont = 1; Cont <= TotalIndividuos; Cont++) {
				Individuo obj = new() {
					Cadena = CadAzar(Busca.Length)
				};
				obj.Evalua(Busca);
				Pobl.Add(obj);
			}
		}

		/* Devuelve una cadena al azar */
		string CadAzar(int Tamano) {
			string Cadena = string.Empty;
			for (int Cont = 1; Cont <= Tamano; Cont++)
				Cadena += Letras[Azar.Next(Letras.Length)].ToString();
			return Cadena;
		}

		/* Estrategia 1: Operador mutación
		 * */
		int Estrategia1() {
			CreaPoblacion();

			//Itera mientras tenga tiempo
			long T = Stopwatch.GetTimestamp();
			while (Stopwatch.GetElapsedTime(T).TotalMilliseconds <= Tiempo) {
				//Selecciona dos individuos distintos al azar
				int IndivA = Azar.Next(Pobl.Count);
				int IndivB;
				do {
					IndivB = Azar.Next(Pobl.Count);
				} while (IndivA == IndivB);

				/* El individuo ganador reemplaza al perdedor
				 * muta esa copia y la evalúa */
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
			}

			//Muestra el mejor individuo con el mejor puntaje
			Pobl = Pobl.OrderByDescending(obj => obj.Puntos).ToList();
			//Console.WriteLine("E1: " + Pobl[0].Cadena + " == " + Busca + " Puntos: " + Pobl[0].Puntos);
			return Pobl[0].Puntos;
		}

		/* Estrategia 2:
		 * Ordena del puntaje mayor a menor la población
		 * Toma el primer individuo, lo copia sobre el último
		 * y luego muta esa copia */
		int Estrategia2() {
			CreaPoblacion();

			//Itera mientras tenga tiempo
			long T = Stopwatch.GetTimestamp();
			while (Stopwatch.GetElapsedTime(T).TotalMilliseconds <= Tiempo) {

				//Ordena la lista de mejor a peor individuo
				Pobl = [.. Pobl.OrderByDescending(obj => obj.Puntos)];
				int Ultimo = Pobl.Count - 1;

				//El mejor individuo reemplaza al peor,
				//muta esa copia y la evalúa
				Pobl[Ultimo].Cadena = Pobl[0].Cadena;
				Pobl[Ultimo].Muta(Azar, Letras);
				Pobl[Ultimo].Evalua(Busca);
			}

			//Muestra el mejor individuo con el mejor puntaje
			Pobl = [.. Pobl.OrderByDescending(obj => obj.Puntos)];
			return Pobl[0].Puntos;
		}

		/* Estrategia 3: Operador mutación.
		 * Si hay empate en puntaje, entonces toma uno de los dos
		 * y lo elimina, luego crea un individuo nuevo
		 * */
		int Estrategia3() {
			CreaPoblacion();

			//Itera mientras tenga tiempo
			long T = Stopwatch.GetTimestamp();
			while (Stopwatch.GetElapsedTime(T).TotalMilliseconds <= Tiempo) {

				//Selecciona dos individuos distintos al azar
				int IndivA = Azar.Next(Pobl.Count);
				int IndivB;
				do {
					IndivB = Azar.Next(Pobl.Count);
				} while (IndivA == IndivB);

				//El individuo ganador reemplaza al perdedor,
				//muta esa copia y la evalúa
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
				else /* Hubo empate, luego elimina uno de los dos
					  * y genera un nuevo individuo */
				{
					Pobl.RemoveAt(IndivA);
					Individuo obj = new() {
						Cadena = CadAzar(Busca.Length)
					};
					obj.Evalua(Busca);
					Pobl.Add(obj);
				}
			}

			//Muestra el mejor individuo con el mejor puntaje
			Pobl = [.. Pobl.OrderByDescending(obj => obj.Puntos)];
			return Pobl[0].Puntos;
		}

		/* Estrategia 4: Operador cruce
		 * */
		int Estrategia4() {
			CreaPoblacion();

			//Itera mientras tenga tiempo
			long T = Stopwatch.GetTimestamp();
			while (Stopwatch.GetElapsedTime(T).TotalMilliseconds <= Tiempo) {

				//Selecciona dos individuos distintos al azar
				int IndivA = Azar.Next(Pobl.Count);
				int IndivB;
				do {
					IndivB = Azar.Next(Pobl.Count);
				} while (IndivA == IndivB);

				//Crea el hijo cruzando porciones de cadena de ambos padres
				Individuo Hijo = new();
				Hijo.Cruce(Azar, Pobl[IndivA].Cadena, Pobl[IndivB].Cadena);
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
			}

			//Muestra el mejor individuo con el mejor puntaje
			Pobl = Pobl.OrderByDescending(obj => obj.Puntos).ToList();
			return Pobl[0].Puntos;
		}

		/* Estrategia 5: Operador cruce + mutación
		 * */
		int Estrategia5() {
			CreaPoblacion();

			//Itera mientras tenga tiempo
			long T = Stopwatch.GetTimestamp();
			while (Stopwatch.GetElapsedTime(T).TotalMilliseconds <= Tiempo) {

				//Selecciona dos individuos distintos al azar
				int IndivA = Azar.Next(Pobl.Count);
				int IndivB;
				do {
					IndivB = Azar.Next(Pobl.Count);
				} while (IndivA == IndivB);

				//Crea el hijo cruzando porciones de cadena de ambos padres
				Individuo Hijo = new();
				Hijo.Cruce(Azar, Pobl[IndivA].Cadena, Pobl[IndivB].Cadena);

				//Muta el hijo además
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
			}

			//Muestra el mejor individuo con el mejor puntaje
			Pobl = [.. Pobl.OrderByDescending(obj => obj.Puntos)];
			return Pobl[0].Puntos;
		}

		/* Estrategia 6: Cada individuo de una población 
		 * pequeña mejora poco a poco
		 * */
		int Estrategia6() {
			CreaPoblacion();

			int Individuo = 0;

			//Itera mientras tenga tiempo
			long T = Stopwatch.GetTimestamp();
			while (Stopwatch.GetElapsedTime(T).TotalMilliseconds <= Tiempo) {
				string CadAntes = Pobl[Individuo].Cadena;
				int PuntajeAntes = Pobl[Individuo].Puntos;

				Pobl[Individuo].Muta(Azar, Letras);
				Pobl[Individuo].Evalua(Busca);

				//Si la nueva mutación desmejora el individuo
				//entonces restaura la cadena anterior
				if (Pobl[Individuo].Puntos < PuntajeAntes) {
					Pobl[Individuo].Cadena = CadAntes;
					Pobl[Individuo].Puntos = PuntajeAntes;
				}

				if (++Individuo >= Pobl.Count) Individuo = 0;
			}

			//Muestra el mejor individuo con el mejor puntaje
			Pobl = [.. Pobl.OrderByDescending(obj => obj.Puntos)];
			return Pobl[0].Puntos;
		}

		/* Estrategia 7: Mutar dos veces
		 * */
		int Estrategia7() {
			CreaPoblacion();

			//Itera mientras tenga tiempo
			long T = Stopwatch.GetTimestamp();
			while (Stopwatch.GetElapsedTime(T).TotalMilliseconds <= Tiempo) {
				//Selecciona dos individuos distintos al azar
				int IndivA = Azar.Next(Pobl.Count);
				int IndivB;
				do {
					IndivB = Azar.Next(Pobl.Count);
				} while (IndivA == IndivB);

				/* El individuo ganador reemplaza al perdedor
				 * muta esa copia y la evalúa */
				if (Pobl[IndivA].Puntos > Pobl[IndivB].Puntos) {
					Pobl[IndivB].Cadena = Pobl[IndivA].Cadena;
					Pobl[IndivB].Muta(Azar, Letras);
					Pobl[IndivB].Muta(Azar, Letras);
					Pobl[IndivB].Evalua(Busca);
				}
				else if (Pobl[IndivB].Puntos > Pobl[IndivA].Puntos) {
					Pobl[IndivA].Cadena = Pobl[IndivB].Cadena;
					Pobl[IndivA].Muta(Azar, Letras);
					Pobl[IndivA].Muta(Azar, Letras);
					Pobl[IndivA].Evalua(Busca);
				}
			}

			//Muestra el mejor individuo con el mejor puntaje
			Pobl = Pobl.OrderByDescending(obj => obj.Puntos).ToList();
			return Pobl[0].Puntos;
		}
	}
}