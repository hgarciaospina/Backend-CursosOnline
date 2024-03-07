using Aplicacion.Seguridad;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : GenericBaseController
    {
        /* http://localhost:5200/api/Usuarios/login */
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(Login.Ejecuta parametros) 
        {
            return await Mediator.Send(parametros);
        }
    }
}
