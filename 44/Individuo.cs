using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplo {
    internal class Individuo {
        public int Fila, Columna, Estado;

        public Individuo(int Fila, int Columna, int Estado) {
            this.Fila = Fila;
            this.Columna = Columna;
            this.Estado = Estado;
        }

        public void Mover(int direccion, int NumFilas, int NumColumnas) {
            switch (direccion) {
                case 0: Fila--; Columna--; break;
                case 1: Fila--; break;
                case 2: Fila--; Columna++; break;
                case 3: Columna--; break;
                case 4: Columna++; break;
                case 5: Fila++; Columna--; break;
                case 6: Fila++; break;
                case 7: Fila++; Columna++; break;
            }

            if (Fila < 0) Fila = 0;
            if (Columna < 0) Columna = 0;
            if (Fila >= NumFilas) Fila = NumFilas - 1;
            if (Columna >= NumColumnas) Columna = NumColumnas - 1;
        }
    }
}
