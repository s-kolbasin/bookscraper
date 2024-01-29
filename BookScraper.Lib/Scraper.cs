namespace BookScraper.Lib;

public class Scraper
{
    private readonly string destination;

    public Scraper (string destination) => this.destination = destination;

    public async Task Scrape() {
        throw new NotImplementedException();
    }
}
