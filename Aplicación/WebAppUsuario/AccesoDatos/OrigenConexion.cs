namespace WebAppUsuario.AccesoDatos
{
    
    public class OrigenConexion
    {
        private string conexionSQL;
        public OrigenConexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            conexionSQL = builder.GetSection("ConnectionStrings:ConexionSQL").Value;
        }

        public string ConexionSQL { get { return conexionSQL; } }
    }
}
