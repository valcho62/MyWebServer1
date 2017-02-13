using System;
using System.Runtime.CompilerServices;
using System.Text;
using MyWebServer.Enums;

namespace MyWebServer.Models
{
    public class HttpResponse
    {
        public int Code { get; set; }
        public ResponseCode CodeMessage { get; set; }
        public Header Header { get; set; }
        public byte[] Content { get; set; }
        public string UTF8Content
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
            response.AppendLine($"HTTP/1.0 {Convert.ToInt32(this.CodeMessage)} {this.CodeMessage}");
            response.AppendLine(this.Header.ToString());
            return response.ToString();
        }
    }
}