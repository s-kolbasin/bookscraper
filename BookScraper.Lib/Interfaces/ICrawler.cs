namespace BookScraper.Lib;

public interface ICrawler : IDisposable
{
    Task CrawlAsync();
    HashSet<string> AllPages { get; }
    Queue<Page> ToScrape { get; }
}