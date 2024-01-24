namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal? precoInicial = null;
        private decimal? precoPorHora = null;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal? precoInicial, decimal? precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;

            if (precoInicial == null || precoInicial < 0)
            {
                throw new ArgumentException("Preço inicial inválido!");
            }

            if (precoPorHora == null || precoPorHora < 0)
            {
                throw new ArgumentException("Preço por hora inválido!");
            }
        }

        public void AdicionarVeiculo()
        {
    
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa); 
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                 int horas;
                 bool parsed = false;

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                while (!parsed)
                {
                    parsed = int.TryParse(Console.ReadLine(), out horas);
                    if (!parsed)
                    {
                        Console.WriteLine("Quantidade de horas inválida! Por favor, digite um número inteiro");
                    }
                }
                
                decimal valorTotal = precoInicial + precoPorHora * horas; 
                
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("N2")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculos) {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
