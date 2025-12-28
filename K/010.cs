namespace Ejemplo;

class Program {
    static void Main() {
    }
}

class Perceptron {
    List<Capa> Capas;
}

class Capa {
    List<Neurona> Neuronas;
}

class Neurona {
    private List<double> Pesos; //Los pesos para cada entrada
    double Umbral; //El peso del umbral

    //Inicializa los pesos y umbral con un valor al azar
    public Neurona(Random Azar, int TotalEntradas) {
        Pesos = [];
        for (int Contador = 0; Contador < TotalEntradas; Contador++)
            Pesos.Add(Azar.NextDouble());
        Umbral = Azar.NextDouble();
    }

    //Calcula la salida de la neurona dependiendo de las entradas
    public double CalculaSalida(List<double> Entradas) {
        double Valor = 0;
        for (int Contador = 0; Contador < Pesos.Count; Contador++)
            Valor += Entradas[Contador] * Pesos[Contador];
        Valor += Umbral;
        return 1 / (1 + Math.Exp(-Valor));
    }
}