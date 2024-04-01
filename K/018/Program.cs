/* Algoritmo evolutivo para detección de patrones (uso de series de Fourier)
 * Autor: Rafael Alberto Moreno Parra
 * 
 * Problema:
 * Dado un conjunto de datos del tipo X, Y donde X es la variable independiente y Y la variable dependiente,
 * hallar la función Y = F(X) que más coincida con ese conjunto de datos.
 * */

using System.Text;

namespace Ejemplo {

	class Program {
		static void Main(string[] args) {
			Random Azar = new(); //Generador de números aleatorios único

			//=======================================
			//Configuración de la operación de ajuste
			//=======================================
			long TiempoParaOperar = 30000; //Cuántos milisegundos dará a cada algoritmo

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
			Console.WriteLine("Algoritmo Evolutivo vs Red Neuronal. Series de tiempo.\r\n");
			Console.WriteLine("Tiempo en milisegundos para operar: " + TiempoParaOperar);
			Console.WriteLine("\r\n\r\nAlgoritmo Evolutivo");
			Console.WriteLine("Tamaño de la población: " + TamanoPoblacion);
			Console.WriteLine("\r\n\r\nRed Neuronal: Perceptrón multicapa");
			Console.WriteLine("Número de neuronas en Capa 1 oculta: " + NeuronasCapa0);
			Console.WriteLine("Número de neuronas en Capa 2 oculta: " + NeuronasCapa1);

			//==============================
			//Leer los datos del archivo CSV
			//==============================
			DatosArchivo Datos = new();
			Datos.LeeXYdeCSV(args[0]);

			//=================================
			//Algoritmo Evolutivo
			//=================================

			//Configura la población que se adaptará al conjunto de datos
			Poblacion poblacion = new(Azar, TamanoPoblacion);

			//Proceso de buscar el mejor individuo al conjunto de datos generado
			List<double> ResultadoEvolutivo = [];
			poblacion.Proceso(Azar, Datos.XentradaN, Datos.YsalidasN, TiempoParaOperar, ResultadoEvolutivo);

			//=================================
			//Red Neuronal
			//=================================
			RedesNeuronales Redes = new();
			List<double> ResultadoNeuronal = [];
			Redes.Proceso(Azar, TiempoParaOperar, NeuronasCapa0, NeuronasCapa1, Datos, ResultadoNeuronal);

			//=================================
			//Imprime la comparativa
			//=================================
			double AjusteEvolutivo = 0;
			double AjusteNeuronal = 0;
			Console.WriteLine("\r\nEntrada;Salida Esperada;Salida Evolutivo;Salida Red Neuronal");
			for (int Cont = 0; Cont < Datos.Xentrada.Count; Cont++) {
				Console.Write(Datos.Xentrada[Cont] + ";" + Datos.Ysalidas[Cont] + ";");
				double ResultadoEvol = (ResultadoEvolutivo[Cont] / 1000) * (Datos.Ysalidas.Max() - Datos.Ysalidas.Min()) + Datos.Ysalidas.Min();
				Console.WriteLine(ResultadoEvol + ";" + ResultadoNeuronal[Cont]);

				AjusteEvolutivo += Math.Abs(Datos.Ysalidas[Cont] - ResultadoEvol);
				AjusteNeuronal += Math.Abs(Datos.Ysalidas[Cont] - ResultadoNeuronal[Cont]);
			}
			Console.WriteLine("\r\nAjuste Evolutivo: " +  AjusteEvolutivo);
			Console.WriteLine("Ajuste Neuronal: " + AjusteNeuronal);
			Console.WriteLine("\r\nFINAL\r\n");
		}
	}
}
