using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using MyWebServer.Enums;
using MyWebServer.Models;

namespace MyWebServer
{
    public class HttpProcessor
    {
        public List<Route> Routes { get; set; }
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }

        public HttpProcessor(IEnumerable<Route> routes )
        {
            Routes = new List<Route>(routes);
        }

        public void HandleClient(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                Request = GetResponse(stream);
                Response = RouteRequest();
                StreamUtils.WriteResponse(stream,Response);
            }
        }

        private HttpResponse RouteRequest()
        {
            var routes = this.Routes
                .Where(x => Regex.Match(Request.Url, x.UrlRegex).Success)
                .ToList();

            if (!routes.Any())
                return HttpResponseBuilder.NotFound();

            var route = routes.SingleOrDefault(x => x.Method == Request.Method);

            if (route == null)
                return new HttpResponse()
                {
                    StatusCode =  ResponseStatusCode.MethodNotAllowed
                };

            #region FIleSystemHandler
            // extract the path if there is one
            //var match = Regex.Match(request.Url, route.UrlRegex);
            //if (match.Groups.Count > 1)
            //{
            //    request.Path = match.Groups[1].Value;
            //}
            //else
            //{
            //    request.Path = request.Url;
            //}
            #endregion


            // trigger the route handler...
            try
            {
                return route.Callable(Request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return HttpResponseBuilder.InternalServerError();
            }
        }

        private HttpRequest GetResponse(NetworkStream stream)
        {
            Header header = new Header(HeaderType.HttpRequiest);
            HttpRequest request = new HttpRequest();
            string line;
            line = StreamUtils.ReadLine(stream);
            var row = line.Split(' ');
            if (row.Length < 3)
            {
                throw new ArgumentException("Bad Request first line");
            }
            request.Method = (RequestMethod) Enum.Parse(typeof(RequestMethod),row[0]);
            request.Url = row[1];

            while ((line = StreamUtils.ReadLine(stream)) != null)
            {
                if (line.Equals(""))
                {
                    break;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                string name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++;
                }

                string value = line.Substring(pos, line.Length - pos);
                if (name == "Cookie")
                {
                    string[] cookieSaves = value.Split(';');
                    foreach (var cookieSave in cookieSaves)
                    {
                        string[] cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                        var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                        header.AddCookie(cookie);
                    }
                }
                else if (name == "Content-Length")
                {
                    header.ContentLenght = value;
                }
                else
                {
                    header.OtherParameters.Add(name, value);
                }
            }
            request.Header = header;

            //content
            string content = null;
            if (header.ContentLenght != null)
            {
                int totalBytes = Convert.ToInt32(header.ContentLenght);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];

                while (bytesLeft > 0)
                {
                    byte[] bufer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = stream.Read(bufer, 0, bufer.Length);
                    bufer.CopyTo(bytes,totalBytes - bytesLeft);

                    bytesLeft -= n;
                }
                content = Encoding.ASCII.GetString(bytes);
            }
            request.Content = content;
            Console.WriteLine("-REQUEST-----------------------------");
            Console.WriteLine(request);
            Console.WriteLine("------------------------------");
            return request;
        }
    }
}