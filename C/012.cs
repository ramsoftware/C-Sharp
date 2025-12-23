using System.Diagnostics;

namespace Ejemplo;

internal class Program {
    static void Main() {
        int Limite = 30000;
        int[] Original = new int[Limite];
        int[] LShell = new int[Limite];
        int[] LInsercion = new int[Limite];
        int[] LSeleccion = new int[Limite];
        int[] LBurbuja = new int[Limite];
        int[] LQuickSort = new int[Limite];

        //Medidor de tiempos
        double TPShell = 0, TPIns = 0, TPSel = 0, TPBur = 0, TPQuick = 0;

        //Para disminuir oscilaciones en el tiempo, se hacen
        //N pruebas con cada grupo de pruebas
        int TotalPruebas = 20;
        for (int prueba = 1; prueba <= TotalPruebas; prueba++) {
            LlenaArreglo(Original, 10, 90);

            //Ordenación por método Shell
            Array.Copy(Original, 0, LShell, 0, Original.Length);
            long Inicia = Stopwatch.GetTimestamp();
            Shell(LShell);
            TimeSpan Transcurrido = Stopwatch.GetElapsedTime(Inicia);
            TPShell += Transcurrido.TotalMilliseconds;

            //Ordenación por método Inserción
            Array.Copy(Original, 0, LInsercion, 0, Original.Length);
            Inicia = Stopwatch.GetTimestamp();
            Insercion(LInsercion);
            Transcurrido = Stopwatch.GetElapsedTime(Inicia);
            TPIns += Transcurrido.TotalMilliseconds;

            //Ordenación por método Selección
            Array.Copy(Original, 0, LSeleccion, 0, Original.Length);
            Inicia = Stopwatch.GetTimestamp();
            Seleccion(LSeleccion);
            Transcurrido = Stopwatch.GetElapsedTime(Inicia);
            TPSel += Transcurrido.TotalMilliseconds;

            //Ordenación por método Burbuja
            Array.Copy(Original, 0, LBurbuja, 0, Original.Length);
            Inicia = Stopwatch.GetTimestamp();
            Burbuja(LBurbuja);
            Transcurrido = Stopwatch.GetElapsedTime(Inicia);
            TPBur += Transcurrido.TotalMilliseconds;

            //Ordenación por método QuickSort
            Array.Copy(Original, 0, LQuickSort, 0, Original.Length);
            Inicia = Stopwatch.GetTimestamp();
            QuickSort(LQuickSort, 0, LQuickSort.Length - 1);
            Transcurrido = Stopwatch.GetElapsedTime(Inicia);
            TPQuick += Transcurrido.TotalMilliseconds;

            //Verifica que los arreglos ordenados coinciden
            for (int cont = 0; cont < Original.Length; cont++) {
                if (LShell[cont] != LInsercion[cont] ||
                    LInsercion[cont] != LSeleccion[cont] ||
                    LSeleccion[cont] != LBurbuja[cont] ||
                    LBurbuja[cont] != LQuickSort[cont])
                    Console.WriteLine("Error en la prueba");
            }
        }

        double TS = (double)TPShell / TotalPruebas;
        double TI = (double)TPIns / TotalPruebas;
        double TL = (double)TPSel / TotalPruebas;
        double TB = (double)TPBur / TotalPruebas;
        double TQ = (double)TPQuick / TotalPruebas;

        Console.WriteLine("Número de elementos a ordenar: " + Limite);
        Console.WriteLine("Tiempo promedio en milisegundos");
        Console.WriteLine("ShellSort: " + TS);
        Console.WriteLine("InsertSort: " + TI);
        Console.WriteLine("Selección: " + TL);
        Console.WriteLine("Burbuja: " + TB);
        Console.WriteLine("QuickSort: " + TQ);
    }

    //Llena el arreglo con valores al azar entre min y max
    static void LlenaArreglo(int[] arreglo, int min, int max) {
        Random azar = new();
        for (int posicion = 0; posicion < arreglo.Length; posicion++) {
            arreglo[posicion] = azar.Next(min, max + 1);
        }
    }

    //Ordenamiento por Insert
    static void Insercion(int[] arreglo) {
        int j;
        for (int i = 1; i < arreglo.Length; i++) {
            int tmp = arreglo[i];
            for (j = i - 1; j >= 0 && arreglo[j] > tmp; j--) {
                arreglo[j + 1] = arreglo[j];
            }
            arreglo[j + 1] = tmp;
        }
    }

    //Ordenamiento por Selección
    static void Seleccion(int[] arreglo) {
        for (int i = 0; i < arreglo.Length - 1; i++) {
            int min = i;
            for (int j = i + 1; j < arreglo.Length; j++) {
                if (arreglo[j] < arreglo[min]) {
                    min = j;
                }
            }
            if (i != min) {
                int aux = arreglo[i];
                arreglo[i] = arreglo[min];
                arreglo[min] = aux;
            }
        }
    }

    //Ordenamiento por Burbuja
    static void Burbuja(int[] arreglo) {
        int n = arreglo.Length;
        int tmp;
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - 1; j++) {
                if (arreglo[j] > arreglo[j + 1]) {
                    tmp = arreglo[j];
                    arreglo[j] = arreglo[j + 1];
                    arreglo[j + 1] = tmp;
                }
            }
        }
    }

    //Ordenamiento por Shell
    static void Shell(int[] arr) {
        int incr = arr.Length;
        do {
            incr /= 2;
            for (int k = 0; k < incr; k++) {
                for (int i = incr + k; i < arr.Length; i += incr) {
                    int j = i;
                    while (j - incr >= 0 && arr[j] < arr[j - incr]) {
                        int tmp = arr[j];
                        arr[j] = arr[j - incr];
                        arr[j - incr] = tmp;
                        j -= incr;
                    }
                }
            }
        } while (incr > 1);
    }

    //Ordenación por QuickSort
    static void QuickSort(int[] arreglo, int primero, int ultimo) {
        int i, j, central;
        int pivote;
        central = (primero + ultimo) / 2;
        pivote = arreglo[central];
        i = primero;
        j = ultimo;
        do {
            while (arreglo[i] < pivote) i++;
            while (arreglo[j] > pivote) j--;
            if (i <= j) {
                int tmp = arreglo[i];
                arreglo[i] = arreglo[j];
                arreglo[j] = tmp;
                i++;
                j--;
            }
        } while (i <= j);

        if (primero < j) {
            QuickSort(arreglo, primero, j);
        }
        if (i < ultimo) {
            QuickSort(arreglo, i, ultimo);
        }
    }
}