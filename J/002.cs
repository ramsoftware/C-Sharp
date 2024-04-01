using System.Text;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Sólo operador cruce
			Poblacion pobl = new();
			StringBuilder Cadena = new();
			Cadena.Append("Estoy probando un algoritmo evolutivo con el operador cruce");

			int TotalPoblacion = 3000; //La población debe ser grande para que haya una gran variedad
			int TotalCiclos = 130000;
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

		//Nace de un proceso de cruce, luego recibe dos genotipos
		public Individuo(Random Azar, StringBuilder GenotipoA, StringBuilder GenotipoB) {
			//Una posición al azar de dónde corta de un genotipo y otro
			int Pos = Azar.Next(GenotipoA.Length);

			Genotipo = new StringBuilder();

			//Agrega el genotipo del primer progenitor
			for (int Contador = 0; Contador < Pos; Contador++)
				Genotipo.Append(GenotipoA[Contador]);

			//Agrega el genotipo del segundo progenitor
			for (int Contador = Pos; Contador < GenotipoB.Length; Contador++)
				Genotipo.Append(GenotipoB[Contador]);
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
		private Random Azar = new();

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

				//Generan un hijo que nace del cruce
				Individuo Hijo = new Individuo(Azar, Individuos[PosA].Genotipo, Individuos[PosB].Genotipo);

				int PuntajeA = Individuos[PosA].Evalua(Original); //Evaluar adaptación de A
				int PuntajeB = Individuos[PosB].Evalua(Original); //Evaluar adaptación de B
				int PuntajeHijo = Hijo.Evalua(Original); //Evalúa al hijo

				if (PuntajeHijo > PuntajeA) Individuos[PosA].Genotipo = new StringBuilder(Hijo.Genotipo.ToString());
				if (PuntajeHijo > PuntajeB) Individuos[PosB].Genotipo = new StringBuilder(Hijo.Genotipo.ToString());
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
