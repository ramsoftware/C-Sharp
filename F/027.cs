namespace Ejemplo {
    internal class Program {
        static void Main(string[] args) {
            //============================================
            //Expresión lambda
            //============================================
            var AlCubo = (int valor) => valor * valor * valor;
            
            //Uso de la expresión lambda
            int Resultado = AlCubo(13);
            Console.WriteLine("Elevado al cubo: " + Resultado);
        }
    }
}
