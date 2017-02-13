using System;
using System.Collections.Generic;
using System.Text;
using MyWebServer.Enums;

namespace MyWebServer.Models
{
    public class Header
    {
        public HeaderType Type { get; set; }
        public string ContentType { get; set; }
        public string ContentLenght { get; set; }
        public CookieCollection Cookies { get; set; }
        public Dictionary<string,string> OtherParameters { get; set; }

        public Header(HeaderType type)
        {
            Type = type;
            ContentType = "text/html";
            Cookies = new CookieCollection();
            OtherParameters = new Dictionary<string, string>();
        }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.Add(cookie);
        }

        public override string ToString()
        {
           StringBuilder header = new StringBuilder();
            header.AppendLine($"Content type: {this.ContentType}");
            if (this.Cookies.Count > 0)
            {
                if (this.Type == HeaderType.HttpRequiest)
                {
                    header.AppendLine("Cookie: " + this.Cookies.ToString());
                }
                else if (this.Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine("Set-Cookie: " + cookie); 
                    }
                }
            }
            if (this.ContentLenght != null)
            {
                header.AppendLine("Content-Length: " + this.ContentLenght);
            }
            if (this.OtherParameters != null)
            {
                foreach (var other in OtherParameters)
                {
                    header.AppendLine($"{other.Key}: {other.Value}");
                }
            }
            header.AppendLine(Environment.NewLine);
            header.AppendLine(Environment.NewLine);

            return header.ToString();
        }
    }
}