namespace Ejemplo;

internal class Program {
    static void Main() {
        //Generador Blum Blum Shub
        long X0, M;

        //Valores de inicio. Se los da el usuario.
        X0 = 3;
        M = 11 * 19;

        for (int contador = 1; contador <= 100; contador++) {
            X0 = (X0 * X0) % M;
            double r = (double)X0 / M;
            Console.Write("Número pseudo-aleatorio: ");
            Console.WriteLine(X0 + "  r: " + r);
        }
    }
}