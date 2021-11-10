using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WindowsService.Utiles
{
    public class Funciones
    {

        public static string ValidarRut(string rutExcel)
        {
            string rutSinFormato = rutExcel.Replace("-", "");
            string rutFormateado = String.Empty;

            //obtengo la parte numerica del RUT
            string rutTemporal = rutSinFormato.Substring(0, rutSinFormato.Length - 1);

            //obtengo el Digito Verificador del RUT
            string dv = rutSinFormato.Substring(rutSinFormato.Length - 1, 1);

            Int64 rut;

            //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
            if (!Int64.TryParse(rutTemporal, out rut))
            {
                rut = 0;
            }

            //este comando es el que formatea con los separadores de miles
            rutFormateado = rut.ToString("N0");

            if (rutFormateado.Equals("0"))
            {
                rutFormateado = string.Empty;
            }
            else
            {
                //si no hubo problemas con el formateo agrego el DV a la salida
                rutFormateado += "-" + dv;

                //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                rutFormateado = rutFormateado.Replace(",", ".");
            }
            return rutFormateado;
        }

        public static string fechaValida(string fecha)
        {
            string fecha2 = "";

            try
            {
                fecha2 = DateTime.Parse(fecha).ToString("dd-MM-yyyy");
            }
            catch (Exception ex)
            {
            }

            return fecha2;
        }

    }
}
