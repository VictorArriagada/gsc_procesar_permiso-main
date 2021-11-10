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
    public class PermisosCirculacionEnvioServicio
    {
        private readonly ProveedorConexion _proveedor;
        private readonly ILogger<PermisosCirculacionEnvioServicio> _log;

        public PermisosCirculacionEnvioServicio(ProveedorConexion proveedor, ILogger<PermisosCirculacionEnvioServicio> log)
        {
            _proveedor = proveedor;
            _log = log;
        }

        public RespuestaGenericaModel Ins(int id_permisosCirculacion, string archivo_pdf)
        {
            string sp = "PA_Ins_Permiso_Circulacion_Envio";

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();

                _log.LogInformation($"Ejecutando {sp} {id_permisosCirculacion} {archivo_pdf}");
                var values = new { id_permisosCirculacion, archivo_pdf };

                RespuestaGenericaModel respuesta = db.QueryFirst<RespuestaGenericaModel>(sp, values, null, null, CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return new RespuestaGenericaModel() { resultado = 3, id = null, mensaje_error = e.Message };
            }

        }

        public IEnumerable<PermisoCirculacionEnvioModel> SelTop(int cantidad)
        {
            string sp = "PA_Sel_Permisos_Circulacion_Envio_Top";

            _log.LogInformation($"Ejecutando {sp} {cantidad}");

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();
                var values = new { cantidad };
                var respuesta = db.Query<PermisoCirculacionEnvioModel>(sp, values, null, true, null, CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return new List<PermisoCirculacionEnvioModel>().AsEnumerable();
            }

        }

        public RespuestaGenericaModel AgregarIntento(int id_permisos_circulacion_envio, int max_intentos)
        {
            string sp = "PA_Upd_Permisos_Circulacion_Envio_Intentos";

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();

                _log.LogInformation($"Ejecutando {sp} {id_permisos_circulacion_envio} {max_intentos}");
                var values = new { id_permisos_circulacion_envio, max_intentos };

                RespuestaGenericaModel respuesta = db.QueryFirst<RespuestaGenericaModel>(sp, values, null, null, CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return new RespuestaGenericaModel() { resultado = 3, id = null, mensaje_error = e.Message };
            }

        }

        public bool DelPorId(int id)
        {
            string sp = "PA_Del_Permisos_circulacion_envio";

            _log.LogInformation($"Ejecutando {sp} {id}");

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();
                var values = new { id };
                var respuesta = db.QueryFirst<RespuestaPermisosCirculacionEnvioDelModel>(sp, values, null, null, CommandType.StoredProcedure);

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

        public class RespuestaPermisosCirculacionEnvioDelModel
        {
            public int res { get; set; }

        }

    }
}
