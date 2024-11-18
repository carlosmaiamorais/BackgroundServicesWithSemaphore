namespace BackgroundServices.API.Services.Interfaces
{
    public interface IOperacoesBancariaService
    {
        Task ExecutarBaixaAutomatica();
        Task GerarBoleto();
    }
}
