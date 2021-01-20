using System;
using System.Collections.Generic;

namespace WebScraper
{
    public class GetDeets
    {
        private readonly static Int32 count = int.MaxValue;
        private readonly static string[] seperator = { "</b></th><td width=\"200\">" };

        public static List<Result> GetDeetsMethod(string url)
        {
            List<Result> res = new List<Result>();

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            var getRows = doc.DocumentNode.SelectNodes("//tr[@bgcolor]");
            //<th width="150"><b>Total Successful</b></th><td width=\"200\">10000</td>

            foreach (var i in getRows)
            {
                string[] splitList = i.InnerHtml.Split(seperator, count, StringSplitOptions.RemoveEmptyEntries);
                string first = splitList[0].Replace("<th width=\"150\"><b>", "");
                string second = splitList[1].Replace("</td>", "");
                res.Add(new Result { Name = first, Value = second });
            }

            return res;
        }

    }
}
