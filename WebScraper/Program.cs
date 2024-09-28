// HtmlAgilityPack - NuGet package
// an agile HTML parser that builds a read/write DOM and supports plain XPATH or XSLT
using HtmlAgilityPack;

namespace WebScrapper
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Send get request to orai24.lt
            string url = "https://www.orai24.lt/orai/vilnius/";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get the location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1['w-temperature']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("Location: " + location);

            // Get the temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='temperature']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temperature);

            // Get the conditions
            var conditionsElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='clouds']");
            var conditions = conditionsElement.InnerText.Trim();
            Console.WriteLine("Conditions: " + conditions);

            Console.ReadLine();
        }
    }
}