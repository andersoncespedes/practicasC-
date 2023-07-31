using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using ConexionBD;
namespace ProductosController
{
    public class Producto{
        public string nombre {get; set;}
        public string telefono {get; set;}
        public string correo {get; set;}
        public Producto(string nombre, string telefono, string correo){
            this.nombre = nombre;
            this.telefono = telefono;
            this.correo = correo;
        }
        public Producto(string nombre){
            this.nombre = nombre;
        }
    }
    public class Productos : Conexion
    {
        protected string table = "persona";
        public Dictionary<int, Producto>?  Selecionar(){
            MySqlConnection con = this.ConexionMysql();
            try
            {
                con.Open();
                string sql = $"SELECT * FROM {table};";
                using MySqlCommand command = new MySqlCommand(sql, con);
                using MySqlDataReader read = command.ExecuteReader();
                Dictionary<int,Producto>? result =new();
                while(read.Read()){
                    string nombre = read.GetString("nombre");
                    string telefono =  read.GetString("telefono");
                    string correo = read.GetString("correo");
                    result.Add(read.GetInt32("id_persona"), new Producto(nombre, telefono, correo));
                }
                read.Close();
                return result;
            }catch(Exception err){
                Console.WriteLine(err.Message);
                return null;
            }
        }
        public void Guardar(){
            MySqlConnection con = this.ConexionMysql();
            try{
                con.Open();
                string sql = $"INSERT INTO {table}(nombre,telefono, correo, foto,documento,tipo_documento, tipo_persona) VALUES(@nombre, @telefono, @correo,@foto, @documento, @tipo_documento, @tipo);";
                using MySqlCommand consult = new MySqlCommand(sql, con);
                Console.Write("Ingresar Nombre-> ");
                consult.Parameters.AddWithValue("@nombre", Console.ReadLine());
                Console.Write("Ingresar Telefono-> ");
                consult.Parameters.AddWithValue("@telefono", int.Parse(Console.ReadLine()));
                Console.Write("Ingresar Correo-> ");
                consult.Parameters.AddWithValue("@correo",Console.ReadLine());
                Console.Write("Ingresar Direccion de la foto-> ");
                consult.Parameters.AddWithValue("@foto",Console.ReadLine());
                Console.Write("Ingresar Documento-> ");
                consult.Parameters.AddWithValue("@documento", Console.ReadLine());
                Console.Write("Ingresar Tipo de Documento-> ");
                consult.Parameters.AddWithValue("@tipo_documento", Console.ReadLine());
                Console.Write("Ingresar Tipo-> ");
                consult.Parameters.AddWithValue("@tipo", Console.ReadLine());
                consult.ExecuteNonQuery();
            }catch(Exception err){
                Console.WriteLine(err);
            }finally{
                con.Close();
            }
        }
        public void SeleccionarDatosRelacionados(){
            MySqlConnection con = this.ConexionMysql();
            try{
                con.Open();
                string sql = $"SELECT * FROM {table} a INNER JOIN entrevista b ON a.id_persona = b.id_persona;";
                MySqlCommand comando = new(sql, con);
                MySqlDataReader read = comando.ExecuteReader();
                Console.WriteLine($"id  Nombre  Fecha  Duracion");
                while(read.Read()){
                    int id        = read.GetInt32("id_persona");
                    string nombre = read.GetString("correo");
                    string fecha = read.GetString("fecha");
                    string duracion = read.GetString("duracion");
                    Console.Write($"{id} {nombre} {fecha} {duracion}");
                    Console.WriteLine();
                }
                read.Close();
            }catch(Exception err){
                Console.WriteLine(err.Message);
            }finally{
                con.Close();
            }
        }
        public void Actualizar(){
            MySqlConnection con = this.ConexionMysql();
            try{
                con.Open();
                string sql = $"UPDATE {table} SET nombre = @nombre, telefono = @telefono WHERE id_persona = 1;";
                MySqlCommand command = new(sql, con);
                Console.Write("Ingrese el Nombre -> ");
                command.Parameters.AddWithValue("@nombre", Console.ReadLine());
                Console.Write("Ingrese el Telefono -> ");
                command.Parameters.AddWithValue("@telefono", Console.ReadLine());
                command.ExecuteNonQuery();
            }catch(Exception err){
                Console.WriteLine(err.Message);
            }finally{
                con.Close();
            }
        }
        public void Eliminar(){
            MySqlConnection con = this.ConexionMysql();
            try{
                con.Open();
                int id = int.Parse(Console.ReadLine());
                string sql = $"DELETE FROM {table} WHERE id_persona = {id}";
                MySqlCommand command = new (sql, con);
                command.ExecuteNonQuery();
            }catch(Exception err){
                Console.WriteLine(err.Message);
            }finally{
                con.Close();
            }
        }
        public int LastId(){
            MySqlConnection con = this.ConexionMysql();
            int id;
            try{
                con.Open();
                string sql = "SELECT LAST_INSERT_ID()";
                MySqlCommand command = new (sql, con);
                id = Convert.ToInt32(command.ExecuteScalar());
                return id;
            }catch(Exception err){
                Console.WriteLine(err.Message);
                return 0;
            }
        }
    }
}