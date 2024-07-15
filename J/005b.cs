namespace MetricaEvolutivo {
	internal class Individuo {
		public int Puntos;
		public string Cadena;

		public Individuo() {
			Puntos = -1;
			Cadena = string.Empty;
		}

		//Operador mutación: Cambia una letra al azar
		public void Muta(Random Azar, string Letras) {
			char[] Arreglo = Cadena.ToCharArray();
			int PosA = Azar.Next(Cadena.Length);
			int PosB = Azar.Next(Letras.Length);
			Arreglo[PosA] = Letras[PosB];
			Cadena = new string(Arreglo);
		}

		//Operador cruce: Cruza dos cadenas en sitios al azar
		public void Cruce(Random Azar, string CadenaA, string CadenaB) {
			int Pos = Azar.Next(CadenaA.Length);

			//Parte izquierda de la cadena A
			//y parte de la derecha de la cadena B
			Cadena = CadenaA[..Pos] + CadenaB[Pos..];
		}

		//Puntaje del individuo
		public void Evalua(string CadenaBusca) {
			Puntos = 0;
			for (int Cont = 0; Cont < CadenaBusca.Length; Cont++)
				if (CadenaBusca[Cont] == Cadena[Cont])
					Puntos++;
		}
	}
}
