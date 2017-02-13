using System.Collections.Generic;
using System.IO;
using MyWebServer;
using MyWebServer.Models;

namespace SharpStore
{
    class SharpStore
    {
        static void Main(string[] args)
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Home Directory",
                    Method = MyWebServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/home$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = MyWebServer.Enums.ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText("../../content/home.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Carousel CSS",
                    Method = MyWebServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/content/css/carousel.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = MyWebServer.Enums.ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText("../../content/css/carousel.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = MyWebServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = MyWebServer.Enums.ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                 new Route()
                {
                    Name = "Bootstrap CSS",
                    Method = MyWebServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = MyWebServer.Enums.ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
            };

            HttpServer server = new HttpServer(8081, routes);
            server.Listen();
        }
    }
}