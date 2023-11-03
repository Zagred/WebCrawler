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
        public static void linksFromSite(List<string> webSites)
        {
            HtmlWeb hw = new HtmlWeb();
            Dictionary<string, string> links = new Dictionary<string, string>();
            foreach (var website in webSites)
            {
                HtmlDocument doc = hw.Load(website);
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    HtmlAttribute att = link.Attributes["href"];
                    if (att.Value[0] == 'h')
                    {
                        try
                        {
                            links.Add(att.Value, att.Value);
                        }
                        catch { }
                    }
                }

            }
        }
        static void Main(string[] args)
        {;
            List<string> webSites = new List<string>()
            {
                @"https://en.wikipedia.org/wiki/Wikipedia:About",
                @"https://www.automobile.tn/fr/neuf/audi ",
                @"https://overframe.gg/tier-list/primary-weapons/",
                @"https://overframe.gg/tier-list/secondary-weapons/",
            };
            linksFromSite(webSites);
            
        }
    }
}
