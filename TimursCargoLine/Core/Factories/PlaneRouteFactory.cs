using TimursCargoLine.Core.Domain;
using TimursCargoLine.Model;

namespace TimursCargoLine.Core.Factories;

internal class PlaneRouteFactory : IRouteFactory
{
    public async Task<IRoute> GetRoute(Order order)
    {
        var targetARequestUrl = UrlBuilder.BuildTargetRequestUrl(order.PointA, order.PointACountryCode);
        var targetBRequestUrl = UrlBuilder.BuildTargetRequestUrl(order.PointB, order.PointBCountryCode);

        var targetAResponse = await WebClient.GetRequestDataAsync(targetARequestUrl);
        var targetBResponse = await WebClient.GetRequestDataAsync(targetBRequestUrl);

        var targetA = new Target(targetAResponse);
        var targetB = new Target(targetBResponse);

        return new PlaneRoute(targetA.Coordinates, targetB.Coordinates);
    }
}