namespace BookScraper.Lib;

public class Scraper
{
	private readonly string rootUrl;
	private readonly string destination;
	private readonly Crawler crawler;

	public int TotalPages => crawler.AllPages.Count;

	public Scraper(string rootUrl, string destination) {
		this.rootUrl = rootUrl;
		this.destination = destination;
		crawler = new(rootUrl, new WebHtmlClient());
	}

	public async Task ScrapeAsync() {

		await crawler.CrawlAsync();

		// TODO: start downloader to actually scrape resources
		// Kind of doing double work in that all pages are read twice, but the site's page are small and the only real bottleneck will be in saving to the disk anyway.
		// Also the crawler would allow to show progress better, as we'd know how many pages are there.
	}
}
