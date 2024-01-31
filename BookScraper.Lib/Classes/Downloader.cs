namespace BookScraper.Lib.Classes
{
	public class Downloader
	{
		private const string DefaultFileName = "index.html";

		// TODO: Probably should either move this to the app configuration, or somehow switch to local paths.
		private readonly string rootUrl;
		private readonly string destination;
		CrawledQueue toDownload;

		public Downloader(string rootUrl, string destination, CrawledQueue toDownload) {
			this.rootUrl = rootUrl;
			this.destination = destination;
			this.toDownload = toDownload;
		}

		public async Task RunAsync()
		{
			bool dequeued;
			while (dequeued = toDownload.PageQueue.TryDequeue(out var page) || !toDownload.Finished)
			{
				if (!dequeued || page == null)
				{
					Thread.Sleep(200);
					continue;
				}

				try
				{
					string localPath = GetLocalPath(page);
					string fullFilePath = Path.Combine(destination, localPath);
					if (!File.Exists(fullFilePath))
					{
						var directory = Path.GetDirectoryName(fullFilePath);
						Directory.CreateDirectory(directory!);
						await File.WriteAllTextAsync(fullFilePath, page.HtmlSource);

						// TODO: also save linked resources.
					}
				}
				catch (Exception ex)
				{
					// TODO: Some kind of logging.
				}
			}
		}

		private string GetLocalPath(Page page) {
			var result = page.FullUrl.Remove(0, rootUrl.Length);
			if (string.IsNullOrEmpty(result))
				result = DefaultFileName;
			return result;
		}
	}
}
