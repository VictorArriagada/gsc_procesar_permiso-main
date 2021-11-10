using App.WindowsService.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WindowsService.Datos
{
    public class PermisosCirculacionServicio
    {
        private readonly ProveedorConexion _proveedor;
        private readonly ILogger<PermisosCirculacionServicio> _log;

        public PermisosCirculacionServicio(ProveedorConexion proveedor, ILogger<PermisosCirculacionServicio> log)
        {
            _proveedor = proveedor;
            _log = log;
        }

        public PermisoCirculacionModel SelPorId(int id_permisosCirculacion)
        {
            string sp = "PA_Sel_Permisos_Circulacion_Por_Id";

            _log.LogInformation($"Ejecutando {sp} {id_permisosCirculacion}");

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();
                var values = new { id_permisosCirculacion };
                var respuesta = db.QueryFirst<PermisoCirculacionModel>(sp, values, null, null, CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return new PermisoCirculacionModel();
            }

        }

        public RespuestaGenericaModel Ins(PermisoCirculacionInsModel solicitud)
        {
            string sp = "PA_Ins_Permiso_Circulacion";

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();

                _log.LogInformation($"Ejecutando {sp} {solicitud}");

                RespuestaPermisosCirculacionInsModel respuesta = db.QueryFirst<RespuestaPermisosCirculacionInsModel> (sp, solicitud, null, null, CommandType.StoredProcedure);

                string[] res = respuesta.res.Split("|");

                return new RespuestaGenericaModel() { resultado = 1, id = int.Parse(res[0]), fecha = Convert.ToDateTime(res[1]) };
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return new RespuestaGenericaModel() { resultado = 3, id = null, mensaje_error = e.Message};
            }

        }

        public bool DelPorId(int id)
        {
            string sp = "PA_Del_Permisos_circulacion";

            _log.LogInformation($"Ejecutando {sp} {id}");

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();
                var values = new { id };
                var respuesta = db.QueryFirst<RespuestaPermisosCirculacionDelModel>(sp, values, null, null, CommandType.StoredProcedure);

                if (respuesta.res == 1)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return false;
            }

        }

        public class RespuestaPermisosCirculacionInsModel
        {
            public string res { get; set; }

        }

        public class RespuestaPermisosCirculacionDelModel
        {
            public int res { get; set; }

        }

    }
}
