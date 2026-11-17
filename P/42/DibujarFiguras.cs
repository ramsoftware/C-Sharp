namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        //Constantes para calificar cada celda del Plano
        private const int CAMINO = 0;
        private const int OBSTACULO = 1;
        private const int CAZADOR = 2;
        private const int PRESA = 3;

        //Dónde ocurre realmente la acción
        int[,] Plano;

        //Coordenadas del cazador
        int CazaX, CazaY;

        //Desplazamiento del cazador
        int CazaMX, CazaMY;

        //Coordenadas de la presa
        int PresaX, PresaY;

        //Coordenadas temporales para desatorar
        int tmpX, tmpY;

        //Alterna entre buscar la presa real o
        //ir a la coordenada temporal
        bool BuscaTmp;

        //Único generador de números aleatorios.
        Random Azar;


        public DibujarFiguras() {
            Azar = new Random();
            IniciarParametros();
        }

        public void IniciarParametros() {
            //Inicializa el Plano.
            Plano = new int[30, 30];

            //Total de paredes dentro del plano
            int Obstaculos = 150;
            for (int cont = 1; cont <= Obstaculos; cont++) {
                int obstaculoX, obstaculoY;
                do {
                    obstaculoX = Azar.Next(0, Plano.GetLength(0));
                    obstaculoY = Azar.Next(0, Plano.GetLength(1));
                } while (Plano[obstaculoX, obstaculoY] != 0);
                Plano[obstaculoX, obstaculoY] = OBSTACULO;
            }

            //Inicializa la posición del cazador
            do {
                CazaX = Azar.Next(0, Plano.GetLength(0));
                CazaY = Azar.Next(0, Plano.GetLength(1));
            } while (Plano[CazaX, CazaY] != 0);
            Plano[CazaX, CazaY] = CAZADOR;

            //Inicializa la posición de la presa
            do {
                PresaX = Azar.Next(0, Plano.GetLength(0));
                PresaY = Azar.Next(0, Plano.GetLength(1));
            } while (Plano[PresaX, PresaY] != 0);
            Plano[PresaX, PresaY] = PRESA;

            //Desplazamiento del cazador
            CazaMX = 1;
            CazaMY = 1;
        }


        public int Logica() {
            Plano[CazaX, CazaY] = CAMINO;

            if (BuscaTmp == false) {
                //Esta buscando la presa
                if (CazaX > PresaX) CazaMX = -1;
                else if (CazaX < PresaX) CazaMX = 1;
                else CazaMX = 0;

                if (CazaY > PresaY) CazaMY = -1;
                else if (CazaY < PresaY) CazaMY = 1;
                else CazaMY = 0;

                //Verifica si ya llegó a la presa
                if (CazaX == PresaX && CazaY == PresaY) {
                    return 1;
                }
                //Si no, verifica si puede desplazarse a la nueva ubicación
                else if (Plano[CazaX + CazaMX, CazaY + CazaMY] == CAMINO ||
                        Plano[CazaX + CazaMX, CazaY + CazaMY] == PRESA) {
                    CazaX += CazaMX;
                    CazaY += CazaMY;
                }
                //Si no, entonces está atorado con los obstáculos.
                //Luego genera ubicación temporal para ir allí
                else {
                    do {
                        tmpX = Azar.Next(0, Plano.GetLength(0));
                        tmpY = Azar.Next(0, Plano.GetLength(1));
                    } while (Plano[tmpX, tmpY] != CAMINO);
                    BuscaTmp = true;
                }
            }
            else { //Está yendo a la ubicación temporal
                if (CazaX > tmpX) CazaMX = -1;
                else if (CazaX < tmpX) CazaMX = 1;
                else CazaMX = 0;

                if (CazaY > tmpY) CazaMY = -1;
                else if (CazaY < tmpY) CazaMY = 1;
                else CazaMY = 0;

                //Si ha llegado a la ubicación temporal o se queda atorado
                //deja de ir a esa ubicación temporal
                if (CazaX == tmpX && CazaY == tmpY ||
                    Plano[CazaX + CazaMX, CazaY + CazaMY] == OBSTACULO)
                    BuscaTmp = false;
                else {
                    CazaX += CazaMX;
                    CazaY += CazaMY;
                }
            }

            Plano[CazaX, CazaY] = CAZADOR;
            return 0;
        }

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeColor = Colors.Blue;
            Lienzo.StrokeSize = 1;
            Lienzo.FillColor = Colors.Red;

            //Tamaño de cada celda
            int tX = (int) dirtyRect.Width / Plano.GetLength(0);
            int tY = (int) dirtyRect.Height / Plano.GetLength(1);
            int desplaza = 10;

            //Dibuja el arreglo bidimensional
            for (int Fil = 0; Fil < Plano.GetLength(0); Fil++) {
                for (int Col = 0; Col < Plano.GetLength(1); Col++) {
                    int uX = Fil * tX + desplaza;
                    int uY = Col * tY + desplaza;
                    switch (Plano[Fil, Col]) {
                        case CAMINO:
                            Lienzo.DrawRectangle(uX, uY, tX, tY);
                            break;
                        case OBSTACULO:
                            Lienzo.FillColor = Colors.Black;
                            Lienzo.FillRectangle(uX, uY, tX, tY);
                            break;
                        case CAZADOR:
                            Lienzo.FillColor = Colors.Red;
                            Lienzo.FillRectangle(uX, uY, tX, tY);
                            break;
                        case PRESA:
                            Lienzo.FillColor = Colors.Blue;
                            Lienzo.FillRectangle(uX, uY, tX, tY);
                            break;
                    }
                }
            }

        }
    }
}