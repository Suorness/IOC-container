using ParserLib.Core;
using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp.Dom.Html;
using System.Linq;

namespace ParserLib.siteBank
{
    public class BankParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("p").Where(item => item.ClassName != null && item.ClassName.Contains("text-center h2"));

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();

        }
    }
}
