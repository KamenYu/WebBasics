using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request,Response>>> routes; // a method with url and responseFunction

        public RoutingTable() => routes = new()
        {

            [Method.GET] = new(StringComparer.InvariantCultureIgnoreCase),
            [Method.POST] = new(StringComparer.InvariantCultureIgnoreCase),
            [Method.Put] = new(StringComparer.InvariantCultureIgnoreCase),
            [Method.Delete] = new(StringComparer.InvariantCultureIgnoreCase),
        };


        public IRoutingTable Map(
           Method method,
           string path,
           Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            switch (method)
            {
                case Method.GET:
                    return MapGet(path, responseFunction);
                case Method.POST:
                    return MapPost(path, responseFunction);
                case Method.Put:
                case Method.Delete:
                default:
                    throw new ArgumentOutOfRangeException($"The method {nameof(method)} is not supported!");
            }
        }

        private IRoutingTable MapGet(
            string path,
            Func<Request, Response> responseFunction)
        {
            routes[Method.GET][path] = responseFunction;

            return this;
        }

        private IRoutingTable MapPost(
            string path,
            Func<Request, Response> responseFunction)
        {
            routes[Method.POST][path] = responseFunction;

            return this;
        }

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (routes.ContainsKey(requestMethod) == false
                || routes[requestMethod].ContainsKey(requestUrl) == false)
            {
                return new NotFoundResponse();
            }

            var responseFunction = routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}
