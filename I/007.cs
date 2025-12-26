namespace Ejemplo;

internal class Program {
    static void Main() {
        /* Variable aleatoria
			   Distribución uniforme. Generar un número
			   entero entre A y B
			   variable = r * (B - A) + A   */
        Random Azar = new();
        double A = 10;
        double B = 50;
        for (int cont = 1; cont <= 100; cont++) {
            double r = Azar.NextDouble();
            double variable = r * (B - A) + A;
            Console.Write(variable + "; ");
        }
    }
}