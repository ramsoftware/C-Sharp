namespace Ejemplo; 

class Program {
    static void Main() {

        // Crea una PriorityQueue con elementos de cadena y prioridades tipo DateTime
        var pq = new PriorityQueue<string, DateTime>();

        // Pone las tareas
        pq.Enqueue("Tarea 1", new DateTime(2026, 03, 25));
        pq.Enqueue("Tarea 2", new DateTime(2026, 01, 15));
        pq.Enqueue("Tarea 3", new DateTime(2026, 01, 24));
        pq.Enqueue("Tarea 4", new DateTime(2026, 04, 19));
        pq.Enqueue("Tarea 5", new DateTime(2026, 02, 06));
        pq.Enqueue("Tarea 6", new DateTime(2026, 02, 18));

        Console.WriteLine("Ordena las tareas según fecha");
        while (pq.Count > 0) {
            pq.TryDequeue(out string Tarea, out DateTime FechaTermina);
            Console.WriteLine($"{Tarea} - Fecha: {FechaTermina.ToShortDateString()}");
        }
    }
}