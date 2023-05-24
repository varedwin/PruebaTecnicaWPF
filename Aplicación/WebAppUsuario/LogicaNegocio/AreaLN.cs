using System.Collections.ObjectModel;
using WebAppUsuario.AccesoDatos;
using WebAppUsuario.DTO;
using WebAppUsuario.Modelos;

namespace WebAppUsuario.LogicaNegocio
{
    public class AreaLN : IAreaLN
    {
        IAreaAD _areaAD; 
        public AreaLN(IAreaAD areaAD)
        {
            _areaAD = areaAD;   
        }


        public bool AsignarUsuarioArea(UsuarioArea usuarioArea)
        {
            return _areaAD.AsignarUsuarioArea(usuarioArea);
        }

        public List<Area> ObtenerAreas()
        {
            return _areaAD.ObtenerAreas();
        }
    }
}
