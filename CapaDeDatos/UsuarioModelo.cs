using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5Hash;

using MySql.Data.MySqlClient;

namespace CapaDeDatos
{
    public class UsuarioModelo : Modelo
    {
        public string Id;
        public string Nombre;
        public string Password;

        const int MYSQL_DUPLICATE_ENTRY = 1062;
        const int MYSQL_ACCESS_DENIED = 1045;


        public bool Autenticar()
        {
            try { 
                string sql = $"SELECT COUNT(*) FROM usuarios WHERE nombre = @nombre AND password = @password";

                this.Comando.CommandText = sql;
                this.Comando.Parameters.AddWithValue("@nombre", Nombre);
                this.Comando.Parameters.AddWithValue("@password", Hash.Content(this.Password));
                this.Comando.Prepare();
                string resultado = this.Comando.ExecuteScalar().ToString();
                
                if (resultado == "0")
                    return false;
                return true;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }
        public void Insertar()
        {
            try
            {
                string sql = $"INSERT INTO usuarios (nombre,password) VALUES(@nombre,@password)";
                this.Comando.CommandText = sql;
                this.Comando.Parameters.AddWithValue("@nombre", Nombre);
                this.Comando.Parameters.AddWithValue("@password", Hash.Content(this.Password));
                this.Comando.Prepare();
                this.Comando.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                if (ex.Number == MYSQL_DUPLICATE_ENTRY)
                    throw new Exception("DUPLICATE_ENTRY");

                if (ex.Number == MYSQL_ACCESS_DENIED)
                    throw new Exception("ACCESS_DENIED");

                throw new Exception("UNKNOWN_DB_ERROR");
            }
            catch (Exception ex)
            {
                throw new Exception("UNKNOWN_ERROR");
            }
        }
    }

}
