namespace Ejemplo;

internal class Program {
    static void Main() {
        //Área bajo la curva

        //Mínimo valor en X, máximo valor en X
        double MinValX = -5;
        double MaxValX = 5;

        //Validar que no hayan puntos de corte
        if (HayPuntosCorte(MinValX, MaxValX)) {
            Console.Write("Hay puntos de corte, ");
            Console.WriteLine("no es válido para hallar el área");
        }
        else {
            double Ymax = MaxMinY(MinValX, MaxValX);
            double Area = AreaC(MinValX, MaxValX, Ymax);
            Console.WriteLine("Área es: " + Area);
        }
    }

    //Retorna true si hay puntos de corte entre los valores
    //de X mínimo y máximo dados
    static public bool HayPuntosCorte(double MinX, double MaxX) {
        int Positivos = 0;
        int Negativos = 0;
        for (double X = MinX; X <= MaxX; X += 0.001) {
            double Y = Ecuacion(X);
            if (Y > 0) Positivos++;
            if (Y < 0) Negativos++;
        }
        if (Positivos != 0 && Negativos != 0) return true;
        return false;
    }

    //Retorna el mínimo valor de Y (área está por debajo del eje X)
    //o el máximo valor de Y (área está por encima del eje X)
    static public double MaxMinY(double MinX, double MaxX) {
        double MaximoY = double.MinValue;
        double MinimoY = double.MaxValue;
        bool Orienta = false;
        for (double X = MinX; X <= MaxX; X += 0.001) {
            double Y = Ecuacion(X);
            if (Y > 0) Orienta = true;
            if (Y > MaximoY) MaximoY = Y;
            if (Y < MinimoY) MinimoY = Y;
        }
        if (Orienta) return MaximoY;
        return MinimoY;
    }

    //Calcula el área bajo la curva usando el método Monte Carlo. 
    //Siguiendo las directrices matemáticas, 
    //el área será positiva si la curva está por encima del eje X, 
    //el área sera negativa si la curva está por debajo del eje X
    static public double AreaC(double MinX, double MaxX, double Ymax) {
        Random Azar = new();
        int PuntosDentro = 0;
        int PuntosTotal = 7000000;
        for (int puntos = 1; puntos <= PuntosTotal; puntos++) {
            double Xazar = Azar.NextDouble() * (MaxX - MinX) + MinX;
            double Yazar = Azar.NextDouble() * Ymax;
            double Y = Ecuacion(Xazar);
            if (Yazar <= Y && Ymax > 0) PuntosDentro++;
            if (Yazar >= Y && Ymax < 0) PuntosDentro++;
        }
        double Valor = (double)PuntosDentro / PuntosTotal;
        double AreaTotal = (MaxX - MinX) * Ymax * Valor;
        return AreaTotal;
    }

    static public double Ecuacion(double X) {
        double Y = -1 * Math.Abs(Math.Cos(X) - Math.Sin(X) * X);
        return Y;
    }
}
