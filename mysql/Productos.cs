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
                string sql = "SELECT * FROM products;";
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
        public void Guardar(){
            MySqlConnection con = this.ConexionMysql();
            try{
                con.Open();
                string sql = "INSERT INTO products(name_pro,code_pro, quanty, marca) VALUES(@name_pro, @code_pro, @quanty, @marca);";
                using MySqlCommand consult = new MySqlCommand(sql, con);
                consult.Parameters.AddWithValue("@name_pro", Console.ReadLine());
                consult.Parameters.AddWithValue("@code_pro", Console.ReadLine());
                consult.Parameters.AddWithValue("@quanty", int.Parse(Console.ReadLine()));
                consult.Parameters.AddWithValue("@marca", Console.ReadLine());
                consult.ExecuteNonQuery();

            }catch(Exception err){
                Console.WriteLine(err);
            }finally{
                con.Close();
            }
        }
    }
}