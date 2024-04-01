using System.Text;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Sólo operador mutación
			Poblacion pobl = new();
			StringBuilder Cadena = new();
			Cadena.Append("esta es una prueba de algoritmo evolutivo");

			int TotalPoblacion = 100; //Una población muy grande hace que tarde más en encontrar la solución
			int TotalCiclos = 90000;
			pobl.Proceso(Cadena, TotalPoblacion, TotalCiclos);
		}
	}

	//Cómo es el individuo
	internal class Individuo {
		public StringBuilder Genotipo;
		private readonly StringBuilder Letras = new StringBuilder("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ áéúíóúÁÉÍÓÚÑñ¿?¡!äëïöüÄËÏÖÜ");

		//Al nacer, tendrá una serie de caracteres al azar
		public Individuo(Random Azar, int Longitud) {
			Genotipo = new StringBuilder();
			for (int Contador = 1; Contador <= Longitud; Contador++)
				Genotipo.Append(Letras[Azar.Next(Letras.Length)]);
		}

		//Cambia una letra del genotipo al azar
		public void Muta(Random Azar) {
			int Posicion = Azar.Next(Genotipo.Length);
			Genotipo[Posicion] = Letras[Azar.Next(Letras.Length)];
		}

		//Compara el genotipo con la cadena a la que debe parecerse
		public int Evalua(StringBuilder Original) {
			int Puntaje = 0;
			for (int Contador = 0; Contador < Original.Length; Contador++)
				if (Original[Contador] == Genotipo[Contador])
					Puntaje++;
			return Puntaje;
		}
	}

	//La población
	internal class Poblacion {
		public List<Individuo> Individuos = new List<Individuo>();
		private Random Azar = new Random();

		public void Proceso(StringBuilder Original, int TotalIndividuos, int TotalCiclos) {
			//Genera la población
			Individuos.Clear();
			for (int Contador = 1; Contador <= TotalIndividuos; Contador++)
				Individuos.Add(new Individuo(Azar, Original.Length));

			//El proceso evolutivo
			for (int Contador = 1; Contador <= TotalCiclos; Contador++) {
				//Seleccionar al azar dos individuos de esa población: A y B
				int PosA = Azar.Next(Individuos.Count);
				int PosB;
				do {
					PosB = Azar.Next(Individuos.Count);
				} while (PosB == PosA);

				int PuntajeA = Individuos[PosA].Evalua(Original); //Evaluar adaptación de A
				int PuntajeB = Individuos[PosB].Evalua(Original); //Evaluar adaptación de B

				//Si adaptación de A es mejor que adaptación de B entonces
				if (PuntajeA > PuntajeB) {
					//Eliminar individuo B y duplicar individuo A
					Individuos[PosB].Genotipo = new StringBuilder(Individuos[PosA].Genotipo.ToString());
					//Modificar levemente al azar el nuevo duplicado
					Individuos[PosB].Muta(Azar);
				}
				else {
					//Eliminar individuo A y duplicar individuo B
					Individuos[PosA].Genotipo = new StringBuilder(Individuos[PosB].Genotipo.ToString());
					//Modificar levemente al azar el nuevo duplicado
					Individuos[PosA].Muta(Azar);
				}
			}

			//Buscar individuo con mejor adaptación de la población
			int MejorPuntaje = 0;
			int MejorIndivid = 0;
			for (int indiv = 0; indiv < Individuos.Count; indiv++) {
				int Puntaje = Individuos[indiv].Evalua(Original);
				if (Puntaje > MejorPuntaje) {
					MejorPuntaje = Puntaje;
					MejorIndivid = indiv;
				}
			}

			//Imprime el mejor individuo
			Console.WriteLine("Mejor individuo: " + Individuos[MejorIndivid].Genotipo);
			Console.WriteLine("Puntaje: " + MejorPuntaje);
		}
	}
}
