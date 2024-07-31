namespace ArbolBinarioEvaluador {
	
	//Genera una ecuación al azar para que sea
	//evaluada
	internal class EcuacionAzar {
		Random azar;

		public EcuacionAzar() {
			azar = new Random();
		}

		public string Ecuacion(int longitud) {
			int TamanoEcuacion = 0;
			int numParentesisAbre = 0;

			string ecuacion = "";
			while (TamanoEcuacion < longitud) {

				if (azar.NextDouble() > 0.5) {
					if (azar.NextDouble() < 0.5) {
						ecuacion += FuncionAzar() + "(";
					}
					else {
						ecuacion += "(";
					}
					numParentesisAbre++;
					TamanoEcuacion++;
				}

				//Variable o número
				if (azar.NextDouble() < 0.5)
					ecuacion += NumeroAzar();
				else
					ecuacion += "x";
				TamanoEcuacion++;

				//Paréntesis que cierra
				int numParentesisCierra = azar.Next(numParentesisAbre + 1);
				for (int num = 1; num <= numParentesisCierra; num++) {
					ecuacion += ")";
					numParentesisAbre--;
					TamanoEcuacion++;
				}

				//Operador
				TamanoEcuacion++;
				ecuacion += OperadorAzar();
			}

			//Variable o número
			if (azar.NextDouble() < 0.5)
				ecuacion += NumeroAzar();
			else
				ecuacion += "x";

			//Cierra los paréntesis
			for (int num = 0; num < numParentesisAbre; num++) ecuacion += ")";

			return ecuacion;
		}

		private string FuncionAzar() {
			string[] funciones = { "sen", "cos", "tan", "abs", "asn", "acs", "atn", "log", "exp", "sqr" };
			return funciones[azar.Next(funciones.Length)];
		}

		private string OperadorAzar() {
			string[] operadores = { "+", "-", "*", "/" };
			return operadores[azar.Next(operadores.Length)];
		}

		private string NumeroAzar() {
			string undecimal = Convert.ToString(azar.Next(100) + 1);
			return "1." + undecimal;
		}
	}
}

