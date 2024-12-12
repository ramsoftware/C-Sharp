namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Fuente de datos, un arreglo unidimensional
            int[] Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3, 2, 9, 2, 9];

            //Promedio
            double Promedio = Lista.Where(x => x % 2 == 1).Average();
            Console.Write("Promedio valores impares: " + Promedio);
        }
    }
}
