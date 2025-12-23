namespace Ejemplo;

internal class Program {
    static void Main() {
        int TamanoX = 3;
        int TamanoY = 4;
        int TamanoZ = 5;

        //Declara un arreglo Tridimensional
        int[,,] Solido = new int[TamanoX, TamanoY, TamanoZ];

        /* Llena ese arreglo tridimensional
           Solido.GetLength(0) Retorna la primera dimensión
           Solido.GetLength(1) Retorna la segunda dimensión
           Solido.GetLength(2) Retorna la tercera dimensión

           Un arreglo tridimensional inicia en [0,0,0]
        */
        for (int posX = 0; posX < Solido.GetLength(0); posX++)
            for (int posY = 0; posY < Solido.GetLength(1); posY++)
                for (int posZ = 0; posZ < Solido.GetLength(2); posZ++)
                    Solido[posX, posY, posZ] = (posX + 1) * 100 + posY * 10 + posZ;

        //Imprime ese arreglo tridimensional
        for (int posX = 0; posX < Solido.GetLength(0); posX++) {
            Console.WriteLine(" ");
            for (int posY = 0; posY < Solido.GetLength(1); posY++) {
                Console.Write("[");
                for (int posZ = 0; posZ < Solido.GetLength(2); posZ++)
                    Console.Write(Solido[posX, posY, posZ] + ";");
                Console.Write("]  ");
            }
        }
    }
}