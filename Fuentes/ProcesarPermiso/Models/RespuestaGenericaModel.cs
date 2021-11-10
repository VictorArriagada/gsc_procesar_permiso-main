using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WindowsService.Models
{
    public class RespuestaGenericaModel
    {
        public int? id { get; set; }

        public int? resultado { get; set; }

        public int? codigo_error { get; set; }

        public string? mensaje_error { get; set; }

        public DateTime fecha { get; set; }

    }
}
