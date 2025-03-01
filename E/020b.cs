using System.Collections;
using System.Diagnostics;

namespace Ejemplo {
    class Program {
        static void Main() {
            /* Prueba de velocidad de los diferentes tipos de estructuras:
			 * arreglo estático, ArrayList, List
			 * Se usará el método de ordenación de burbuja en el que
			 * hace una gran cantidad de lectura y escritura sobre
			 * la estructura (por eso es el más lento pero muy bueno para
			 * hacer esta comparativa)
			 * */

            int minOrden = 500; //Mínimo número de elementos a ordenar
            int maxOrden = 5000; //Máximo número de elementos a ordenar
            int avanceOrden = 500; //Avance de elementos a ordenar

            /* Número de pruebas por ordenamiento
			 * Luego el tiempo de ordenar N elementos es el promedio
			 * de esas pruebas así se evita que por algún motivo los
			 * tiempos tengan picos o valles */
            int numPruebas = 40;

            //Limite es el tamaño de datos que se van a ordenar
            Console.WriteLine("Ordenación. Tiempo promedio en milisegundos");
            Console.WriteLine("Elementos;Arreglo;ArrayList;List");
            for (int Lim = minOrden; Lim <= maxOrden; Lim += avanceOrden)
                Ordenamiento(Lim, numPruebas);

            Console.WriteLine("\r\nFinal de la prueba");
        }

        static void Ordenamiento(int Limite, int numPruebas) {
            Random azar = new();

            //Las estructuras usadas: arreglo estático, ArrayList, List
            double[] numerosA = new double[Limite];
            double[] numerosB = new double[Limite];
            ArrayList arraylist = [];
            List<double> list = [];

            //Medidor de tiempos
            Stopwatch temporizador = new();

            //Almacena los tiempos de cada método de ordenación
            long TParreglo = 0, TParraylist = 0, TPlist = 0;

            //Para disminuir picos o valles en el tiempo,
            //se hacen varias pruebas 
            for (int prueba = 1; prueba <= numPruebas; prueba++) {

                //Llena con valores al azar el arreglo
                LlenaAzar(numerosA, azar);

                //Ordenación por Burbuja ArrayList
                arraylist.Clear();
                arraylist.AddRange(numerosA);
                temporizador.Reset();
                temporizador.Start();
                BurbujaArrayList(arraylist);
                TParraylist += temporizador.ElapsedMilliseconds;

                //Ordenación por Burbuja List
                list.Clear();
                list.AddRange(numerosA);
                temporizador.Reset();
                temporizador.Start();
                BurbujaList(list);
                TPlist += temporizador.ElapsedMilliseconds;

                //Ordenación por Burbuja Arreglo estático
                Array.Copy(numerosA, 0, numerosB, 0, numerosA.Length);
                temporizador.Reset();
                temporizador.Start();
                BurbujaArreglo(numerosB);
                TParreglo += temporizador.ElapsedMilliseconds;

                //Compara las listas ordenadas
                for (int cont = 0; cont < numerosB.Length; cont++) {
                    if (numerosB[cont] != list[cont] ||
                        list[cont] != Convert.ToDouble(arraylist[cont]))
                        Console.WriteLine("Error en la ordenación");
                }
            }

            double Tarreglo = (double)TParreglo / numPruebas;
            double Tarraylist = (double)TParraylist / numPruebas;
            double Tlist = (double)TPlist / numPruebas;

            Console.Write(Limite + ";" + Tarreglo);
            Console.Write(";" + Tarraylist);
            Console.WriteLine(";" + Tlist);
        }

        //Llena el arreglo unidimensional con valores aleatorios
        static void LlenaAzar(double[] numerosA, Random azar) {
            for (int cont = 0; cont < numerosA.Length; cont++)
                numerosA[cont] = azar.NextDouble();
        }

        //Ordenamiento por burbuja usando ArrayList
        static void BurbujaArrayList(ArrayList arraylist) {
            int tamano = arraylist.Count;
            object tmp;
            for (int i = 0; i < tamano - 1; i++) {
                for (int j = 0; j < tamano - 1; j++) {
                    double dA = Convert.ToDouble(arraylist[j]);
                    double dB = Convert.ToDouble(arraylist[j + 1]);
                    if (dA > dB) {
                        tmp = arraylist[j];
                        arraylist[j] = arraylist[j + 1];
                        arraylist[j + 1] = tmp;
                    }
                }
            }
        }

        //Ordenamiento por burbuja usando List
        static void BurbujaList(List<double> list) {
            int tamano = list.Count;
            double tmp;
            for (int i = 0; i < tamano - 1; i++) {
                for (int j = 0; j < tamano - 1; j++) {
                    if (list[j] > list[j + 1]) {
                        tmp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tmp;
                    }
                }
            }
        }

        //Ordenamiento por burbuja usando arreglo unidimensional estático
        static void BurbujaArreglo(double[] arregloestatico) {
            int tamano = arregloestatico.Length;
            double tmp;
            for (int i = 0; i < tamano - 1; i++) {
                for (int j = 0; j < tamano - 1; j++) {
                    if (arregloestatico[j] > arregloestatico[j + 1]) {
                        tmp = arregloestatico[j];
                        arregloestatico[j] = arregloestatico[j + 1];
                        arregloestatico[j + 1] = tmp;
                    }
                }
            }
        }
    }
}