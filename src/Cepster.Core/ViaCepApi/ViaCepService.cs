using Cepster.Core.Response;
using Cepster.Core.ViaCepApi.Response;
using System.Net.Http.Json;

namespace Cepster.Core.ViaCepApi;

public class ViaCepService
{
    private readonly HttpClient _httpClient;
    private readonly Configuration _configuration;

    private const string SEARCH_ADDRESS_NOT_FOUND = "ZipCode not found";

    public ViaCepService(HttpClient httpClient, Configuration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    /// <summary>
    /// Search an address by ViaCep through a certain zip code
    /// </summary>
    /// <param name="zipCode"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CepsterResponse> SearchAddressAsync(
        string zipCode,
        CancellationToken cancellationToken = default)
    {
        var url = $"{_configuration.BaseUrl}/{zipCode}/json";
        var result = await _httpClient.GetFromJsonAsync<ViaCepAddressResponse>(url, cancellationToken);

        return result is not null && string.IsNullOrEmpty(result.Error)
            ? new CepsterResponse
            {
                ZipCode = result.ZipCode,
                State = result.State,
                City = result.City,
                Neighborhood = result.Neighborhood,
                Street = result.Street,
                Complement = result.Complement,
                Ibge = result.Ibge,
                Gia = result.Gia,
                DDD = result.DDD,
                Siafi = result.Siafi
            }
            : new CepsterResponse { Message = SEARCH_ADDRESS_NOT_FOUND };
    }
}
