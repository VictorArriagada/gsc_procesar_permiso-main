using System.Data;
using System.Data.SqlClient;

namespace App.WindowsService.Datos
{
    public class ProveedorConexion
    {
        private readonly string _cadenaConexion;

        public ProveedorConexion(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_cadenaConexion);
        }

    }
}
