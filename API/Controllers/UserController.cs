using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using CapaLogica;
using API.Models;
namespace API.Controllers
{
    public class PizzaController : ApiController
    {


        [Route("api/login")]
        public IHttpActionResult Login(UserModel user)
        {
            Dictionary<string, bool> resultado = new Dictionary<string, bool>();

            bool autenticacion = UsuarioController.Login(user.Username, user.Password);
            resultado.Add("Resultado",autenticacion);

            if(autenticacion)
                return Ok(resultado);

            return NotFound();
        }

    }
}