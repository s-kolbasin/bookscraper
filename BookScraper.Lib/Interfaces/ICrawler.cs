namespace BookScraper.Lib;

public interface ICrawler
{
    Task CrawlAsync();
}