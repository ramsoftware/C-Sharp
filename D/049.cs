namespace Ejemplo
{
    class Valores {
        private int Entero;
        private double ValorReal;
        private bool Booleano;
        private char Caracter;
        private string Cadena;

        public Valores(int entero, double valorReal, bool booleano, char caracter, string cadena) {
            Entero = entero;
            ValorReal = valorReal;
            Booleano = booleano;
            Caracter = caracter;
            Cadena = cadena;
        }

        public void Imprime() {
            Console.WriteLine(Entero + ";" + ValorReal + ";" + Booleano + ";" + Caracter + ";" + Cadena);
        } 
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Arreglo unidimensional de objetos
            Valores[] objetos = new Valores[10];

            //Se crean los objetos
            objetos[0] = new Valores(16, 83.2, true, 'R', "probar");
            objetos[1] = new Valores(72, 6.26, false, 'a', "koala");
            objetos[2] = new Valores(95, -5.21, false, 'K', "Rinoceronte");

            //Se imprimen los objetos
            objetos[1].Imprime();
            objetos[2].Imprime();
            objetos[0].Imprime();

            //¿Que pasaría aquí? Un mensaje de error porque el objeto no ha sido creado
            //objetos[4].Imprime();
        }
    }
}
