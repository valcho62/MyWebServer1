using System.Collections.Generic;
using System.IO;
using MyWebServer;
using MyWebServer.Models;
using SharpStoreDB;


namespace SharpStore
{
    class SharpStore
    {
        static void Main()
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
                    Name = "About Us",
                    Method = MyWebServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/about$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = MyWebServer.Enums.ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText("../../content/about.html")
                        };
                    }
                },
                  new Route()
                {
                    Name = "Products",
                    Method = MyWebServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/products$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = MyWebServer.Enums.ResponseStatusCode.OK,
                            ContentAsUTF8 = GetProduct.GetProductsPage()
                        };
                    }
                },
                    new Route()
                {
                    Name = "Contacts",
                    Method = MyWebServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/contacts$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = MyWebServer.Enums.ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText("../../content/contacts.html")
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
                    UrlRegex = "^/bootstrap/css/bootstrap.min.css$",
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
