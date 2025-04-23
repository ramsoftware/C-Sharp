namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Fuente de datos, un arreglo unidimensional
            int[] Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3, 2];

            Console.WriteLine("Consulta usando LINQ");
            List<int> Resultados = (from numero in Lista
                                    where numero > 5
                                    select numero).ToList();

            //Ejecuta la consulta y la imprime
            for (int cont = 0; cont < Resultados.Count; cont++)
                Console.Write(Resultados[cont].ToString() + ", ");

            //Hacer lo mismo con una expresión lambda
            Console.WriteLine("\r\nConsulta usando Lambda");
            List<int> Datos = Lista.Where(x => x > 5).ToList();
            foreach (int UnValor in Datos) Console.Write(UnValor + ", ");
        }
    }
}
