namespace Cepster.Core.BrasilApi.Response;

internal class BrasilApiResponse
{
    public string? ZipCode { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Neighborhood { get; set; }
    public string? Street { get; set; }
    public string? Service { get; set; }
    public BrasilApiErrors[]? Errors { get; set; }
}
