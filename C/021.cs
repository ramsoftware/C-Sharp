namespace Ejemplo;

internal class Program {
    static void Main() {
        //Una cadena
        string Cadena = " abc  def  ghij  klmn  opqrstu  vw  ";

        //Se divide en un arreglo de palabras
        string[] Palabras = Cadena.Split(' ');

        //¡OJO! que cuando hay más de un espacio
        //intermedio, este se interpreta como una palabra
        foreach (string elemento in Palabras) {
            Console.WriteLine("[" + elemento + "]");
        }
    }
}