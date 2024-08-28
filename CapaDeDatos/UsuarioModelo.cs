using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5Hash;

namespace CapaDeDatos
{
    public class UsuarioModelo : Modelo
    {
        public string Id;
        public string Nombre;
        public string Password;


        public bool Autenticar()
        {
            
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
        public void Insertar()
        {
            string sql = $"INSERT INTO usuarios (nombre,password) VALUES(@nombre,@password)";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.AddWithValue("@nombre", Nombre);
            this.Comando.Parameters.AddWithValue("@password", Hash.Content(this.Password));
            this.Comando.Prepare();
            this.Comando.ExecuteNonQuery();
        }
    }

}
