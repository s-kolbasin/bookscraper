
namespace BookScraper.Lib;

public class Crawler : ICrawler
{
    // There are 1K books, surely the total number of pages isn't much bigger than that. Or we will see otherwise :)
    private const int EstimatedPages = 2000;

    private string root;

    public Crawler(string root) => this.root = root;

    public HashSet<string> AllPages { get; } = new HashSet<string>(EstimatedPages);

    public async Task CrawlAsync() => await VisitPageAsync(root);

    private async Task VisitPageAsync(string fullUrl) {
        using HttpClient client = new();
        string pageSource = await client.GetStringAsync(fullUrl);

        // Find ahrefs, iterate 'VisitPageAsync' through them.
        // TODO: HttpClient is lightweight, right? should we preserve it at all? Should we queue the pages and multithread? Here there are no IO limitations.
    }
}