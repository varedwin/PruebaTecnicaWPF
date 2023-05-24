using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using WebAppUsuario.DTO;
using WebAppUsuario.LogicaNegocio;
using WebAppUsuario.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppUsuario.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        IAreaLN _areaLN;
        public AreaController(IAreaLN areaLN)
        {
            _areaLN = areaLN;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("ObtenerAreas")]
        public ActionResult<IEnumerable<Area>> ObtenerAreas()
        {
            try
            {
                return _areaLN.ObtenerAreas();
            }
            catch (Exception)
            {

                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

        }

        [Microsoft.AspNetCore.Mvc.HttpPost("AsignarUsuarioArea")]
        public ActionResult<HttpResponseMessage> AsignarUsuarioArea(UsuarioArea usuarioArea)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                bool resultado = _areaLN.AsignarUsuarioArea(usuarioArea);
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
