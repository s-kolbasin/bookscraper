
using HtmlAgilityPack;

namespace BookScraper.Lib;

public sealed class Crawler : ICrawler
{
	// There are 1K books, surely the total number of pages isn't much bigger than that. Or we will see otherwise :)
	private const int EstimatedPages = 2000;
	
	// TODO: probably not the only way to have a link to a page.
	// TODO: are there any external links?
	private const string LinkSelector = "//a[@href]";
	private const string HrefAttribute = "href";

	private readonly string root;
	private readonly IHtmlClient htmlClient;

	public Crawler(string root, IHtmlClient htmlClient) => (this.root, this.htmlClient) = (root, htmlClient);
	public HashSet<string> AllPages { get; } = new HashSet<string>(EstimatedPages);
	public Queue<string> ToScrape { get; } = new Queue<string>(EstimatedPages);

	public async Task CrawlAsync() => await VisitPageAsync(root);

	public void Dispose() => htmlClient.Dispose();

	private async Task VisitPageAsync(string fullUrl) {

		string? pageSource = default;

		try {
			pageSource = await htmlClient.ReadHtml(fullUrl);
		}
		catch (HttpRequestException) { /* Could do something meaningful such as log a broken link, but probably don't care for scraping purposes? */ }

		if (pageSource != default) {
			if (AllPages.Add(fullUrl))
			{
				ToScrape.Enqueue(fullUrl);

				var links = ParseForLinks(pageSource)
					.Select(reference => htmlClient.CombinePath(fullUrl, reference));

				var parseLinkTasks = links
					.Select(linkPath => Task.Run(() => VisitPageAsync(linkPath)))
					.ToArray();
				await Task.WhenAll(parseLinkTasks);
			}
		}
	}

	private IEnumerable<string> ParseForLinks(string pageSource)
	{
		if (!string.IsNullOrWhiteSpace(pageSource)) {
			// Find ahrefs, iterate 'VisitPageAsync' through them.
			HtmlDocument dom = new ();
			dom.LoadHtml(pageSource);

			return dom.DocumentNode
				.SelectNodes(LinkSelector)
				.SelectMany(
					node => node.GetAttributes(HrefAttribute)
						.Select(attrNode => attrNode.Value)
				);
		}

		return Array.Empty<string>();
	}
}