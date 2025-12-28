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

    //Inicializa los pesos y umbral con valores al azar
    public Neurona(Random Azar, int TotalEntradas) {
        Pesos = [];
        for (int Contador = 0; Contador < TotalEntradas; Contador++)
            Pesos.Add(Azar.NextDouble());
        Umbral = Azar.NextDouble();
    }
}