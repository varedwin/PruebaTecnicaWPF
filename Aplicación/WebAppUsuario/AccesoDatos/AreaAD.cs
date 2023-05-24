namespace WebAppUsuario.AccesoDatos
{
    using System.Collections.ObjectModel;
    using System.Data.SqlClient;
    using WebAppUsuario.DTO;
    using WebAppUsuario.Modelos;
    public class AreaAD: IAreaAD
    {

        public List<Area> ObtenerAreas()
        {
            List<Area> lstAreas = new List<Area>();
            OrigenConexion cadena = new OrigenConexion();

            using (var conexion = new SqlConnection(cadena.ConexionSQL))
            {
                conexion.Open();

                var cmd = new SqlCommand("ObtenerAreas", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var area = new Area();
                        area.Id = Convert.ToInt32(reader["Id"]);
                        area.Nombre = Convert.ToString(reader["Nombre"]);
                        lstAreas.Add(area);
                    }
                }
            }

            return lstAreas;
        }

        public bool AsignarUsuarioArea(UsuarioArea usuarioArea)
        {
            OrigenConexion cadena = new OrigenConexion();
            bool exito = false;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand("AsignarUsuarioArea", conn);
                cmd.Parameters.AddWithValue("@cedula", usuarioArea.Cedula);
                cmd.Parameters.AddWithValue("@idArea", usuarioArea.IdArea);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                exito = true;
            }

            return exito;
        }
    }
}
