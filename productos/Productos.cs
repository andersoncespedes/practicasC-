namespace productosPaquete
{
    public class Producto{
    // Propiedades Privadas
    private int?      Codigo     { get; set; }
    private string?   Nombre     { get; set; }
    private double?   Precio     { get; set; }
    private int?      Inventario { get; set; }
    private string[]? Clientes   { get; set; }
    // Propiedades Publicas
    // Constructores
    public Producto(int id, string nombre, double precio, int inventario, string[] clientes) {
        Codigo     = id;
        Nombre     = nombre;
        Precio     = precio;
        Inventario = inventario;
        Clientes   = clientes;
    }
    // Metodos
    public void MostrarDatos(){
        Console.WriteLine($"Codigo-> {this.Codigo} ///////////////////////");
        Console.WriteLine($"Nombre-> {this.Nombre} ");
        Console.WriteLine($"Precio-> {this.Precio:C} ");
        Console.WriteLine($"Inventario-> { this.Inventario} ");
        Console.WriteLine($"Clientes-> {String.Join(", ", this.Clientes) } ");
        Console.WriteLine("//////////////////////////////////////////");
        
    }
    public void ActualizarPrecio(double precio){
        Precio = precio;
    }
    public void ActualizarInventario(int inventario){
        Inventario = inventario;
    }
    public void ActualizarClientes(string[] clientes){
        Clientes = clientes;
    }
}
}