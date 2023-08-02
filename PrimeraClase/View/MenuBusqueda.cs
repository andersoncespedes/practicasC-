namespace Federacion.View;
public class MenuBusqueda
{
    public MenuBusqueda()
    {

    }
    public int menuBusqueda(){
        Console.Clear();
        Console.WriteLine("1. Listar Jugadores por Equipo");
        Console.WriteLine("2. Registro Jugador");
        Console.WriteLine("3. Registro Entrenador");
        Console.WriteLine("4. Registro Masajista");
        Console.WriteLine("5. Venta Jugador");
        Console.WriteLine("6. Salir");
        return int.Parse(Console.ReadLine());
    }
}