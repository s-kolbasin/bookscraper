
namespace BookScraper.Lib;

public sealed class WebHtmlClient : IHtmlClient
{
    private readonly HttpClient internalClient = new ();

    public void Dispose() => internalClient.Dispose();

    public async Task<string> ReadHtml(string path) => await internalClient.GetStringAsync(path);
}
