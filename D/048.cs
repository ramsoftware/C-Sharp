namespace Ejemplo;
// S: Single Responsibility Principle (SRP)
// sólo se encarga de los datos del pedido.
public class Pedido {
	public int Codigo { get; set; }
	public decimal TotalCosto { get; set; }

	public Pedido(int Codigo, decimal TotalCosto) {
		this.Codigo = Codigo;
		this.TotalCosto = TotalCosto;
	}
}

// Clase con la responsabilidad de persistir los pedidos
// se encarga de guardar los pedidos, separando la responsabilidad
public class PersistePedidos {
	public void Guardar(Pedido objPedido) {
		Console.WriteLine("Pedido: " + objPedido.Codigo + " guardado con un total de: " + objPedido.TotalCosto);
	}
}

// O: Open/Closed Principle (OCP)
//La interfaz `IDescuento` permite extender el sistema con nuevos tipos de descuento
//(`SinDescuento`, `DescuentoTemporada`) sin modificar las clases existentes.
public interface IDescuento {
	decimal AplicaDescuento(decimal TotalCosto);
}

public class SinDescuento : IDescuento {
	public decimal AplicaDescuento(decimal TotalCosto) {
		return TotalCosto;
	}
}

public class DescuentoTemporada : IDescuento {
	public decimal AplicaDescuento(decimal TotalCosto) {
		return TotalCosto * 0.9m; // 10% de descuento
	}
}

// L: Liskov Substitution Principle (LSP)
//La clase abstracta `Notificacion` asegura que sus subclases
//(`EmailNotificacion`, `SmsNotificacion`) sean intercambiables sin afectar el comportamiento.
public abstract class Notificacion {
	public abstract void Notificar(string Mensaje);
}

public class EmailNotificacion : Notificacion {
	public override void Notificar(string Mensaje) {
		Console.WriteLine("Correo enviado: " + Mensaje);
	}
}

public class SmsNotificacion : Notificacion {
	public override void Notificar(string Mensaje) {
		Console.WriteLine("SMS enviado: " + Mensaje);
	}
}

// I: Interface Segregation Principle (ISP)
//Las interfaces separadas, como `IProcesoPago`, aseguran que
//las clases solo implementen métodos que necesitan
//(`TarjetaCredito`, `PorPayPal`)
public interface IProcesoPago {
	void Pago(decimal Precio);
}

public class TarjetaCredito : IProcesoPago {
	public void Pago(decimal Precio) {
		Console.WriteLine("Pago con tarjeta crédito de: " + Precio + " fue procesado.");
	}
}

public class PorPayPal : IProcesoPago {
	public void Pago(decimal Precio) {
		Console.WriteLine("Pago con PayPal de: " + Precio + " fue procesado.");
	}
}

// D: Dependency Inversion Principle (DIP)
// La clase `ServicioPedido` no depende de implementaciones concretas,
// sino de abstracciones (`IDescuento`, `Notificacion`, `IProcesoPago`),
// lo que mejora la flexibilidad y el testeo
public class ServicioPedido {
	private readonly IDescuento _descuento;
	private readonly Notificacion _notificacion;
	private readonly PersistePedidos _repositorio;
	private readonly IProcesoPago _formadePago;

	public ServicioPedido(IDescuento descuento, Notificacion notificacion, PersistePedidos repositorio, IProcesoPago formadePago) {
		_descuento = descuento;
		_notificacion = notificacion;
		_repositorio = repositorio;
		_formadePago = formadePago;
	}

	public void ProcesarPedido(Pedido objPedido) {
		// Aplicar descuento
		objPedido.TotalCosto = _descuento.AplicaDescuento(objPedido.TotalCosto);

		// Procesar pago
		_formadePago.Pago(objPedido.TotalCosto);

		// Guardar pedido
		_repositorio.Guardar(objPedido);

		// Enviar notificación
		_notificacion.Notificar("Pedido " + objPedido.Codigo + " procesado exitósamente con un total de: " + objPedido.TotalCosto);
	}
}

// Uso
class Program {
	static void Main() {
		var objPedido = new Pedido(1, 100m);

		// Inyectar dependencias
		var Descuento = new DescuentoTemporada();
		var Notificacion = new EmailNotificacion();
		var Persistencia = new PersistePedidos();
		var MododePago = new TarjetaCredito();

		var objServicioPedido = new ServicioPedido(Descuento, Notificacion, Persistencia, MododePago);

		// Procesar pedido
		objServicioPedido.ProcesarPedido(objPedido);
	}
}