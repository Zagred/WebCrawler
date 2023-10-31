using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebCrawler
{
    internal class Program
    {
        public static async Task StartCralwer()
        {
            var url = @"https://www.automobile.tn/fr/neuf/audi ";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var HtmlDocument=new HtmlDocument();
            HtmlDocument.LoadHtml(html);

           var divs= HtmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("versions-item")).ToList();
            foreach ( var div in divs )
            {
                var link = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
                Console.WriteLine($"https://www.automobile.tn{link}");
            }
        }
        static void Main(string[] args)
        {          
            StartCralwer();

            Console.ReadLine();
        }
    }
}
