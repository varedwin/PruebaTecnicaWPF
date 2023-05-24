using WebAppUsuario.AccesoDatos;
using WebAppUsuario.Modelos;

namespace WebAppUsuario.LogicaNegocio
{
    public class UsuarioLN: IUsuarioLN
    {
        IGenericoAD<Usuario> _usuarioAD;
        public UsuarioLN(IGenericoAD<Usuario> usuarioAD)
        {
            _usuarioAD = usuarioAD;
        }
        public bool GuardarUsuario(Usuario entidad)
        {
            
            return _usuarioAD.GuardarEntidad(entidad);
        }
        public List<Usuario> ObtenerUsuarios()
        {
            
            return _usuarioAD.ObtenerEntidades();
        }
    }
}
