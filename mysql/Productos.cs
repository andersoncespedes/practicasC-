using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ConexionBD;
namespace ProductosController
{
    public class Productos : Conexion
    {
        public void Selecionar(){
            MySqlConnection con = this.ConexionMysql();
            try
            {
                con.Open();
                string sql = "SELECT * FROM products a INNER JOIN facturas b ON a.id_prod = b.id_prod;";
                using MySqlCommand command = new MySqlCommand(sql, con);
                using MySqlDataReader reader = command.ExecuteReader();
                List<string> Nombres = new();
                while(reader.Read()){
                    string name_pro = reader.GetString("name_pro");
                    int    id       = reader.GetInt32("id_prod");
                    string code     = reader.GetString("code");
                    Console.WriteLine(id);
                    Console.WriteLine(code);
                    Console.WriteLine(name_pro);
                    Nombres.Add(name_pro);
                }
                reader.Close();
            }catch(Exception err){
                Console.WriteLine(err.Message);
            }finally{
                con.Close();
            }
        }
    }
}