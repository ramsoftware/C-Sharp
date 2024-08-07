﻿using System.Globalization;

namespace Ejemplo {
	internal class DatosArchivo {
		//Los datos seleccionados para 
		//encontrar patrón de comportamiento
		public List<double> Xentrada;
		public List<double> Ysalidas;

		//Los datos normalizados para la red neuronal
		public List<double> XentradaN;
		public List<double> YsalidasN;

		//Lee los valores X y Y.
		public void LeeXYdeCSV(string urlArchivo) {
			//Empieza a leer el archivo
			var Archivo = new StreamReader(urlArchivo);

			//Inicializa las listas
			Xentrada = [];
			Ysalidas = [];
			XentradaN = [];
			YsalidasN = [];

			//Lee la linea de los dos datos numéricos
			string LineaDato;
			double valX, valY;
			while ((LineaDato = Archivo.ReadLine()) != null) {
				int Coma = LineaDato.IndexOf(',');
				string Xc = LineaDato[..Coma];
				string Yc = LineaDato[(Coma + 1)..];
				valX = double.Parse(Xc, CultureInfo.InvariantCulture);
				valY = double.Parse(Yc, CultureInfo.InvariantCulture);
				Xentrada.Add(valX);
				Ysalidas.Add(valY);
			}

			//Normaliza los datos para la red neuronal
			double MaximoX = Xentrada.Max();
			double MinimoX = Xentrada.Min();
			double MaximoY = Ysalidas.Max();
			double MinimoY = Ysalidas.Min();
			double Dividir = MaximoX - MinimoX;
			for (int Cont = 0; Cont < Xentrada.Count; Cont++) {
				XentradaN.Add((Xentrada[Cont] - MinimoX) / Dividir);
				YsalidasN.Add((Ysalidas[Cont] - MinimoY) / Dividir);
			}
		}
	}
}
