namespace Ejemplo {

    //Inicia la aplicación aquí
    internal class Program {
        // 1. Se declara el delegado
        public delegate double EstrategiaDescuento(double precioOriginal);

        // 2. Distintas estrategias de descuento. Obsérvese que debe
        //coincidir el tipo de dato devuelto, el número de parámetros
        //y el tipo.
        public static double DescuentoRegular(double precio) { 
            return precio * 0.95; // 5%
        }
        public static double DescuentoPremium(double precio) {
            return precio * 0.85; // 15%
        }
        public static double SinDescuento(double precio) {
            return precio; // 0%
        }


        // 3. Método que aplica el descuento usando el delegado
        public static void AplicarDescuento(string tipoCliente, double precio, 
            EstrategiaDescuento descuento) {
            double precioFinal = descuento(precio);
            Console.WriteLine($"Cliente: {tipoCliente} - Precio original: {precio:C} - Precio con descuento: {precioFinal:C}");
        }

        static void Main() {
            double precioProducto = 100;

            // 4. Se usa el delegado para aplicar distintas estrategias
            AplicarDescuento("Regular", precioProducto, DescuentoRegular);
            AplicarDescuento("Premium", precioProducto, DescuentoPremium);
            AplicarDescuento("Invitado", precioProducto, SinDescuento);
        }
    }
}