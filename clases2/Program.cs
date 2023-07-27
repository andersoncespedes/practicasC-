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

    }
}