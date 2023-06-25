using Cepster.Core.BrasilApi.Response;
using Cepster.Core.Response;
using System.Net.Http.Json;

namespace Cepster.Core.BrasilApi;

public class BrasilApiService
{
    private readonly HttpClient _httpClient;
    private readonly Configuration _configuration;

    private const string SEARCH_ADDRESS_NOT_FOUND = "ZipCode not found";

    public BrasilApiService(HttpClient httpClient, Configuration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    /// <summary>
    /// Search for an address by BrasilAPI through a certain zip code
    /// </summary>
    /// <param name="zipCode"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CepsterResponse> SearchAddressAsync(
        string zipCode,
        CancellationToken cancellationToken = default)
    {
        var url = $"{_configuration.BaseUrl}/{zipCode}";
        var result = await _httpClient.GetFromJsonAsync<BrasilApiResponse>(url, cancellationToken);
        return result is not null && result.Errors?.Length != 0
            ? new CepsterResponse
            {
                ZipCode = result.ZipCode,
                State = result.State,
                City = result.City,
                Neighborhood = result.Neighborhood,
                Street = result.Street,
            }
            : new CepsterResponse { Message = SEARCH_ADDRESS_NOT_FOUND };
    }
}
