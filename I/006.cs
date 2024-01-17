namespace Ejemplo {
    internal class Program {
        static void Main(string[] args) {
            /* Distribución Triangular. Generar una variable aleatoria con valor mínimo A,
                 valor más probable B y valor máximo C
                 Si r < (B-A)/(C-A)
                    Variable = A + raizcuadrada(r*(C-A)*(B-A))
                 de lo contrario
                    Variable = C - raizcuadrada((1-r)*(C-A)*(C-B))
                 */
            Random Azar = new Random();

            double A = 150;
            double B = 190;
            double C = 230;
            double variable = 0;
            for (int cont = 1; cont <= 100; cont++) {
                double r = Azar.NextDouble();
                if (r < (B - A) / (C - A))
                    variable = A + Math.Sqrt(r * (C - A) * (B - A));
                else
                    variable = C - Math.Sqrt((1 - r) * (C - A) * (C - B));
                Console.Write(variable + "; ");
            }
        }
    }
}
