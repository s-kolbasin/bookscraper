namespace BookScraper.Lib.Classes
{
	public class Downloader
	{
		private readonly string destination;
		Queue<Page> pageQueue;

		public Downloader(string destination, Queue<Page> pageQueue) {
			this.destination = destination;
			this.pageQueue = pageQueue;
		}

		public async Task RunAsync()
		{

		}
	}
}
