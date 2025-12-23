using System.Diagnostics;

namespace Ejemplo;

internal class Program {
    static void Main() {
        /* ¿Qué es más rápido? 
         * ¿Un arreglo bidimensional o un arreglo de arreglos */

        //Limite ancho*alto de ambos arreglos
        int Limite = 80;

        //Arreglo Bidimensional
        int[,] tablero = new int[Limite, Limite];

        //Arreglo de arreglos
        int[][] arreglo = new int[Limite][];
        for (int rama = 0; rama < arreglo.Length; rama++)
            arreglo[rama] = new int[Limite];

        //Medidor de tiempos
        Stopwatch cronometro = new();

        //Llenando un arreglo bidimensional
        int valor = 0;
        cronometro.Reset();
        cronometro.Start();
        for (int fila = 0; fila < tablero.GetLength(0); fila++)
            for (int col = 0; col < tablero.GetLength(1); col++)
                tablero[fila, col] = valor++;
        long TBidim = cronometro.ElapsedTicks;

        //Llenando un arreglo de arreglos
        valor = 0;
        cronometro.Reset();
        cronometro.Start();
        for (int conjunto = 0; conjunto < arreglo.Length; conjunto++)
            for (int rama = 0; rama < arreglo[conjunto].Length; rama++)
                arreglo[conjunto][rama] = valor++;
        long TArreglo = cronometro.ElapsedTicks;

        //Imprime los tiempos
        Console.WriteLine("Tiempo arreglo bidimensional: " + TBidim);
        Console.WriteLine("Tiempo arreglo de arreglos: " + TArreglo);
    }
}
