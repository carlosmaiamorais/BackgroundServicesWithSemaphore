using BackgroundServices.API.Services.Interfaces;

namespace BackgroundServices.API.Services
{
    public class OperacoesBancariaService : IOperacoesBancariaService
    {
        public OperacoesBancariaService()
        {
            
        }

        public async Task ExecutarBaixaAutomatica()
        {
            //lógica 

            //pesquisa no banco de dados

            //loop para processar e efetuar as baixas

            var i = 0;
            while (i < 20)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Processando baixa número {i} ");
                Thread.Sleep(1000);
                Console.WriteLine($"Baixa número {i} efetuada com sucesso ");
                i++;
            }
        }

        public async Task GerarBoleto()
        {
            //pesquisar na base quais boletos vou gerar

            //loop para processar a geração dos boletos

            var i = 0;
            while (i < 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" Processando BOLETO número {i}");
                Thread.Sleep(1000); // esperar 1 segundo;
                i++;
                Console.WriteLine($" BOLETO número {i} PROCESSADO.");
            }
        }
    }
}
