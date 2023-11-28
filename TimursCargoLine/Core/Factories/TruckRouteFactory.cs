using TimursCargoLine.Core.Domain;
using TimursCargoLine.Core.Web;
using TimursCargoLine.Model;

namespace TimursCargoLine.Core.Factories;

internal class TruckRouteFactory : IRouteFactory
{
    public async Task<IRoute> GetRoute(Order order)
    {
        var targetARequestUrl = UrlBuilder.BuildTargetRequestUrl(order.PointA, order.PointACountryCode);
        var targetBRequestUrl = UrlBuilder.BuildTargetRequestUrl(order.PointB, order.PointBCountryCode);

        var targetAResponse = await WebClient.GetRequestDataAsync(targetARequestUrl);
        var targetBResponse = await WebClient.GetRequestDataAsync(targetBRequestUrl);

        var targetA = new Target(targetAResponse);
        var targetB = new Target(targetBResponse);

        var routeRequestUri = UrlBuilder.BuildRouteRequestUrl(targetA.Coordinates, targetB.Coordinates);
        var routeResponse = await WebClient.GetRequestDataAsync(routeRequestUri);

        return new TruckRoute(routeResponse);
    }
}