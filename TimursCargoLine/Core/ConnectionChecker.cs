using System.Net.Http;

namespace TimursCargoLine.Core;

public static class ConnectionChecker
{
    public static bool IsNetworkAvailable()
    {
        try
        {
            using var client = new HttpClient();
            var response = client.GetAsync("http://www.google.com").Result;
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}