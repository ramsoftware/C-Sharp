namespace Ejemplo {
    internal class Program {
        static void Main() {
            List<string> ColoresA = ["Azul", "Rojo", "Verde", "Marrón", "Violeta"];

            List<string> ColoresB = ["Violeta", "Azul", "Marrón", "Naranja"];

            /* Une los valores de ambas listas evitando repetir */
            List<string> Resultado = ColoresA.Union(ColoresB).ToList();

            for (int Cont = 0; Cont < Resultado.Count; Cont++) {
                Console.WriteLine(Resultado[Cont]);
            }
        }
    }
}