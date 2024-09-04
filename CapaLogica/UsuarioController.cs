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
            try
            {
                UsuarioModelo u = new UsuarioModelo();
                u.Nombre = nombre;
                u.Password = password;

                u.Insertar();
            }
            catch(Exception e)
            {
                if(e.Message == "DUPLICATE_ENTRY")
                throw new Exception("El usuario ya existe");

            }
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
