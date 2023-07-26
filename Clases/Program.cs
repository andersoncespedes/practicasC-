    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Jugar;

namespace Clases{
    public class Edificio{
        int id {get; set;}
        string _direccion {get;set;}
        int _cantApts {get; set;}
        string _nombre {get; set;}
        string _colorFachada {get; set;}
        public void cambiarColor(string color){
            this._colorFachada = color;
        }
        public void cambiarNombre(string nombre){
            this._nombre = nombre;
        }
        public void aumentarApts(int suma){
            this._cantApts += suma;
        }
    }
    public class Apartamento : Edificio{
        int _numApto {get; set;}
        int _idEDificio {get; set;}
        int _numHabs{get; set;}
        public void venderApto(){
            this._numApto = 0;
        }
        public void arrendarApto(){

        }
    }
    class Programa{
        public static void Main(){
           Edificio edificio = new();
           edificio.aumentarApts(12);
           Nombres[] nomb = {new Nombres(edad:12, nombre:"asada",peso:4.56), new Nombres("pedo", 15,4.56), new Nombres("Caca", 15,4.56)};
           string[] arr = {"ASDA", "hola", "KLASDLKA", "KASDJLKJAS", "DA", "como", "estas", "PENSASKDLAKDLA"};
           IEnumerable<string> arrs = from i in arr where i.Length > 0 orderby i.Length descending select i;
           IEnumerable<Nombres> xx = from a in nomb where a.nombre.Contains("a") select a;
           Nombres[] arrsx = nomb.Where(x => ((byte)x.edad) > 12 ).ToArray();
           var anon = new {a = 1, b = 2, c =3};
           foreach(Nombres n in xx){
            Console.WriteLine($"{n.nombre:T} {n.edad} {n.peso:E}");
           }
           foreach(Nombres a in arrsx){
            Console.WriteLine(a.nombre + " ");
           }
           foreach(string X in arrs){
            Console.WriteLine(X + " ");
           }
           Console.WriteLine(anon.c);
        }
    }
}