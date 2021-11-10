using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProcesarPermiso
{
    public sealed class Worker : BackgroundService
    {
        private readonly ProcesosService _procesosService;
        private readonly ILogger<Worker> _logger;

        public Worker(
            ProcesosService procesosService,
            ILogger<Worker> logger) =>
            (_procesosService, _logger) = (procesosService, logger);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Iniciando...");

            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    _procesosService.ColaCrearPermisos();
                    await _procesosService.ColaEnvioPermisosAsync();

                    var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, true)
                    .Build();

                    int colaTimerSegundos = config.GetSection("ColaSolicitud").GetValue<int>("TimerSegundos");
                    //_logger.LogInformation($"Procesando cada {colaTimerSegundos} segundos");

                    await Task.Delay(TimeSpan.FromSeconds(colaTimerSegundos), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }

            }
        }
    
    }
}
