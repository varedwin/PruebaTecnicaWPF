using WebAppUsuario.AccesoDatos;
using WebAppUsuario.Modelos;

namespace WebAppUsuario.LogicaNegocio
{
    public interface IUsuarioLN
    {
        public bool GuardarUsuario(Usuario entidad);
        public List<Usuario> ObtenerUsuarios();
    }
}
