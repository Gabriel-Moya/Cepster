using System.Text.Json.Serialization;

namespace Cepster.Core.ViaCepApi.Response;

public class ViaCepAddressResponse
{
    [JsonPropertyName("cep")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("uf")]
    public string? State { get; set; }

    [JsonPropertyName("localidade")]
    public string? City { get; set; }

    [JsonPropertyName("bairro")]
    public string? Neighborhood { get; set; }

    [JsonPropertyName("logradouro")]
    public string? Street { get; set; }

    [JsonPropertyName("complemento")]
    public string? Complement { get; set; }

    [JsonPropertyName("ibge")]
    public string? Ibge { get; set; }

    [JsonPropertyName("gia")]
    public string? Gia { get; set; }

    [JsonPropertyName("ddd")]
    public string? DDD { get; set; }

    [JsonPropertyName("siafi")]
    public string? Siafi { get; set; }

    [JsonPropertyName("erro")]
    public string? Error { get; set; }
}
