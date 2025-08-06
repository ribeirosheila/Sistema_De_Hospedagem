using System.Text.Json;
using System.Text;

namespace Sistema_de_Hospedagem.Models;

/// <summary>
/// Classe responsável pelas operações relacionadas a reservas,
/// como check-in, listagem de hóspedes, cálculo de diárias, seleção de suítes e checkout.
/// </summary>
public class Reserva
{
    private string idSelecionado;

    /// <summary>
    /// Realiza o processo completo de check-in de um hóspede.
    /// </summary>
    public async Task FazerChekin()
    {
        Pessoa checkin = new Pessoa();
        checkin.ObtainInfoDeHospede();

        Thread.Sleep(2000); // Simula tempo de carregamento

        Console.Clear();

        var suites = await APIServer.GetSuitesAsync();

        Suite listaDeQuartos = new Suite();
        await listaDeQuartos.ObterListaDeQuartos();

        CalculoDeDiarias();

        // Registra o ID do quarto na pessoa antes de adicionar à lista
        checkin.QuartoReservado = idSelecionado;
        checkin.AddHospedes();

        checkin.QuantidadeDeAcompanhantes(); // acompanhantes herdam o mesmo quarto

        Console.WriteLine("\nDeseja continuar com a reserva? (s/n)");
        string confirmacao = Console.ReadLine();

        if (confirmacao == "s")
        {
            await SelecionarQuarto(suites);
        }
        else
        {
            Console.WriteLine("Digite 0 para retornar ao menu ou 1 para selecionar outro quarto");
            string selecao = Console.ReadLine();

            if (selecao == "1")
            {
                await SelecionarQuarto(suites);
            }
            else
            {
                Menu retorno = new Menu();
                await retorno.VoltarAoMenu();
            }
        }

        Thread.Sleep(2000);
    }

    /// <summary>
    /// Exibe a lista de hóspedes cadastrados.
    /// </summary>
    public void Hospedes()
    {
        Pessoa listaDePessoas = new Pessoa();
        listaDePessoas.Apresentar();
        Thread.Sleep(3000);
    }

    /// <summary>
    /// Realiza a seleção da suíte com base no ID armazenado.
    /// </summary>
    public async Task SelecionarQuarto(List<Suite> suites)
    {
        if (!string.IsNullOrWhiteSpace(idSelecionado))
        {
            var suiteSelecionada = suites.FirstOrDefault(s => s.ID == idSelecionado);

            Console.WriteLine("\nDeseja confirmar a seleção do quarto? (s/n): ");
            string confirmacao = Console.ReadLine();

            if (confirmacao == "s")
            {
                suiteSelecionada.Status = "Ocupado";

                var json = JsonSerializer.Serialize(suiteSelecionada);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using HttpClient client = new HttpClient();
                var response = await client.PutAsync($"http://localhost:3000/quartos/{idSelecionado}", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Quarto atualizado!");
                }
                else
                {
                    Console.WriteLine($"Erro ao atualizar: {response.StatusCode}");
                }
            }
            else
            {
                Console.WriteLine("Digite 0 para retornar ao menu ou 1 para selecionar outro quarto");
                string selecao = Console.ReadLine();

                if (selecao == "1")
                {
                    await SelecionarQuarto(suites);
                }
                else
                {
                    Menu retorno = new Menu();
                    await retorno.VoltarAoMenu();
                }
            }
        }
        else
        {
            Console.WriteLine("ID não encontrado.");
        }
    }

    /// <summary>
    /// Solicita o ID do quarto e a quantidade de dias, calcula o valor da reserva com desconto se aplicável.
    /// </summary>
    public void CalculoDeDiarias()
    {
        Console.WriteLine("\nDigite o ID do quarto desejado: ");
        idSelecionado = Console.ReadLine();

        Console.WriteLine("\nDigite a quantidade de dias para reserva: ");
        int qtdDeDias = int.Parse(Console.ReadLine());

        int valorDaDiaria = idSelecionado switch
        {
            "1" => 150,
            "2" => 200,
            "3" => 250,
            "4" => 300,
            "5" => 350,
            _ => 0
        };

        if (valorDaDiaria == 0)
        {
            Console.WriteLine("Tipo de suíte inválido");
            return;
        }

        Console.WriteLine($"\nO valor da diária para este quarto é: R$ {valorDaDiaria}");

        decimal totalDaReserva = valorDaDiaria * qtdDeDias;

        if (qtdDeDias >= 10)
        {
            decimal desconto = totalDaReserva * 0.10m;
            totalDaReserva -= desconto;
            Console.WriteLine($"\nDesconto aplicado: R$ {desconto:F2}");
        }

        Console.WriteLine($"\nO total da reserva é R$ {totalDaReserva:F2}");
    }

    /// <summary>
    /// Realiza o checkout do quarto e remove os hóspedes associados.
    /// </summary>
    public async Task Checkout()
    {
        Console.WriteLine("\nDigite o ID do quarto para realizar o checkout:");
        string id = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(id))
        {
            try
            {
                var suites = await APIServer.GetSuitesAsync();
                var suiteSelecionada = suites.FirstOrDefault(s => s.ID == id);

                if (suiteSelecionada != null)
                {
                    suiteSelecionada.Status = "Disponível";

                    var json = JsonSerializer.Serialize(suiteSelecionada);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    using HttpClient client = new HttpClient();
                    var response = await client.PutAsync($"http://localhost:3000/quartos/{id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Checkout realizado com sucesso! Quarto disponível novamente.");

                        // Remove todos os hóspedes associados ao quarto
                        Pessoa.RemoverHospedesDoQuarto(id);

                        Thread.Sleep(3000);
                        Menu retorno = new Menu();
                        await retorno.VoltarAoMenu();
                    }
                    else
                    {
                        Console.WriteLine($"Erro ao atualizar o quarto: {response.StatusCode}");
                    }
                }
                else
                {
                    Console.WriteLine("\nID de suíte não encontrado.");
                    await RepetirOuMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no checkout: {ex.Message}");
            }
        }
        else
        {
            await RepetirOuMenu();
        }
    }

    /// <summary>
    /// Oferece opção de tentar novamente ou voltar ao menu.
    /// </summary>
    private async Task RepetirOuMenu()
    {
        Console.WriteLine("Digite 0 para retornar ao menu ou 1 para tentar novamente:");
        string selecao = Console.ReadLine();

        if (selecao == "1")
            await Checkout();
        else
        {
            Menu retorno = new Menu();
            await retorno.VoltarAoMenu();
        }
    }
}
