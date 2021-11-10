using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WindowsService.Models
{
    public class PermisoCirculacionInsModel
    {
        public int id_permisosCirculacion { get; set; }

        public int tipo { get; set; }

        public string? rut { get; set; }

        public string? patente { get; set; }

        public string? monto_neto { get; set; }

        public DateTime? fecha_vencimiento { get; set; }

        public string? digito_verificador { get; set; }

        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public string? ano { get; set; }

        public string? tipo_vehiculo { get; set; }

        public string? motor { get; set; }

        public string? color { get; set; }

        public string? chasis { get; set; }

        public string? n_puertas { get; set; }

        public string? n_asiento { get; set; }

        public string? tara { get; set; }

        public string? codigo_sii { get; set; }

        public string? tasacion { get; set; }

        public string? cilindrada { get; set; }

        public string? combustible { get; set; }

        public string? transmision { get; set; }

        public string? equipamiento { get; set; }

        public string? nombre_propietario { get; set; }

        public string? domicilio_propietario { get; set; }

        public string? comuna_propietario { get; set; }

        public string? telefono_propietario { get; set; }

        public string? pago_total { get; set; }

        public string? sello_verde { get; set; }

        public string? comuna_anterior { get; set; }

        public string? zona_franca { get; set; }

        public string? carga { get; set; }

        public string? multa { get; set; }

        public int? ipc { get; set; }

        public int? valor_total { get; set; }

        public float? interes { get; set; }

        public int? total_neto { get; set; }

        public int? total_pagado { get; set; }

        public string? cuota { get; set; }

        public string? empresa { get; set; }

        public string? usuario { get; set; }

    }
}
