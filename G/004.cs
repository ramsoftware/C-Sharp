namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Instancia el evaluador
			Evaluador4 evaluador = new();

			//Una expresión con funciones 
			string Ecuacion = "sen(4.90+2.34)-cos(1.89)";
			Ecuacion += "*tan(3)/abs(4-12)+asn(0.12)";
			Ecuacion += "-acs(0-0.4)+atn(0.03)*log(1.3)";
			Ecuacion += "+cei(3.4)+exp(2.8)-sqr(9)";
			evaluador.Analizar(Ecuacion);
			double valorY = evaluador.Evaluar();
			Console.WriteLine(valorY);
		}
	}
}