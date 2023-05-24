using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Web.Http;
using WebAppUsuario.LogicaNegocio;
using WebAppUsuario.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppUsuario.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioLN _usuarioLN;

        public UsuarioController(IUsuarioLN usuarioLN)
        {
            _usuarioLN = usuarioLN;
        }

        // GET: api/<UsuarioController>
        [Microsoft.AspNetCore.Mvc.HttpGet("ObtenerUsuarios")]
        public ActionResult<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            try
            {
                
                return _usuarioLN.ObtenerUsuarios();
            }
            catch (Exception)
            {

                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("GuardarUsuario")]
        public ActionResult<HttpResponseMessage> GuardarCliente(Usuario usuario)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                bool resultado = _usuarioLN.GuardarUsuario(usuario);
                if (resultado)
                    message.StatusCode = HttpStatusCode.OK;
                return message;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);

            }
        }
    }
}
