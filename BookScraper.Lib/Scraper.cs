using BookScraper.Lib.Classes;

namespace BookScraper.Lib;

public class Scraper
{	
	private readonly Crawler crawler;
	private readonly Downloader downloader;

	public int TotalPages => crawler.AllPages.Count;
	public int ProcessedPages => TotalPages - crawler.ToScrape.PageQueue.Count;

	public Scraper(string rootUrl, string destination) {
		crawler = new(rootUrl, new WebHtmlClient());
		downloader = new(rootUrl, destination, crawler.ToScrape);
	}

	public async Task ScrapeAsync() {

		var crawlerTask = Task.Run(crawler.CrawlAsync);
		var downloadTask = Task.Run(downloader.RunAsync);

		await Task.WhenAll(crawlerTask, downloadTask);		
	}
}
