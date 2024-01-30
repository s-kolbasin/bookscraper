using BookScraper.Lib;

namespace Bookscraper.Tests;

public class CrawlerTest
{
    private const string InputFolder = @"..\..\..\Bookscraper.Tests\Input";

    [Fact]
    public async void WhenRootIsEmpty_ListsRoot()
    {
        var path = Path.Combine(InputFolder, "EmptyRoot.html");
        var crawler = await CrawlFile(path);

        Assert.Single(crawler.AllPages);
        Assert.Single(crawler.ToScrape);
        Assert.Equal(path, crawler.AllPages.Single());
        Assert.Equal(path, crawler.ToScrape.Single());
    }

    [Fact]
    public void WhenHasLinks_ListsRootAndLinks()
    {

    }

    [Fact]
    public void WhenHasSecondaryLinks_ListsAllLinks()
    {

    }

    [Fact]
    public void WhenHasResourceHrefs_ListsOnlyLinks()
    {

    }

    private async Task<Crawler> CrawlFile(string rootFile) {
        // TODO: IoC?
        Crawler crawler = new (rootFile, new FileHtmlClient());
        await crawler.CrawlAsync();
        return crawler;
    }
}