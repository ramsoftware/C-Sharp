namespace Ejemplo;

class Neurona {
    //Pesos para cada entrada P0 y P1; y el peso de la entrada interna U
    private double P0;
    private double P1;
    private double U;

    public Neurona(Random Azar) { //Constructor
        P0 = Azar.NextDouble();
        P1 = Azar.NextDouble();
        U = Azar.NextDouble();
    }

    //Calcula la salida de la neurona con las dos entradas E0 y E1
    public double CalculaSalida(double E0, double E1) {
        double Valor = E0 * P0 + E1 * P1 + 1 * U;
        return 1 / (1 + Math.Exp(-Valor));
    }
}

class Program {
    static void Main() {
        Random Azar = new();
        Neurona objA = new(Azar);
        Neurona objB = new(Azar);
    }
}