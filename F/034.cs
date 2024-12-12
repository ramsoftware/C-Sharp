namespace Ejemplo {
    internal class Program {
        static void Main(string[] args) {
            int ValorExterno = 13;
            
            /* El uso de static mejora el desempeño de la expresión lambda
             * pero ya NO se puede hacer uso de variables externas */
            var UnCalculo = static (int Numero) => Numero * ValorExterno;

            int Resultado = UnCalculo(17);
            Console.WriteLine(Resultado);
        }
    }
}