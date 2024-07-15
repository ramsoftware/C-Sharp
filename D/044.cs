namespace Ejemplo {
	//Patrón de diseño: Adapter

	public interface IEjecutorMultimedia {
		void Ejecutar(string TipoAudio, string NombreArchivo);
	}

	public interface IEjecutorAvanzadoArchivosMultimedia {
		void EjecutaVLC(string NombreArchivo);
		void EjecutaMP4(string NombreArchivo);
	}

	class EjecutorVLC : IEjecutorAvanzadoArchivosMultimedia {
		public void EjecutaVLC(string NombreArchivo) {
			Console.WriteLine("Ejecutando VLC: " + NombreArchivo);
		}
		public void EjecutaMP4(string NombreArchivo) {
		}
	}

	class EjecutorMP4 : IEjecutorAvanzadoArchivosMultimedia {
		public void EjecutaVLC(string NombreArchivo) {
		}
		public void EjecutaMP4(string NombreArchivo) {
			Console.WriteLine("Ejecutando MP4: " + NombreArchivo);
		}
	}

	class AdaptadorMultimedia : IEjecutorMultimedia {
		IEjecutorAvanzadoArchivosMultimedia ejecutorAvanzado;

		//Constructor
		public AdaptadorMultimedia(string TipoAudio) {
			if (TipoAudio.Equals("vlc")) {
				ejecutorAvanzado = new EjecutorVLC();
			}
			if (TipoAudio.Equals("mp4")) {
				ejecutorAvanzado = new EjecutorMP4();
			}
		}

		//Dependiendo del tipo de audio llama a VLC o MP4
		public void Ejecutar(string TipoAudio, string NombreArchivo) {
			if (TipoAudio.Equals("vlc")) {
				ejecutorAvanzado.EjecutaVLC(NombreArchivo);
			}
			else if (TipoAudio.Equals("mp4")) {
				ejecutorAvanzado.EjecutaMP4(NombreArchivo);
			}
		}
	}

	class EjecutorAudio : IEjecutorMultimedia {

		AdaptadorMultimedia adaptadorMultimedia;

		public void Ejecutar(string TipoAudio, string NombreArchivo) {
			//Archivos MP3
			if (TipoAudio.Equals("mp3")) {
				Console.WriteLine("Ejecutando MP3: " + NombreArchivo);
			} //Otros formatos
			else if (TipoAudio.Equals("vlc") || TipoAudio.Equals("mp4")) {
				adaptadorMultimedia = new AdaptadorMultimedia(TipoAudio);
				adaptadorMultimedia.Ejecutar(TipoAudio, NombreArchivo);
			}
			else {
				Console.Write("Medio inválido. (" + TipoAudio);
				Console.WriteLine(") es un formato no soportado");
			}
		}
	}

	class Program {
		static void Main() {
			EjecutorAudio Multimedia = new EjecutorAudio();

			Multimedia.Ejecutar("mp3", "MiMusica.mp3");
			Multimedia.Ejecutar("mp4", "unSonido.mp4");
			Multimedia.Ejecutar("vlc", "FondoMusical.vlc");
			Multimedia.Ejecutar("avi", "unAudio.avi");
		}
	}
}
