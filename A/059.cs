namespace Ejemplo;

internal class Program {
	static void Main() {
		//Funciones de números
		int Numero = 16832929;
		Console.Write("Número: ");
		Console.WriteLine(Numero);

		Console.Write("Impar: ");
		Console.WriteLine(EsImpar(Numero));

		Console.Write("Par: ");
		Console.WriteLine(EsPar(Numero));

		Console.Write("Total de cifras: ");
		Console.WriteLine(TotalCifras(Numero));

		Console.Write("Dos últimas cifras: ");
		Console.WriteLine(RetornadosultimasCifras(Numero));

		Console.Write("Antepenúltima cifra: ");
		Console.WriteLine(AntepenultimaCifra(Numero));

		Console.Write("Penúltima cifra: ");
		Console.WriteLine(PenultimaCifra(Numero));

		Console.Write("Última cifra: ");
		Console.WriteLine(UltimaCifra(Numero));

		Console.Write("Cifra más alta: ");
		Console.WriteLine(LaCifraMasAlta(Numero));

		Console.Write("Cifra más baja: ");
		Console.WriteLine(LaCifraMasBaja(Numero));

		Console.Write("Total de cifras iguales a 5 es: ");
		Console.WriteLine(Cifrashalladas(Numero, 5));

		Console.Write("Al invertirlo es: ");
		Console.WriteLine(InvierteNumero(Numero));

		Console.Write("Es palíndromo: ");
		Console.WriteLine(EsPalindromo(Numero));

		Console.Write("Tercera cifra es: ");
		Console.WriteLine(CifraPosicion(Numero, 3));

		Console.Write("Primera cifra es: ");
		Console.WriteLine(PrimeraCifra(Numero));

		Console.Write("Suma de las cifras es: ");
		Console.WriteLine(SumaCifras(Numero));

		Console.Write("Suma de cifras pares es: ");
		Console.WriteLine(SumaCifrasPares(Numero));

		Console.Write("Suma de cifras impares es: ");
		Console.WriteLine(SumaCifrasImpares(Numero));

		Console.Write("Multiplicación de cifras es: ");
		Console.WriteLine(MultiplicaCifras(Numero));

		Console.Write("Multiplicación de cifras pares es: ");
		Console.WriteLine(MultiplicaCifrasPares(Numero));

		Console.Write("Multiplicación de cifras impares es: ");
		Console.WriteLine(MultiplicaCifrasImpares(Numero));

		Console.Write("Todas las cifras son pares: ");
		Console.WriteLine(TodasCifrasPares(Numero));

		Console.Write("Todas las cifras son impares: ");
		Console.WriteLine(TodasCifrasImpares(Numero));

		Console.Write("Total cifras pares: ");
		Console.WriteLine(TotalCifrasPares(Numero));

		Console.Write("Total cifras impares: ");
		Console.WriteLine(TotalCifrasImpares(Numero));

		Console.Write("Solo hay cifras menores o iguales a 5: ");
		Console.WriteLine(SoloCifrasMenorIgual(Numero, 5));

		Console.Write("Solo hay cifras mayores o iguales a 5: ");
		Console.WriteLine(SoloCifrasMayorIgual(Numero, 5));

		Console.Write("Usa distintas cifras: ");
		Console.WriteLine(DistintasCifras(Numero));

		Console.Write("Usa distintas cifras pares: ");
		Console.WriteLine(DistintasCifrasPares(Numero));

		Console.Write("Usa distintas cifras impares: ");
		Console.WriteLine(DistintasCifrasImPares(Numero));

		Console.Write("Extrayendo cifras pares: ");
		Console.WriteLine(NumeroSoloPares(Numero));

		Console.Write("Extrayendo cifras impares: ");
		Console.WriteLine(NumeroSoloImpares(Numero));
	}

	// Retorna true si un número es impar
	static bool EsImpar(int Numero) {
		return Numero % 2 == 1;
	}

	// Retorna true si un número es par
	static bool EsPar(int Numero) {
		return Numero % 2 == 0;
	}

	// Retorna el número de Cifras de un número
	static int TotalCifras(int Numero) {
		if (Numero == 0) return 1;
		return (int)Math.Floor(Math.Log10(Math.Abs(Numero))) + 1;
	}

	// Retorna las dos últimas Cifras del número
	static int RetornadosultimasCifras(int Numero) {
		return Numero % 100;
	}

	// Retorna la antepenúltima Cifra de un número entero
	static int AntepenultimaCifra(int Numero) {
		return (Numero / 100) % 10;
	}

	// Retorna la penúltima Cifra de un número entero
	static int PenultimaCifra(int Numero) {
		return (Numero / 10) % 10;
	}

	// Retorna la última Cifra de un número entero
	static int UltimaCifra(int Numero) {
		return Numero % 10;
	}

	// Retorna la Cifra más alta
	static int LaCifraMasAlta(int Numero) {
		int Copia = Numero;
		int Cifra = 0;
		while (Copia != 0) {
			if (Copia % 10 > Cifra) Cifra = Copia % 10;
			Copia /= 10;
		}
		return Cifra;
	}

	// Retorna la Cifra más baja
	static int LaCifraMasBaja(int Numero) {
		if (Numero == 0) return 0;
		int Copia = Numero;
		int Cifra = 9;
		while (Copia != 0) {
			if (Copia % 10 < Cifra) Cifra = Copia % 10;
			Copia /= 10;
		}
		return Cifra;
	}

	// Dice cuántas Cifras de determinado número hay en el número enviado
	static int Cifrashalladas(int Numero, int Cifra) {
		int Copia = Numero;
		int Acumula = 0;
		while (Copia != 0) {
			if (Copia % 10 == Cifra) Acumula++;
			Copia /= 10;
		}
		return Acumula;
	}

	// Invierte un número
	static int InvierteNumero(int Numero) {
		int resultado = 0;
		while (Numero != 0) {
			resultado = resultado * 10 + (Numero % 10);
			Numero /= 10;
		}
		return resultado;
	}

	// Retorna true si el número es palíndromo
	static bool EsPalindromo(int Numero) {
		return Numero == InvierteNumero(Numero);
	}

	//Retorna la Cifra de una determinada posición
	static int CifraPosicion(int Numero, int Posicion) {
		int totalCifras = TotalCifras(Numero);
		if (Posicion < 1 || Posicion > totalCifras) return 0;
		int divisor = (int)Math.Pow(10, totalCifras - Posicion);
		return (Numero / divisor) % 10;
	}

	// Retorna la primera Cifra de un número
	static int PrimeraCifra(int Numero) {
		return CifraPosicion(Numero, 1);
	}

	// Retorna la sumatoria de las Cifras de un número
	static int SumaCifras(int Numero) {
		int Copia = Numero;
		int Acumula = 0;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			Acumula += Cifra;
			Copia /= 10;
		}
		return Acumula;
	}

	// Retorna la sumatoria de las Cifras pares de un número
	static int SumaCifrasPares(int Numero) {
		int Copia = Numero;
		int Acumula = 0;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 == 0) Acumula += Cifra;
			Copia /= 10;
		}
		return Acumula;
	}

	// Retorna la sumatoria de las Cifras impares de un número
	static int SumaCifrasImpares(int Numero) {
		int Copia = Numero;
		int Acumula = 0;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 != 0) Acumula += Cifra;
			Copia /= 10;
		}
		return Acumula;
	}

	// Retorna el producto de las Cifras de un número
	static int MultiplicaCifras(int Numero) {
		if (Numero == 0) return 0;
		int Copia = Numero;
		int Acumula = 1;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			Acumula *= Cifra;
			Copia /= 10;
		}
		return Acumula;
	}

	// Retorna el producto de las Cifras pares de un número
	static int MultiplicaCifrasPares(int Numero) {
		int Copia = Numero;
		int Acumula = 1;
		bool HayPar = false;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 == 0) {
				Acumula *= Cifra;
				HayPar = true;
			}
			Copia /= 10;
		}
		if (HayPar) return Acumula;
		return 0;
	}

	// Retorna el producto de las Cifras impares de un número
	static int MultiplicaCifrasImpares(int Numero) {
		int Copia = Numero;
		int Acumula = 1;
		bool HayImpar = false;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 != 0) {
				Acumula *= Cifra;
				HayImpar = true;
			}
			Copia /= 10;
		}
		if (HayImpar) return Acumula;
		return 0;
	}

	// Retorna true si todas las Cifras son pares
	static bool TodasCifrasPares(int Numero) {
		int Copia = Numero;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 != 0) return false;
			Copia /= 10;
		}
		return true;
	}

	// Retorna true si todas las Cifras son impares
	static bool TodasCifrasImpares(int Numero) {
		int Copia = Numero;
		if (Copia == 0) return false;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 == 0) return false;
			Copia /= 10;
		}
		return true;
	}

	// Retorna el número de Cifras pares
	static int TotalCifrasPares(int Numero) {
		int Copia = Numero;
		int Acumula = 0;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 == 0) Acumula++;
			Copia /= 10;
		}
		return Acumula;
	}

	// Retorna el número de Cifras impares
	static int TotalCifrasImpares(int Numero) {
		int Copia = Numero;
		int Acumula = 0;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 != 0) Acumula++;
			Copia /= 10;
		}
		return Acumula;
	}

	// Retorna true si el número tiene sólo Cifras menores o iguales a Cifra
	static bool SoloCifrasMenorIgual(int Numero, int Cifra) {
		int Copia = Numero;
		while (Copia != 0) {
			if (Copia % 10 > Cifra) return false;
			Copia /= 10;
		}
		return true;
	}

	// Retorna true si el número tiene sólo Cifras mayores o iguales a Cifra
	static bool SoloCifrasMayorIgual(int Numero, int Cifra) {
		int Copia = Numero;
		while (Copia != 0) {
			if (Copia % 10 < Cifra) return false;
			Copia /= 10;
		}
		return true;
	}

	// Retorna true si todas las Cifras son distintas
	static bool DistintasCifras(int Numero) {
		string s = Numero.ToString();
		return s.Length == s.Distinct().Count();
	}

	// Retorna si todas las Cifras pares son distintas
	static bool DistintasCifrasPares(int Numero) {
		for (int Cifra = 0; Cifra <= 8; Cifra += 2) {
			int Copia = Numero;
			int Cuenta = 0;
			while (Copia != 0) {
				if (Copia % 10 == Cifra) Cuenta++;
				if (Cuenta > 1) return false;
				Copia /= 10;
			}
		}
		return true;
	}

	// Retorna si todas las Cifras impares son distintas
	static bool DistintasCifrasImPares(int Numero) {
		for (int Cifra = 1; Cifra <= 9; Cifra += 2) {
			int Copia = Numero;
			int Cuenta = 0;
			while (Copia != 0) {
				if (Copia % 10 == Cifra) Cuenta++;
				if (Cuenta > 1) return false;
				Copia /= 10;
			}
		}
		return true;
	}

	//Retorna un número con solo las Cifras pares
	static int NumeroSoloPares(int Numero) {
		int Copia = Numero;
		int Acumula = 0;
		int Posicion = 1;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 == 0) {
				Acumula += Posicion * Cifra;
				Posicion *= 10;
			}
			Copia /= 10;
		}
		return Acumula;
	}

	//Retorna un número con solo las Cifras impares
	static int NumeroSoloImpares(int Numero) {
		int Copia = Numero;
		int Acumula = 0;
		int Posicion = 1;
		while (Copia != 0) {
			int Cifra = Copia % 10;
			if (Cifra % 2 != 0) {
				Acumula += Posicion * Cifra;
				Posicion *= 10;
			}
			Copia /= 10;
		}
		return Acumula;
	}
}