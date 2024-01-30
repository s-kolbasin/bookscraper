namespace BookScraper.Lib;

public class Scraper
{
    private readonly string rootUrl;
    private readonly string destination;
    private HashSet<string> allPages = new HashSet<string>(1000);
    private Queue<string> pagesToScrape = new Queue<string>(1000);

    public Scraper (string rootUrl, string destination) => (this.rootUrl, this.destination) = (rootUrl, destination);

    public async Task Scrape() {
        // TODO: start crawler to fill the known pages and queue
        // TODO: start downloader to actually scrape resources
        // Kind of doing double work in that all pages are read twice, but the site's page are small and the only real bottleneck will be in saving to the disk anyway.
        // Also the crawler would allow to show progress better, as we'd know how many pages are there.
        throw new NotImplementedException();
    }
}
