

using BackgroundServices.API.Semaphores;
using BackgroundServices.API.Services.Interfaces;

namespace BackgroundServices.API.BackgroundServices
{
    public class GerarBoletoBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public GerarBoletoBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessarGerarBoleto(stoppingToken);
            }
        }

        private async Task ProcessarGerarBoleto(CancellationToken stoppingToken)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var _boletoService = scope.ServiceProvider.GetRequiredService<IOperacoesBancariaService>();

                await SemaphoreBackgroundServiceController.UseResourceAsync(); //adquirindo o semáforo;

                await _boletoService.GerarBoleto();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SemaphoreBackgroundServiceController.ReleaseResource(); //liberando o semáfoto
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}
