using TimursCargoLine.Core.Domain;
using TimursCargoLine.Model;

namespace TimursCargoLine.Core.Factories;

internal interface IRouteFactory
{
    Task<IRoute> GetRoute(Order order);
}