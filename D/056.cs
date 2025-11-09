namespace Ejemplo
{
    public class Caja<T> {
        public T Contenido { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var cajaInt = new Caja<int> { Contenido = 42 };
            var cajaTexto = new Caja<string> { Contenido = "Hola Rafael" };

            Console.WriteLine("Entero:" + cajaInt.Contenido);
            Console.WriteLine("Texto: " + cajaTexto.Contenido);
        }
    }
}