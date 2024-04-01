namespace Ejemplo {
    internal class Program {
        static void Main() {
            /* Generador de números pseudo-aleatorios */
            Random Azar = new();

            /* Contador de éxitos si el jugador cambia su decisión inicial */
            int CambiaDecision = 0;

            /* Contador de éxitos si el jugador  insiste en mantener su decisión inicial */
            int InsisteNOCambiar = 0;

            for (int prueba = 1; prueba <= 1000000; prueba++) {
                /* Selecciona una caja al azar que será la ganadora */
                int cajaGanadora = Azar.Next(3);

                /* El jugador selecciona una caja al azar */
                int cajaJugador = Azar.Next(3);

                /* Si el jugador escogió por casualidad la caja ganadora,
                   el dueño escoge al azar alguna de las dos cajas restantes */
                int cajaDueno;
                if (cajaGanadora == cajaJugador)
                    do {
                        cajaDueno = Azar.Next(3);
                    } while (cajaDueno == cajaGanadora);
                else
                    /* El dueño sólo puede escoger la caja que no tiene premio */
                    do {
                        cajaDueno = Azar.Next(3);
                    } while (cajaDueno == cajaGanadora || cajaDueno == cajaJugador);

                /* El jugador NO cambia su elección */
                if (cajaGanadora == cajaJugador) InsisteNOCambiar++;

                /* El jugador SI cambia su elección */
                int nuevaCaja;
                do {
                    nuevaCaja = Azar.Next(3);
                } while (nuevaCaja == cajaDueno || nuevaCaja == cajaJugador);
                if (nuevaCaja == cajaGanadora) CambiaDecision++;
            }

            Console.WriteLine("Número de aciertos");
            Console.WriteLine("SIN cambiar la elección inicial: " + InsisteNOCambiar);
            Console.WriteLine("CAMBIANDO la elección inicial: " + CambiaDecision);
        }
    }
}
