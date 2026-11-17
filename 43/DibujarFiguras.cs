namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        //Constantes para calificar cada celda del tablero
        private const int INACTIVA = 0;
        private const int ACTIVA = 1;

        int[,] Plano; //Dónde ocurre realmente la acción
        Random Azar; //Único generador de números aleatorios.

        public DibujarFiguras() {
            Azar = new Random();
            IniciarParametros();
        }

        public void IniciarParametros() {
            //Inicializa el tablero.
            Plano = new int[40, 40];

            //Habrán celdas activas en el 20%
            int Activos = 200;
            for (int cont = 1; cont <= Activos; cont++) {
                int posX, posY;
                do {
                    posX = Azar.Next(0, Plano.GetLength(0));
                    posY = Azar.Next(0, Plano.GetLength(1));
                } while (Plano[posX, posY] != 0);
                Plano[posX, posY] = ACTIVA;
            }
        }



        public void Logica() {
            //Copia el tablero a uno temporal   
            int[,] PlanoTmp = Plano.Clone() as int[,];

            //Va de celda en celda
            for (int posX = 0; posX < Plano.GetLength(0); posX++) {
                for (int posY = 0; posY < Plano.GetLength(1); posY++) {

                    //Determina el número de vecinos activos
                    int BordeXizq;
                    if (posX - 1 < 0)
                        BordeXizq = Plano.GetLength(0) - 1;
                    else
                        BordeXizq = posX - 1;

                    int BordeYarr;
                    if (posY - 1 < 0)
                        BordeYarr = Plano.GetLength(1) - 1;
                    else
                        BordeYarr = posY - 1;

                    int BordeXder;
                    if (posX + 1 >= Plano.GetLength(0))
                        BordeXder = 0;
                    else
                        BordeXder = posX + 1;


                    int BordeYaba;
                    if (posY + 1 >= Plano.GetLength(1))
                        BordeYaba = 0;
                    else
                        BordeYaba = posY + 1;

                    int Activos = Plano[BordeXizq, BordeYarr];
                    Activos += Plano[posX, BordeYarr];
                    Activos += Plano[BordeXder, BordeYarr];

                    Activos += Plano[BordeXizq, posY];
                    Activos += Plano[BordeXder, posY];

                    Activos += Plano[BordeXizq, BordeYaba];
                    Activos += Plano[posX, BordeYaba];
                    Activos += Plano[BordeXder, BordeYaba];

                    //Los cambios se registran en el tablero temporal

                    //Si la celda está inactiva y tiene 3 celdas activas
                    //alrededor, entonces la celda se activa
                    if (Plano[posX, posY] == INACTIVA && Activos == 3)
                        PlanoTmp[posX, posY] = ACTIVA;

                    //Si la celda está activa y tiene menos de 2 celdas o
                    //más de 3 celdas, entonces la celda se inactiva
                    if (Plano[posX, posY] == ACTIVA &&
                        (Activos < 2 || Activos > 3))
                        PlanoTmp[posX, posY] = INACTIVA;
                }
            }

            //El cambio en el tablero temporal se copia sobre el tablero
            Plano = PlanoTmp.Clone() as int[,];
        }

        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeColor = Colors.Blue;
            Lienzo.StrokeSize = 1;
            Lienzo.FillColor = Colors.Black;

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
                        case INACTIVA:
                            Lienzo.DrawRectangle(uX, uY, tX, tY);
                            break;
                        case ACTIVA:
                            Lienzo.FillRectangle(uX, uY, tX, tY);
                            break;
                    }
                }
            }
        }
    }
}