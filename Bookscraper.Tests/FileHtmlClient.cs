using BookScraper.Lib;

public sealed class FileHtmlClient : IHtmlClient
{
    public void Dispose() {}

    public async Task<string> ReadHtml(string path) => await File.ReadAllTextAsync(path);
}
