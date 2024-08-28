using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaLogica
{
    public class UsuarioController
    {
        public static void Crear(string nombre, string password){
            UsuarioModelo u = new UsuarioModelo();
            u.Nombre = nombre;
            u.Password = password;

            u.Insertar();
        }

        public static bool Login(string nombre, string password)
        {
            UsuarioModelo u = new UsuarioModelo();
            u.Nombre = nombre;
            u.Password = password;

            return u.Autenticar();
        }
    }
}
