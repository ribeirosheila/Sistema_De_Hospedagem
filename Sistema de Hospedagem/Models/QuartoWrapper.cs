using System.Text.Json.Serialization;

namespace Sistema_de_Hospedagem.Models;

/// <summary>
/// Classe auxiliar usada para deserializar respostas da API que envolvem uma coleção de suítes,
/// quando os dados vêm encapsulados em uma propriedade "quartos".
/// </summary>
public class QuartoWrapper
{
    /// <summary>
    /// Lista de suítes (quartos) obtida da API, contida dentro da propriedade "quartos" do JSON.
    /// </summary>
    [JsonPropertyName("quartos")]
    public List<Suite> Quartos { get; set; }
}

