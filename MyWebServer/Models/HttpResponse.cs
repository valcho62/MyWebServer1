using System;
using System.Runtime.CompilerServices;
using System.Text;
using MyWebServer.Enums;

namespace MyWebServer.Models
{
    public class HttpResponse
    {
        public ResponseStatusCode StatusCode { get; set; }
        public string StatusMessage
        {
            get
            {
                return Enum.GetName(typeof(ResponseStatusCode), this.StatusCode);
            }
        }
        public Header Header { get; set; }
        public byte[] Content { get; set; }
        public string ContentAsUTF8
        {
            set
            {
                this.Content = Encoding.UTF8.GetBytes(value);
            }
        }

        public HttpResponse()
        {
            this.Header = new Header(HeaderType.HttpResponse);
            this.Content = new byte[] { };
        }

        public override string ToString()
        {
            var response = new StringBuilder();
            response.AppendLine($"HTTP/1.0 {this.StatusCode} {this.StatusMessage}");
            response.AppendLine(this.Header.ToString());
            return response.ToString();
        }
    }
}