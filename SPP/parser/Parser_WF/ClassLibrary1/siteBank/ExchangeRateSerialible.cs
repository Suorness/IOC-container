using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLib.siteBank
{
    [Serializable]
    public class ExchangeRateSerialible
    {
        //[JsonProperty("CurrencyName")]
        public string CurrencyName { get; set; }
        //[JsonProperty("CurrencyValue")]
        public string CurrencyValue { get; set; }

        public ExchangeRateSerialible(string value, string name)
        {
            CurrencyName = name;
            CurrencyValue = value;
        }
        public ExchangeRateSerialible()
        {

        }
        public override string ToString()
        {
            return string.Format("{0} = {1}", CurrencyName.Trim(), CurrencyValue.Trim());

        }
    }

}
