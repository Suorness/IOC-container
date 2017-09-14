using AngleSharp.Dom.Html;


namespace ParserLib.Core
{
    interface IParser <T> where T:class
    {
        T Parse(IHtmlDocument document);

    }
}
