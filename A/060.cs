namespace Ejemplo;

internal class Program {
	static void Main() {
		int Minimo = 1000;
		int Maximo = 15000;
		Console.WriteLine("Entre " + Minimo + " y " + Maximo + ": ");

		Ejemplo1(Minimo, Maximo);
		Ejemplo2(Minimo, Maximo);
		Ejemplo3(Minimo, Maximo);
		Ejemplo4(Minimo, Maximo);
		Ejemplo5(Minimo, Maximo);
		Ejemplo6(Minimo, Maximo);
		Ejemplo7(Minimo, Maximo);
		Ejemplo8(Minimo, Maximo);
		Ejemplo9(Minimo, Maximo);
		Ejemplo10(Minimo, Maximo);
		Ejemplo11(Minimo, Maximo);
		Ejemplo12(Minimo, Maximo);
		Ejemplo13(Minimo, Maximo);
		Ejemplo14(Minimo, Maximo);
		Ejemplo15(Minimo, Maximo);
		Ejemplo16(Minimo, Maximo);
		Ejemplo17(Minimo, Maximo);
		Ejemplo18(Minimo, Maximo);
	}

	//Cantidad de números que la suma de las tres últimas cifras es par
	static void Ejemplo1(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsPar(AntepenultimaCifra(num) + UltimaCifra(num) + PenultimaCifra(num)))
				cuenta++;
		Console.WriteLine("Cantidad de números que la suma de las tres últimas cifras es par: " + cuenta);
	}

	//Cantidad de números que la multiplicación de las tres últimas cifras es igual a la suma de esas tres últimas cifras
	static void Ejemplo2(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (AntepenultimaCifra(num) * UltimaCifra(num) * PenultimaCifra(num) == AntepenultimaCifra(num) + UltimaCifra(num) + PenultimaCifra(num))
				cuenta++;
		Console.WriteLine("Cantidad de números que la multiplicación de las tres últimas cifras es igual a la suma de esas tres últimas cifras: " + cuenta);
	}

	//Cantidad de números que cada una de sus tres últimas cifras es menor de 5
	static void Ejemplo3(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (AntepenultimaCifra(num) < 5 && PenultimaCifra(num) < 5 && UltimaCifra(num) < 5)
				cuenta++;
		Console.WriteLine("Cantidad de números que cada una de sus tres últimas cifras es menor de 5: " + cuenta);
	}

	//Cantidad de números que al juntar la antepenúltima cifra y la última cifra se obtenga un primo
	static void Ejemplo4(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++) {
			int nuevo = AntepenultimaCifra(num) * 10 + UltimaCifra(num);
			if (EsPrimo(nuevo))
				cuenta++;
		}
		Console.WriteLine("Cantidad de números que al juntar la antepenúltima cifra y la última cifra se obtenga un primo: " + cuenta);
	}

	//Cantidad de números primos que no tengan el número 3 en sus cifras
	static void Ejemplo5(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (Cifrashalladas(num, 3) == 0 && EsPrimo(num))
				cuenta++;
		Console.WriteLine("Cantidad de números primos que no tengan el número 3 en sus cifras: " + cuenta);
	}

	//Cantidad de números palíndromos que tengan mínimo dos veces el 7 en sus cifras
	static void Ejemplo6(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (Cifrashalladas(num, 7) >= 2 && EsPalindromo(num))
				cuenta++;
		Console.WriteLine("Cantidad de números palíndromos que tengan mínimo dos veces el 7 en sus cifras: " + cuenta);
	}

	//Cantidad de números que tengan solo cifras pares y al menos un número 4
	static void Ejemplo7(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (Cifrashalladas(num, 4) >= 1 && TodasCifrasPares(num))
				cuenta++;
		Console.WriteLine("Cantidad de números que tengan solo cifras pares y al menos un número 4: " + cuenta);
	}

	//Cantidad de números que la suma de sus cifras es impar y al menos tenga una vez el número 7
	static void Ejemplo8(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsImpar(SumaCifras(num)) && Cifrashalladas(num, 7) >= 1) {
				cuenta++;
			}
		Console.WriteLine("Cantidad de números que la suma de sus cifras es impar y al menos tenga una vez el número 7: " + cuenta);
	}

	//Cantidad de números primos que sus cifras están entre 3 y 7
	static void Ejemplo9(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsPrimo(num) && LaCifraMasBaja(num) >= 3 && LaCifraMasAlta(num) <= 7)
				cuenta++;
		Console.WriteLine("Cantidad de números primos que sus cifras están entre 3 y 7: " + cuenta);
	}

	//Cantidad de números primos y a su vez palíndromos
	static void Ejemplo10(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsPrimo(num) && EsPalindromo(num))
				cuenta++;
		Console.WriteLine("Cantidad de números primos y a su vez palíndromos: " + cuenta);
	}

	//Cantidad de números que sus dos últimas cifras generan números primos
	static void Ejemplo11(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsPrimo(RetornadosultimasCifras(num)))
				cuenta++;
		Console.WriteLine("Cantidad de números que sus dos últimas cifras generan números primos: " + cuenta);
	}

	//Cantidad de números que tiene el mismo número de cifras pares e impares
	static void Ejemplo12(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (TotalCifrasPares(num) == TotalCifrasImpares(num))
				cuenta++;
		Console.WriteLine("Cantidad de números que tiene el mismo número de cifras pares e impares: " + cuenta);
	}

	//Cantidad de números que la multiplicación de sus cifras pares es igual a la multiplicación de sus cifras impares
	static void Ejemplo13(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (MultiplicaCifrasPares(num) == MultiplicaCifrasImpares(num))
				cuenta++;
		Console.WriteLine("Cantidad de números que la multiplicación de sus cifras pares es igual a la multiplicación de sus cifras impares: " + cuenta);
	}

	//Cantidad de números que la suma de sus cifras pares es igual a la suma de sus cifras impares
	static void Ejemplo14(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (SumaCifrasPares(num) == SumaCifrasImpares(num))
				cuenta++;
		Console.WriteLine("Cantidad de números que la suma de sus cifras pares es igual a la suma de sus cifras impares: " + cuenta);
	}

	//Cantidad de números que al extraer sus cifras impares genera un primo
	static void Ejemplo15(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsPrimo(NumeroSoloImpares(num)))
				cuenta++;
		Console.WriteLine("Cantidad de números que al extraer sus cifras impares genera un primo: " + cuenta);
	}


	//Cantidad de números que al extraer sus cifras pares genera un palindromo
	static void Ejemplo16(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsPalindromo(NumeroSoloPares(num)))
				cuenta++;
		Console.WriteLine("Cantidad de números que al extraer sus cifras pares genera un palindromo: " + cuenta);
	}


	//Cantidad de números que son primos y además todas sus cifras son impares
	static void Ejemplo17(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsPrimo(num) && TodasCifrasImpares(num))
				cuenta++;
		Console.WriteLine("Cantidad de números que son primos y además todas sus cifras son impares: " + cuenta);
	}

	//Cantidad de números que al multiplicar sus cifras y sumarle 1 genera un número primo
	static void Ejemplo18(int minimo, int maximo) {
		int cuenta = 0;
		for (int num = minimo; num <= maximo; num++)
			if (EsPrimo(MultiplicaCifras(num) + 1))
				cuenta++;
		Console.WriteLine("Cantidad de números que al multiplicar sus cifras y sumarle 1 genera un número primo: " + cuenta);
	}

	//Retorna true si el número enviado por parámetro es primo
	static bool EsPrimo(int num) {
		if (num <= 1) return false;
		if (num == 2) return true;
		if (num % 2 == 0) return false;
		for (int divide = 3; divide <= Math.Sqrt(num); divide += 2)
			if (num % divide == 0) return false;
		return true;
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