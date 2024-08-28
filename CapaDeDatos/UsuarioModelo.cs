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
            string sql = $"SELECT COUNT(*) FROM usuarios WHERE nombre='{this.Nombre}' AND password ='{Hash.Content(this.Password)}'";
            this.Comando.CommandText = sql;
            string resultado = this.Comando.ExecuteScalar().ToString();
            if (resultado == "0")
                return false;
            return true;

        }
        public void Insertar()
        {
            string sql = $"INSERT INTO usuarios (nombre,password) VALUES('{this.Nombre}','{Hash.Content(this.Password)}')";

            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
    }

}
