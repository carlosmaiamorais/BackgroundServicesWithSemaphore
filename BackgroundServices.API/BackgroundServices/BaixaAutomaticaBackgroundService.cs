

using BackgroundServices.API.Semaphores;
using BackgroundServices.API.Services.Interfaces;

namespace BackgroundServices.API.BackgroundServices
{
    public class BaixaAutomaticaBackgroundService : BackgroundService
    {

        private readonly IServiceProvider _serviceProvider;
        public BaixaAutomaticaBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessarBaixaAutomatica(stoppingToken);
            }
        }

        private async Task ProcessarBaixaAutomatica(CancellationToken stoppingToken)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var _baixaAutomaticaService = scope.ServiceProvider.GetRequiredService<IOperacoesBancariaService>();

                await SemaphoreBackgroundServiceController.UseResourceAsync(); //adquirindo o semáforo;

                await _baixaAutomaticaService.ExecutarBaixaAutomatica();
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
