using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using ProductosController;
namespace Principal{
    class Mysql{

        public static void Main(string[] args){
            Productos productos = new ();
            productos.Guardar();
        }
    }
}