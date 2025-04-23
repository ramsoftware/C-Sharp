namespace Ejemplo {
    internal class Program {
        static void Main() {
            // Crear la lista de enteros
            List<int> numeros = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            // Agrupar usando LINQ con expresiones lambda
            var Agrupados = numeros.GroupBy(num => num % 2 == 0 ? "Pares" : "Impares");

            // Mostrar los resultados
            foreach (var grupo in Agrupados) {
                Console.WriteLine($"{grupo.Key}: {string.Join(", ", grupo)}");
            }
        }
    }
}