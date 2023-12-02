using System.Net.Http;
using System.Windows;

namespace TimursCargoLine.Core.Web;

internal static class WebClient
{
    public static async Task<string> GetRequestDataAsync(Uri uri)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(uri);

        if (!response.IsSuccessStatusCode)
            MessageBox.Show($"HTTP request failed with status code {response.StatusCode}");
        
        return await response.Content.ReadAsStringAsync();
    }
}