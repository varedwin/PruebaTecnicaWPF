using System.Collections.ObjectModel;
using System.Data.SqlClient;
using WebAppUsuario.Modelos;

namespace WebAppUsuario.AccesoDatos
{
    public class UsuarioAD : IGenericoAD<Usuario>
    {
        public bool GuardarEntidad(Usuario entidad)
        {
            OrigenConexion cadena = new OrigenConexion();
            bool exito = false;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand("GuardarUsuario", conn);
                cmd.Parameters.AddWithValue("Cedula", entidad.Cedula);
                cmd.Parameters.AddWithValue("Nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("Apellido", entidad.Apellido);
                cmd.Parameters.AddWithValue("Direccion", entidad.Direccion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                exito = true;
            }

            return exito;
        }

        public List<Usuario> ObtenerEntidades()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            OrigenConexion cadena = new OrigenConexion();

            using (var conexion = new SqlConnection(cadena.ConexionSQL))
            {
                conexion.Open();

                var cmd = new SqlCommand("ObtenerUsuarios", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Cedula = Convert.ToString(reader["Cedula"]);
                        usuario.Nombre = Convert.ToString(reader["Nombre"]);
                        usuario.Apellido = Convert.ToString(reader["Apellido"]);
                        usuario.Direccion = Convert.ToString(reader["Direccion"]);

                        lstUsuarios.Add(usuario);
                    }
                }
            }

            return lstUsuarios;
        }
    }
}
