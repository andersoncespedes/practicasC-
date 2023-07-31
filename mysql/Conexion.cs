using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
namespace ConexionBD{
    public abstract class Conexion{
        private string Server   = "localhost";
        private string Port     = "3306";
        private string Db       = "psicologia";
        private string User     = "campus";
        private string Pass     = "campus2023";
        private string conectionString() => $"server={Server};port={Port};database={Db};user={User};password={Pass};";
        protected MySqlConnection ConexionMysql(){
            using MySqlConnection connection = new MySqlConnection(this.conectionString());
            try{
                return connection;
            }catch(Exception err){
                Console.WriteLine(err.Message);
                return connection;
            }
        }
    }

}