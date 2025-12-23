namespace Ejemplo;

internal class Program {
    static void Main() {
        Random Azar = new();

        //Llena un arreglo con valores aleatorios
        double[] Numeros = new double[10];
        for (int cont = 0; cont < Numeros.Length; cont++)
            Numeros[cont] = Azar.NextDouble();

        //Ordena el arreglo
        Array.Sort(Numeros);

        //Recorre el arreglo y lo imprime
        foreach (double unvalor in Numeros) {
            Console.WriteLine(unvalor);
        }
    }
}