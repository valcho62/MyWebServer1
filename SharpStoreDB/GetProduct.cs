


using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SharpStoreDB
{


    using System.IO;
    using System.Text;


    public static class GetProduct
    {
        private static SharpStoreDBcontex context;
        public static string GetProductsPage()
        {
            context = new SharpStoreDBcontex();



            StringBuilder sb = new StringBuilder();
            var allLines = File.ReadLines("../../content/Products.html");

            foreach (var line in allLines)
            {
                if (!line.Contains("endOfUpper"))
                {
                    sb.AppendLine(line);
                }
                else
                {
                    break;
                }
            }

            foreach (var knife in context.Knives)
            {
                sb.AppendLine("<div container>");

                sb.AppendLine("<div class=\"card col-lg-4 img-thumbnail\">");
                sb.AppendLine(
                    $"<img class=\"card-img-top \" src=\"{knife.ImageUrl}\" alt=\"{knife.Name}\" width=\"350px\" height=\"250px\">");
                sb.AppendLine("<div class=\"card-block\">");
                sb.AppendLine($"<h4 class=\"card-title\"><b>{knife.Name}</b></h4>");
                sb.AppendLine($"<p class=\"card-text\">${knife.Price}</p> ");
                sb.AppendLine("<p> <button type = \"button\" class=\"btn btn-primary\">Buy Now</button>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");

            }



            bool isWrite = false;
            foreach (var line in allLines)
            {

                if (isWrite)
                {
                    sb.AppendLine(line);
                }
                if (line.Contains("beginEnd"))
                {
                    sb.AppendLine(line);
                    isWrite = true;
                }
            }

            return sb.ToString();
        }
    }
}


