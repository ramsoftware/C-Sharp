namespace Ejemplo {
    public class DibujarFiguras : IDrawable {

        int[,] Plano; //Dónde ocurre realmente la acción
        int PosX, PosY; //Coordenadas del cuadrado relleno
        int IncrX, IncrY; //Desplazamiento del cuadrado relleno

        public DibujarFiguras() {
            //Inicializa el tablero
            Plano = new int[30, 30];

            //Inicializa la posición del cuadrado relleno
            Random azar = new();
            PosX = azar.Next(0, Plano.GetLength(0));
            PosY = azar.Next(0, Plano.GetLength(1));

            //Desplaza el cuadrado relleno
            IncrX = 1;
            IncrY = 1;
        }

        public void Logica() {
            //Borra la posición anterior
            Plano[PosX, PosY] = 0;

            //Si colisiona con alguna pared cambia el incremento
            if (PosX + IncrX >= Plano.GetLength(0) || PosX + IncrX < 0)
                IncrX *= -1;

            if (PosY + IncrY >= Plano.GetLength(1) || PosY + IncrY < 0)
                IncrY *= -1;

            //Cambia la posición de X y Y 
            PosX += IncrX;
            PosY += IncrY;

            //Nueva posición
            Plano[PosX, PosY] = 1;
        }


        public void Draw(ICanvas Lienzo, RectF dirtyRect) {
            Lienzo.StrokeColor = Colors.Black;
            Lienzo.StrokeSize = 2;
            Lienzo.FillColor = Colors.Red;

            //Tamaño de cada celda
            int tX = (int) dirtyRect.Width / Plano.GetLength(0);
            int tY = (int) dirtyRect.Height / Plano.GetLength(1);

            //Dibuja la malla y la posición del rectángulo relleno
            for (int Fil = 0; Fil < Plano.GetLength(0); Fil++) {
                for (int Col = 0; Col < Plano.GetLength(1); Col++)
                    if (Plano[Fil, Col] == 0)
                        Lienzo.DrawRectangle(Fil * tX, Col * tY, tX, tY);
                    else
                        Lienzo.FillRectangle(Fil * tX, Col * tY, tX, tY);
            }
        }
    }
}