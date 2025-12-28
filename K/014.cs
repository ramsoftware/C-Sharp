namespace Ejemplo;

class Program {
    static void Main() {
        //Un solo generador de números pseudo-aleatorios
        Random Azar = new();
        Perceptron perceptron = new Perceptron();

        int numEntradas = 2; //Número de entradas
        int capa0 = 3; //Total neuronas en la capa 0
        int capa1 = 4; //Total neuronas en la capa 1
        int capa2 = 1; //Total neuronas en la capa 2
        perceptron.CreaCapas(Azar, numEntradas, capa0, capa1, capa2);

        //Estas serán las entradas externas al perceptrón
        List<double> Entradas = new List<double>();
        Entradas.Add(1);
        Entradas.Add(0);

        //Se hace el cálculo
        perceptron.calculaSalida(Entradas);
    }
}

class Perceptron {
    List<Capa>? Capas;

    //Crea las diversas capas
    public void CreaCapas(Random Azar, int Entradas, int NeuronasCapa0, int NeuronasCapa1, int NeuronasCapa2) {
        Capas =
        [
            //Crea la capa 0
            new Capa(Azar, NeuronasCapa0, Entradas),

				//Crea la capa 1 (el número de entradas es
				//el número de neuronas de la capa anterior)
				new Capa(Azar, NeuronasCapa1, NeuronasCapa0),

				//Crea la capa 2 (el número de entradas es
				//el número de neuronas de la capa anterior)
				new Capa(Azar, NeuronasCapa2, NeuronasCapa1),
            ];
    }

    public void calculaSalida(List<double> Entradas) {
        Capas[0].CalculaCapa(Entradas);

        //Las salidas de la capa anterior son
        //las entradas de la siguiente capa
        Capas[1].CalculaCapa(Capas[0].Salidas);
        Capas[2].CalculaCapa(Capas[1].Salidas);
    }

}

class Capa {
    //Las neuronas que tendrá la capa
    List<Neurona> Neuronas;

    //Almacena la salida de cada neurona
    public List<double> Salidas;

    public Capa(Random Azar, int TotalNeuronas, int TotalEntradas) {
        Neuronas = [];
        Salidas = [];

        //Genera las neuronas e inicializa sus salidas
        for (int Contador = 0; Contador < TotalNeuronas; Contador++) {
            Neuronas.Add(new Neurona(Azar, TotalEntradas));
            Salidas.Add(0);
        }
    }

    //Calcula la salida de cada neurona de la capa
    public void CalculaCapa(List<double> Entradas) {
        for (int cont = 0; cont < Neuronas.Count; cont++)
            Salidas[cont] = Neuronas[cont].CalculaSalida(Entradas);
    }
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

    //Calcula la salida de la neurona
    //dependiendo de las entradas
    public double CalculaSalida(List<double> Entradas) {
        double Valor = 0;
        for (int Contador = 0; Contador < Pesos.Count; Contador++)
            Valor += Entradas[Contador] * Pesos[Contador];
        Valor += Umbral;
        return 1 / (1 + Math.Exp(-Valor));
    }
}