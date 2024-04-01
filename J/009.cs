/* Algoritmo evolutivo para detección de patrones
 * Autor: Rafael Alberto Moreno Parra
 * 
 * Problema:
 * Dado un conjunto de datos del tipo X, Y donde X es la variable independiente y Y la variable dependiente,
 * hallar la función Y = F(X) que más coincida con ese conjunto de datos.
 * 
 * Solución:
 * Usar un algoritmo evolutivo para dar con esa función que mejor se adapte a ese conjunto de datos.
 * 
 * Metodología:
 * Se genera al azar una ecuación del tipo:
 * Y = a*seno(b*X+c) + ... + p*seno(q*X+r)
 * Con esa ecuación se generan los valores X,Y que será el conjunto de datos
 * */

using System.Diagnostics;

namespace Ejemplo {

	class Program {
		static void Main() {
			Random Azar = new(); //Generador de números aleatorios único

			//==================================
			//Configuración básica del simulador
			//==================================
			int TotalPruebas = 5; //Número de veces que se generará un dataset con ecuación aleatoria para probar ambos algoritmos
			int IndividuosPorPoblacion = 200; //Cuántos individuos tendrá la población
			long TiempoParaOperar = 20000; //Cuántos milisegundos dará al algoritmo genético para operar
			int TotalDatos = 100; //Cuántos datos tendrá el dataset
			double Xmin = -720; //Valor mínimo de la variable X para el conjunto de datos
			double Xmax = 720; //Valor máximo de la variable X para el conjunto de datos

			//====================================
			//Configuración avanzada del simulador
			//====================================

			//Y = a*seno(b*x+c) + d*seno(e*x+f) + ... + coef0*seno(coef1*x+coef2) + coef3*seno(coef4*x+coef5) 
			//Cada coef0*seno(coef1*x+coef2) se le conoce como bloque
			int BloquesDataset = 30; //Número de bloques de la ecuación que genera el dataset
			int BloquesIndividuo = 6; //Número de bloques de la ecuación del individuo
			double CoefMinimo = -3; //Valor mínimo que tendrán los coeficientes
			double CoefMaximo = 3; //Valor máximo que tendrán los coeficientes

			//=================================
			//Imrime los datos de la simulación
			//=================================
			Console.WriteLine("Algoritmo Evolutivo\r\n");
			Console.WriteLine("Número de pruebas: " + TotalPruebas);
			Console.WriteLine("Número de individuos por población: " + IndividuosPorPoblacion);
			Console.WriteLine("Tiempo en milisegundos para cada prueba: " + TiempoParaOperar);
			Console.WriteLine("Total de datos que tendrá el dataset: " + TotalDatos);
			Console.WriteLine("Rango de datos en X entre: " + Xmin + " y " + Xmax);
			Console.WriteLine("Ecuación que genera dataset. Número de bloques: " + BloquesDataset);
			Console.WriteLine("Ecuación que genera individuo. Número de bloques: " + BloquesIndividuo);
			Console.WriteLine("Rango de coeficientes para ecuaciones entre: " + CoefMinimo + " y " + CoefMaximo);

			//Prepara el generador de datos
			GeneradorDatos Genera = new();

			//Prueba varias veces a generar datasets y luego hallar el individuo que mejor ajusta
			for (int Prueba = 1; Prueba <= TotalPruebas; Prueba++) {

				//Crea un dataset de valores X, Y
				Genera.GeneraDatos(Azar, BloquesDataset, CoefMinimo, CoefMaximo, Xmin, Xmax, TotalDatos);

				//Configura la población que se adaptará al dataset
				Poblacion poblacion = new(Azar, IndividuosPorPoblacion, BloquesIndividuo, CoefMinimo, CoefMaximo);

				//Proceso de buscar el mejor individuo al dataset generado
				poblacion.Proceso(Azar, Genera.Xentrada, Genera.Ysalidaesperada, TiempoParaOperar);
			}

			Console.WriteLine("\r\nFINAL\r\n");
		}
	}

	//Crea una ecuación al azar para generar el dataset
	public class GeneradorDatos {
		//Coeficientes de la ecuación que representa a los datos del dataset
		//Y = a*seno(b*x+c) + d*seno(e*x+f) + ... + coef0*seno(coef1*x+coef2) + coef3*seno(coef4*x+coef5) 
		//Cada coef0*seno(coef1*x+coef2) se le conoce como bloque
		List<double>? Coef;

		public List<double> Xentrada = []; //Valores X de entrada
		public List<double> Ysalidaesperada = []; //Valores Y generados por la ecuación

		//Genera los datos del dataset
		public void GeneraDatos(Random Azar, int NumBloques, double CoefMinimo, double CoefMaximo, double Xmin, double Xmax, int TotalDatos) {
			//Coeficientes al azar
			Coef = [];
			for (int Cont = 1; Cont <= NumBloques * 3; Cont++)
				Coef.Add(Azar.NextDouble() * (CoefMaximo - CoefMinimo) + CoefMinimo);

			Xentrada.Clear();
			Ysalidaesperada.Clear();

			//Valores de X que tendrá.
			for (int Cont = 1; Cont <= TotalDatos; Cont++)
				Xentrada.Add(Azar.NextDouble() * (Xmax - Xmin) + Xmin);
			Xentrada.Sort();

			//Genera el dataset con esta ecuación
			for (int Xval = 0; Xval < Xentrada.Count; Xval++) {
				double Y = 0;
				for (int Cont = 0; Cont < Coef.Count; Cont += 3)
					Y += Coef[Cont] * Math.Sin((Coef[Cont + 1] * Xentrada[Xval] + Coef[Cont + 2]) * Math.PI / 180);
				Ysalidaesperada.Add(Y);
			}
		}
	}

	internal class Poblacion {
		//Almacena los individuos de la población
		List<Individuo> Individuos = new List<Individuo>();

		//Inicializa la población con los individuos
		public Poblacion(Random Azar, int numIndividuos, int BloquesIndividuo, double CoefMinimo, double CoefMaximo) {
			Individuos.Clear();
			for (int cont = 1; cont <= numIndividuos; cont++)
				Individuos.Add(new Individuo(Azar, BloquesIndividuo, CoefMinimo, CoefMaximo));
		}

		//Proceso evolutivo.
		public void Proceso(Random Azar, List<double> Entradas, List<double> SalidasEsperadas, long TiempoParaOperar) {

			//Medidor de tiempos
			Stopwatch cronometro = new();
			cronometro.Reset();
			cronometro.Start();

			//Tiempo que repetirá el proceso evolutivo
			while (cronometro.ElapsedMilliseconds < TiempoParaOperar) {

				//Escoge dos individuos al azar
				int indivA = Azar.Next(Individuos.Count);
				int indivB;
				do {
					indivB = Azar.Next(Individuos.Count);
				} while (indivB == indivA);

				//Evalúa cada individuo con respecto a las entradas y salidas esperadas
				Individuos[indivA].AjusteIndividuo(Entradas, SalidasEsperadas);
				Individuos[indivB].AjusteIndividuo(Entradas, SalidasEsperadas);

				//El mejor individuo genera una copia que sobreescribe al peor y la copia se muta
				if (Individuos[indivA].Ajuste < Individuos[indivB].Ajuste)
					CopiaMuta(Azar, indivA, indivB);
				else
					CopiaMuta(Azar, indivB, indivA);
			}

			//Imprime el mejor individuo
			int MejorIndividuo = -1;
			double MejorAjuste = double.MaxValue;
			for (int cont = 0; cont < Individuos.Count; cont++)
				if (Individuos[cont].Ajuste != -1 && Individuos[cont].Ajuste < MejorAjuste) {
					MejorAjuste = Individuos[cont].Ajuste;
					MejorIndividuo = cont;
				}

			Individuos[MejorIndividuo].ImprimeNormalizado(Entradas, SalidasEsperadas);
		}

		public void CopiaMuta(Random Azar, int Origen, int Destino) {
			Individuo ganador, perdedor;
			ganador = Individuos[Origen];
			perdedor = Individuos[Destino];

			//Copia el individuo
			for (int Cont = 0; Cont < ganador.Coef.Count; Cont++)
				perdedor.Coef[Cont] = ganador.Coef[Cont];

			//Muta la copia
			perdedor.Muta(Azar);
		}
	}

	internal class Individuo {
		//Coeficientes de la ecuación que representa al individuo
		//Y = a*seno(b*x+c) + d*seno(e*x+f) + ... + coef0*seno(coef1*x+coef2) + coef3*seno(coef4*x+coef5) 
		//Cada coef0*seno(coef1*x+coef2) se le conoce como bloque
		public List<double>? Coef;

		//Guarda en "caché" el ajuste para no tener que calcularlo continuamente
		public double Ajuste;

		//Inicializa el individuo con las Piezas, Modificadores y Operadores al azar
		public Individuo(Random Azar, int BloquesIndividuo, double CoefMinimo, double CoefMaximo) {
			//Coeficientes al azar
			Coef = [];
			for (int Cont = 1; Cont <= BloquesIndividuo * 3; Cont++)
				Coef.Add(Azar.NextDouble() * (CoefMaximo - CoefMinimo) + CoefMinimo);
			Ajuste = -1;
		}

		//Calcula el ajuste del individuo con los valores de salida esperados
		public void AjusteIndividuo(List<double> Entradas, List<double> SalidasEsperadas) {
			//Si ya había sido calculado entonces evita calcularlo de nuevo
			if (Ajuste != -1) return;

			//Deduce el ajuste
			Ajuste = 0;
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				double Y = 0;
				for (int Cont = 0; Cont < Coef.Count; Cont += 3)
					Y += Coef[Cont] * Math.Sin((Coef[Cont + 1] * Entradas[Xval] + Coef[Cont + 2]) * Math.PI / 180);

				//Diferencia entre la salida calculada y la esperada
				Ajuste += Math.Abs(Y - SalidasEsperadas[Xval]);
			}
		}

		//Muta alguna parte del individuo
		public void Muta(Random Azar) {
			int CualMuta = Azar.Next(Coef.Count);
			Coef[CualMuta] += Azar.NextDouble() * 2 - 1;
			Ajuste = -1;
		}

		//Imprime el individuo frente a los datos esperados
		public void Imprime(List<double> Entradas, List<double> SalidasEsperadas) {
			Console.WriteLine("\r\n\r\nIndividuo");
			Console.WriteLine("Ajuste: " + Ajuste);
			for (int Cont = 0; Cont < Coef.Count; Cont++)
				Console.WriteLine("Coef: " + Coef[Cont]);

			Console.WriteLine("\r\nEntrada;Salida Esperada;Salida Calculada");
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				double Y = 0;
				for (int Cont = 0; Cont < Coef.Count; Cont += 3)
					Y += Coef[Cont] * Math.Sin((Coef[Cont + 1] * Entradas[Xval] + Coef[Cont + 2]) * Math.PI / 180);
				Console.WriteLine(Entradas[Xval] + ";" + SalidasEsperadas[Xval] + ";" + Y);
			}
		}

		//Imprime el individuo con los datos normalizados
		public void ImprimeNormalizado(List<double> Entradas, List<double> SalidasEsperadas) {
			Console.WriteLine("\r\n\r\nIndividuo. Normalizado.");

			double Xminimo = double.MaxValue;
			double Yminimo = double.MaxValue;
			double Xmaximo = double.MinValue;
			double Ymaximo = double.MinValue;

			//Máximos y mínimos del dataset
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				if (Entradas[Xval] < Xminimo) Xminimo = Entradas[Xval];
				if (Entradas[Xval] > Xmaximo) Xmaximo = Entradas[Xval];
				if (SalidasEsperadas[Xval] < Yminimo) Yminimo = SalidasEsperadas[Xval];
				if (SalidasEsperadas[Xval] > Ymaximo) Ymaximo = SalidasEsperadas[Xval];
			}

			//Salidas del individuo
			List<double> IndivSale = new List<double>();
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				double Y = 0;
				for (int Cont = 0; Cont < Coef.Count; Cont += 3)
					Y += Coef[Cont] * Math.Sin((Coef[Cont + 1] * Entradas[Xval] + Coef[Cont + 2]) * Math.PI / 180);
				IndivSale.Add(Y);
				if (Y < Yminimo) Yminimo = Y;
				if (Y > Ymaximo) Ymaximo = Y;
			}

			//Normaliza
			double AjusteNorm = 0;
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				Entradas[Xval] = (Entradas[Xval] - Xminimo) / (Xmaximo - Xminimo);
				SalidasEsperadas[Xval] = (SalidasEsperadas[Xval] - Yminimo) / (Ymaximo - Yminimo);
				IndivSale[Xval] = (IndivSale[Xval] - Yminimo) / (Ymaximo - Yminimo);
				AjusteNorm += Math.Abs(SalidasEsperadas[Xval] - IndivSale[Xval]);
			}

			//Imprime
			Console.WriteLine("Ajuste: " + AjusteNorm);
			Console.WriteLine("\r\nEntrada;Salida Esperada;Salida Calculada");
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				Console.WriteLine(Entradas[Xval] + ";" + SalidasEsperadas[Xval] + ";" + IndivSale[Xval]);
			}
		}
	}
}
