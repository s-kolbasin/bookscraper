namespace BookScraper.Lib;

public interface IHtmlClient : IDisposable
{
    Task<string> ReadHtml(string path);
    string CombinePath(string currentPath, string localReference);
}