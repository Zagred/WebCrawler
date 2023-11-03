using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
namespace WebCrawler
{
    internal class Program
    {
        public static async Task StartCralwer()
        {
           // var url = @"https://en.wikipedia.org/wiki/English_Wikipedia";
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
            //StartCralwer();
            List<string> webSites = new List<string>()
            {
                @"https://en.wikipedia.org/wiki/Wikipedia:About",
                @"https://www.automobile.tn/fr/neuf/audi ",
                @"https://overframe.gg/tier-list/primary-weapons/",
                @"https://overframe.gg/tier-list/secondary-weapons/",
            };
            var url = @"https://en.wikipedia.org/wiki/Wikipedia:About";
            HtmlWeb hw = new HtmlWeb();
            foreach (var website in webSites)
            {
                HtmlDocument doc = hw.Load(website);
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    HtmlAttribute att = link.Attributes["href"];
                    if (att.Value[0] == 'h')
                    {
                        Console.WriteLine(att.Value);
                    }
                }
            }
        }
    }
}
