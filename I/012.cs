namespace Ejemplo {
    internal class Program {
        static void Main() {
            /*  Encuentro de dos robots sin sensor visual en un tablero. 
                ¿Cuál es la mejor estrategia?
                1. Un robot quieto y el otro moviéndose.
                2. Los dos robots moviéndose.
            */

            Random Azar = new();

            //Tamaño del tablero
            int Filas = 300;
            int Columnas = 300;

            int MueveEstrategia1 = 0;
            int MueveEstrategia2 = 0;
            for (int Pruebas = 1; Pruebas <= 1000; Pruebas++) {
                //Robot A
                int FilRobotA = Azar.Next(Filas);
                int ColRobotA = Azar.Next(Columnas);

                //Robot B
                int FilRobotB, ColRobotB;
                do {
                    FilRobotB = Azar.Next(Filas);
                    ColRobotB = Azar.Next(Columnas);
                } while (FilRobotA == FilRobotB || ColRobotA == ColRobotB);

                MueveEstrategia1 += Estrategia1(Azar, FilRobotA, ColRobotA, FilRobotB, ColRobotB, Filas, Columnas);
                MueveEstrategia2 += Estrategia2(Azar, FilRobotA, ColRobotA, FilRobotB, ColRobotB, Filas, Columnas);
            }

            Console.WriteLine("Total movimientos para: Un robot quieto (B) y el otro moviéndose (A): " + MueveEstrategia1);
            Console.WriteLine("Total movimientos para: Los dos robots movéndose: " + MueveEstrategia2);

        }

        static int Estrategia1(Random Azar, int FilRobotA, int ColRobotA, int FilRobotB, int ColRobotB, int Filas, int Columnas) {
            //Estrategia 1. Un robot quieto (B) y el otro moviéndose (A)
            int TotalMovimientos = 0;
            do {
                TotalMovimientos++;
                int FilaMueve, ColumnaMueve;
                do {
                    FilaMueve = Azar.Next(-1, 2);
                    ColumnaMueve = Azar.Next(-1, 2);
                } while (FilRobotA + FilaMueve < 0 || FilRobotA + FilaMueve >= Filas ||
                         ColRobotA + ColumnaMueve < 0 || ColRobotA + ColumnaMueve >= Columnas ||
                         (FilaMueve == 0 && ColumnaMueve == 0));
                FilRobotA += FilaMueve;
                ColRobotA += ColumnaMueve;
            } while (FilRobotA != FilRobotB || ColRobotA != ColRobotB);
            return TotalMovimientos;
        }

        static int Estrategia2(Random Azar, int FilRobotA, int ColRobotA, int FilRobotB, int ColRobotB, int Filas, int Columnas) {
            //Estrategia 2. Los dos robots movéndose
            int TotalMovimientos = 0;
            do {
                TotalMovimientos++;

                //Mueve Robot A
                int A_FilaMueve, A_ColumnaMueve;
                do {
                    A_FilaMueve = Azar.Next(-1, 2);
                    A_ColumnaMueve = Azar.Next(-1, 2);
                } while (FilRobotA + A_FilaMueve < 0 || FilRobotA + A_FilaMueve >= Filas ||
                         ColRobotA + A_ColumnaMueve < 0 || ColRobotA + A_ColumnaMueve >= Columnas ||
                         (A_FilaMueve == 0 && A_ColumnaMueve == 0));
                FilRobotA += A_FilaMueve;
                ColRobotA += A_ColumnaMueve;

                //Mueve RobotB
                int B_FilaMueve, B_ColumnaMueve;
                do {
                    B_FilaMueve = Azar.Next(-1, 2);
                    B_ColumnaMueve = Azar.Next(-1, 2);
                } while (FilRobotB + B_FilaMueve < 0 || FilRobotB + B_FilaMueve >= Filas ||
                         ColRobotB + B_ColumnaMueve < 0 || ColRobotB + B_ColumnaMueve >= Columnas ||
                         (B_FilaMueve == 0 && B_ColumnaMueve == 0));
                FilRobotB += B_FilaMueve;
                ColRobotB += B_ColumnaMueve;

            } while (FilRobotA != FilRobotB || ColRobotA != ColRobotB);
            return TotalMovimientos;
        }
    }
}
