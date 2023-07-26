namespace Jugar{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal interface IJugute{
        public string text {get{
            return text; 
        }set{
            if(value.Contains("a")){
                text = value;
            }
        }} 
        public int num {get; set;}
        public List<int>? list{get; set;} 
    }
    public abstract class Juguete: IJugute{
        public string text {get{
            return text; 
        }set{
            if(value.Contains("a")){
                text = value;
            }
        }} 
        public int num {get; set;}
        public List<int>? list{get; set;}
        public virtual void Stack (){
            this.list = null;
        }
        public List<int>? Listar(){
            return this.list;
        }
    }
    public class Jugar : Juguete{
        public Jugar(List<int>? list){
            this.list = list;
        }
        public override void Stack (){
            this.list = new List<int>() {1,2,3,4};
        }
    }
    public class Juegos:Juguete{
        public Juegos (List<int>? list){
            this.list = list;
        }

         public override void Stack (){
            this.list = new List<int>() {0,0,0,0,0,0,0};
        }
    }
    public class Nombres{
        public string nombre {get; set;}
        public int edad {get; set;}
        public double peso {get;set;}
        public Nombres(string nombre, int edad, double peso){
            this.nombre = nombre;
            this.edad = edad;
            this.peso = peso;
        }
    }
}
