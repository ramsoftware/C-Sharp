namespace Ejemplo {
    internal class Mascota {
        public string Especie { get; set; }
        public string Nombre { get; set; }
        public Mascota(string Especie, string Nombre) {
            this.Especie = Especie;
            this.Nombre = Nombre;
        }
    }

    internal class Program {
        static void Main() {
            //Fuente de datos, una lista
            List<Mascota> listaMascotas =
            [
                new Mascota("gato", "Suini"),
                new Mascota("gato", "Gris"),
                new Mascota("gato", "Sally"),
                new Mascota("gato", "Tinita"),
                new Mascota("conejo", "Krousky"),
                new Mascota("gato", "Capuchina"),
                new Mascota("gato", "Tammy"),
                new Mascota("gato", "Grisú"),
                new Mascota("ave", "Lua"),
                new Mascota("conejo", "Copo"),
                new Mascota("gato", "Vikingo"),
                new Mascota("gato", "Arian"),
                new Mascota("gato", "Milú"),
                new Mascota("ave", "Azulin"),
                new Mascota("gato", "Frac"),
                new Mascota("ave", "Negro"),
                new Mascota("conejo", "Clopa"),
            ];

            var ConjuntoGrupos = from animal in listaMascotas
                                 group animal by animal.Especie;

            //Itera por grupo, cada grupo tiene una llave
            foreach (var grupo in ConjuntoGrupos) {
                Console.WriteLine("\r\nGrupo: " + grupo.Key);

                // Cada grupo tiene una colección interna
                foreach (Mascota individuo in grupo)
                    Console.WriteLine("Nombre: " + individuo.Nombre);
            }
        }
    }
}