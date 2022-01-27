using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;

        public HttpServer(string _ipAddress, int _port, Action<IRoutingTable> routingTableConfiguration)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;

            serverListener = new TcpListener(this.ipAddress, port);

            routingTableConfiguration(routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable) : this("127.0.0.1", port, routingTable)
        {

        }

        public HttpServer(Action<IRoutingTable> routingTable) : this(8080, routingTable)
        {

        }


        public async Task Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
               {

                   var networkStream = connection.GetStream();

                   var requestText = await this.ReadRequest(networkStream);

                   Console.WriteLine(requestText);

                   var request = Request.Parse(requestText);

                   var response = routingTable.MatchRequest(request);

                   // Execute pre-render action for the response
                   if (response.PreRenderAction != null)
                   {
                       response.PreRenderAction(request, response);
                   }

                   AddSession(request, response);

                   await WriteResponse(networkStream, response);
                   connection.Close();
               });
            }
        }

        private static void AddSession(Request request, Response response)
        {
            var sessionExists = request.Session
                .ContainsKey(Session.SessionCurrentDateKey);

            if (sessionExists == false)
            {
                request.Session[Session.SessionCurrentDateKey] = DateTime.Now.ToString();

                response.Cookies
                    .Add(Session.SessionCookieName, request.Session.Id);
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];

            var totalBytes = 0;

            StringBuilder requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
                totalBytes += bytesRead;

                if (totalBytes > 10 * bufferLength)
                {
                    throw new InvalidOperationException("Request is too large");
                }
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable); // May not run correctly over the internet

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            if (response.FileContent != null)
            {
                responseBytes = responseBytes.Concat(response.FileContent).ToArray();
            }

            await networkStream.WriteAsync(responseBytes);
        }
    }
}
