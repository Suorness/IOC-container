using AngleSharp.Dom.Html;


namespace ParserLib.Core
{
    public interface IParser <T> where T:class
    {
        T Parse(IHtmlDocument document);

    }
}
