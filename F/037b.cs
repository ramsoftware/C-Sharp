namespace Ejemplo {
    internal class Program {
        // Método para clasificar números como "Pares" o "Impares"
        static string ClasificarParidad(int num) {
            return num % 2 == 0 ? "Pares" : "Impares";
        }

        static void Main() {
            // Crear la lista de enteros
            List<int> numeros = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            // Agrupar usando LINQ y un método en lugar de lambda
            var agrupados = numeros.GroupBy(ClasificarParidad);

            // Mostrar los resultados
            foreach (var grupo in agrupados) {
                Console.WriteLine($"{grupo.Key}: {string.Join(", ", grupo)}");
            }
        }
    }
}