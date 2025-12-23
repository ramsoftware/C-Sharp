namespace Ejemplo;

internal class Program {
    static void Main() {
        //Reemplazar
        string cadena = "manzana y naranja";
        Console.WriteLine(cadena);

        //Cambia en toda la cadena una letra por otra
        string ReemplazaA = cadena.Replace('a', 'u');
        Console.WriteLine(ReemplazaA);

        //Cambia en toda la cadena una subcadena por otra subcadena
        string ReemplazaB = cadena.Replace("na", "po");
        Console.WriteLine(ReemplazaB);

        //Cambia en toda la cadena una subcadena por una letra
        string ReemplazaC = cadena.Replace("na", "x");
        Console.WriteLine(ReemplazaC);

        //Cambia en toda la cadena una letra por una subcadena
        string ReemplazaD = cadena.Replace("n", "GH");
        Console.WriteLine(ReemplazaD);

        //Cambia en toda la cadena una letra por vacío
        string ReemplazaE = cadena.Replace("a", "");
        Console.WriteLine(ReemplazaE);
    }
}