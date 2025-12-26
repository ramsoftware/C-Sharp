namespace Ejemplo;

internal class Program {
    static void Main() {
        /*  Encuentro de dos robots sin sensor visual
            en un tablero. 
            ¿Cuál es la mejor estrategia?
            1. Un robot quieto y el otro moviéndose.
            2. Los dos robots moviéndose.
        */

        Random Azar = new();

        //Tamaño del tablero
        int Filas = 50;
        int Columnas = 50;

        int Estrategia1 = 0;
        int Estrategia2 = 0;
        for (int Pruebas = 1; Pruebas <= 500; Pruebas++) {
            //Fila, Columna => Robot A
            int FilaRobotA = Azar.Next(Filas);
            int ColumnaRobotA = Azar.Next(Columnas);

            //Fila, Columna => Robot B
            int FilaRobotB, ColumnaRobotB;
            do {
                FilaRobotB = Azar.Next(Filas);
                ColumnaRobotB = Azar.Next(Columnas);
            } while (FilaRobotA == FilaRobotB || ColumnaRobotA == ColumnaRobotB);

            Estrategia1 += Program.Estrategia1(Azar, FilaRobotA, ColumnaRobotA, FilaRobotB, ColumnaRobotB, Filas, Columnas);
            Estrategia2 += Program.Estrategia2(Azar, FilaRobotA, ColumnaRobotA, FilaRobotB, ColumnaRobotB, Filas, Columnas);
        }

        Console.Write("Uno quieto y el otro moviéndose");
        Console.WriteLine(". Movimientos: " + Estrategia1);
        Console.Write("Ambos robots se están moviendo.");
        Console.WriteLine("  Movimientos: " + Estrategia2);
    }

    static int Estrategia1(Random Azar, int FilaRobotA, int ColumnaRobotA, int FilaRobotB, int ColumnaRobotB,
                            int Filas, int Columnas) {

        //Estrategia 1. Un robot quieto (B) y el otro moviéndose (A)
        int TotalMovimientos = 0;
        do {
            TotalMovimientos++;
            int FilaMueve, ColumnaMueve;
            do {
                FilaMueve = Azar.Next(-1, 2);
                ColumnaMueve = Azar.Next(-1, 2);
            } while (FilaRobotA + FilaMueve < 0 || FilaRobotA + FilaMueve >= Filas ||
                     ColumnaRobotA + ColumnaMueve < 0 || ColumnaRobotA + ColumnaMueve >= Columnas ||
                     (FilaMueve == 0 && ColumnaMueve == 0));
            FilaRobotA += FilaMueve;
            ColumnaRobotA += ColumnaMueve;
        } while (FilaRobotA != FilaRobotB || ColumnaRobotA != ColumnaRobotB);
        return TotalMovimientos;
    }

    static int Estrategia2(Random Azar, int FilaRobotA, int ColumnaRobotA, int FilaRobotB, int ColumnaRobotB,
                            int Filas, int Columnas) {
        //Estrategia 2. Los dos robots moviéndose
        int TotalMovimientos = 0;
        do {
            TotalMovimientos++;

            //Mueve Robot A
            int RobotA_FilaMueve, RobotA_ColumnaMueve;
            do {
                RobotA_FilaMueve = Azar.Next(-1, 2);
                RobotA_ColumnaMueve = Azar.Next(-1, 2);
            } while (FilaRobotA + RobotA_FilaMueve < 0 || FilaRobotA + RobotA_FilaMueve >= Filas ||
                     ColumnaRobotA + RobotA_ColumnaMueve < 0 || ColumnaRobotA + RobotA_ColumnaMueve >= Columnas ||
                     (RobotA_FilaMueve == 0 && RobotA_ColumnaMueve == 0));
            FilaRobotA += RobotA_FilaMueve;
            ColumnaRobotA += RobotA_ColumnaMueve;

            //Mueve RobotB
            int RobotB_FilaMueve, RobotB_ColumnaMueve;
            do {
                RobotB_FilaMueve = Azar.Next(-1, 2);
                RobotB_ColumnaMueve = Azar.Next(-1, 2);
            } while (FilaRobotB + RobotB_FilaMueve < 0 || FilaRobotB + RobotB_FilaMueve >= Filas ||
                     ColumnaRobotB + RobotB_ColumnaMueve < 0 || ColumnaRobotB + RobotB_ColumnaMueve >= Columnas ||
                     (RobotB_FilaMueve == 0 && RobotB_ColumnaMueve == 0));
            FilaRobotB += RobotB_FilaMueve;
            ColumnaRobotB += RobotB_ColumnaMueve;

        } while (FilaRobotA != FilaRobotB || ColumnaRobotA != ColumnaRobotB);
        return TotalMovimientos;
    }
}