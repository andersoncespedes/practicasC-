using System.Collections.Generic;
using System;
using productosPaquete;
class Programa{
    public static void Menu(){
        Console.WriteLine($"/////////////////////////////Menu///////////////////////");
        Console.WriteLine($"1. Agregar Un Nuevo Producto ");
        Console.WriteLine($"2. Mostrar Un Producto");
        Console.WriteLine($"3. Mostrar Listas de Productos");
        Console.WriteLine($"4. Actualizar Un Producto ");
        Console.WriteLine($"5. Salir ");
        Console.WriteLine("//////////////////////////////////////////");
    }
    public static Dictionary<int, Producto> Productos = new();
    public static void Main(String[] args){
        Console.Clear();
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
                Console.Write("Presione Enter Para Continuar -> ");
                Console.ReadLine();
                break;
            
            case 3:
                Console.Clear();
                MostrarTodos();
                break;
            case 4:
                Console.Clear();
                MenuActualizar();
                break;
            case 5:
                Console.Clear();
                Console.WriteLine("Adios");
                break;
            default:
                Console.Clear();
                Console.WriteLine("Opcion No Valida");
                break;
           }
        }while(op != 5);
    }
    public static void MostrarTodos(){
        Console.WriteLine($"/////////////////////////////Lista De Productos///////////////////////");
        foreach (KeyValuePair<int, Producto> item in Productos)
        {
            Productos[item.Key].MostrarDatos();
        }
        Console.Write("Presione Enter Para Continuar -> ");
        Console.ReadLine();
    }
    public static void Mostrar(){
        int code;
        Console.Write("Ingrese el Codigo del producto-> ");
        bool proc = int.TryParse(Console.ReadLine(), out code);
        Productos[code].MostrarDatos();
    }
    public static void MenuActualizar(){
        Console.WriteLine($"//////////// Que Desea Modificar ////////////");
        Console.WriteLine($"1. Precio ");
        Console.WriteLine($"2. Cantidad");
        Console.WriteLine($"3. Clientes");
        Console.WriteLine($"4. Salir ");
        Console.WriteLine("//////////////////////////////////////////");
        EleccionesActualizar();
    }
    public static string[] Clientes(){
        Console.WriteLine("Agregar Clientes ");
        List<string> arr = new();
        bool seguir = true;
        while (seguir)
        {
            Console.Write("Cliente-> ");
            string cliente = Console.ReadLine();
            arr.Add(cliente);
            Console.Write("Seguir Agregando Clientes (S/N)-> ");
            seguir = Console.ReadLine().ToUpper() != "S" ? !seguir : seguir;
        } 
        return arr.ToArray();
    } 
    public static void EleccionesActualizar(){
        try{
            int opcion;
            int code;  
            int precio;
            int inventario;
            Console.Write("Opcion-> ");
            bool proc     = int.TryParse(Console.ReadLine(), out opcion);
            switch(opcion){
                case 1:
                    Console.Write("Codigo-> ");
                    bool proca = int.TryParse(Console.ReadLine(), out code);
                    Productos.ContainsKey(code);
                    Console.Write("Precio-> ");
                    bool prec = int.TryParse(Console.ReadLine(), out precio);
                    Productos[code].ActualizarPrecio(precio);
                    Console.WriteLine("Actualizacion Realizada Con Exito");
                    break;
                case 2:
                    Console.Write("Codigo-> ");
                    bool prot = int.TryParse(Console.ReadLine(), out code);
                    Console.Write("Inventario-> ");
                    bool pro = int.TryParse(Console.ReadLine(), out inventario);
                    Productos[code].ActualizarInventario(inventario);
                    Console.WriteLine("Actualizacion Realizada Con Exito");
                    break;
                case 3:
                    Console.Write("Codigo-> ");
                    bool protax = int.TryParse(Console.ReadLine(), out code);
                    string[] clientes = Clientes();
                    Productos[code].ActualizarClientes(clientes);
                    break;
                case 4:
                    Console.WriteLine("Adios");
                    break;
                default:
                    break;
            }
        }catch(KeyNotFoundException err){
            Console.WriteLine(err.Message);
        }
        Console.Write("Presione Enter Para Continuar -> ");
        Console.ReadLine();
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
            string[] clientes =  Clientes();
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