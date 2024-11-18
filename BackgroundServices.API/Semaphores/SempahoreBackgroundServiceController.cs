namespace BackgroundServices.API.Semaphores
{
    public static class SemaphoreBackgroundServiceController
    {
        // Semáforo compartilhado entre os serviços
        //Parametro 1: Apenas uma thread pode acessar o recurso de cada vez.
        //Parametro 2: número máximo de permissões que o semáforo pode conceder

        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        // Método para adquirir o semáforo (bloquear a execução)
        public static async Task UseResourceAsync()
        {
            await _semaphore.WaitAsync();
        }

        // Método para liberar o semáforo (permitir execução de outro serviço)
        public static void ReleaseResource()
        {
            _semaphore.Release();
        }
    }
}
