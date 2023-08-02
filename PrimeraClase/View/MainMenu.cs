namespace Federacion.View;
public class MainMenu{
    public MainMenu()
    {

    }
    public int menu(){
        Console.Clear();
        Console.WriteLine("1. Registro Panel");
        Console.WriteLine("2. Consulta de Datos");
        Console.WriteLine("3. Crear Liga");
        Console.WriteLine("3. Salir");
        return int.Parse(Console.ReadLine());
    }
}