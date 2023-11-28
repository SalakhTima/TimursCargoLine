using System.Globalization;
using System.Windows;

namespace TimursCargoLine.Core.Web;

public static class UrlBuilder
{
    private const string Key = "5b3ce3597851110001cf6248f293a640b21148a2aeefcd4cf0a2e245";

    public static Uri BuildRouteRequestUrl(Coordinates a, Coordinates b)
    {
        if (a == b)
        {
            MessageBox.Show("Entered points have the same coordinates.");
        }

        return new Uri(string.Format(CultureInfo.InvariantCulture,
            "https://api.openrouteservice.org/v2/directions/driving-car?api_key={0}&start={1},{2}&end={3},{4}",
            Key, a.Longitude, a.Latitude, b.Longitude, b.Latitude));
    }

    public static Uri BuildTargetRequestUrl(string keyWords, string countryCode)
    {
        return new Uri(string.Format(CultureInfo.InvariantCulture,
            "https://api.openrouteservice.org/geocode/search?api_key=" +
            "{0}&text={1}&boundary.country={2}&size=1", Key, keyWords, countryCode));
    }
}