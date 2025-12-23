namespace Ejemplo;

internal class Program {
    static void Main() {
        //Ordenación
        int Limite = 10;
        int[] Listado = new int[Limite];

        int minimo = 10, maximo = 99;

        //Ordena por Inserción
        Console.WriteLine("\nOrdena por inserción");
        LlenaArreglo(Listado, minimo, maximo);
        ImprimeArreglo("Original", Listado);
        Insercion(Listado);
        ImprimeArreglo("Ordenado", Listado);

        //Ordena por Selección
        Console.WriteLine("\nOrdena por selección");
        LlenaArreglo(Listado, minimo, maximo);
        Array.Copy(Listado, 0, Listado, 0, Listado.Length);
        ImprimeArreglo("Original", Listado);
        Seleccion(Listado);
        ImprimeArreglo("Ordenado", Listado);

        //Ordena por Burbuja
        Console.WriteLine("\nOrdena por burbuja");
        LlenaArreglo(Listado, minimo, maximo);
        ImprimeArreglo("Original", Listado);
        Burbuja(Listado);
        ImprimeArreglo("Ordenado", Listado);

        //Ordena por Shell
        Console.WriteLine("\nOrdena por shell");
        LlenaArreglo(Listado, minimo, maximo);
        ImprimeArreglo("Original", Listado);
        Shell(Listado);
        ImprimeArreglo("Ordenado", Listado);

        //Ordena por QuickSort
        Console.WriteLine("\nOrdena por quicksort");
        LlenaArreglo(Listado, minimo, maximo);
        ImprimeArreglo("Original", Listado);
        QuickSort(Listado, 0, Listado.Length - 1);
        ImprimeArreglo("Ordenado", Listado);
    }

    //Llena el arreglo con valores al azar
    //entre min y max (ambos incluídos)
    static void LlenaArreglo(int[] arreglo, int min, int max) {
        Random azar = new Random();
        for (int pos = 0; pos < arreglo.Length; pos++) {
            arreglo[pos] = azar.Next(min, max + 1);
        }
    }

    //Imprime el arreglo en consola
    static void ImprimeArreglo(string Texto, int[] arreglo) {
        Console.Write(Texto + ": ");
        for (int pos = 0; pos < arreglo.Length; pos++) {
            Console.Write(arreglo[pos] + ";");
        }
        Console.WriteLine(" ");
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