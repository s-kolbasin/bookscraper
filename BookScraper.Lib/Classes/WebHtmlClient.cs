
using Flurl;

namespace BookScraper.Lib;

public sealed class WebHtmlClient : IHtmlClient
{
	// TODO: seems true that here all pages end with .html, but an overall lousy assumption.
	private const string PageDeterminer = ".html";
	private const string DoubleDot = "../";

	private readonly HttpClient internalClient = new ();

	public string CombinePath(string root, string localPath)
	{
		var rootUrl = new Url(root);

		if (root.EndsWith(PageDeterminer))
			rootUrl = rootUrl.RemovePathSegment();
		while (localPath.StartsWith(DoubleDot))
		{
			rootUrl = rootUrl.RemovePathSegment();
			localPath = localPath.Remove(0, DoubleDot.Length);
		}
		return Url.Combine(rootUrl, localPath);
	}

	public void Dispose() => internalClient.Dispose();

	public async Task<string> ReadHtml(string path) => await internalClient.GetStringAsync(path);
}
