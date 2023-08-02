using System.Collections.Generic;
using System.Linq;
using Federacion.View;
    public class Program{
        public static void Main(string[] args){
            List<string> list = new List<string>();
            list.Add("dsadsa");
            list.Add("ssdf");
            list.Add("dsadsa");
            string a = list.Find(e => e == "ssdf");
            Console.WriteLine(a);
            Console.ReadLine();
            MainMenu menu = new();
            int opcion = 0;
            do{
                opcion = menu.menu();
                switch(opcion){
                    case 1:
                        int opcionPlantel = 0;
                        MenuPlantel menuPlantel = new();
                        do{
                            opcionPlantel = menuPlantel.menuPlantel();
                        }while(opcionPlantel != 6);
                        break;
                    case 2:
                        int opcionBuscar = 0;
                        MenuBusqueda menuBusqueda = new();
                        do{
                            opcionBuscar = menuBusqueda.menuBusqueda();
                        }while(opcionBuscar != 6);
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }while(opcion != 3);
        }
    }
