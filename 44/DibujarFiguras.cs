namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        //Constantes para calificar cada celda del tablero
        private const int VACIO = 0;
        private const int SANO = 1;
        private const int INFECTADO = 2;

        int[,] Plano; //Dónde ocurre realmente la acción

        Random azar;

        //Población
        List<Individuo> Pobl;

        public DibujarFiguras() {
            IniciarParametros();
        }

        public void IniciarParametros() {
            Plano = new int[30, 30]; //Inicializa el tablero.
            azar = new Random();

            //Inicializa la población
            Pobl = new List<Individuo>();
            int NumIndividuos = 100;
            for (int cont = 1; cont <= NumIndividuos; cont++) {
                int Fila, Columna;
                do {
                    Fila = azar.Next(Plano.GetLength(0));
                    Columna = azar.Next(Plano.GetLength(1));
                } while (Plano[Fila, Columna] != VACIO);
                Plano[Fila, Columna] = SANO;
                Pobl.Add(new Individuo(Fila, Columna, SANO));
            }

            //Inicia con un individuo infectado
            Pobl[azar.Next(NumIndividuos)].Estado = INFECTADO;
        }


        //Lógica de la población
        public void Logica() {
            int NumFil = Plano.GetLength(0);
            int NumCol = Plano.GetLength(1);

            //Mueve los individuos
            for (int cont = 0; cont < Pobl.Count; cont++)
                Pobl[cont].Mover(azar.Next(8), NumFil, NumCol);

            //Limpia el tablero
            for (int Fil = 0; Fil < NumFil; Fil++)
                for (int Col = 0; Col < NumCol; Col++)
                    Plano[Fil, Col] = VACIO;

            //Refleja ese movimiento en el tablero
            for (int cont = 0; cont < Pobl.Count; cont++) {
                int Fila = Pobl[cont].Fila;
                int Columna = Pobl[cont].Columna;
                Plano[Fila, Columna] = Pobl[cont].Estado;
            }

            //Chequea si un individuo infectado coincide con un
            //individuo sano en la misma casilla para infectarlo
            for (int cont = 0; cont < Pobl.Count; cont++) {
                if (Pobl[cont].Estado == INFECTADO) {
                    for (int busca = 0; busca < Pobl.Count; busca++) {
                        if (Pobl[cont].Fila == Pobl[busca].Fila &&
                            Pobl[cont].Columna == Pobl[busca].Columna)
                            Pobl[busca].Estado = INFECTADO;
                    }
                }
            }
        }


        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeColor = Colors.Blue;
            Lienzo.StrokeSize = 1;

            //Tamaño de cada celda
            int tamF = (int) dirtyRect.Width / Plano.GetLength(0);
            int tamC = (int) dirtyRect.Height / Plano.GetLength(1);
            int desplaza = 10;

            //Dibuja el arreglo bidimensional
            for (int Fil = 0; Fil < Plano.GetLength(0); Fil++) {
                for (int Col = 0; Col < Plano.GetLength(1); Col++) {
                    int uF = Fil * tamF + desplaza;
                    int uC = Col * tamC + desplaza;
                    switch (Plano[Fil, Col]) {
                        case VACIO:
                            Lienzo.DrawRectangle(uF, uC, tamF, tamC);
                            break;
                        case SANO:
                            Lienzo.FillColor = Colors.Black;
                            Lienzo.FillRectangle(uF, uC, tamF, tamC);
                            break;
                        case INFECTADO:
                            Lienzo.FillColor = Colors.Red;
                            Lienzo.FillRectangle(uF, uC, tamF, tamC);
                            break;
                    }
                }
            }
        }
    }
}