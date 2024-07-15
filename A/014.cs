namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Compara la precisión entre float y double
            float valA = (float)(1.7 / 2.3);
            double valB = 1.7 / 2.3;
            decimal valC = (decimal)1.7 / (decimal)2.3;

            Console.WriteLine("Valor A (float): " + valA);
            Console.WriteLine("Valor B (double): " + valB);
            Console.WriteLine("Valor C (decimal): " + valC);
        }
    }
}