using System.Globalization;
using System.Net.Http.Json;
using Application.Interfaces;

namespace Application.Service;

public class WorldTimeApiService : ITimeApiService
{
    private readonly HttpClient _httpClient;

    public WorldTimeApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DateTimeOffset> GetDateTimeAsync(string timezone)
    {
        var response = await _httpClient.GetAsync($"http://worldtimeapi.org/api/timezone/{timezone}");
        response.EnsureSuccessStatusCode();
        var dateTimeResponse = await response.Content.ReadFromJsonAsync<WorldTimeApiResponse>();

        return dateTimeResponse == null ? throw new InvalidOperationException("Failed to retrieve valid datetime information from the API.") : DateTimeOffset.ParseExact(dateTimeResponse.datetime, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFzzz", CultureInfo.InvariantCulture);
    }
}