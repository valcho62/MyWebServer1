using System;
using System.IO;
using MyWebServer.Enums;
using MyWebServer.Models;

namespace MyWebServer
{
    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            var page500 = File.ReadAllText("500.html");
            var header = new Header(HeaderType.HttpResponse);
            var response = new HttpResponse()
            {
                StatusCode = ResponseStatusCode.InternalServerError,
                Header = header,
                ContentAsUTF8 = page500
            };
            return response;
        }

        public static HttpResponse NotFound()
        {
            var page401 = File.ReadAllText("401.html");
            var header = new Header(HeaderType.HttpResponse);
            var response = new HttpResponse()
            {
                StatusCode = ResponseStatusCode.NotFound,
                Header = header,
                ContentAsUTF8 = page401
            };
            Console.WriteLine("-RESPONSE-----------------------------");
            Console.WriteLine(response);
            Console.WriteLine("------------------------------");
            return response;
        }
    }
}
