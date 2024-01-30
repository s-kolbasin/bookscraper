
using Flurl;

namespace BookScraper.Lib;

public sealed class WebHtmlClient : IHtmlClient
{
	private readonly HttpClient internalClient = new ();

	public string CombinePath(string root, string localPath) => Url.Combine(root, localPath);

	public void Dispose() => internalClient.Dispose();

	public async Task<string> ReadHtml(string path) => await internalClient.GetStringAsync(path);
}
