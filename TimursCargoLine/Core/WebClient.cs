using System.Net.Http;

namespace TimursCargoLine.Core;

internal static class WebClient
{
    public static async Task<string> GetRequestDataAsync(Uri uri)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(uri);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}.");
        }

        return await response.Content.ReadAsStringAsync(); 
    }
}