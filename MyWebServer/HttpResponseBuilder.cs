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
                Code = 500,
                CodeMessage = ResponseCode.InternalServerError,
                Header = header,
                UTF8Content = page500
            };
            return response;
        }

        public static HttpResponse NotFound()
        {
            var page401 = File.ReadAllText("401.html");
            var header = new Header(HeaderType.HttpResponse);
            var response = new HttpResponse()
            {
                Code = 401,
                CodeMessage = ResponseCode.NotFound,
                Header = header,
                UTF8Content = page401
            };
            return response;
        }
    }
}
