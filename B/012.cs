using System.Text;
//Librería requerida para StringBuilder

namespace Ejemplo;

internal class Program {
    static void Main() {
        //StringBuilder, mayor velocidad y se puede modificar
        StringBuilder cadenaRapida = new("Prueba");
        Console.WriteLine(cadenaRapida);

        //Cambia el primer caracter
        cadenaRapida[0] = 'e';
        Console.WriteLine(cadenaRapida);

        //Agrega caracteres
        for (int Numero = 0; Numero <= 9; Numero++)
            cadenaRapida.Append(Numero);

        Console.WriteLine(cadenaRapida);
    }
}