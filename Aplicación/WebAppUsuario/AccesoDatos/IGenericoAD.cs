namespace WebAppUsuario.AccesoDatos
{
    public interface IGenericoAD<T> where T : class
    {
        public List<T> ObtenerEntidades();

        public bool GuardarEntidad(T entidad);
    }
}
