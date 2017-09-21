using AngleSharp.Dom.Html;
using ParserLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLib.siteBank
{
    public class BankParserSerialible : IParser<ExchangeRateSerialible[]>
    {
        public ExchangeRateSerialible[] Parse(IHtmlDocument document)
        {
            var list = new List<ExchangeRateSerialible>();
            var values = document.QuerySelectorAll("p").Where
                    (item => item.ClassName != null && item.ClassName.Contains("text-center h2"));
            var names = document.QuerySelectorAll("h2").Where
                    (item => item.ClassName != null && item.ClassName.Contains("text-center"));

            int count = names.Count();
            var aNames = names.ToArray();
            var aValues = values.ToArray();
            for (int i = 0; i < count; i++)
            {
                list.Add(new ExchangeRateSerialible(aValues[i].TextContent.Trim(), aNames[i].TextContent.Trim()));
            }
            return list.ToArray();
        }
    }
}
