using BookScraper.Lib;

namespace Bookscraper.Tests;

public sealed class FileHtmlClient : IHtmlClient
{
	public string CombinePath(string root, string localPath) => Path.Combine(Path.GetDirectoryName(root)!, localPath);

	public void Dispose() { }

	public async Task<string> ReadHtml(string path) => await File.ReadAllTextAsync(path);
}