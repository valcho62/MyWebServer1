using System.Text;
using MyWebServer.Enums;

namespace MyWebServer.Models
{
    public class HttpRequest
    {
        public RequestMethod Method { get; set; }
        public string Url { get; set; }
        public Header Header { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            StringBuilder request = new StringBuilder();
            request.AppendLine($"{this.Method} {this.Url} HTTP/1.0");
            request.AppendLine(this.Header.ToString());
            if (this.Content != null)
            {
                request.AppendLine(this.Content); 
            }
            return request.ToString();
        }
    }
}