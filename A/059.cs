namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Funciones de números
			int Numero = 16832929;
			Console.WriteLine(Numero.ToString() + " es impar: " + EsImpar(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " es par: " + EsPar(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " total de cifras: " + TotalCifras(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " sus dos últimas cifras: " + RetornadosultimasCifras(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " su antepenúltima cifra: " + AntepenultimaCifra(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " su penúltima cifra: " + PenultimaCifra(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " su última cifra: " + UltimaCifra(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " la cifra más alta: " + LaCifraMasAlta(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " la cifra más baja: " + LaCifraMasBaja(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " total de cifras iguales a 5 es: " + Cifrashalladas(Numero, 5).ToString());
			Console.WriteLine(Numero.ToString() + " al invertirlo es: " + InvierteNumero(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " es palíndromo: " + EsPalindromo(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " tercera cifra es: " + CifraPosicion(Numero, 3).ToString());
			Console.WriteLine(Numero.ToString() + " primera cifra es: " + PrimeraCifra(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " la suma de las cifras es: " + SumaCifras(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " la suma de las cifras pares es: " + SumaCifrasPares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " la suma de las cifras impares es: " + SumaCifrasImpares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " la Multiplicación de las cifras es: " + MultiplicaCifras(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " la Multiplicación de las cifras pares es: " + MultiplicaCifrasPares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " la Multiplicación de las cifras impares es: " + MultiplicaCifrasImpares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " todas las cifras son pares: " + TodasCifrasPares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " todas las cifras son impares: " + TodasCifrasImpares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " total cifras pares: " + TotalCifrasPares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " total cifras impares: " + TotalCifrasImpares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " solo hay cifras menores o iguales a 5: " + SoloCifrasMenorIgual(Numero, 5).ToString());
			Console.WriteLine(Numero.ToString() + " solo hay cifras mayores o iguales a 5: " + SoloCifrasMayorIgual(Numero, 5).ToString());
			Console.WriteLine(Numero.ToString() + " usa distintas cifras: " + DistintasCifras(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " usa distintas cifras pares: " + DistintasCifrasPares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " usa distintas cifras impares: " + DistintasCifrasImPares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " extrayendo cifras pares: " + NumeroSoloPares(Numero).ToString());
			Console.WriteLine(Numero.ToString() + " extrayendo cifras impares: " + NumeroSoloImpares(Numero).ToString());
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
			int Copia = Numero;
			int Cuenta = 0;
			while (Copia != 0) {
				Cuenta++;
				Copia /= 10;
			}
			return Cuenta;
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
			int Copia = Numero;
			int Multiplica = (int)Math.Pow(10, TotalCifras(Copia) - 1);
			int Acumula = 0;
			while (Copia != 0) {
				int Cifra = Copia % 10;
				Acumula += Cifra * Multiplica;
				Multiplica /= 10;
				Copia /= 10;
			}
			return Acumula;
		}

		// Retorna true si el número es palíndromo
		static bool EsPalindromo(int Numero) {
			if (Numero == InvierteNumero(Numero)) return true;
			return false;
		}

		//Retorna la Cifra de una determinada posición
		static int CifraPosicion(int Numero, int Posicion) {
			int Copia = InvierteNumero(Numero);
			int Pos = 1;
			while (Copia != 0) {
				int Cifra = Copia % 10;
				if (Pos == Posicion) return Cifra;
				Copia /= 10;
				Pos++;
			}
			return 0;
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
			for (int Cifra = 0; Cifra <= 9; Cifra++) {
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
}
