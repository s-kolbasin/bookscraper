namespace BookScraper.Lib;

public interface IHtmlClient : IDisposable
{
    Task<string> ReadHtml(string path);
}