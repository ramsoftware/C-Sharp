namespace Ejemplo {
    internal class Program {
        static void Main() {
            List<string> Textos =
                            [ "abc", "Opq", "Afv", "Tkl", "qaz",
                            "Akh", "oSd", "uyt", "oxv" ];

            //Extrae las palabras que empiezan con "a"
            List<string> PalabraMinusculaA = (from palabra in Textos
                                    where palabra.ToLower().StartsWith("a")
                                    select palabra.ToLower()).ToList();

            for (int Cont = 0; Cont < PalabraMinusculaA.Count; Cont++)
                Console.WriteLine(PalabraMinusculaA[Cont]);

            //Extrae las palabras que empiezan con "o"
            //usando la instrucción Let
            List<string> PalabraMinusculaB = (from palabra in Textos
                                    let minuscula = palabra.ToLower()
                                    where minuscula.StartsWith("o")
                                    select minuscula).ToList();

            for (int Cont = 0; Cont < PalabraMinusculaB.Count; Cont++)
                Console.WriteLine(PalabraMinusculaB[Cont]);
        }
    }
}
