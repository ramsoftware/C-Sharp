namespace Ejemplo;

internal class Program {
    static void Main() {
        //Único generador de números aleatorios
        Random Azar = new();

        //Tabla AND
        int[][] Entra = [
            [1, 1],
            [1, 0],
            [0, 1],
            [0, 0]
        ];
        int[] Sale = [1, 0, 0, 0];

        //Los pesos
        double P0, P1, U;

        //Mantiene el proceso activo
        bool Proceso;

        //Número de iteraciones
        int Iteracion = 0;

        //Tasa de aprendizaje
        double TasaAprende = 0.3;

        //Pesos inician al azar
        P0 = Azar.NextDouble();
        P1 = Azar.NextDouble();
        U = Azar.NextDouble();

        //Hasta que aprenda la tabla AND
        do {
            Iteracion++;

            //Prueba la tabla AND
            Proceso = false;
            for (int Cont = 0; Cont < Entra.GetLength(0); Cont++) {

                //Calcula el valor de entrada a la función
                double Oper = Entra[Cont][0] * P0 + Entra[Cont][1] * P1 + U;

                //Función de activación
                int Salida = Oper > 0.5 ? 1 : 0;

                //El error
                int Error = Sale[Cont] - Salida;

                //Si hay error, cambia los pesos con
                //la Tasa de Aprendizaje
                if (Error != 0) {
                    P0 += TasaAprende * Error * Entra[Cont][0];
                    P1 += TasaAprende * Error * Entra[Cont][1];
                    U += TasaAprende * Error * 1;
                    Proceso = true;
                }
            }
        } while (Proceso);

        //Muestra aprendizaje perceptrón simple
        for (int Cont = 0; Cont < Entra.GetLength(0); Cont++) {
            double Oper = Entra[Cont][0] * P0 + Entra[Cont][1] * P1 + U;

            //Función de activación
            int Salida = Oper > 0.5 ? 1 : 0;

            Console.Write("Entradas: " + Entra[Cont][0]);
            Console.Write(" y " + Entra[Cont][1] + " = ");
            Console.WriteLine(Sale[Cont] + " red: " + Salida);
        }

        Console.Write("Pesos encontrados P0= " + P0);
        Console.WriteLine(" P1= " + P1 + " U= " + U);
        Console.WriteLine("Total Iteraciones: " + Iteracion);
    }
}