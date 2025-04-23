namespace Ejemplo {
    internal class Program {
        static int CalcularCuadrado(int num) {
            return num * num;
        }

        static void Main() {
            // Crear una lista de enteros
            List<int> numeros = [3, 1, 2, 7, 6, 9];

            // Usar LINQ con un método en lugar de expresiones lambda
            List<int> cuadrados = numeros.Select(CalcularCuadrado).ToList();

            // Usar LINQ para sumar los cuadrados
            int sumaCuadrados = cuadrados.Sum();

            // Mostrar los resultados
            Console.WriteLine("Cuadrados: " + string.Join(", ", cuadrados));
            Console.WriteLine("Suma de cuadrados: " + sumaCuadrados);

            // Usar LINQ con expresión Lambda
            var CuadradoLINQ = numeros.Select(num => num * num);

            // Usar LINQ para sumar todos los cuadrados
            int SumaCuadradosLINQ = CuadradoLINQ.Sum();

            // Mostrar los resultados
            Console.WriteLine("Cuadrados: " + string.Join(", ", CuadradoLINQ));
            Console.WriteLine("Suma de cuadrados: " + SumaCuadradosLINQ);
        }
    }
}