using System;
using System.Collections.Generic;
using MyWebServer;
using MyWebServer.Enums;
using MyWebServer.Models;


namespace WebServerApp
{
    class Program
    {
        static void Main()
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Hello from me",
                    UrlRegex = @"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = (HttpRequest request) =>
                    {
                        return new HttpResponse()
                        {
                            Code = 200,
                            CodeMessage = ResponseCode.OK,
                            UTF8Content = "<h3>Hello from server ;-)</h3>",
                        };
                    }
                }

            };
            HttpServer server = new HttpServer(8081,routes);
            server.Listen();
        }
    }
}
