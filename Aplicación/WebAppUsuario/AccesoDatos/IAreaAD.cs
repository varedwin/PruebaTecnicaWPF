using WebAppUsuario.DTO;
using WebAppUsuario.Modelos;

namespace WebAppUsuario.AccesoDatos
{
    public interface IAreaAD
    {
        public List<Area> ObtenerAreas();

        public bool AsignarUsuarioArea(UsuarioArea usuarioArea);
    }
}
