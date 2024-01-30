
namespace BookScraper.Lib;

public sealed class Crawler : ICrawler
{
    // There are 1K books, surely the total number of pages isn't much bigger than that. Or we will see otherwise :)
    private const int EstimatedPages = 2000;

    private readonly string root;
    private readonly IHtmlClient htmlClient;

    public Crawler(string root, IHtmlClient htmlClient) => (this.root, this.htmlClient) = (root, htmlClient);
    public HashSet<string> AllPages { get; } = new HashSet<string>(EstimatedPages);
    public Queue<string> ToScrape { get; } = new Queue<string>(EstimatedPages);

    public async Task CrawlAsync() => await VisitPageAsync(root);

    public void Dispose() => htmlClient.Dispose();

    private async Task VisitPageAsync(string fullUrl) {
        string pageSource = await htmlClient.ReadHtml(fullUrl);

        // Find ahrefs, iterate 'VisitPageAsync' through them.
    }
}