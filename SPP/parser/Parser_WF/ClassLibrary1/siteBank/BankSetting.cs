using ParserLib.Core;
namespace ParserLib.siteBank
{
    public class BankSetting : IParserSetting
    {
        public string BaseUrl { get; set; } = "https://banki24.by/exchange/currencymarket";
    }
}
