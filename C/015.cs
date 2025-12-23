namespace Ejemplo;

internal class Program {
    static void Main() {
        /* Arreglo de arreglos
         * NO confundirlos con arreglos bidimensionales.
         * Se entiende mejor haciendo analogía con
         * un tronco y ramas */

        //Defino un arreglo (el tronco)
        int[][] arreglo = new int[5][];

        //Defino las ramas
        arreglo[0] = new int[7]; //Tendrá 7 elementos
        arreglo[1] = new int[3]; //Tendrá 3 elementos
        arreglo[2] = new int[9]; //Tendrá 9 elementos
        arreglo[3] = new int[4]; //Tendrá 4 elementos
        arreglo[4] = new int[8]; //Tendrá 8 elementos

        //Llenando un arreglo de arreglos
        Random azar = new();
        for (int tronco = 0; tronco < arreglo.Length; tronco++)
            for (int rama = 0; rama < arreglo[tronco].Length; rama++)
                arreglo[tronco][rama] = azar.Next(0, 9);

        //Imprime ese arreglo de arreglos
        for (int tronco = 0; tronco < arreglo.Length; tronco++) {
            Console.WriteLine(" ");
            for (int rama = 0; rama < arreglo[tronco].Length; rama++)
                Console.Write(arreglo[tronco][rama] + " ; ");
        }
    }
}