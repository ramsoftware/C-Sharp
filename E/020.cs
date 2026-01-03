namespace Ejemplo;


//Datos del actor o actriz
class ActorActriz {
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string URLIMDB { get; set; }

    //Constructor
    public ActorActriz(int Codigo, string Nombre, string URLIMDB) {
        this.Codigo = Codigo;
        this.Nombre = Nombre;
        this.URLIMDB = "https://www.imdb.com/name/" + URLIMDB;
    }
}

//Datos de la serie de televisión
class Serie {
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string URLIMDB { get; set; }

    //Listado de códigos de actores que actúan en la serie
    public List<int> Actor = [];

    //Constructor
    public Serie(int Codigo, string Nombre, string URLIMDB) {
        this.Codigo = Codigo;
        this.Nombre = Nombre;
        this.URLIMDB = "https://www.imdb.com/title/" + URLIMDB;
    }
}

//La parte que simula la capa de persistencia
class Persistencia {
    public List<ActorActriz> Actores;
    public List<Serie> Series;

    //Carga datos de prueba
    public Persistencia() {
        Actores = [];
        Series = [];

        //Un listado de actores y actrices
        ActorAdiciona(78, "Ana María Orozco", "nm0650450");
        ActorAdiciona(81, "Laura Londoño", "nm2256810");
        ActorAdiciona(84, "Carolina Ramírez", "nm1329835");
        ActorAdiciona(93, "Catherine Siachoque", "nm0796171");
        ActorAdiciona(98, "Carmenza González", "nm1863990");
        ActorAdiciona(99, "Andrés Londoño", "nm2150265");

        //Un listado de series
        Series.Add(new Serie(16, "Yo soy Betty, la fea", "tt0233127"));
        Series.Add(new Serie(43, "La reina del flow", "tt8560918"));
        Series.Add(new Serie(60, "Café con Aroma de Mujer", "tt14471346"));
        Series.Add(new Serie(62, "Los Briceño", "tt10348478"));
        Series.Add(new Serie(70, "Distrito Salvaje", "tt8105958"));
        Series.Add(new Serie(72, "Mil Colmillos", "tt9701670"));
        Series.Add(new Serie(83, "Perdida", "tt10064124"));

        //Obsérvese que un mismo actor o actriz puede
        //estar en dos series distintas
        Series[0].Actor.Add(78);
        Series[0].Actor.Add(93);
        Series[0].Actor.Add(98);
        Series[6].Actor.Add(78);
        Series[4].Actor.Add(78);
    }

    //Adicionar actor
    public bool ActorAdiciona(int Codigo, string Nombre, string URL) {
        for (int Cont = 0; Cont < Actores.Count; Cont++) {
            if (Actores[Cont].Codigo == Codigo)
                return false;
        }
        Actores.Add(new ActorActriz(Codigo, Nombre, URL));
        return true;
    }

    //Editar actor
    public bool ActorEdita(int CodigoActor, string Nombre, string URL) {
        for (int Cont = 0; Cont < Actores.Count; Cont++) {
            if (Actores[Cont].Codigo == CodigoActor) {
                Actores[Cont].Nombre = Nombre;
                Actores[Cont].URLIMDB = URL;
                return true;
            }
        }
        return false;
    }

    //Chequea si el actor está trabajando en alguna serie
    public bool ActorEnSerie(int CodigoActor) {
        for (int Cont = 0; Cont < Series.Count; Cont++)
            for (int Num = 0; Num < Series[Cont].Actor.Count; Num++)
                if (Series[Cont].Actor[Num] == CodigoActor)
                    return true;
        return false;
    }

    //Borrar actor, si y solo si no está trabajando en alguna serie
    public bool ActorBorra(int CodigoActor) {
        if (ActorEnSerie(CodigoActor) == false) {
            for (int Cont = 0; Cont < Actores.Count; Cont++)
                if (Actores[Cont].Codigo == CodigoActor) {
                    Actores.RemoveAt(Cont);
                    return true;
                }
        }
        return false;
    }

    //Dado el código, retorna el nombre del actor/actriz
    public string NombreActor(int CodigoActor) {
        for (int cont = 0; cont < Actores.Count; cont++) {
            if (Actores[cont].Codigo == CodigoActor)
                return Actores[cont].Nombre;
        }
        return "N/A";
    }

    //Retorna una lista de series donde el actor trabaja
    public List<string> ActorTrabaja(int CodigoActor) {
        List<string> ListaSeries = [];
        for (int cont = 0; cont < Series.Count; cont++) {
            for (int num = 0; num < Series[cont].Actor.Count; num++) {
                if (Series[cont].Actor[num] == CodigoActor)
                    ListaSeries.Add(Series[cont].Nombre);
            }
        }
        return ListaSeries;
    }

    //Adicionar serie
    public bool SerieAdiciona(int CodigoSerie, string Nombre, string URL) {
        for (int Cont = 0; Cont < Series.Count; Cont++) {
            if (Series[Cont].Codigo == CodigoSerie)
                return false;
        }
        Series.Add(new Serie(CodigoSerie, Nombre, URL));
        return true;
    }

    //Editar serie
    public bool SerieEdita(int CodigoSerie, string Nombre, string URL) {
        for (int Cont = 0; Cont < Series.Count; Cont++) {
            if (Series[Cont].Codigo == CodigoSerie) {
                Series[Cont].Nombre = Nombre;
                Series[Cont].URLIMDB = URL;
                return true;
            }
        }
        return false;
    }

    //Borrar serie
    public bool SerieBorra(int CodigoSerie) {
        for (int Cont = 0; Cont < Series.Count; Cont++)
            if (Series[Cont].Codigo == CodigoSerie) {
                Series.RemoveAt(Cont);
                return true;
            }
        return false;
    }


    //Retornar los actores que trabajan en la serie
    public List<string> SerieActores(int CodigoSerie) {
        int Pos = PosSerie(CodigoSerie);
        List<string> Nombres = [];
        for (int Cont = 0; Cont < Series[Pos].Actor.Count; Cont++)
            Nombres.Add("[" + Series[Pos].Actor[Cont] + "] " + NombreActor(Series[Pos].Actor[Cont]));
        return Nombres;
    }

    //Añade un actor a una serie
    public bool SerieAsocia(int CodigoSerie, int CodigoActor) {
        int PosSerial = PosSerie(CodigoSerie);
        if (PosSerial >= 0) {
            if (Series[PosSerial].Actor.Contains(CodigoActor) == false) {
                Series[PosSerial].Actor.Add(CodigoActor);
                return true;
            }
            else
                return false;
        }
        return false;
    }

    //Quita un actor de una serie
    public bool SerieDisocia(int CodigoSerie, int CodigoActor) {
        int PosSerial = PosSerie(CodigoSerie);
        if (PosSerial >= 0) {
            if (Series[PosSerial].Actor.Contains(CodigoActor) == true) {
                Series[PosSerial].Actor.Remove(CodigoActor);
                return true;
            }
            else
                return false;
        }
        return false;
    }

    //Dado el código de la serie, retorna su posición
    public int PosSerie(int CodigoSerie) {
        for (int Cont = 0; Cont < Series.Count; Cont++)
            if (Series[Cont].Codigo == CodigoSerie) {
                return Cont;
            }
        return -1;
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
        int Opcion;
        do {
            Console.Clear();
            Console.WriteLine("\nSoftware TV Show 1.7 (Marzo de 2025)");
            Console.WriteLine("1. CRUD de actores y actrices");
            Console.WriteLine("2. CRUD de series");
            Console.WriteLine("3. Salir");
            Console.Write("¿Opción? ");
            Opcion = Convert.ToInt32(Console.ReadLine());
            switch (Opcion) {
                case 1: CRUDactores(); break;
                case 2: CRUDseries(); break;
            }
        } while (Opcion != 3);
    }

    //Menú de actores y actrices
    public void CRUDactores() {
        int Opcion;
        do {
            Console.Clear();
            Console.WriteLine("\nSoftware TV Show. Actores/Actrices");
            for (int Cont = 0; Cont < Datos.Actores.Count; Cont++) {
                Console.Write("[" + Datos.Actores[Cont].Codigo + "] ");
                Console.Write(Datos.Actores[Cont].Nombre);
                Console.WriteLine(" URL: " + Datos.Actores[Cont].URLIMDB);
            }
            Console.WriteLine(" \n1. Adicionar");
            Console.WriteLine("2. Editar");
            Console.WriteLine("3. Borrar");
            Console.WriteLine("4. ¿En cuáles series trabaja?");
            Console.WriteLine("5. Volver a menú principal");
            Console.Write("¿Opción? ");
            Opcion = Convert.ToInt32(Console.ReadLine());
            switch (Opcion) {
                case 1: ActorAdiciona(); break;
                case 2: ActorEdita(); break;
                case 3: ActorBorra(); break;
                case 4: ActorTrabaja(); break;
            }
        } while (Opcion != 5);
    }

    //Menú de series de TV
    public void CRUDseries() {
        int Opcion;
        do {
            Console.Clear();
            Console.WriteLine("\nSoftware TV Show. Series");
            for (int Cont = 0; Cont < Datos.Series.Count; Cont++) {
                Console.Write("[" + Datos.Series[Cont].Codigo + "] ");
                Console.Write(Datos.Series[Cont].Nombre);
                Console.WriteLine(" URL: " + Datos.Series[Cont].URLIMDB);
            }
            Console.WriteLine("\n1. Adicionar");
            Console.WriteLine("2. Editar");
            Console.WriteLine("3. Borrar");
            Console.WriteLine("4. Detalles de la serie");
            Console.WriteLine("5. Asociar actor a serie");
            Console.WriteLine("6. Disociar actor a serie");
            Console.WriteLine("7. Volver a menú principal");
            Console.Write("¿Opción? ");
            Opcion = Convert.ToInt32(Console.ReadLine());
            switch (Opcion) {
                case 1: SerieAdiciona(); break;
                case 2: SerieEdita(); break;
                case 3: SerieBorra(); break;
                case 4: SerieDetalle(); break;
                case 5: SerieAsocia(); break;
                case 6: SerieDisocia(); break;
            }
        } while (Opcion != 7);
    }

    //Pantalla para adicionar actores
    public void ActorAdiciona() {
        Console.WriteLine("\tAdicionar actor al listado");
        Console.Write("¿Código? ");
        int CodigoActor = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Nombre? ");
        string Nombre = Console.ReadLine();
        Console.Write("¿URL de IMDB? ");
        string URL = Console.ReadLine();
        if (Datos.ActorAdiciona(CodigoActor, Nombre, URL))
            Console.WriteLine("\nActor adicionado.");
        else
            Console.WriteLine("\nError al adicionar el actor. El código ya existe.");
        Console.ReadKey();
    }

    //Pantalla para editar actores
    public void ActorEdita() {
        Console.WriteLine("\tEditar actor");
        Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
        int CodigoActor = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Nombre? ");
        string Nombre = Console.ReadLine();
        Console.Write("¿URL de IMDB? ");
        string URL = Console.ReadLine();
        if (Datos.ActorEdita(CodigoActor, Nombre, URL))
            Console.WriteLine("\nActor editado.");
        else
            Console.WriteLine("\nError al editar el actor");
        Console.ReadKey();
    }

    //Pantalla para borrar actores
    public void ActorBorra() {
        Console.WriteLine("\tBorrar actor o actriz");
        Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
        int CodigoActor = Convert.ToInt32(Console.ReadLine());
        if (Datos.ActorBorra(CodigoActor))
            Console.WriteLine("\nActor borrado.");
        else
            Console.WriteLine("\nError al borrar el actor. Código erróneo o el actor trabaja en series.");
        Console.ReadKey();
    }

    //Pantalla para mostrar en que series trabaja el actor
    public void ActorTrabaja() {
        List<string> ListaSeries;
        Console.WriteLine("\tListar series donde actúa");
        Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
        int CodigoActor = Convert.ToInt32(Console.ReadLine());
        ListaSeries = Datos.ActorTrabaja(CodigoActor);
        for (int Cont = 0; Cont < ListaSeries.Count; Cont++)
            Console.WriteLine(ListaSeries[Cont]);
        Console.WriteLine("\nPresione");
        Console.ReadKey();
    }

    //Pantalla para adicionar series
    public void SerieAdiciona() {
        Console.WriteLine("\tAdicionar serie al listado");
        Console.Write("¿Código? ");
        int codigo = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Nombre? ");
        string nombre = Console.ReadLine();
        Console.Write("¿URL en IMDB? ");
        string url = Console.ReadLine();
        if (Datos.SerieAdiciona(codigo, nombre, url))
            Console.WriteLine("\nSerie adicionada.");
        else
            Console.WriteLine("\nError al adicionar la serie");
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
        if (Datos.SerieEdita(codigo, nombre, url))
            Console.WriteLine("\nSerie editada.");
        else
            Console.WriteLine("\nError al editar la serie");
        Console.ReadKey();
    }

    //Pantalla para borrar series
    public void SerieBorra() {
        Console.WriteLine("\tBorrar serie");
        Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
        int codigo = Convert.ToInt32(Console.ReadLine());
        if (Datos.SerieBorra(codigo))
            Console.WriteLine("\nSerie borrada.");
        else
            Console.WriteLine("\nError al borrar la serie.");
        Console.ReadKey();
    }

    //Pantalla para ver el detalle de la serie
    public void SerieDetalle() {
        List<string> ListaActores;

        Console.WriteLine("\t === Detalle de una serie ===");
        Console.Write("¿Cuál? Número[ ]: ");
        int CodigoSerie = Convert.ToInt32(Console.ReadLine());
        int Pos = Datos.PosSerie(CodigoSerie);
        if (Pos >= 0) {
            Console.WriteLine("Nombre: " + Datos.Series[Pos].Nombre);
            Console.WriteLine("URL: " + Datos.Series[Pos].URLIMDB);
            Console.WriteLine("Actores");
            ListaActores = Datos.SerieActores(CodigoSerie);
            for (int cont = 0; cont < ListaActores.Count; cont++)
                Console.WriteLine("\t" + ListaActores[cont]);
        }
        else
            Console.WriteLine("Error en código de la serie");
        Console.WriteLine("\nENTER para continuar");
        Console.ReadKey();
    }

    //Asociar actor o actriz a una serie
    public void SerieAsocia() {
        Console.WriteLine("\tAsocia un actor o actriz a una serie");
        Console.Write("¿Cuál serie? Número[ ]: ");
        int CodigoSerie = Convert.ToInt32(Console.ReadLine());
        for (int cont = 0; cont < Datos.Actores.Count; cont++) {
            Console.Write("[" + Datos.Actores[cont].Codigo + "] ");
            Console.Write(Datos.Actores[cont].Nombre);
            Console.WriteLine(" URL: " + Datos.Actores[cont].URLIMDB);
        }
        Console.Write("¿Cuál Actor? Número[ ]: ");
        int CodigoActor = Convert.ToInt32(Console.ReadLine());
        if (Datos.SerieAsocia(CodigoSerie, CodigoActor))
            Console.WriteLine("\nActor asociado a la serie.");
        else
            Console.WriteLine("\nError código del actor o ya estaba asociado a la serie");
        Console.ReadKey();
    }

    //Pantalla para disociar actor de alguna serie
    public void SerieDisocia() {
        List<string> ListaActores;

        Console.WriteLine("\t === Disociar actor de la serie ===");
        Console.Write("¿Cuál serie? Número[ ]: ");
        int CodigoSerie = Convert.ToInt32(Console.ReadLine());
        int Pos = Datos.PosSerie(CodigoSerie);
        if (Pos >= 0) {
            ListaActores = Datos.SerieActores(CodigoSerie);
            for (int cont = 0; cont < ListaActores.Count; cont++)
                Console.WriteLine(ListaActores[cont]);

            Console.Write("¿Cuál actor quiere quitar? Número[ ]: ");
            int CodigoActor = Convert.ToInt32(Console.ReadLine());

            if (Datos.SerieDisocia(CodigoSerie, CodigoActor) == true)
                Console.WriteLine("\nActor retirado de la serie.");
            else
                Console.WriteLine("\nError retirando actor de la serie");
        }
        else
            Console.WriteLine("Error en el código de la serie");
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
