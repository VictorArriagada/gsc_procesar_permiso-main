using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProcesarPermiso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Configuration;
using App.WindowsService.Datos;

namespace ProcesarPermiso
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            using IHost host = Host.CreateDefaultBuilder(args)
                .UseWindowsService(options =>
                {
                    options.ServiceName = "Calle Larga - Procesar Permisos";
                })
                .ConfigureServices(services =>
                {
                    var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: false)
                            .Build();

                    services.AddHostedService<Worker>()
                    .Configure<EventLogSettings>(config =>
                    {
                        config.LogName = "Calle Larga";
                        config.SourceName = "Procesar Permisos";

                    });

                    services.AddHttpClient<ProcesosService>();  //Para conectarse a un servicio http

                    string cadenaConexion = config.GetConnectionString("BD_Muni");
                    services.AddTransient(provider => new ProveedorConexion(cadenaConexion));

                    services.AddTransient<PermisosCirculacionServicio>();
                    services.AddTransient<PermisosCirculacionSolicitudServicio>();
                    services.AddTransient<PermisosCirculacionEnvioServicio>();
                })
                .Build();

            await host.RunAsync();

        }

    }
}

/*


using IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "Calle Larga - Procesar Permisos";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
        .Configure<EventLogSettings>(config =>
        {
            config.LogName = "Calle Larga";
            config.SourceName = "Procesar Permisos";

        }); services.AddHttpClient<ProcesosService>();  //Para conectarse a un servicio http
    })
    .Build();

await host.RunAsync();
 
 
*/
