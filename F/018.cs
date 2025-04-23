namespace Ejemplo {
    internal class Program {
        static void Main() {
            List<string> ColoresA = ["Azul", "Rojo", "Verde", "Violeta"];

            List<string> ColoresB = ["Violeta", "Azul", "Marrón"];

            /* Intersecta los animales que están en ambas listas */
            List<string> Resultado = ColoresA.Intersect(ColoresB).ToList();

            for (int Cont = 0; Cont < Resultado.Count; Cont++) {
                Console.WriteLine(Resultado[Cont]);
            }
        }
    }
}