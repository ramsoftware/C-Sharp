namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Instancia el evaluador
			Evaluador4 evaluador = new Evaluador4();

			//Una expresión con funciones 
			string Ecuacion = "sen(4.90+2.34)-cos(1.89)*tan(3)/abs(4-12)+asn(0.12)-acs(0-0.4)+atn(0.03)*log(1.3)+cei(3.4)+exp(2.8)-sqr(9)";
			evaluador.Analizar(Ecuacion);
			double valorY = evaluador.Evaluar();
			Console.WriteLine(valorY);
		}
	}
}