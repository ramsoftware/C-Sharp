/* Algoritmo evolutivo para detección de patrones
 * (uso de series de Fourier)
 * Autor: Rafael Alberto Moreno Parra
 * 
 * Problema:
 * Dado un conjunto de datos del tipo X, Y 
 * donde X es la variable independiente y
 * Y la variable dependiente,
 * hallar la función Y = F(X) que más
 * coincida con ese conjunto de datos.
 * */

using System.Text;

namespace Ejemplo {

	class Program {
		static void Main(string[] args) {
			//Generador de números aleatorios único
			Random Azar = new();

			//=======================================
			//Configuración de la operación de ajuste
			//=======================================
			
			//Cuántos milisegundos dará a cada algoritmo
			long TiempoParaOperar = 30000;

			//=======================================
			//Configuración del algoritmo evolutivo
			//=======================================
			int TamanoPoblacion = 200;

			//================================
			//Configuración de la red neuronal
			//================================
			int NeuronasCapa0 = 7; //Total neuronas en la capa 0
			int NeuronasCapa1 = 7; //Total neuronas en la capa 1

			//===================================
			//Imprime los datos de la comparativa
			//===================================
			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine("Algoritmo Evolutivo vs Red Neuronal\r\n");
			Console.WriteLine("Series de tiempo.\r\n");
			Console.WriteLine("Milisegundos: " + TiempoParaOperar);
			Console.WriteLine("\r\n\r\nAlgoritmo Evolutivo");
			Console.WriteLine("Tamaño de la población: " + TamanoPoblacion);
			Console.WriteLine("\r\n\r\nRed Neuronal: Perceptrón multicapa");
			Console.WriteLine("Neuronas en Capa 1 oculta: " + NeuronasCapa0);
			Console.WriteLine("Neuronas en Capa 2 oculta: " + NeuronasCapa1);

			//==============================
			//Leer los datos del archivo CSV
			//==============================
			DatosArchivo Datos = new();
			Datos.LeeXYdeCSV(args[0]);

			//=================================
			//Algoritmo Evolutivo
			//=================================

			//Configura la población que se
			//adaptará al conjunto de datos
			Poblacion poblacion = new(Azar, TamanoPoblacion);

			//Proceso de buscar el mejor individuo
			//al conjunto de datos generado
			List<double> ResultadoEvolutivo = [];
			poblacion.Proceso(Azar, Datos.XentradaN, 
								Datos.YsalidasN,
								TiempoParaOperar,
								ResultadoEvolutivo);

			//=================================
			//Red Neuronal
			//=================================
			RedesNeuronales Redes = new();
			List<double> ResultadoNeuronal = [];
			Redes.Proceso(Azar, TiempoParaOperar,
							NeuronasCapa0, NeuronasCapa1,
							Datos, ResultadoNeuronal);

			//=================================
			//Imprime la comparativa
			//=================================
			double AjusteEvolutivo = 0;
			double AjusteNeuronal = 0;
			Console.Write("\r\nEntrada;Salida Esperada;");
			Console.WriteLine("Salida Evolutivo;Salida Red Neuronal");

			for (int Cont = 0; Cont < Datos.Xentrada.Count; Cont++) {
				double valE = Datos.Xentrada[Cont];
				double valS = Datos.Ysalidas[Cont];
				Console.Write( valE + ";" + valS + ";");
				
				double valA = ResultadoEvolutivo[Cont] / 1000;
				double valB = Datos.Ysalidas.Max();
				double valC = Datos.Ysalidas.Min();
				double Evolutivo = valA * (valB - valC) + valC;

				double valN = ResultadoNeuronal[Cont];
				Console.WriteLine(Evolutivo + ";" + valN);

				AjusteEvolutivo += Math.Abs(valS - Evolutivo);
				AjusteNeuronal += Math.Abs(valS - valN);
			}
			Console.WriteLine("\r\nAjuste Evolutivo: " +  AjusteEvolutivo);
			Console.WriteLine("Ajuste Neuronal: " + AjusteNeuronal);
			Console.WriteLine("\r\nFINAL\r\n");
		}
	}
}
