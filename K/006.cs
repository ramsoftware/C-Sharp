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

    public double CalculaSalida(double E0, double E1) {
        double S = 0;

        //Se hace una operación aquí

        return S;
    }
}

class Program {
    static void Main() {
        Random Azar = new();
        Neurona objA = new(Azar);
        Neurona objB = new(Azar);
    }
}