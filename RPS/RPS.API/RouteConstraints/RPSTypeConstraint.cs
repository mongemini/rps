using RPS.Contracts.Models;

namespace RPS.API.RouteConstraints
{
    public class RPSTypeConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var candidate = values[routeKey]?.ToString();
            var parseResult = Enum.TryParse(candidate, out RPSType result);
            return parseResult && result > RPSType.None;
        }
    }
}
