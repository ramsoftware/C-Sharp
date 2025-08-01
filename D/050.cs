
namespace Ejemplo
{
    class Valores {
        private int Entero;
        private double ValorReal;

        public Valores(int entero, double valorReal) {
            Entero = entero;
            ValorReal = valorReal;
        }

        public void Imprime() {
            Console.WriteLine(Entero + ";" + ValorReal);
        } 
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Arreglo unidimensional de objetos
            Valores[] objetos = new Valores[10];

            Random Azar = new();

            //Se crean los objetos
            for (int Cont=0; Cont < objetos.Length; Cont++)
                objetos[Cont] = new Valores(Cont, Azar.NextDouble());

            //Se imprimen los objetos
            for (int Cont = 0; Cont < objetos.Length; Cont++)
                objetos[Cont].Imprime();
        }
    }
}
