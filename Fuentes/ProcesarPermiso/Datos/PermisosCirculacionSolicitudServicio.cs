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
    public class PermisosCirculacionSolicitudServicio
    {
        private readonly ProveedorConexion _proveedor;
        private readonly ILogger<PermisosCirculacionSolicitudServicio> _log;

        public PermisosCirculacionSolicitudServicio(ProveedorConexion proveedor, ILogger<PermisosCirculacionSolicitudServicio> log)
        {
            _proveedor = proveedor;
            _log = log;
        }

        public PermisoCirculacionSolicitudModel SelPorId(int id_permisosCirculacion_solicitud)
        {
            string sp = "PA_Sel_Permisos_Circulacion_Solicitud_Por_Id";

            _log.LogInformation($"Ejecutando {sp} {id_permisosCirculacion_solicitud}");

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();
                var values = new { id_permisosCirculacion_solicitud };
                var respuesta = db.QueryFirst<PermisoCirculacionSolicitudModel>(sp, values, null, null, CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");
                
                return new PermisoCirculacionSolicitudModel();
            }

        }

        public IEnumerable<PermisoCirculacionSolicitudModel> SelTop(int cantidad)
        {
            string sp = "PA_Sel_Permisos_Circulacion_Solicitud_Top";

            _log.LogInformation($"Ejecutando {sp} {cantidad}");

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();
                var values = new { cantidad };
                var respuesta = db.Query<PermisoCirculacionSolicitudModel>(sp, values, null, true, null, CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return new List<PermisoCirculacionSolicitudModel>().AsEnumerable();
            }

        }

        public bool DelPorId(int id)
        {
            string sp = "PA_Del_Permisos_circulacion_solicitud";

            _log.LogInformation($"Ejecutando {sp} {id}");

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();
                var values = new { id };
                var respuesta = db.QueryFirst<RespuestaPermisosCirculacionSolicitudDelModel>(sp, values, null, null, CommandType.StoredProcedure);

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

        public class RespuestaPermisosCirculacionSolicitudDelModel
        {
            public int res { get; set; }

        }

    }
}
