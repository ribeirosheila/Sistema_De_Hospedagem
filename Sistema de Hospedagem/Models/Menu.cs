using Sistema_de_Hospedagem.Models;

namespace Sistema_de_Hospedagem;

/// <summary>
/// Classe responsável por exibir o menu principal e controlar a navegação do sistema de hospedagem.
/// </summary>
public class Menu
{
    /// <summary>
    /// Exibe o título estilizado do sistema no console.
    /// </summary>
    public void Titulo()
    {
        Console.WriteLine("***************************");
        Console.WriteLine(@"𝐇𝐨𝐭𝐞𝐥 𝐂𝐚𝐦𝐚, 𝐂𝐚𝐟𝐞́ 𝐞 𝐂𝐨𝐧𝐟𝐮𝐬𝐚̃𝐨");
        Console.WriteLine("***************************");
    }

    /// <summary>
    /// Exibe o menu principal de opções e executa ações com base na seleção do usuário.
    /// </summary>
    public async Task MenuDeSelecao()
    {
        Console.Clear();

        Titulo();

        Console.WriteLine("Digite a opção desejada: ");
        Console.WriteLine("1- Realizar checkin");
        //Console.WriteLine("2- Verificar lista de quartos disponíveis");
        Console.WriteLine("2- Verificar lista de hóspedes");
        Console.WriteLine("3- Realizar checkout");
        Console.WriteLine("4- Sair");

        if (!int.TryParse(Console.ReadLine(), out int selecao))
        {
            Console.WriteLine("Entrada inválida. Pressione qualquer tecla para tentar novamente.");
            Console.ReadKey();
            await MenuDeSelecao();
            return;
        }


        switch (selecao)
        {
            case 1:
                {
                    Titulo();

                    /// Cria uma nova instância de Reserva e chama o método de check-in
                    Reserva novoCheckin = new Reserva();
                    await novoCheckin.FazerChekin();

                    await VoltarAoMenu();
                    break;
                }

            /* case 2:
                {
                    Console.Clear();
                    Titulo();

                    /// Exibe o status das suítes disponíveis
                    Suite listaDeQuartos = new Suite();
                    listaDeQuartos.SuitesStatus();

                    await VoltarAoMenu();
                    break;
                }*/

            case 2:
                {
                    Console.Clear();
                    Titulo();

                    /// Mostra a lista de hóspedes cadastrados
                    Reserva listHospedes = new Reserva();
                    listHospedes.Hospedes();

                    await VoltarAoMenu();
                    break;
                }

            case 3:
                {
                    Console.Clear();
                    Titulo();

                    Reserva chekout = new Reserva();
                    await chekout.Checkout();
                    break;
            }
        }
    }

    /// <summary>
    /// Aguarda o usuário digitar 0 para retornar ao menu principal.
    /// </summary>
    public async Task VoltarAoMenu()
    {
        Console.WriteLine("\nDigite 0 para retornar ao menu: ");
        int voltar = int.Parse(Console.ReadLine());

        if (voltar == 0)
        {
            await MenuDeSelecao();
        }
    }
}

