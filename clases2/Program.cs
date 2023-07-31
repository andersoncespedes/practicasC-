using System;
using System.IO;
using Newtonsoft.Json;
class Lector{
    public string Texto(){
        string path = "a.txt";
        string a;
        try{
            StreamReader arr = new StreamReader(path);
            string line;
            while((line = arr.ReadLine()) != null ){
                Console.WriteLine(line);
            }
            return line;
        }catch(FileNotFoundException err){
            return err.Message;
        }catch(IOException erro){
            return erro.Message;
        }
    }
    public void Json(){
        string path = "b.json";
        try{
            string json = File.ReadAllText(path);
            Persona[]? persona = JsonConvert.DeserializeObject<Persona[]>(json);
            Console.WriteLine($"Nombre: {persona[1].nombre}");
            Console.WriteLine($"Edad: {persona[1].edad}");
            Console.WriteLine($"Ciudad: {persona[1].ciudad}");
        }catch(FileNotFoundException ){
        }catch(JsonException ){

        }
    }
}
class Persona
{
    public string nombre { get; set; }
    public int edad { get; set; }
    public string? ciudad { get; set; }
}
class Program
{
    static void Main()
    {
        Lector leer = new Lector();
        Console.WriteLine( leer.Texto());
        leer.Json();
        List<string> Materias = new();
        List<string> Encontrados = new();
        Materias.Add("Calculo");
        Materias.Add("Español");
        Materias.Add("Dibujo Tecnico");
        Materias.Add("Ingles");
        Console.WriteLine("Total de elementos de la lista {0}", Materias.Count());
        string ? palabra;
        List<string> Dinosaurios = new();
        string[] dinos = {
            "Brachiosaurus",
            "Amargasaurus",
            "Mamenchisaurus"
        };
        Dinosaurios.AddRange(dinos);
        Console.WriteLine("Ingresa el nombre del Dinosaurio a buscar: ");
        palabra = Console.ReadLine();
        Encontrados = Dinosaurios.FindAll(n => n.Contains(palabra ?? string.Empty));
       foreach(string n in Encontrados){
        Console.WriteLine(n);
       }

    }
}