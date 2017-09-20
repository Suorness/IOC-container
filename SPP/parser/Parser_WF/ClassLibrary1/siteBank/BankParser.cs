using ParserLib.Core;
using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp.Dom.Html;
using System.Linq;

namespace ParserLib.siteBank
{
    public class BankParser : IParser<ExchangeRates[]>
    {
        public ExchangeRates[] Parse(IHtmlDocument document)
        {
            var list = new List<ExchangeRates>();
            var values = document.QuerySelectorAll("p").Where
                    (item => item.ClassName != null && item.ClassName.Contains("text-center h2"));
            var names = document.QuerySelectorAll("h2").Where
                    (item => item.ClassName != null && item.ClassName.Contains("text-center"));

            int count = names.Count();
            var aNames=names.ToArray();
            var aValues = values.ToArray();
            for (int i=0; i < count; i++)
            {
                list.Add(new ExchangeRates(aValues[i].TextContent, aNames[i].TextContent));
            }
            return list.ToArray();
        }

    }
}
