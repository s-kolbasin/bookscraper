using BookScraper.Lib;

namespace Bookscraper.Tests;

public class CrawlerTest
{
	private const string InputFolder = @"..\..\..\Input";

	[Fact]
	public async void WhenRootIsEmpty_ListsRoot()
	{
		var path = Path.Combine(InputFolder, "EmptyRoot.html");
		var crawler = await CrawlFile(path);

		Assert.Single(crawler.AllPages);
		Assert.Single(crawler.ToScrape.PageQueue);
		Assert.Equal(path, crawler.AllPages.Single());
		Assert.Equal(path, crawler.ToScrape.PageQueue.Single().FullUrl);
	}

	[Fact]
	public async Task WhenHasLinks_ListsRootAndLinksAsync()
	{
		var path = Path.Combine(InputFolder, "SomeLinks.html");
		var crawler = await CrawlFile(path);

		Assert.Equal(3, crawler.AllPages.Count);
		Assert.Equal(3, crawler.ToScrape.PageQueue.Count);
	}

	[Fact]
	public async Task WhenHasSecondaryLinks_ListsAllLinksAsync()
	{
		var path = Path.Combine(InputFolder, "RecursiveLinks.html");
		var crawler = await CrawlFile(path);

		Assert.Equal(3, crawler.AllPages.Count);
		Assert.Equal(3, crawler.ToScrape.PageQueue.Count);
	}

	[Fact]
	public async Task WhenHasResourceHrefs_ListsOnlyLinksAsync()
	{
		var path = Path.Combine(InputFolder, "FullBody.html");
		var crawler = await CrawlFile(path);

		Assert.Equal(2, crawler.AllPages.Count);
		Assert.Equal(2, crawler.ToScrape.PageQueue.Count);
	}

	private static async Task<Crawler> CrawlFile(string rootFile) {
		// TODO: IoC?
		Crawler crawler = new (rootFile, new FileHtmlClient());
		await crawler.CrawlAsync();
		return crawler;
	}
}