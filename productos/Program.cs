using System;
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
        Console.Write("Presione Enter Para Continuar -> ");
        Console.ReadLine();
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
class Programa{
    public static void Menu(){
        Console.WriteLine($"/////////////////////////////Menu///////////////////////");
        Console.WriteLine($"1. Agregar Un Nuevo Producto ");
        Console.WriteLine($"2. Mostrar Un Producto");
        Console.WriteLine($"3. Actualizar Un Producto ");
        Console.WriteLine("//////////////////////////////////////////");
    }
    public static Dictionary<int, Producto> Productos = new();
    public static void Main(String[] args){
        int op;
        do{
           Console.Clear();
           Menu();
           bool succ = int.TryParse(Console.ReadLine(), out op);
           switch(op){
            case 1:
                Console.Clear();
                Guardar();
                break;
            case 2:
               Console.Clear();
                Mostrar();
                break;
            default:
                Console.WriteLine("Opcion No Valida");
            break;
           }
        }while(op != 5);
    }
    public static void Mostrar(){
        int code;
        bool proc = int.TryParse(Console.ReadLine(), out code);
        Productos[code].MostrarDatos();
    }
    public static void Guardar(){
        try{
            int    code;
            double precio;
            int    inventario;
            Console.Write("Codigo-> ");
            bool proc     = int.TryParse(Console.ReadLine(), out code);
            Console.Write("Nombre-> ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("Precio-> ");
            bool proca    = double.TryParse(Console.ReadLine(), out precio);
            Console.Write("Inventario-> ");
            bool procas   = int.TryParse(Console.ReadLine(), out inventario);
            string[] clientes =  {"jhoan", "christian"};
            if(!procas || !proc || !proca ){
                throw new Exception("Ingrese Los Valores Correspondientes");
            }
            Producto producto = new Producto(code, nombre, precio, inventario, clientes);
            Productos.Add(code, producto);
        }catch(ArgumentException err){
            Console.WriteLine(err.Message);
            Console.Write("Presione Enter Para Continuar -> ");
            Console.ReadLine();
        }catch(Exception err){
            Console.WriteLine(err.Message);
            Console.Write("Presione Enter Para Continuar -> ");
            Console.ReadLine();
        }
        
    }
}