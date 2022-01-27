using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes; // a method with url and response

        public RoutingTable()
        {
            routes = new Dictionary<Method, Dictionary<string, Response>>()
            {
                [Method.GET] = new (StringComparer.InvariantCultureIgnoreCase),
                [Method.POST] = new (StringComparer.InvariantCultureIgnoreCase),
                [Method.Put] = new (StringComparer.InvariantCultureIgnoreCase),
                [Method.Delete] = new (StringComparer.InvariantCultureIgnoreCase),
            };
        }

        public IRoutingTable Map(string url, Method method, Response response)
            => method switch
            {
                Method.GET => MapGet(url, response),
                Method.POST => MapPost(url, response),
                _ => throw new InvalidOperationException($"Method '{method}' is not supported")
            };

        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.GET][url] = response;

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.POST][url] = response;

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

            return routes[requestMethod][requestUrl];
        }
    }
}
