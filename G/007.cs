namespace Ejemplo {
	internal class Program {
		static void Main() {
			string[] exprAlgebraica = new string[] { 
				"2q-(*3)", //0
				"7-2(5-6)", //1
				"3..1", //2
				"3.*1", //3
				"3+5.w-8", //4
				"2-5.(4+1)*3", //5
				"2-(5.)*3", //6
				"2-(4+.1)-7", //7
				"5-*3", //8
				"2-(4+)-7", //9
				"7-a2-6", //10
				"7-a.4*3", //11
				"7-qw*9", //12
				"2-u(7-3)", //13
				"7-(.8+4)-6", //14
				"(+3-5)*7", //15
				"4+()*2", //16
				"(3-5)8", //17
				"(3-5).+2", //18
				"2-(7*3)k+7", //19
				"(4-3)(2+1)", //20
				"*3+5", //21
				"3*5*", //22
				"9*4)+(2-6", //23
				"((2+4)", //24
				"2.71*3.56.01" }; //25

			Evaluador4 evaluador = new Evaluador4();

			for (int num = 0; num < exprAlgebraica.Length; num++) {
				Console.WriteLine("\r\nExpresión " + num + ": " + exprAlgebraica[num]);
				int ErrorSintaxis = evaluador.Analizar(exprAlgebraica[num]);
				if (ErrorSintaxis >= 0) {
					Console.WriteLine(evaluador.MensajeError(ErrorSintaxis));
				}
			}
		}
	}
}
