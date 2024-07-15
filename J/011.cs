using System.Diagnostics;

/* Algoritmo evolutivo para simplificar ecuaciones
 * Autor: Rafael Alberto Moreno Parra
 * 
 * Problema:
 * Dada una ecuación compleja del tipo
 * Y = a*seno(b*X+c) + ... + p*seno(q*X+r) + ...
 * Con múltiples sumandos
 * 
 * donde X es la variable independiente y
 * Y la variable dependiente, hallar una función
 * que simplifique la ecuación anterior.
 * 
 * Solución:
 * Usar un algoritmo evolutivo para dar con esa
 * función que se acerque al comportamiento de la 
 * función compleja. 
 * ¿Cómo?
 * La ecuación compleja genera una serie de datos, luego
 * se busca la ecuación simple que se acerque a esa serie
 * de datos.
 * */

namespace Ejemplo {

	class Program {
		static void Main() {
			Random Azar = new(); //Generador de números aleatorios único

			//==================================
			//Configuración básica del simulador
			//==================================

			//Cuántos individuos tendrá la población
			int NumIndiv = 200;

			//Cuántos milisegundos dará al
			//algoritmo evolutivo para operar
			long Tiempo = 20000;

			//Cuántos datos generará la ecuación compleja
			int TotalDatos = 100;

			//Valor mínimo de la variable X
			//para el conjunto de datos
			double Xmin = -720;

			//Valor máximo de la variable X
			//para el conjunto de datos
			double Xmax = 720;

			//====================================
			//Configuración avanzada del simulador
			//====================================

			//Y = a*seno(b*x+c) + d*seno(e*x+f) + ... +
			//coef0*seno(coef1*x+coef2) + coef3*seno(coef4*x+coef5) 

			//Cada coef0*seno(coef1*x+coef2) se le conoce como bloque

			//Número de bloques de la ecuación que genera el dataset
			int BloquesDataset = 30;

			//Número de bloques de la ecuación del individuo
			int BloqueIndiv = 6;

			//Valor mínimo que tendrán los coeficientes
			double CfMin = -3;

			//Valor máximo que tendrán los coeficientes
			double CfMax = 3;

			//=================================
			//Imrime los datos de la simulación
			//=================================
			Console.WriteLine("Algoritmo Evolutivo\r\n");
			Console.WriteLine("Individuos por población: " + NumIndiv);
			Console.WriteLine("Milisegundos: " + Tiempo);
			Console.WriteLine("Datos generados: " + TotalDatos);
			Console.WriteLine("Rango de datos en X entre: " + Xmin + " y " + Xmax);
			Console.WriteLine("Ecuación compleja. Bloques: " + BloquesDataset);
			Console.WriteLine("Ecuación simple. Bloques: " + BloqueIndiv);
			Console.Write("Coeficientes entre: " + CfMin);
			Console.WriteLine(" y " + CfMax);

			//Prepara el generador de datos
			GeneraEcuacion Genera = new();

			//Crea un dataset de valores X, Y
			Genera.GeneraDatos(Azar, BloquesDataset, CfMin, CfMax,
								Xmin, Xmax, TotalDatos);

			//Configura la población que se
			//adaptará al dataset
			Poblacion poblacion = new(Azar, NumIndiv, BloqueIndiv, CfMin, CfMax);

			//Proceso de buscar el mejor individuo
			//al dataset generado
			poblacion.Proceso(Azar, Genera.Xentrada,
								Genera.Yesperado, Tiempo);
		}
	}

	//Crea una ecuación compleja al azar
	public class GeneraEcuacion {
		//Coeficientes de la ecuación que representa a los datos del dataset
		//Y =   a*seno(b*x+c) + d*seno(e*x+f) + ... +
		//	  coef0*seno(coef1*x+coef2) + coef3*seno(coef4*x+coef5) 
		//
		//Cada coef0*seno(coef1*x+coef2) se le conoce como bloque
		List<double>? Cf;

		//Valores X de entrada
		public List<double> Xentrada = [];

		//Valores Y generados por la ecuación
		public List<double> Yesperado = [];

		//Genera los datos del dataset
		public void GeneraDatos(Random Azar, int NumBloques,
								double CfMin, double CfMax,
								double Xmin, double Xmax, int TotalDatos) {
			//Coeficientes al azar
			Cf = [];
			for (int Cont = 1; Cont <= NumBloques * 3; Cont++)
				Cf.Add(Azar.NextDouble() * (CfMax - CfMin) + CfMin);

			Xentrada.Clear();
			Yesperado.Clear();

			//Valores de X que tendrá.
			for (int Cont = 1; Cont <= TotalDatos; Cont++)
				Xentrada.Add(Azar.NextDouble() * (Xmax - Xmin) + Xmin);
			Xentrada.Sort();

			//Genera el dataset con esta ecuación compleja
			for (int Xval = 0; Xval < Xentrada.Count; Xval++) {
				double Y = 0;
				for (int Cont = 0; Cont < Cf.Count; Cont += 3) {
					double Valor = Cf[Cont + 1] * Xentrada[Xval] + Cf[Cont + 2];
					Y += Cf[Cont] * Math.Sin(Valor * Math.PI / 180);
				}
				Yesperado.Add(Y);
			}
		}
	}

	internal class Poblacion {
		//Almacena los individuos de la población
		List<Individuo> Individuos = [];

		//Inicializa la población con los individuos
		public Poblacion(Random Azar, int numIndividuos, 
							int BloqInd,
							double CfMin, double CfMax) {
			Individuos.Clear();
			for (int cont = 1; cont <= numIndividuos; cont++)
				Individuos.Add(new Individuo(Azar, BloqInd, CfMin, CfMax));
		}

		//Proceso evolutivo.
		public void Proceso(Random Azar, List<double> Xentra,
							List<double> Yespera, long Tiempo) {

			//Medidor de tiempos
			Stopwatch cronometro = new();
			cronometro.Reset();
			cronometro.Start();

			//Tiempo que repetirá el proceso evolutivo
			while (cronometro.ElapsedMilliseconds < Tiempo) {

				//Escoge dos individuos al azar
				int indivA = Azar.Next(Individuos.Count);
				int indivB;
				do {
					indivB = Azar.Next(Individuos.Count);
				} while (indivB == indivA);

				//Evalúa cada individuo con respecto a las
				//entradas y salidas esperadas
				Individuos[indivA].AjusteIndiv(Xentra, Yespera);
				Individuos[indivB].AjusteIndiv(Xentra, Yespera);

				//El mejor individuo genera una copia
				//que sobreescribe al peor y la copia se muta
				if (Individuos[indivA].Ajuste < Individuos[indivB].Ajuste)
					CopiaMuta(Azar, indivA, indivB);
				else
					CopiaMuta(Azar, indivB, indivA);
			}

			//Imprime el mejor individuo
			int MejorIndividuo = -1;
			double MejorAjuste = double.MaxValue;
			for (int cont = 0; cont < Individuos.Count; cont++) {

				if (Individuos[cont].Ajuste != -1 &&
					Individuos[cont].Ajuste < MejorAjuste) {
					MejorAjuste = Individuos[cont].Ajuste;
					MejorIndividuo = cont;
				}

			}

			Individuos[MejorIndividuo].Muestra(Xentra, Yespera);
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
		//Y = a*seno(b*x+c) + d*seno(e*x+f) + ... +
		//	coef0*seno(coef1*x+coef2) + coef3*seno(coef4*x+coef5) 

		//Cada coef0*seno(coef1*x+coef2) se le conoce como bloque
		public List<double>? Coef;

		//Guarda en "caché" el ajuste para no tener
		//que calcularlo continuamente
		public double Ajuste;

		//Inicializa el individuo con las Piezas,
		//Modificadores y Operadores al azar
		public Individuo(Random Azar, int BloqInd, 
						 double CfMin, double CfMax) {
			//Coeficientes al azar
			Coef = [];
			for (int Cont = 1; Cont <= BloqInd * 3; Cont++)
				Coef.Add(Azar.NextDouble() * (CfMax - CfMin) + CfMin);
			Ajuste = -1;
		}

		//Calcula el ajuste del individuo con los valores de salida esperados
		public void AjusteIndiv(List<double> Entradas, List<double> Yesperado) {
			//Si ya había sido calculado entonces
			//evita calcularlo de nuevo
			if (Ajuste != -1) return;

			//Deduce el ajuste
			Ajuste = 0;
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				double Y = 0;
				for (int Cont = 0; Cont < Coef.Count; Cont += 3) {
					double Valor = Coef[Cont + 1] * Entradas[Xval] + Coef[Cont + 2];
					Y += Coef[Cont] * Math.Sin(Valor * Math.PI / 180);
				}

				//Diferencia entre la salida calculada y la esperada
				Ajuste += Math.Abs(Y - Yesperado[Xval]);
			}
		}

		//Muta alguna parte del individuo
		public void Muta(Random Azar) {
			int CualMuta = Azar.Next(Coef.Count);
			Coef[CualMuta] += Azar.NextDouble() * 2 - 1;
			Ajuste = -1;
		}

		//Imprime el individuo frente a los datos esperados
		public void Imprime(List<double> Entradas, List<double> Yesperado) {
			Console.WriteLine("\r\n\r\nIndividuo");
			Console.WriteLine("Ajuste: " + Ajuste);
			for (int Cont = 0; Cont < Coef.Count; Cont++)
				Console.WriteLine("Coef: " + Coef[Cont]);

			Console.WriteLine("\r\nEntrada;Salida Esperada;Salida Calculada");
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				double Y = 0;
				for (int Cont = 0; Cont < Coef.Count; Cont += 3) {
					double Valor = Coef[Cont + 1] * Entradas[Xval] + Coef[Cont + 2];
					Y += Coef[Cont] * Math.Sin(Valor * Math.PI / 180);
				}
				Console.Write(Entradas[Xval] + ";" + Yesperado[Xval]);
				Console.WriteLine(";" + Y);
			}
		}

		//Imprime el individuo con los datos normalizados
		public void Muestra(List<double> Entradas, 
							List<double> Yesperado) {

			Console.WriteLine("\r\n\r\nIndividuo. Normalizado.");

			double Xmin = double.MaxValue;
			double Ymin = double.MaxValue;
			double Xmax = double.MinValue;
			double Ymax = double.MinValue;

			//Máximos y mínimos del dataset
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {

				if (Entradas[Xval] < Xmin)
					Xmin = Entradas[Xval];
				
				if (Entradas[Xval] > Xmax)
					Xmax = Entradas[Xval];
				
				if (Yesperado[Xval] < Ymin)
					Ymin = Yesperado[Xval];
				
				if (Yesperado[Xval] > Ymax)
					Ymax = Yesperado[Xval];
			}

			//Salidas del individuo
			List<double> IndivSale = [];
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				double Y = 0;
				for (int Cont = 0; Cont < Coef.Count; Cont += 3) {
					double Valor = Coef[Cont + 1] * Entradas[Xval] + Coef[Cont + 2];
					Y += Coef[Cont] * Math.Sin(Valor * Math.PI / 180);
				}
				IndivSale.Add(Y);
				if (Y < Ymin) Ymin = Y;
				if (Y > Ymax) Ymax = Y;
			}

			//Normaliza
			double AjusteNorm = 0;
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				Entradas[Xval] = (Entradas[Xval] - Xmin) / (Xmax - Xmin);
				Yesperado[Xval] = (Yesperado[Xval] - Ymin) / (Ymax - Ymin);
				IndivSale[Xval] = (IndivSale[Xval] - Ymin) / (Ymax - Ymin);
				AjusteNorm += Math.Abs(Yesperado[Xval] - IndivSale[Xval]);
			}

			//Imprime
			Console.WriteLine("Ajuste: " + AjusteNorm);
			Console.WriteLine("\r\nEntrada;Salida Esperada;Salida Calculada");
			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				Console.Write(Entradas[Xval] + ";" + Yesperado[Xval]);
				Console.WriteLine(";" + IndivSale[Xval]);
			}
		}
	}
}
