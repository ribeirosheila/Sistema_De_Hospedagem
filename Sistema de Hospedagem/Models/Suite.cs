using System.Text.Json.Serialization;

namespace Sistema_de_Hospedagem.Models;

/// <summary>
/// Representa uma suíte (quarto) do hotel, com informações sobre tipo, número, status de ocupação
/// e funcionalidades relacionadas à exibição e listagem de quartos.
/// </summary>
public class Suite
{
    /// <summary>
    /// Identificador único da suíte.
    /// </summary>
    [JsonPropertyName("id")]
    public string ID { get; set; }

    /// <summary>
    /// Tipo da suíte (ex: Standard, Luxo, Presidencial).
    /// </summary>
    [JsonPropertyName("Tipo de Quarto")]
    public string Quarto { get; set; }

    /// <summary>
    /// Número da suíte dentro do hotel.
    /// </summary>
    [JsonPropertyName("Numero do Quarto")]
    public int NumeroDoQuarto { get; set; }

    /// <summary>
    /// Status atual da suíte (ex: Disponível, Ocupado).
    /// </summary>
    [JsonPropertyName("Status")]
    public string Status { get; set; }

    /// <summary>
    /// Obtém e exibe a lista de suítes disponíveis no sistema.
    /// Utiliza a API para buscar os dados e exibe cada suíte no console.
    /// </summary>
    public async Task ObterListaDeQuartos()
    {
        try
        {
            var suites = await APIServer.GetSuitesAsync();
            foreach (var suite in suites)
            {
                suite.ExibirQuartos();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Houve um problema com: {ex.Message}");
        }
    }

    /// <summary>
    /// Exibe no console as informações da suíte atual (ID, tipo, número e status).
    /// </summary>
    public void ExibirQuartos()
    {
        Console.WriteLine($"Id {ID} | Tipo de Quarto: {Quarto} | Número: {NumeroDoQuarto} | Status: {Status}");
    }
}

