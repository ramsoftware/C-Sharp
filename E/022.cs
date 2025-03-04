namespace Ejemplo {

    //Datos del actor o actriz
    class ActorActriz {
        public string Nombre { get; set; }
        public string URLIMDB { get; set; }

        //Constructor
        public ActorActriz(string Nombre, string URLIMDB) {
            this.Nombre = Nombre;
            this.URLIMDB = "https://www.imdb.com/name/" + URLIMDB;
        }
    }

    //Datos de la serie de televisión
    class Serie {
        public string Nombre { get; set; }
        public string URLIMDB { get; set; }

        //Listado de actores y actrices que actúan en la serie
        public List<ActorActriz> Actor = [];

        //Constructor
        public Serie(string Nombre, string URLIMDB) {
            this.Nombre = Nombre;
            this.URLIMDB = "https://www.imdb.com/title/" + URLIMDB;
        }
    }

    //La parte que simula la capa de persistencia
    class Persistencia {
        List<ActorActriz> Actores;
        List<Serie> Series;

        //Carga datos de prueba
        public Persistencia() {
            Actores = [];
            Series = [];

            //Un listado de actores y actrices
            Actores.Add(new ActorActriz("Ana María Orozco", "nm0650450"));
            Actores.Add(new ActorActriz("Laura Londoño", "nm2256810"));
            Actores.Add(new ActorActriz("Carolina Ramírez", "nm1329835"));
            Actores.Add(new ActorActriz("Catherine Siachoque", "nm0796171"));
            Actores.Add(new ActorActriz("Carmenza González", "nm1863990"));
            Actores.Add(new ActorActriz("Andrés Londoño", "nm2150265"));

            //Un listado de series
            Series.Add(new Serie("Yo soy Betty, la fea", "tt0233127"));
            Series.Add(new Serie("La reina del flow", "tt8560918"));
            Series.Add(new Serie("Café con Aroma de Mujer", "tt14471346"));
            Series.Add(new Serie("Los Briceño", "tt10348478"));
            Series.Add(new Serie("Distrito Salvaje", "tt8105958"));
            Series.Add(new Serie("Mil Colmillos", "tt9701670"));
            Series.Add(new Serie("Perdida", "tt10064124"));

            //Añado actores y actrices a la tercera serie
            Series[2].Actor.Add(Actores[1]);

            //Observe que un mismo actor o actriz puede
            //estar en dos series distintas
            Series[0].Actor.Add(Actores[0]);
            Series[6].Actor.Add(Actores[0]);
        }

        //Trae datos de la serie
        public string SerieNombre(int pos) { return Series[pos].Nombre; }
        public string SerieIMDB(int pos) { return Series[pos].URLIMDB; }

        //Trae datos del actor
        public string ActorNombre(int pos) { return Actores[pos].Nombre; }
        public string ActorURL(int pos) { return Actores[pos].URLIMDB; }

        //Total de registros
        public int ActorTotal() { return Actores.Count; }
        public int SerieTotal() { return Series.Count; }

        //Adicionar actor
        public void ActorAdiciona(string Nombre, string URL) {
            Actores.Add(new ActorActriz(Nombre, URL));
        }

        //Editar actor
        public void ActorEdita(int codigo, string Nombre, string URL) {
            Actores[codigo].Nombre = Nombre;
            Actores[codigo].URLIMDB = URL;
        }

        //Borrar actor
        public void ActorBorra(int codigo) {
            Actores.RemoveAt(codigo);
        }

        //Retorna una lista de series donde el actor trabaja
        public List<string> ActorTrabaja(int codigo) {
            List<string> ListaSeries = [];
            for (int cont = 0; cont < Series.Count; cont++) {
                for (int num = 0; num < Series[cont].Actor.Count; num++) {
                    if (Actores[codigo] == Series[cont].Actor[num])
                        ListaSeries.Add(Series[cont].Nombre);
                }
            }
            return ListaSeries;
        }

        //Adicionar serie
        public void SerieAdiciona(string Nombre, string URL) {
            Series.Add(new Serie(Nombre, URL));
        }

        //Editar serie
        public void SerieEdita(int codigo, string Nombre, string URL) {
            Series[codigo].Nombre = Nombre;
            Series[codigo].URLIMDB = URL;
        }

        //Borrar serie
        public void SerieBorra(int codigo) {
            Series.RemoveAt(codigo);
        }

        //Retornar los actores que trabajan en la serie
        public List<string> SerieActores(int codigo) {
            List<ActorActriz> actores = Series[codigo].Actor;
            List<string> Nombres = [];
            for (int cont = 0; cont < actores.Count; cont++)
                Nombres.Add(actores[cont].Nombre);
            return Nombres;
        }

        //Añade un actor a una serie
        public void SerieAsocia(int serie, int actor) {
            Series[serie].Actor.Add(Actores[actor]);
        }

        //Quita un actor de una serie
        public void SerieDisocia(int serie, int actor) {
            Series[serie].Actor.RemoveAt(actor);
        }
    }

    //La parte visual del programa
    class Visual {
        public Persistencia Datos;

        //Conecta con la capa de persistencia
        public Visual(Persistencia objDatos) {
            Datos = objDatos;
        }

        //Menú principal
        public void Menu() {
            int opcion;
            do {
                Console.Clear();
                Console.WriteLine("\nSoftware TV Show 1.6 (Marzo de 2025)");
                Console.WriteLine("1. CRUD de actores y actrices");
                Console.WriteLine("2. CRUD de series");
                Console.WriteLine("3. Salir");
                Console.Write("¿Opción? ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion) {
                    case 1: CRUDactores(); break;
                    case 2: CRUDseries(); break;
                }
            } while (opcion != 3);
        }

        //Menú de actores y actrices
        public void CRUDactores() {
            int opcion;
            do {
                Console.Clear();
                Console.WriteLine("\nSoftware TV Show. Actores/Actrices");
                for (int cont = 0; cont < Datos.ActorTotal(); cont++) {
                    Console.Write("[" + cont + "] ");
                    Console.Write(Datos.ActorNombre(cont));
                    Console.WriteLine(" URL: " + Datos.ActorURL(cont));
                }
                Console.WriteLine(" \n1. Adicionar");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Borrar");
                Console.WriteLine("4. ¿En cuáles series trabaja?");
                Console.WriteLine("5. Volver a menú principal");
                Console.Write("¿Opción? ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion) {
                    case 1: ActorAdiciona(); break;
                    case 2: ActorEdita(); break;
                    case 3: ActorBorra(); break;
                    case 4: ActorTrabaja(); break;
                }
            } while (opcion != 5);
        }

        //Menú de series de TV
        public void CRUDseries() {
            int opcion;
            do {
                Console.Clear();
                Console.WriteLine("\nSoftware TV Show. Series");
                for (int cont = 0; cont < Datos.SerieTotal(); cont++) {
                    Console.Write("[" + cont + "] ");
                    Console.Write(Datos.SerieNombre(cont));
                    Console.WriteLine(" URL: " + Datos.SerieIMDB(cont));
                }
                Console.WriteLine("\n1. Adicionar");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Borrar");
                Console.WriteLine("4. Detalles de la serie");
                Console.WriteLine("5. Asociar actor a serie");
                Console.WriteLine("6. Disociar actor a serie");
                Console.WriteLine("7. Volver a menú principal");
                Console.Write("¿Opción? ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion) {
                    case 1: SerieAdiciona(); break;
                    case 2: SerieEdita(); break;
                    case 3: SerieBorra(); break;
                    case 4: SerieDetalle(); break;
                    case 5: SerieAsocia(); break;
                    case 6: SerieDisocia(); break;
                }
            } while (opcion != 7);
        }

        //Pantalla para adicionar actores
        public void ActorAdiciona() {
            Console.WriteLine("\tAdicionar actor al listado");
            Console.Write("¿Nombre? ");
            string nombre = Console.ReadLine();
            Console.Write("¿URL de IMDB? ");
            string URL = Console.ReadLine();
            Datos.ActorAdiciona(nombre, URL);
            Console.WriteLine("\nActor adicionado.");
            Console.ReadKey();
        }

        //Pantalla para editar actores
        public void ActorEdita() {
            Console.WriteLine("\tEditar actor");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Nombre? ");
            string nombre = Console.ReadLine();
            Console.Write("¿URL de IMDB? ");
            string URL = Console.ReadLine();
            Datos.ActorEdita(codigo, nombre, URL);
            Console.WriteLine("\nActor editado.");
            Console.ReadKey();
        }

        //Pantalla para borrar actores
        public void ActorBorra() {
            Console.WriteLine("\tBorrar actor o actriz");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Datos.ActorBorra(codigo);
            Console.WriteLine("\nActor borrado.");
            Console.ReadKey();
        }

        //Pantalla para mostrar en que series trabaja el actor
        public void ActorTrabaja() {
            List<string> ListaSeries;
            Console.WriteLine("\tListar series donde actúa");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            ListaSeries = Datos.ActorTrabaja(codigo);
            for (int cont = 0; cont < ListaSeries.Count; cont++)
                Console.WriteLine(ListaSeries[cont]);
            Console.WriteLine("\nPresione");
            Console.ReadKey();
        }

        //Pantalla para adicionar series
        public void SerieAdiciona() {
            Console.WriteLine("\tAdicionar serie al listado");
            Console.Write("¿Nombre? ");
            string nombre = Console.ReadLine();
            Console.Write("¿URL en IMDB? ");
            string url = Console.ReadLine();
            Datos.SerieAdiciona(nombre, url);
            Console.WriteLine("\nSerie adicionada.");
            Console.ReadKey();
        }

        //Pantalla para editar series
        public void SerieEdita() {
            Console.WriteLine("\tEditar serie");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Nombre? ");
            string nombre = Console.ReadLine();
            Console.Write("¿URL en IMDB? ");
            string url = Console.ReadLine();
            Datos.SerieEdita(codigo, nombre, url);
            Console.WriteLine("\nSerie editada.");
            Console.ReadKey();
        }

        //Pantalla para borrar series
        public void SerieBorra() {
            Console.WriteLine("\tBorrar serie");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Datos.SerieBorra(codigo);
            Console.WriteLine("\nSerie borrada.");
            Console.ReadKey();
        }

        //Pantalla para ver el detalle de la serie
        public void SerieDetalle() {
            List<string> ListaActores;

            Console.WriteLine("\t === Detalle de una serie ===");
            Console.Write("¿Cuál? Número[ ]: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nombre: " + Datos.SerieNombre(codigo));
            Console.WriteLine("URL: " + Datos.SerieIMDB(codigo));
            Console.WriteLine("Actores");
            ListaActores = Datos.SerieActores(codigo);
            for (int cont = 0; cont < ListaActores.Count; cont++)
                Console.WriteLine("\t" + ListaActores[cont]);

            Console.WriteLine("\nENTER para continuar");
            Console.ReadKey();
        }

        //Asociar actor o actriz a una serie
        public void SerieAsocia() {
            Console.WriteLine("\tAsocia un actor o actriz a una serie");
            Console.Write("¿Cuál serie? Número[ ]: ");
            int serie = Convert.ToInt32(Console.ReadLine());
            for (int cont = 0; cont < Datos.ActorTotal(); cont++) {
                Console.Write("[" + cont + "] ");
                Console.Write(Datos.ActorNombre(cont));
                Console.WriteLine(" URL: " + Datos.ActorURL(cont));
            }
            Console.Write("¿Cuál Actor? Número[ ]: ");
            int actor = Convert.ToInt32(Console.ReadLine());
            Datos.SerieAsocia(serie, actor);
            Console.WriteLine("\nActor asociado a la serie.");
            Console.ReadKey();
        }

        //Pantalla para disociar actor de alguna serie
        public void SerieDisocia() {
            List<string> ListaActores;

            Console.WriteLine("\t === Disociar actor de la serie ===");
            Console.Write("¿Cuál serie? Número[ ]: ");
            int serie = Convert.ToInt32(Console.ReadLine());

            ListaActores = Datos.SerieActores(serie);
            for (int cont = 0; cont < ListaActores.Count; cont++)
                Console.WriteLine("[" + cont + "] " + ListaActores[cont]);

            Console.Write("¿Cuál actor quiere quitar? Número[ ]: ");
            int actor = Convert.ToInt32(Console.ReadLine());

            Datos.SerieDisocia(serie, actor);
            Console.WriteLine("\nActor retirado de la serie.");
            Console.ReadKey();
        }

    }

    class Program {
        static void Main() {
            //Se debe llamar primero la capa de persistencia
            //(carga datos de ejemplo)
            Persistencia objDatos = new();

            //Luego se llama la capa visual
            Visual objVisual = new(objDatos);
            objVisual.Menu();
        }
    }
}