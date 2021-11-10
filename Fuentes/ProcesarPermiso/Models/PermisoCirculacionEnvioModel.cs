using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WindowsService.Models
{
    public class PermisoCirculacionEnvioModel
    {
        public int id_permisos_circulacion_envio { get; set; }

        public int id_permisosCirculacion { get; set; }

        public string archivo_pdf { get; set; }

        public int intentos { get; set; }

        public string patente { get; set; }

        public string motor { get; set; }

    }
}
