namespace WebAppUsuario.LogicaNegocio
{
    using System.Collections.ObjectModel;
    using WebAppUsuario.DTO;
    using WebAppUsuario.Modelos;
    public interface IAreaLN
    {
        public List<Area> ObtenerAreas();

        public bool AsignarUsuarioArea(UsuarioArea usuarioArea);
    }
}
