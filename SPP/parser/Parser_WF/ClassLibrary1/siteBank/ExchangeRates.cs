using System;
using System.Collections.Generic;
using System.Text;

namespace ParserLib.siteBank
{
   // [Serializable]
   public class ExchangeRates
    {
        public string CurrencyName { get; set; }
        public string CurrencyValue { get; set; }

        public ExchangeRates(string value,string name)
        {
            CurrencyName = name;
            CurrencyValue = value;
        }
        public ExchangeRates()
        {

        }
        public override string ToString()
        {
            return string.Format("{0} = {1}", CurrencyName.Trim(), CurrencyValue.Trim());

        }
    }
}
