namespace Ejemplo {
    internal class Program {
        static void Main(string[] args) {
            //============================================
            //Expresión Lambda: Uso del return y { } porque hay
            //más de dos líneas
            //============================================
            var AreaTriangulo = (double ladoA,  double ladoB, double ladoC) =>
            {
                double s = (ladoA + ladoB + ladoC) / 2;
                return Math.Sqrt(s*(s-ladoA)*(s-ladoB)*(s-ladoC));
            };

            double Area = AreaTriangulo(3, 4, 5);
            Console.WriteLine("Área del triángulo es: " + Area);
        }
    }
}
