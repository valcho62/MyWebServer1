using System;
using System.Linq;
using SharpStoreDB;

namespace Products
{
    class Program
    {
        static void Main()
        {
            SharpStoreDBcontex contex = new SharpStoreDBcontex();
            //contex.Database.Initialize(true);


           
            var knifes = contex.Knives.ToList();
            //sb.AppendLine("<div class=\"card-deck\">");
            foreach (var knife in knifes)
            {
                Console.WriteLine("<div class=\"card\">");
                Console.WriteLine($"<img class=\"card-img-top\" src=\"{knife.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                Console.WriteLine("<div class=\"card-block\">");
                Console.WriteLine($"<h4 class=\"card-title\">{knife.Name}</h4>");
                //Console.WriteLine($"<p class=\"card-text\"><a href=\"DetailsPizza.exe?pizzaid={knife.Id}\">Recipe</a></p>");
                //Console.WriteLine("<form method=\"POST\">");
                //Console.WriteLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"up\">Up</label></div>");
                //Console.WriteLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"down\">Down</label></div>");
                //Console.WriteLine($"<input type=\"hidden\" name=\"pizzaid\" value=\"{knife.Id}\" />");
                //Console.WriteLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                //Console.WriteLine("</form>");
                Console.WriteLine("</div>");
                Console.WriteLine("</div>");
            }
            Console.WriteLine("</div>");

        }
    }
}
