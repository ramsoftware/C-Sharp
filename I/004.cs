namespace Ejemplo {
	internal class Program {
		static void Main(string[] args) {

			List<double> Numeros = new List<double>();

			//Generador congruencial lineal
			long X0, A, B, Ndiv;

			//Valores de inicio. Se los da el usuario.
			X0 = 7302; //debe ser menor de Ndiv
			A = 5278;
			B = 3435;
			Ndiv = 20000;

			for (int contador = 1; contador <= 2000; contador++) {
				X0 = (A * X0 + B) % Ndiv;
				double r = (double)X0 / Ndiv;
				Numeros.Add(r);
			}

			//=====================
			//Prueba de promedio
			//=====================
			double Acumula = 0;
			for (int cont = 0; cont < Numeros.Count; cont++) {
				Acumula += Numeros[cont];
			}
			double Promedio = (double)Acumula / Numeros.Count;
			Console.WriteLine("Promedio es: {0:0.00000} y debe ser similar a 0,5", Promedio);

			//=====================
			//Prueba de varianza
			//=====================
			double Sumatoria = 0;
			for (int cont = 0; cont < Numeros.Count; cont++) {
				Sumatoria += (Numeros[cont] - Promedio) * (Numeros[cont] - Promedio);
			}
			double Varianza = Sumatoria / Numeros.Count;
			Console.WriteLine("Promedio es: {0:0.00000} y debe ser similar a {1:0.00000}", Varianza, (1.0 / 12.0));

			//=====================
			//Prueba de Uniformidad
			//=====================
			int[] Rango = new int[10];
			for (int cont = 0; cont < Numeros.Count; cont++) {
				if (Numeros[cont] < 0.1) Rango[0]++;
				else if (Numeros[cont] < 0.2) Rango[1]++;
				else if (Numeros[cont] < 0.3) Rango[2]++;
				else if (Numeros[cont] < 0.4) Rango[3]++;
				else if (Numeros[cont] < 0.5) Rango[4]++;
				else if (Numeros[cont] < 0.6) Rango[5]++;
				else if (Numeros[cont] < 0.7) Rango[6]++;
				else if (Numeros[cont] < 0.8) Rango[7]++;
				else if (Numeros[cont] < 0.9) Rango[8]++;
				else Rango[9]++;
			}

			Console.WriteLine("\n\nPrueba de Uniformidad");
			Console.WriteLine("Números por rango");
			Console.WriteLine(" Rango\t\tFrecuencia Obtenida Fo\tFrecuencia Esperada Fe\t((Fe-Fo)^2)/Fe");

			double FrecuenciaEsperada = Numeros.Count / 10;
			double SumaRango = 0;
			for (int cont = 0; cont < Rango.Length; cont++) {
				double Minimo = cont / 10.0;
				double Maximo = (cont + 1) / 10.0;
				double Diferencia = (double)(FrecuenciaEsperada - Rango[cont]) * (FrecuenciaEsperada - Rango[cont]) / FrecuenciaEsperada;
				Console.WriteLine(" {0:0.0} y {1:0.0}\t\t{2:#}\t\t\t{3:#}\t\t{4:0.00000}", Minimo, Maximo, Rango[cont], FrecuenciaEsperada, Diferencia);
				SumaRango += Diferencia;
			}

			if (SumaRango < 16.9)
				Console.WriteLine("Pasa la prueba de uniformidad porque " + SumaRango.ToString() + " debe ser menor a 16,9");
			else
				Console.WriteLine("NO aprobó la prueba de uniformidad porque " + SumaRango.ToString() + " fue mayor o igual a 16,9");


			//===========================================
			//Prueba de Uniformidad de Kolmogorov-Smirnov
			//===========================================
			double[] ProbabilidadAcumula = new double[10];
			ProbabilidadAcumula[0] = (double)Rango[0] / Numeros.Count;
			for (int cont = 1; cont < Rango.Length; cont++) {
				ProbabilidadAcumula[cont] = (double)ProbabilidadAcumula[cont - 1] + (double)Rango[cont] / Numeros.Count;
			}

			Console.WriteLine("\n\nPrueba de Uniformidad de Kolmogorov-Smirnov");
			Console.WriteLine("Probabilidad acumulada");
			Console.WriteLine(" Rango\t\t\tEsperada\tObtenida\tDiferencia");
			double MaximaDiferencia = 0;
			for (int cont = 0; cont < ProbabilidadAcumula.Length; cont++) {
				double Minimo = cont / 10.0;
				double Maximo = (cont + 1) / 10.0;
				double Espera = (double)(cont + 1) / 10;
				double Diferencia = Math.Abs(ProbabilidadAcumula[cont] - Espera);
				if (Diferencia > MaximaDiferencia) MaximaDiferencia = Diferencia;
				Console.WriteLine(" {0:0.0} y {1:0.0}\t\t{2:0.00000}\t\t{3:0.00000}\t\t{4:0.00000}", Minimo, Maximo, Espera, ProbabilidadAcumula[cont], Diferencia);
			}

			double Compara = 1.36 / Math.Sqrt(Numeros.Count);
			if (MaximaDiferencia < Compara)
				Console.WriteLine("Pasa la prueba de uniformidad porque " + MaximaDiferencia.ToString() + " < " + Compara.ToString());
			else
				Console.WriteLine("NO aprobó la prueba de uniformidad porque " + MaximaDiferencia.ToString() + " >= " + Compara.ToString());

			//===========================================
			// Prueba de Independencia - Wald-Wolfowitz
			//===========================================
			Console.WriteLine("\n\nPrueba de Independencia - Wald-Wolfowitz");

			//Deduce el valor de R, N1, N2, N
			double N1 = 0, N2 = 0, R = 0;
			int Bloque = 0;
			for (int cont = 0; cont < Numeros.Count; cont++) {
				if (Numeros[cont] < Promedio) {
					if (Bloque != 1) R++;
					Bloque = 1;
					N1++;
				}
				else {
					if (Bloque != 2) R++;
					Bloque = 2;
					N2++;
				}
			}

			double N = Numeros.Count;

			Console.WriteLine("N = " + N);
			Console.WriteLine("N1 = " + N1);
			Console.WriteLine("N2 = " + N2);
			Console.WriteLine("R = " + R);

			//Deduce la media
			double Media = (2 * N1 * N2) / (N + 1);
			double Variar = (Media - 1) * (Media - 2) / (N - 1);
			double Z = (R - Media) / Math.Sqrt(Variar);

			Console.WriteLine("Media = " + Media);
			Console.WriteLine("Variación = " + Variar);
			Console.WriteLine("Z = " + Z);

			if (Z >= -1.96 && Z <= 1.96)
				Console.WriteLine("Pasa la prueba de independencia porque Z está entre -1,96 y 1,96");
			else
				Console.WriteLine("NO pasó la prueba de independencia porque Z está fuera del rango de -1,96 y 1,96");
		}
	}
}
